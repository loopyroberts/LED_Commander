namespace LED_Commander
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.backImage = new System.Windows.Forms.PictureBox();
            this.allOnBut = new System.Windows.Forms.Button();
            this.allOffBut = new System.Windows.Forms.Button();
            this.fwdBut = new System.Windows.Forms.Button();
            this.backBut = new System.Windows.Forms.Button();
            this.frameLab = new System.Windows.Forms.TextBox();
            this.bbBut = new System.Windows.Forms.Button();
            this.ffBut = new System.Windows.Forms.Button();
            this.maxLab = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.sysTab = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.browseBut = new System.Windows.Forms.Button();
            this.folderBox = new System.Windows.Forms.TextBox();
            this.stopBut = new System.Windows.Forms.Button();
            this.pauseBut = new System.Windows.Forms.Button();
            this.playBut = new System.Windows.Forms.Button();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.animList = new System.Windows.Forms.ListBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.rotStopBut = new System.Windows.Forms.Button();
            this.rotPauseBut = new System.Windows.Forms.Button();
            this.fwdRotBut = new System.Windows.Forms.Button();
            this.revRotBut = new System.Windows.Forms.Button();
            this.rotBox = new System.Windows.Forms.PictureBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.decVis = new System.Windows.Forms.Button();
            this.visLab = new System.Windows.Forms.TextBox();
            this.incVis = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.leftVol = new System.Windows.Forms.ProgressBar();
            this.rightVol = new System.Windows.Forms.ProgressBar();
            this.musDown = new System.Windows.Forms.Button();
            this.musUp = new System.Windows.Forms.Button();
            this.musDel = new System.Windows.Forms.Button();
            this.musAdd = new System.Windows.Forms.Button();
            this.musStop = new System.Windows.Forms.Button();
            this.musPause = new System.Windows.Forms.Button();
            this.musPlay = new System.Windows.Forms.Button();
            this.playList = new System.Windows.Forms.ListBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.refBut = new System.Windows.Forms.Button();
            this.disconBut = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.portList = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.baudList = new System.Windows.Forms.ComboBox();
            this.connectBut = new System.Windows.Forms.Button();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.saveBut = new System.Windows.Forms.Button();
            this.openBut = new System.Windows.Forms.Button();
            this.delFrameBut = new System.Windows.Forms.Button();
            this.editBut = new System.Windows.Forms.CheckBox();
            this.delBut = new System.Windows.Forms.Button();
            this.animName = new System.Windows.Forms.TextBox();
            this.addBut = new System.Windows.Forms.Button();
            this.frameTimer = new System.Windows.Forms.Timer(this.components);
            this.rotTimer = new System.Windows.Forms.Timer(this.components);
            this.musTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.backImage)).BeginInit();
            this.sysTab.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rotBox)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // backImage
            // 
            this.backImage.Location = new System.Drawing.Point(53, 12);
            this.backImage.Name = "backImage";
            this.backImage.Size = new System.Drawing.Size(1133, 424);
            this.backImage.TabIndex = 1;
            this.backImage.TabStop = false;
            this.backImage.MouseDown += new System.Windows.Forms.MouseEventHandler(this.backImage_MouseDown);
            this.backImage.MouseMove += new System.Windows.Forms.MouseEventHandler(this.backImage_MouseMove);
            this.backImage.MouseUp += new System.Windows.Forms.MouseEventHandler(this.backImage_MouseUp);
            // 
            // allOnBut
            // 
            this.allOnBut.Location = new System.Drawing.Point(12, 12);
            this.allOnBut.Name = "allOnBut";
            this.allOnBut.Size = new System.Drawing.Size(35, 38);
            this.allOnBut.TabIndex = 5;
            this.allOnBut.Text = "All On";
            this.allOnBut.UseVisualStyleBackColor = true;
            this.allOnBut.Click += new System.EventHandler(this.allOnBut_Click);
            // 
            // allOffBut
            // 
            this.allOffBut.Location = new System.Drawing.Point(12, 56);
            this.allOffBut.Name = "allOffBut";
            this.allOffBut.Size = new System.Drawing.Size(35, 38);
            this.allOffBut.TabIndex = 5;
            this.allOffBut.Text = "All Off";
            this.allOffBut.UseVisualStyleBackColor = true;
            this.allOffBut.Click += new System.EventHandler(this.allOffBut_Click);
            // 
            // fwdBut
            // 
            this.fwdBut.Location = new System.Drawing.Point(187, 19);
            this.fwdBut.Name = "fwdBut";
            this.fwdBut.Size = new System.Drawing.Size(31, 32);
            this.fwdBut.TabIndex = 6;
            this.fwdBut.Text = ">";
            this.fwdBut.UseVisualStyleBackColor = true;
            this.fwdBut.Click += new System.EventHandler(this.fwdBut_Click);
            // 
            // backBut
            // 
            this.backBut.Location = new System.Drawing.Point(43, 19);
            this.backBut.Name = "backBut";
            this.backBut.Size = new System.Drawing.Size(31, 32);
            this.backBut.TabIndex = 7;
            this.backBut.Text = "<";
            this.backBut.UseVisualStyleBackColor = true;
            this.backBut.Click += new System.EventHandler(this.backBut_Click);
            // 
            // frameLab
            // 
            this.frameLab.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.frameLab.Location = new System.Drawing.Point(80, 19);
            this.frameLab.MaxLength = 3;
            this.frameLab.Name = "frameLab";
            this.frameLab.Size = new System.Drawing.Size(40, 32);
            this.frameLab.TabIndex = 8;
            this.frameLab.Text = "1";
            this.frameLab.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // bbBut
            // 
            this.bbBut.Location = new System.Drawing.Point(6, 19);
            this.bbBut.Name = "bbBut";
            this.bbBut.Size = new System.Drawing.Size(31, 32);
            this.bbBut.TabIndex = 9;
            this.bbBut.Text = "<<";
            this.bbBut.UseVisualStyleBackColor = true;
            this.bbBut.Click += new System.EventHandler(this.bbBut_Click);
            // 
            // ffBut
            // 
            this.ffBut.Location = new System.Drawing.Point(224, 19);
            this.ffBut.Name = "ffBut";
            this.ffBut.Size = new System.Drawing.Size(31, 32);
            this.ffBut.TabIndex = 10;
            this.ffBut.Text = ">>";
            this.ffBut.UseVisualStyleBackColor = true;
            this.ffBut.Click += new System.EventHandler(this.ffBut_Click);
            // 
            // maxLab
            // 
            this.maxLab.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maxLab.Location = new System.Drawing.Point(141, 19);
            this.maxLab.MaxLength = 3;
            this.maxLab.Name = "maxLab";
            this.maxLab.Size = new System.Drawing.Size(40, 32);
            this.maxLab.TabIndex = 11;
            this.maxLab.Text = "1";
            this.maxLab.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(117, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 46);
            this.label1.TabIndex = 12;
            this.label1.Text = "/";
            // 
            // sysTab
            // 
            this.sysTab.Controls.Add(this.tabPage1);
            this.sysTab.Controls.Add(this.tabPage2);
            this.sysTab.Controls.Add(this.tabPage3);
            this.sysTab.Controls.Add(this.tabPage4);
            this.sysTab.Location = new System.Drawing.Point(380, 442);
            this.sysTab.Name = "sysTab";
            this.sysTab.SelectedIndex = 0;
            this.sysTab.Size = new System.Drawing.Size(806, 240);
            this.sysTab.TabIndex = 13;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.browseBut);
            this.tabPage1.Controls.Add(this.folderBox);
            this.tabPage1.Controls.Add(this.stopBut);
            this.tabPage1.Controls.Add(this.pauseBut);
            this.tabPage1.Controls.Add(this.playBut);
            this.tabPage1.Controls.Add(this.radioButton3);
            this.tabPage1.Controls.Add(this.radioButton2);
            this.tabPage1.Controls.Add(this.radioButton1);
            this.tabPage1.Controls.Add(this.animList);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(798, 214);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Animations";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // browseBut
            // 
            this.browseBut.Location = new System.Drawing.Point(535, 85);
            this.browseBut.Name = "browseBut";
            this.browseBut.Size = new System.Drawing.Size(75, 23);
            this.browseBut.TabIndex = 8;
            this.browseBut.Text = "Browse";
            this.browseBut.UseVisualStyleBackColor = true;
            this.browseBut.Click += new System.EventHandler(this.browseBut_Click);
            // 
            // folderBox
            // 
            this.folderBox.Location = new System.Drawing.Point(208, 59);
            this.folderBox.Name = "folderBox";
            this.folderBox.Size = new System.Drawing.Size(402, 20);
            this.folderBox.TabIndex = 7;
            // 
            // stopBut
            // 
            this.stopBut.Location = new System.Drawing.Point(346, 6);
            this.stopBut.Name = "stopBut";
            this.stopBut.Size = new System.Drawing.Size(63, 47);
            this.stopBut.TabIndex = 6;
            this.stopBut.Text = "Stop";
            this.stopBut.UseVisualStyleBackColor = true;
            this.stopBut.Click += new System.EventHandler(this.stopBut_Click);
            // 
            // pauseBut
            // 
            this.pauseBut.Location = new System.Drawing.Point(277, 6);
            this.pauseBut.Name = "pauseBut";
            this.pauseBut.Size = new System.Drawing.Size(63, 47);
            this.pauseBut.TabIndex = 5;
            this.pauseBut.Text = "Pause";
            this.pauseBut.UseVisualStyleBackColor = true;
            this.pauseBut.Click += new System.EventHandler(this.pauseBut_Click);
            // 
            // playBut
            // 
            this.playBut.Location = new System.Drawing.Point(208, 6);
            this.playBut.Name = "playBut";
            this.playBut.Size = new System.Drawing.Size(63, 47);
            this.playBut.TabIndex = 4;
            this.playBut.Text = "Play";
            this.playBut.UseVisualStyleBackColor = true;
            this.playBut.Click += new System.EventHandler(this.playBut_Click);
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(142, 194);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(60, 17);
            this.radioButton3.TabIndex = 3;
            this.radioButton3.Text = "Repeat";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(71, 194);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(65, 17);
            this.radioButton2.TabIndex = 2;
            this.radioButton2.Text = "Random";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(6, 194);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(59, 17);
            this.radioButton1.TabIndex = 1;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Default";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // animList
            // 
            this.animList.FormattingEnabled = true;
            this.animList.Items.AddRange(new object[] {
            "Frame",
            "Block",
            "Rise",
            "Blow",
            "Fall",
            "Climb",
            "Cube",
            "Poker",
            "Fill",
            "Dance",
            "Bug",
            "Bugs",
            "Drop",
            "Firework",
            "14. Roll"});
            this.animList.Location = new System.Drawing.Point(6, 6);
            this.animList.Name = "animList";
            this.animList.Size = new System.Drawing.Size(196, 186);
            this.animList.TabIndex = 0;
            this.animList.SelectedIndexChanged += new System.EventHandler(this.animList_SelectedIndexChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.listBox1);
            this.tabPage2.Controls.Add(this.rotStopBut);
            this.tabPage2.Controls.Add(this.rotPauseBut);
            this.tabPage2.Controls.Add(this.fwdRotBut);
            this.tabPage2.Controls.Add(this.revRotBut);
            this.tabPage2.Controls.Add(this.rotBox);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(798, 214);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Rotation";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Items.AddRange(new object[] {
            "Heart"});
            this.listBox1.Location = new System.Drawing.Point(6, 6);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(203, 199);
            this.listBox1.TabIndex = 2;
            // 
            // rotStopBut
            // 
            this.rotStopBut.Location = new System.Drawing.Point(515, 127);
            this.rotStopBut.Name = "rotStopBut";
            this.rotStopBut.Size = new System.Drawing.Size(94, 23);
            this.rotStopBut.TabIndex = 1;
            this.rotStopBut.Text = "Stop";
            this.rotStopBut.UseVisualStyleBackColor = true;
            this.rotStopBut.Click += new System.EventHandler(this.rotStopBut_Click);
            // 
            // rotPauseBut
            // 
            this.rotPauseBut.Location = new System.Drawing.Point(415, 127);
            this.rotPauseBut.Name = "rotPauseBut";
            this.rotPauseBut.Size = new System.Drawing.Size(94, 23);
            this.rotPauseBut.TabIndex = 1;
            this.rotPauseBut.Text = "Pause";
            this.rotPauseBut.UseVisualStyleBackColor = true;
            this.rotPauseBut.Click += new System.EventHandler(this.rotPauseBut_Click);
            // 
            // fwdRotBut
            // 
            this.fwdRotBut.Location = new System.Drawing.Point(315, 127);
            this.fwdRotBut.Name = "fwdRotBut";
            this.fwdRotBut.Size = new System.Drawing.Size(94, 23);
            this.fwdRotBut.TabIndex = 1;
            this.fwdRotBut.Text = "-------->";
            this.fwdRotBut.UseVisualStyleBackColor = true;
            this.fwdRotBut.Click += new System.EventHandler(this.fwdRotBut_Click);
            // 
            // revRotBut
            // 
            this.revRotBut.Location = new System.Drawing.Point(215, 127);
            this.revRotBut.Name = "revRotBut";
            this.revRotBut.Size = new System.Drawing.Size(94, 23);
            this.revRotBut.TabIndex = 1;
            this.revRotBut.Text = "<--------";
            this.revRotBut.UseVisualStyleBackColor = true;
            this.revRotBut.Click += new System.EventHandler(this.revRotBut_Click);
            // 
            // rotBox
            // 
            this.rotBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rotBox.Location = new System.Drawing.Point(215, 6);
            this.rotBox.Name = "rotBox";
            this.rotBox.Size = new System.Drawing.Size(395, 115);
            this.rotBox.TabIndex = 0;
            this.rotBox.TabStop = false;
            this.rotBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.rotBox_MouseDown);
            this.rotBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rotBox_MouseMove);
            this.rotBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.rotBox_MouseUp);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.decVis);
            this.tabPage3.Controls.Add(this.visLab);
            this.tabPage3.Controls.Add(this.incVis);
            this.tabPage3.Controls.Add(this.pictureBox1);
            this.tabPage3.Controls.Add(this.leftVol);
            this.tabPage3.Controls.Add(this.rightVol);
            this.tabPage3.Controls.Add(this.musDown);
            this.tabPage3.Controls.Add(this.musUp);
            this.tabPage3.Controls.Add(this.musDel);
            this.tabPage3.Controls.Add(this.musAdd);
            this.tabPage3.Controls.Add(this.musStop);
            this.tabPage3.Controls.Add(this.musPause);
            this.tabPage3.Controls.Add(this.musPlay);
            this.tabPage3.Controls.Add(this.playList);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tabPage3.Size = new System.Drawing.Size(798, 214);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "MP3 Visualisation";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // decVis
            // 
            this.decVis.Location = new System.Drawing.Point(756, 99);
            this.decVis.Name = "decVis";
            this.decVis.Size = new System.Drawing.Size(31, 47);
            this.decVis.TabIndex = 21;
            this.decVis.Text = "▼";
            this.decVis.UseVisualStyleBackColor = true;
            this.decVis.Click += new System.EventHandler(this.decVis_Click);
            // 
            // visLab
            // 
            this.visLab.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.visLab.Location = new System.Drawing.Point(756, 60);
            this.visLab.MaxLength = 3;
            this.visLab.Name = "visLab";
            this.visLab.Size = new System.Drawing.Size(31, 32);
            this.visLab.TabIndex = 20;
            this.visLab.Text = "0";
            this.visLab.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // incVis
            // 
            this.incVis.Location = new System.Drawing.Point(756, 6);
            this.incVis.Name = "incVis";
            this.incVis.Size = new System.Drawing.Size(31, 47);
            this.incVis.TabIndex = 4;
            this.incVis.Text = "▲";
            this.incVis.UseVisualStyleBackColor = true;
            this.incVis.Click += new System.EventHandler(this.incVis_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(378, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(372, 139);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            // 
            // leftVol
            // 
            this.leftVol.Location = new System.Drawing.Point(378, 152);
            this.leftVol.Maximum = 32768;
            this.leftVol.Name = "leftVol";
            this.leftVol.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.leftVol.Size = new System.Drawing.Size(409, 22);
            this.leftVol.TabIndex = 2;
            this.leftVol.Value = 16000;
            // 
            // rightVol
            // 
            this.rightVol.Location = new System.Drawing.Point(378, 179);
            this.rightVol.Maximum = 32768;
            this.rightVol.Name = "rightVol";
            this.rightVol.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rightVol.Size = new System.Drawing.Size(409, 22);
            this.rightVol.TabIndex = 2;
            this.rightVol.Value = 16000;
            // 
            // musDown
            // 
            this.musDown.Location = new System.Drawing.Point(297, 180);
            this.musDown.Name = "musDown";
            this.musDown.Size = new System.Drawing.Size(75, 23);
            this.musDown.TabIndex = 1;
            this.musDown.Text = "Move Down";
            this.musDown.UseVisualStyleBackColor = true;
            this.musDown.Click += new System.EventHandler(this.musDown_Click);
            // 
            // musUp
            // 
            this.musUp.Location = new System.Drawing.Point(297, 151);
            this.musUp.Name = "musUp";
            this.musUp.Size = new System.Drawing.Size(75, 23);
            this.musUp.TabIndex = 1;
            this.musUp.Text = "Move Up";
            this.musUp.UseVisualStyleBackColor = true;
            this.musUp.Click += new System.EventHandler(this.musUp_Click);
            // 
            // musDel
            // 
            this.musDel.Location = new System.Drawing.Point(297, 122);
            this.musDel.Name = "musDel";
            this.musDel.Size = new System.Drawing.Size(75, 23);
            this.musDel.TabIndex = 1;
            this.musDel.Text = "Delete Song";
            this.musDel.UseVisualStyleBackColor = true;
            this.musDel.Click += new System.EventHandler(this.musDel_Click);
            // 
            // musAdd
            // 
            this.musAdd.Location = new System.Drawing.Point(297, 93);
            this.musAdd.Name = "musAdd";
            this.musAdd.Size = new System.Drawing.Size(75, 23);
            this.musAdd.TabIndex = 1;
            this.musAdd.Text = "Open File";
            this.musAdd.UseVisualStyleBackColor = true;
            this.musAdd.Click += new System.EventHandler(this.musAdd_Click);
            // 
            // musStop
            // 
            this.musStop.Location = new System.Drawing.Point(297, 64);
            this.musStop.Name = "musStop";
            this.musStop.Size = new System.Drawing.Size(75, 23);
            this.musStop.TabIndex = 1;
            this.musStop.Text = "Stop";
            this.musStop.UseVisualStyleBackColor = true;
            this.musStop.Click += new System.EventHandler(this.musStop_Click);
            // 
            // musPause
            // 
            this.musPause.Location = new System.Drawing.Point(297, 35);
            this.musPause.Name = "musPause";
            this.musPause.Size = new System.Drawing.Size(75, 23);
            this.musPause.TabIndex = 1;
            this.musPause.Text = "Pause";
            this.musPause.UseVisualStyleBackColor = true;
            this.musPause.Click += new System.EventHandler(this.musPause_Click);
            // 
            // musPlay
            // 
            this.musPlay.Location = new System.Drawing.Point(297, 6);
            this.musPlay.Name = "musPlay";
            this.musPlay.Size = new System.Drawing.Size(75, 23);
            this.musPlay.TabIndex = 1;
            this.musPlay.Text = "Play";
            this.musPlay.UseVisualStyleBackColor = true;
            this.musPlay.Click += new System.EventHandler(this.musPlay_Click);
            // 
            // playList
            // 
            this.playList.FormattingEnabled = true;
            this.playList.Location = new System.Drawing.Point(6, 6);
            this.playList.Name = "playList";
            this.playList.Size = new System.Drawing.Size(285, 199);
            this.playList.TabIndex = 0;
            this.playList.SelectedIndexChanged += new System.EventHandler(this.playList_SelectedIndexChanged);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.refBut);
            this.tabPage4.Controls.Add(this.disconBut);
            this.tabPage4.Controls.Add(this.label3);
            this.tabPage4.Controls.Add(this.portList);
            this.tabPage4.Controls.Add(this.label2);
            this.tabPage4.Controls.Add(this.baudList);
            this.tabPage4.Controls.Add(this.connectBut);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(798, 214);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "System";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // refBut
            // 
            this.refBut.Location = new System.Drawing.Point(256, 33);
            this.refBut.Name = "refBut";
            this.refBut.Size = new System.Drawing.Size(121, 23);
            this.refBut.TabIndex = 6;
            this.refBut.Text = "Refresh";
            this.refBut.UseVisualStyleBackColor = true;
            this.refBut.Click += new System.EventHandler(this.refBut_Click);
            // 
            // disconBut
            // 
            this.disconBut.Location = new System.Drawing.Point(464, 6);
            this.disconBut.Name = "disconBut";
            this.disconBut.Size = new System.Drawing.Size(75, 23);
            this.disconBut.TabIndex = 5;
            this.disconBut.Text = "Disconnect";
            this.disconBut.UseVisualStyleBackColor = true;
            this.disconBut.Click += new System.EventHandler(this.disconBut_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(197, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "COM Port";
            // 
            // portList
            // 
            this.portList.FormattingEnabled = true;
            this.portList.Location = new System.Drawing.Point(256, 6);
            this.portList.Name = "portList";
            this.portList.Size = new System.Drawing.Size(121, 21);
            this.portList.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Baud Rate";
            // 
            // baudList
            // 
            this.baudList.FormattingEnabled = true;
            this.baudList.Items.AddRange(new object[] {
            "9600",
            "19200",
            "38400",
            "57600",
            "115200",
            "230400",
            "460800",
            "921600"});
            this.baudList.Location = new System.Drawing.Point(70, 6);
            this.baudList.Name = "baudList";
            this.baudList.Size = new System.Drawing.Size(121, 21);
            this.baudList.TabIndex = 1;
            // 
            // connectBut
            // 
            this.connectBut.Location = new System.Drawing.Point(383, 6);
            this.connectBut.Name = "connectBut";
            this.connectBut.Size = new System.Drawing.Size(75, 23);
            this.connectBut.TabIndex = 0;
            this.connectBut.Text = "Connect";
            this.connectBut.UseVisualStyleBackColor = true;
            this.connectBut.Click += new System.EventHandler(this.connectBut_Click);
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(6, 19);
            this.trackBar1.Maximum = 1010;
            this.trackBar1.Minimum = 10;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBar1.Size = new System.Drawing.Size(45, 211);
            this.trackBar1.TabIndex = 14;
            this.trackBar1.TickFrequency = 100;
            this.trackBar1.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trackBar1.Value = 10;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.trackBar1);
            this.groupBox1.Location = new System.Drawing.Point(320, 442);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(54, 236);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Speed";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.saveBut);
            this.groupBox2.Controls.Add(this.openBut);
            this.groupBox2.Controls.Add(this.delFrameBut);
            this.groupBox2.Controls.Add(this.editBut);
            this.groupBox2.Controls.Add(this.delBut);
            this.groupBox2.Controls.Add(this.animName);
            this.groupBox2.Controls.Add(this.addBut);
            this.groupBox2.Controls.Add(this.bbBut);
            this.groupBox2.Controls.Add(this.fwdBut);
            this.groupBox2.Controls.Add(this.maxLab);
            this.groupBox2.Controls.Add(this.backBut);
            this.groupBox2.Controls.Add(this.ffBut);
            this.groupBox2.Controls.Add(this.frameLab);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(53, 442);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(261, 230);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Control";
            // 
            // saveBut
            // 
            this.saveBut.Location = new System.Drawing.Point(115, 57);
            this.saveBut.Name = "saveBut";
            this.saveBut.Size = new System.Drawing.Size(139, 40);
            this.saveBut.TabIndex = 19;
            this.saveBut.Text = "Save Animation File";
            this.saveBut.UseVisualStyleBackColor = true;
            this.saveBut.Click += new System.EventHandler(this.saveBut_Click);
            // 
            // openBut
            // 
            this.openBut.Location = new System.Drawing.Point(7, 57);
            this.openBut.Name = "openBut";
            this.openBut.Size = new System.Drawing.Size(102, 40);
            this.openBut.TabIndex = 18;
            this.openBut.Text = "Open Animation File";
            this.openBut.UseVisualStyleBackColor = true;
            this.openBut.Click += new System.EventHandler(this.openBut_Click);
            // 
            // delFrameBut
            // 
            this.delFrameBut.Location = new System.Drawing.Point(115, 201);
            this.delFrameBut.Name = "delFrameBut";
            this.delFrameBut.Size = new System.Drawing.Size(139, 23);
            this.delFrameBut.TabIndex = 17;
            this.delFrameBut.Text = "Delete Frame";
            this.delFrameBut.UseVisualStyleBackColor = true;
            this.delFrameBut.Click += new System.EventHandler(this.delFrameBut_Click);
            // 
            // editBut
            // 
            this.editBut.Appearance = System.Windows.Forms.Appearance.Button;
            this.editBut.AutoSize = true;
            this.editBut.Location = new System.Drawing.Point(7, 103);
            this.editBut.MinimumSize = new System.Drawing.Size(248, 62);
            this.editBut.Name = "editBut";
            this.editBut.Size = new System.Drawing.Size(248, 62);
            this.editBut.TabIndex = 16;
            this.editBut.Text = "Edit Mode";
            this.editBut.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.editBut.UseVisualStyleBackColor = true;
            this.editBut.CheckedChanged += new System.EventHandler(this.editBut_CheckedChanged);
            // 
            // delBut
            // 
            this.delBut.Enabled = false;
            this.delBut.Location = new System.Drawing.Point(6, 201);
            this.delBut.Name = "delBut";
            this.delBut.Size = new System.Drawing.Size(103, 23);
            this.delBut.TabIndex = 15;
            this.delBut.Text = "Delete Animation";
            this.delBut.UseVisualStyleBackColor = true;
            this.delBut.Click += new System.EventHandler(this.delBut_Click);
            // 
            // animName
            // 
            this.animName.Location = new System.Drawing.Point(115, 173);
            this.animName.Name = "animName";
            this.animName.Size = new System.Drawing.Size(139, 20);
            this.animName.TabIndex = 14;
            this.animName.Text = "New Animation";
            // 
            // addBut
            // 
            this.addBut.Location = new System.Drawing.Point(6, 171);
            this.addBut.Name = "addBut";
            this.addBut.Size = new System.Drawing.Size(103, 23);
            this.addBut.TabIndex = 13;
            this.addBut.Text = "Add Animation";
            this.addBut.UseVisualStyleBackColor = true;
            this.addBut.Click += new System.EventHandler(this.addBut_Click);
            // 
            // frameTimer
            // 
            this.frameTimer.Tick += new System.EventHandler(this.frameTimer_Tick);
            // 
            // rotTimer
            // 
            this.rotTimer.Tick += new System.EventHandler(this.rotTimer_Tick);
            // 
            // musTimer
            // 
            this.musTimer.Interval = 10;
            this.musTimer.Tick += new System.EventHandler(this.musTimer_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1198, 690);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.sysTab);
            this.Controls.Add(this.allOffBut);
            this.Controls.Add(this.allOnBut);
            this.Controls.Add(this.backImage);
            this.Name = "Form1";
            this.Text = "Luke\'s LED Commander";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.backImage)).EndInit();
            this.sysTab.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rotBox)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox backImage;
        private System.Windows.Forms.Button allOnBut;
        private System.Windows.Forms.Button allOffBut;
        private System.Windows.Forms.Button fwdBut;
        private System.Windows.Forms.Button backBut;
        private System.Windows.Forms.TextBox frameLab;
        private System.Windows.Forms.Button bbBut;
        private System.Windows.Forms.Button ffBut;
        private System.Windows.Forms.TextBox maxLab;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl sysTab;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.ListBox animList;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.TextBox animName;
        private System.Windows.Forms.Button addBut;
        private System.Windows.Forms.CheckBox editBut;
        private System.Windows.Forms.Button delFrameBut;
        private System.Windows.Forms.Button delBut;
        private System.Windows.Forms.Timer frameTimer;
        private System.Windows.Forms.Button openBut;
        private System.Windows.Forms.Button saveBut;
        private System.Windows.Forms.Button stopBut;
        private System.Windows.Forms.Button pauseBut;
        private System.Windows.Forms.Button playBut;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox baudList;
        private System.Windows.Forms.Button connectBut;
        private System.Windows.Forms.Button refBut;
        private System.Windows.Forms.Button disconBut;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox portList;
        private System.Windows.Forms.Button browseBut;
        private System.Windows.Forms.TextBox folderBox;
        private System.Windows.Forms.PictureBox rotBox;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button rotStopBut;
        private System.Windows.Forms.Button rotPauseBut;
        private System.Windows.Forms.Button fwdRotBut;
        private System.Windows.Forms.Button revRotBut;
        private System.Windows.Forms.Timer rotTimer;
        private System.Windows.Forms.Button musDown;
        private System.Windows.Forms.Button musUp;
        private System.Windows.Forms.Button musDel;
        private System.Windows.Forms.Button musAdd;
        private System.Windows.Forms.Button musStop;
        private System.Windows.Forms.Button musPause;
        private System.Windows.Forms.Button musPlay;
        private System.Windows.Forms.ListBox playList;
        private System.Windows.Forms.Timer musTimer;
        private System.Windows.Forms.ProgressBar rightVol;
        private System.Windows.Forms.ProgressBar leftVol;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button decVis;
        private System.Windows.Forms.TextBox visLab;
        private System.Windows.Forms.Button incVis;


    }
}

