namespace geekMusicBox
{
    partial class Drawer
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Drawer));
            this.enlargeButton = new System.Windows.Forms.Button();
            this.narrowButton = new System.Windows.Forms.Button();
            this.stopButton = new System.Windows.Forms.Button();
            this.displayMainForm = new System.Windows.Forms.Button();
            this.HideMainForm = new System.Windows.Forms.Button();
            this.musicPath = new System.Windows.Forms.TextBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.setZeroWeight = new System.Windows.Forms.Button();
            this.RecordMusicButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.nextButton = new System.Windows.Forms.Button();
            this.pauseButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.song = new System.Windows.Forms.TextBox();
            this.person = new System.Windows.Forms.TextBox();
            this.MediaPlayer = new AxWMPLib.AxWindowsMediaPlayer();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.showNet = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MediaPlayer)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // enlargeButton
            // 
            this.enlargeButton.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.enlargeButton.Location = new System.Drawing.Point(297, 24);
            this.enlargeButton.Name = "enlargeButton";
            this.enlargeButton.Size = new System.Drawing.Size(124, 37);
            this.enlargeButton.TabIndex = 4;
            this.enlargeButton.Text = "放大波形";
            this.enlargeButton.UseVisualStyleBackColor = true;
            this.enlargeButton.Click += new System.EventHandler(this.enlarge);
            // 
            // narrowButton
            // 
            this.narrowButton.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.narrowButton.Location = new System.Drawing.Point(427, 24);
            this.narrowButton.Name = "narrowButton";
            this.narrowButton.Size = new System.Drawing.Size(124, 37);
            this.narrowButton.TabIndex = 5;
            this.narrowButton.Text = "缩小波形";
            this.narrowButton.UseVisualStyleBackColor = true;
            this.narrowButton.Click += new System.EventHandler(this.narrow);
            // 
            // stopButton
            // 
            this.stopButton.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.stopButton.Location = new System.Drawing.Point(575, 24);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(124, 37);
            this.stopButton.TabIndex = 6;
            this.stopButton.Text = "暂停传输";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.stop);
            // 
            // displayMainForm
            // 
            this.displayMainForm.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.displayMainForm.Location = new System.Drawing.Point(19, 24);
            this.displayMainForm.Name = "displayMainForm";
            this.displayMainForm.Size = new System.Drawing.Size(124, 37);
            this.displayMainForm.TabIndex = 2;
            this.displayMainForm.Text = "显示主窗口";
            this.displayMainForm.UseVisualStyleBackColor = true;
            this.displayMainForm.Click += new System.EventHandler(this.showMainWindowClick);
            // 
            // HideMainForm
            // 
            this.HideMainForm.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.HideMainForm.Location = new System.Drawing.Point(149, 24);
            this.HideMainForm.Name = "HideMainForm";
            this.HideMainForm.Size = new System.Drawing.Size(124, 37);
            this.HideMainForm.TabIndex = 3;
            this.HideMainForm.Text = "隐藏主窗口";
            this.HideMainForm.UseVisualStyleBackColor = true;
            this.HideMainForm.Click += new System.EventHandler(this.hideMainWindow);
            // 
            // musicPath
            // 
            this.musicPath.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.musicPath.Location = new System.Drawing.Point(27, 24);
            this.musicPath.Name = "musicPath";
            this.musicPath.Size = new System.Drawing.Size(143, 28);
            this.musicPath.TabIndex = 7;
            // 
            // setZeroWeight
            // 
            this.setZeroWeight.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.setZeroWeight.Location = new System.Drawing.Point(27, 69);
            this.setZeroWeight.Name = "setZeroWeight";
            this.setZeroWeight.Size = new System.Drawing.Size(143, 37);
            this.setZeroWeight.TabIndex = 8;
            this.setZeroWeight.Text = "校零";
            this.setZeroWeight.UseVisualStyleBackColor = true;
            this.setZeroWeight.Click += new System.EventHandler(this.setZeroWeight_Click);
            // 
            // RecordMusicButton
            // 
            this.RecordMusicButton.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.RecordMusicButton.Location = new System.Drawing.Point(27, 112);
            this.RecordMusicButton.Name = "RecordMusicButton";
            this.RecordMusicButton.Size = new System.Drawing.Size(143, 37);
            this.RecordMusicButton.TabIndex = 9;
            this.RecordMusicButton.Text = "录入节拍";
            this.RecordMusicButton.UseVisualStyleBackColor = true;
            this.RecordMusicButton.Click += new System.EventHandler(this.RecordMusicButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.musicPath);
            this.groupBox1.Controls.Add(this.setZeroWeight);
            this.groupBox1.Controls.Add(this.RecordMusicButton);
            this.groupBox1.Location = new System.Drawing.Point(1372, 133);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(193, 167);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "设置";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.nextButton);
            this.groupBox2.Controls.Add(this.pauseButton);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.song);
            this.groupBox2.Controls.Add(this.person);
            this.groupBox2.Location = new System.Drawing.Point(1372, 336);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(193, 278);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "播放信息";
            // 
            // nextButton
            // 
            this.nextButton.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.nextButton.Location = new System.Drawing.Point(27, 211);
            this.nextButton.Name = "nextButton";
            this.nextButton.Size = new System.Drawing.Size(143, 39);
            this.nextButton.TabIndex = 6;
            this.nextButton.Text = "下一首";
            this.nextButton.UseVisualStyleBackColor = true;
            this.nextButton.Click += new System.EventHandler(this.nextButton_Click);
            // 
            // pauseButton
            // 
            this.pauseButton.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.pauseButton.Location = new System.Drawing.Point(27, 162);
            this.pauseButton.Name = "pauseButton";
            this.pauseButton.Size = new System.Drawing.Size(143, 43);
            this.pauseButton.TabIndex = 5;
            this.pauseButton.Text = "暂停";
            this.pauseButton.UseVisualStyleBackColor = true;
            this.pauseButton.Click += new System.EventHandler(this.pauseButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "播放歌曲";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "房间内的人";
            // 
            // song
            // 
            this.song.Enabled = false;
            this.song.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.song.Location = new System.Drawing.Point(27, 115);
            this.song.Name = "song";
            this.song.Size = new System.Drawing.Size(143, 25);
            this.song.TabIndex = 1;
            // 
            // person
            // 
            this.person.Enabled = false;
            this.person.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.person.Location = new System.Drawing.Point(27, 60);
            this.person.Name = "person";
            this.person.Size = new System.Drawing.Size(143, 25);
            this.person.TabIndex = 0;
            // 
            // MediaPlayer
            // 
            this.MediaPlayer.Enabled = true;
            this.MediaPlayer.Location = new System.Drawing.Point(1372, 82);
            this.MediaPlayer.Name = "MediaPlayer";
            this.MediaPlayer.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("MediaPlayer.OcxState")));
            this.MediaPlayer.Size = new System.Drawing.Size(75, 23);
            this.MediaPlayer.TabIndex = 13;
            this.MediaPlayer.Visible = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.showNet);
            this.groupBox3.Controls.Add(this.HideMainForm);
            this.groupBox3.Controls.Add(this.displayMainForm);
            this.groupBox3.Controls.Add(this.enlargeButton);
            this.groupBox3.Controls.Add(this.narrowButton);
            this.groupBox3.Controls.Add(this.stopButton);
            this.groupBox3.Location = new System.Drawing.Point(246, 2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(844, 77);
            this.groupBox3.TabIndex = 14;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "波形控制";
            // 
            // showNet
            // 
            this.showNet.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.showNet.Location = new System.Drawing.Point(705, 24);
            this.showNet.Name = "showNet";
            this.showNet.Size = new System.Drawing.Size(124, 37);
            this.showNet.TabIndex = 7;
            this.showNet.Text = "显示网格";
            this.showNet.UseVisualStyleBackColor = true;
            this.showNet.Click += new System.EventHandler(this.showNet_Click);
            // 
            // Drawer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1652, 835);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.MediaPlayer);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Drawer";
            this.Text = "            ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Drawer_FormClosing);
            this.Load += new System.EventHandler(this.Drawer_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MediaPlayer)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button enlargeButton;
        private System.Windows.Forms.Button narrowButton;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.Button displayMainForm;
        private System.Windows.Forms.Button HideMainForm;
        private System.Windows.Forms.TextBox musicPath;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button setZeroWeight;
        private System.Windows.Forms.Button RecordMusicButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button pauseButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox song;
        private System.Windows.Forms.TextBox person;
        private System.Windows.Forms.Button nextButton;
        private AxWMPLib.AxWindowsMediaPlayer MediaPlayer;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button showNet;





    }
}

