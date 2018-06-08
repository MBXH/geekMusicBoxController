using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using System.Threading;
using System.Runtime.InteropServices;
namespace geekMusicBox
{
    public delegate void ShowWindow();
    public delegate void HideWindow();
    public delegate void OpenPort();
    public delegate void ClosePort();
    public delegate Point GetMainPos();
    public delegate int GetMainWidth();
    public delegate void Stopdisplay(bool allow);
    public delegate void Changeunit();
    public delegate void GotoDraw();
    //波形窗口委托声明
    public partial class Form1 : Form
    {
        //全局变量，代表发送相应的值时进行相应动作
        //转动方向，发送0x11向前转，0x12向后转
        const byte getWeight = 0x66;

        Drawer Displayer;
        public void ClosePort()//关闭串口，供委托调用
        {
            try
            {
                serialPort.Close();
                openSerialPortButton.Text = "打开端口";
                isOpen = true;
                Displayer.Close();
                displayButton.Text = "打开波形图";
                displayer = false;
            }
            catch
            {
                MessageBox.Show("串口数据关闭出错，请检查.", "错误");
            }
        }
        private Point GetMyPos()//供委托调用
        {
            return this.Location;
        }
        public void OpenPort()//打开串口，供委托调用
        {
            try
            {
                serialPort.PortName = portSelectComboBox.Text;
                serialPort.BaudRate = Convert.ToInt32(baudRateComboBox.Text);
                serialPort.Open();
                openSerialPortButton.Text = "关闭端口";
                isOpen = false;
            }
            catch { MessageBox.Show("端口错误,请检查串口", "错误"); }
        }
        public void ShowMe()//供委托调用
        {
            this.Show();
            goDisplay();
        }
        public void HideMe()//供委托调用
        {
            this.Hide();
        }
        private void CreateNewDrawer()//创建绘制窗口
        {
            Displayer = new Drawer();//创建新对象
            Displayer.ShowMainWindow = new ShowWindow(ShowMe);//初始化类成员委托
            Displayer.HideMainWindow = new HideWindow(HideMe);
            Displayer.GetMainPos = new GetMainPos(GetMyPos);
            Displayer.CloseSerialPort = new ClosePort(ClosePort);
            Displayer.OpenSerialPort = new OpenPort(OpenPort);
            Displayer.GetMainWidth = new GetMainWidth(GetMyWidth);
            Displayer.Show();//显示窗口
        }
        public int GetMyWidth()//供委托调用
        {
            return this.Width;
        }
        private void CreateDisplayer()
        {
            this.Left = 0;
            CreateNewDrawer();
            Rectangle Rect = Screen.GetWorkingArea(this);
            Displayer.SetWindow(new Point(this.Width, this.Top));//设置绘制窗口宽度，以及坐标
        }

        bool displayer = false;
        private void goDisplay(object sender, EventArgs e)
        {
            if (!displayer)
            {
                if (Displayer == null)//第一次创建Displayer = null
                {
                    CreateDisplayer();
                }
                else
                {
                    if (Displayer.IsDisposed)//多次创建通过判断IsDisposed确定串口是否已关闭，避免多次创建
                    {
                        CreateDisplayer();
                    }
                }
                displayButton.Text = "关闭波形图";
                displayer = true;
            }
            else
            {
                Displayer.Close();
                displayButton.Text = "打开波形图";
                displayer = false;
            }
            //WriteByteToSerialPort(0x66);
        }

        private void goDisplay()
        {
            if (!displayer)
            {
                if (Displayer == null)//第一次创建Displayer = null
                {
                    CreateDisplayer();
                }
                else
                {
                    if (Displayer.IsDisposed)//多次创建通过判断IsDisposed确定串口是否已关闭，避免多次创建
                    {
                        CreateDisplayer();
                    }
                }
                displayButton.Text = "关闭波形图";
                displayer = true;
            }
            else
            {
                //Displayer.Close();
                displayButton.Text = "打开波形图";
                displayer = false;
            }
            //WriteByteToSerialPort(0x66);
        }

        public Form1()
        {
            InitializeComponent();
            serialPort.Encoding = Encoding.GetEncoding("GB2312");
            System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;
        }
        private void SearchAndAddSerialToComboBox(SerialPort MyPort, ComboBox MyBox)
        {
            string Buffer;
            MyBox.Items.Clear();
            const int search_lim = 10;
            bool one = true;
            for (int i = 1; i <= search_lim; i++)
            {
                try
                {
                    Buffer = "COM" + i.ToString();
                    MyPort.PortName = Buffer;
                    MyPort.Open();

                    MyBox.Items.Add(Buffer);
                    if (one)
                    {
                        MyBox.Text = Buffer;
                        one = false;
                    }
                    MyPort.Close();
                }
                catch { }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SearchAndAddSerialToComboBox(serialPort, portSelectComboBox);
            serialPort.DataReceived += new SerialDataReceivedEventHandler(port_DataReceived);
            baudRateComboBox.Text = "9600";
        }

        private void WriteByteToSerialPort(byte data)//单字节写入串口
        {
            //将data写入byte类型数组中（serialPort1.Write函数的参数需为byte数组）
            byte[] Buffer = new byte[1] { data };
            if (serialPort.IsOpen)//判断端口是否打开
            {
                try
                {
                    serialPort.Write(Buffer, 0, 1);//向串口写数据
                }
                catch
                {
                    MessageBox.Show("串口数据发送出错，请检查.", "错误");//错误处理
                }
            }
        }

        private void scanButtonClick(object sender, EventArgs e)
        {
            SearchAndAddSerialToComboBox(serialPort, portSelectComboBox);
        }
        int maxW = 0;
        private void port_DataReceived(object sender, SerialDataReceivedEventArgs e)//串口数据接收事件
        {
            try
            {
                if (radioButton3.Checked)
                {
                    //发送读取数据请求
                    //WriteByteToSerialPort(getWeight);
                    char ch = (char)serialPort.ReadChar();
                    if (ch == '$')//检测数据包包头
                    {
                        byte[] data = new byte[4];//数据缓冲区
                        //读入重量信息
                        for (int i = 0; i < 4; i++) 
                        {
                            data[i] = (byte)serialPort.ReadByte();
                        }
                        int weight = BitConverter.ToInt32(data, 0);
                        maxW = Math.Max(maxW,weight);
                        //将数据传给波形图窗口，由波形图窗口完成绘制   
                        if (Displayer != null)
                            Displayer.AddData(weight);
                    }
                }
            }
            catch { }
        }

        bool isOpen = true;
        private void changeSerialPort(object sender, EventArgs e)
        {
            if (isOpen == true)
            {
                try
                {
                    serialPort.PortName = portSelectComboBox.Text;
                    serialPort.BaudRate = Convert.ToInt32(baudRateComboBox.Text);
                    serialPort.Open();
                    openSerialPortButton.Text = "关闭端口";
                    isOpen = false;
                }
                catch { MessageBox.Show("端口错误,请检查串口", "错误"); }
            }
            else
            {
                try
                {
                    serialPort.Close();
                    openSerialPortButton.Text = "打开端口";
                    isOpen = true;
                    Displayer.Close();
                    displayButton.Text = "打开波形图";
                    displayer = false;
                }
                catch { }
            }
        }

        private void showTitleInfo(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("软件：鼓动音乐盒控制程序\n版本：V1.0\n作者：熊浩\n说明：本软件用于“第一届华南农业大学极客挑战赛”", "关于本软件");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            System.Media.SystemSounds.Exclamation.Play();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            System.Media.SystemSounds.Question.Play();
        }
    }
}
