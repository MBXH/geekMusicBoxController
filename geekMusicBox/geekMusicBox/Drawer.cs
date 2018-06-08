using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace geekMusicBox
{
    public partial class Drawer : Form
    {
        private const int maxInput = 1 << 25;//最大压力
        private const int levelNumber = 4;//压力等级个数
        //原点坐标
        private const int baseX = 25;
        private const int baseY = 25;
        //绘图网格长宽
        private const int maxHight = 512;
        private const int maxWidth = 1024;
        private const int Unit_length = 32;//单位格大小
        private int DrawStep = 8;//默认绘制单位
        private const int Y_Max = 448;//Y轴最大数值
        private const int MaxStep = 33;//绘制单位最大值
        private const int MinStep = 1;//绘制单位最小值
        private const int StartPrint = 45;//点坐标偏移量
        private List<int> DataList = new List<int>();//线性链表
        private List<int> rawDataList = new List<int>();//线性链表
        private Pen TablePen = new Pen(Color.FromArgb(0x00, 0x00, 0x00));//轴线颜色
        private Pen LinesPen = new Pen(Color.FromArgb(0x00, 0x00, 0x00), (float)5);//波形颜色,粗细

        public ShowWindow ShowMainWindow;//定义显示主窗口委托访问权限为public
        public HideWindow HideMainWindow;//定义隐藏主窗口委托
        public OpenPort OpenSerialPort;//定义打开串口委托
        public ClosePort CloseSerialPort;//定义关闭串口委托
        public GetMainPos GetMainPos;//定义获取主窗口信息委托(自动对齐)
        public GetMainWidth GetMainWidth;//定义获取主窗口宽度(自动对齐)
        public Stopdisplay Stopdisplay;//暂停
        public Changeunit Changeunit;//改变单位


        public Drawer()
        {
            this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.UserPaint |
                           ControlStyles.AllPaintingInWmPaint,
                           true);//开启双缓冲
            this.UpdateStyles();
            InitializeComponent();
        }

        private int zeroWeight = 0;
        private int cnt = 0;
        public void AddData(int Data)
        {
            if (display)
            {
                rawDataList.Add(Data);
                cnt++;
                if (cnt >= 20 && rawDataList.Count >= 20)
                {
                    playMusicType(analyser.findMusicType(rawDataList));
                    cnt = 0;
                }
                if (DataList.Count == 0)
                {
                    zeroWeight = Data;
                }
                Data -= zeroWeight;
                Data = -Data;
                DataList.Add(Data);//链表尾部添加数据
                Invalidate();//刷新显示
            }
        }

        public void ClearData()
        {
            DataList.Clear();
            rawDataList.Clear();
        }
        private int maxDeta = 600000;
        private void Form1_Paint(object sender, PaintEventArgs e)//绘制图形
        {
            System.Drawing.Drawing2D.GraphicsPath gp = new System.Drawing.Drawing2D.GraphicsPath();
            //e.Graphics.FillRectangle(Brushes.White, e.Graphics.ClipBounds);
            //Draw Y 纵向轴绘制
            const float timeunit = 0.5F;
            for (int i = 0; i <= (this.ClientRectangle.Width / Unit_length); i++)
            {
                if (i > 30) break;
                if(isShowNet)e.Graphics.DrawLine(TablePen, StartPrint + i * Unit_length, StartPrint+2*32, StartPrint + i * Unit_length, StartPrint + Y_Max);//画线
                float nowtimes = (float)(timeunit * i);
                //if (nowtimes == (int)nowtimes)
                //gp.AddString((nowtimes).ToString(), this.Font.FontFamily, (int)FontStyle.Regular, 14, new RectangleF(StartPrint + i * Unit_length - 5, this.ClientRectangle.Height - StartPrint + 20, 40, 50), null);//添加文字
            }
            //Draw X 横向轴绘制
            for (int i = 2; i <= (this.ClientRectangle.Height / Unit_length); i++)
            {
                if(isShowNet)e.Graphics.DrawLine(TablePen, StartPrint, StartPrint + i * Unit_length, StartPrint + 960, StartPrint + i * Unit_length);//画线
                //gp.AddString((num - i * 750).ToString(), this.Font.FontFamily, (int)FontStyle.Regular, 14, new RectangleF(gap, StartPrint + i * Unit_length - 8, 400, 50), null);//添加文字
                if (i >= 14) break;
            }

            e.Graphics.DrawPath(Pens.Black, gp);//写文字
            if (DataList.Count - 1 >= 870 / DrawStep)//如果数据量大于可容纳的数据量，即删除最左数据
            {
                DataList.RemoveRange(0, DataList.Count - (870 / DrawStep));
            }
            int numPerUnit = maxDeta / 16;
            for (int i = 1; i <= DataList.Count() - 1; i++)//绘制
            {
                e.Graphics.DrawLine(LinesPen,
                    (float)(StartPrint + (i) * DrawStep),
                    (float)((float)10 * Unit_length + StartPrint + ((float)DataList[i] / numPerUnit) * Unit_length),
                    (float)(StartPrint + (i - 1) * DrawStep),
                    (float)((float)10 * Unit_length + StartPrint + ((float)DataList[i - 1] / numPerUnit) * Unit_length));
            }
        }

        public void SetWindow(Point Pt)//允许主窗口设置自己
        {
            this.Size = new Size(1250, 625);
            this.Location = Pt;
        }

        private void Drawer_FormClosing(object sender, FormClosingEventArgs e)
        {
            ShowMainWindow();//关闭自己，显示主窗口
        }

        private bool display = true;
        public bool isDisplay()
        {
            return this.display;
        }
        public void setDisplay(bool display)
        {
            this.display = display;
        }
        private void stop(object sender, EventArgs e)
        {
            if (display == true)
            {
                stopButton.Text = "继续传输";
                display = false;
                pauseButton.Text = "播放";
            }
            else
            {
                stopButton.Text = "暂停传输";
                display = true;
                pauseButton.Text = "暂停";
            }
        }

        private void hideMainWindow(object sender, EventArgs e)
        {
            HideMainWindow();
        }

        private void enlarge(object sender, EventArgs e)
        {
            if (DrawStep < MaxStep)//绘制单位递增
                DrawStep++;
            Invalidate();
        }

        private void narrow(object sender, EventArgs e)
        {
            if (DrawStep > MinStep)//绘制单位递减
                DrawStep--;
            Invalidate();
        }

        private void showMainWindowClick(object sender, EventArgs e)
        {
            ShowMainWindow();
        }

        private void Drawer_Load(object sender, EventArgs e)
        {
            this.Text = "geeker never give up!";
        }

        private void setZeroWeight_Click(object sender, EventArgs e)
        {
            DataList.Clear();
            rawDataList.Clear();
        }

        //public waveAnalyse analyser = new waveAnalyse();
        public modelAnalyse analyser = new modelAnalyse();
        private void RecordMusicButton_Click(object sender, EventArgs e)
        {
            analyser.addMusicList(rawDataList, musicPath.Text);
        }


        private void guessButton_Click(object sender, EventArgs e)
        {
            string music = analyser.findMusicType(rawDataList);
            //MessageBox.Show(music);
            playMusicType(music);
        }

        private string rootPath = "C:\\Users\\10618\\Desktop\\geekMusicBoxController\\music\\";
        private string nowMusicType = "";
        private void playMusicType(string type)
        {
            if (type == null)
            {
                nowMusicType = "";
                song.Text = "";
                person.Text = "";
                MediaPlayer.Ctlcontrols.stop();
            }
            else if (nowMusicType != type)
            {
                nowMusicType = type;
                person.Text = nowMusicType;
                DirectoryInfo TheFolder = new DirectoryInfo(rootPath + nowMusicType);
                //遍历文件
                List<string> musicName = new List<string>();
                foreach (FileInfo NextFile in TheFolder.GetFiles())
                {
                    musicName.Add(NextFile.Name);
                }
                Random random = new Random();
                int pos = random.Next(0, musicName.Count);
                song.Text = musicName[pos];
                MediaPlayer.URL = rootPath + nowMusicType + "\\" + song.Text;
                MediaPlayer.Ctlcontrols.play();

            }
        }

        private void pauseButton_Click(object sender, EventArgs e)
        {
            if (display == true)
            {
                stopButton.Text = "继续传输";
                display = false;
                pauseButton.Text = "播放";
                MediaPlayer.Ctlcontrols.pause();
            }
            else
            {
                stopButton.Text = "暂停传输";
                display = true;
                pauseButton.Text = "暂停";
                MediaPlayer.Ctlcontrols.play();
            }
        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            DirectoryInfo TheFolder = new DirectoryInfo(rootPath + nowMusicType);
            //遍历文件
            List<string> musicName = new List<string>();
            foreach (FileInfo NextFile in TheFolder.GetFiles())
            {
                musicName.Add(NextFile.Name);
            }
            if (musicName.Count > 0)
            {
                Random random = new Random();
                int pos = random.Next(0, musicName.Count);
                while (musicName.Count > 1 && musicName[pos] == song.Text)
                {
                    pos = random.Next(0, musicName.Count);
                }
                song.Text = musicName[pos];
                MediaPlayer.URL = rootPath + nowMusicType + "\\" + song.Text;
                MediaPlayer.Ctlcontrols.play();
            }
        }
        bool isShowNet = false;
        private void showNet_Click(object sender, EventArgs e)
        {
            if (isShowNet)
            {
                showNet.Text = "显示网格";
                isShowNet = false;
            }
            else
            {
                showNet.Text = "隐藏网格";
                isShowNet = true;
            }
        }

    }
}
