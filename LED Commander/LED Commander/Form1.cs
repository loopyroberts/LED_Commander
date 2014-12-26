using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Un4seen.Bass;
using Un4seen.Bass.Misc;
//using Un4seen.Bass.AddOn.Tags;


namespace LED_Commander
{
    public partial class Form1 : Form
    {
        Bitmap drawArea, rotArea;
        bool[, , ,] data;
        bool[,] rotData, rotDataTemp;
        bool[, ,] rotTemp;
        int[,] ring0, ring1, ring2, ring3;
        int[] ringLengths;
        bool serialOpen, direction;
        int size, width, frameNum, frameMax, frameLim, rotPosition, currentStream, visNum;
        bool mouseOn, firstData;
        System.IO.Ports.SerialPort sp1;
        private int _tickCounter = 0;
        private int _syncer = 0;
        private int _30mslength = 0;
        private int _deviceLatencyMS = 0; // device latency in milliseconds
		private int _deviceLatencyBytes = 0; // device latency in bytes
        private Un4seen.Bass.Misc.WaveForm WF2 = null;
		private SYNCPROC _sync = null;
        private float[] _rmsData; 

        public Form1()
        {
            serialOpen = false;
            frameNum = 0;
            InitializeComponent();
            drawArea = new Bitmap(backImage.Size.Width, backImage.Size.Height);
            rotArea = new Bitmap(rotBox.Size.Width, rotBox.Size.Height);
            backImage.Image = drawArea;
            rotBox.Image = rotArea;
            data = new bool[100, 8, 8, 8];
            rotData = new bool[28, 8];
            rotTemp = new bool[8, 8, 8];
            for (int k = 0; k < 8; k++)
            {
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        data[frameNum, k, i, j] = false;
                    }
                }
            }
            string[] ports = System.IO.Ports.SerialPort.GetPortNames();
            foreach (string p in ports)
            {
                portList.Items.Add(p);
            }
            if (ports.Length != 0)
            {
                portList.SelectedIndex = 0;
            }
            folderBox.Text = Directory.GetCurrentDirectory();
            animList.Items.Clear();
            string[] anims = Directory.GetFiles(folderBox.Text);
            foreach (string a in anims)
            {
                if (Path.GetExtension(a).Equals(".dat"))
                {
                    animList.Items.Add(Path.GetFileNameWithoutExtension(a));
                }
            }
            size = 14;
            visNum = 0;
            width = 140;
            frameMax = 0;
            frameLim = 100;
            mouseOn = false;
            firstData = false;
            baudList.SelectedIndex = 3; //115200 baud
            ring0 = new int[28, 2] { { 0, 0 }, { 0, 1 }, { 0, 2 }, { 0, 3 }, { 0, 4 }, { 0, 5 }, { 0, 6 }, { 0, 7 }, { 1, 7 }, { 2, 7 }, { 3, 7 }, { 4, 7 }, { 5, 7 }, { 6, 7 }, { 7, 7 }, { 7, 6 }, { 7, 5 }, { 7, 4 }, { 7, 3 }, { 7, 2 }, { 7, 1 }, { 7, 0 }, { 6, 0 }, { 5, 0 }, { 4, 0 }, { 3, 0 }, { 2, 0 }, { 1, 0 } };
            ring1 = new int[20, 2] { { 1, 1 }, { 1, 2 }, { 1, 3 }, { 1, 4 }, { 1, 5 }, { 1, 6 }, { 2, 6 }, { 3, 6 }, { 4, 6 }, { 5, 6 }, { 6, 6 }, { 6, 5 }, { 6, 4 }, { 6, 3 }, { 6, 2 }, { 6, 1 }, { 5, 1 }, { 4, 1 }, { 3, 1 }, { 2, 1 } };
            ring2 = new int[12, 2] { { 2, 2 }, { 2, 3 }, { 2, 4 }, { 2, 5 }, { 3, 5 }, { 4, 5 }, { 5, 5 }, { 5, 4 }, { 5, 3 }, { 5, 2 }, { 4, 2 }, { 3, 2 } };
            ring3 = new int[4, 2] { { 3, 3 }, { 3, 4 }, { 4, 4 }, { 4, 3 } };
            ringLengths = new int[4] { ring0.GetLength(0), ring1.GetLength(0), ring2.GetLength(0), ring3.GetLength(0) };
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            update_gfx();
            if (!Bass.BASS_Init(-1, 44100, BASSInit.BASS_DEVICE_DEFAULT, this.Handle))
            {
                MessageBox.Show(this, "Bass_Init error!");
                this.Close();
                return;
            }
        }

        private void backImage_MouseUp(object sender, MouseEventArgs e)
        {
            mouseOn = false;
        }

        private void allOnBut_Click(object sender, EventArgs e)
        {

            for (int k = 0; k < 8; k++)
            {
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        data[frameNum, k, i, j] = true;
                    }
                }
            }
            update_gfx();
        }


        private void allOffBut_Click(object sender, EventArgs e)
        {
            for (int k = 0; k < 8; k++)
            {
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        data[frameNum, k, i, j] = false;
                    }
                }
            }
            update_gfx();
        }

        public void update_gfx()
        {
            Graphics g, rg;
            SolidBrush bc;
            SolidBrush lb = new SolidBrush(Color.DarkTurquoise);
            SolidBrush lg = new SolidBrush(Color.LightGray);
            g = Graphics.FromImage(drawArea);
            rg = Graphics.FromImage(rotArea);
            if (editBut.Checked)
            {
                bc = new SolidBrush(Color.LightGray);
            }
            else
            {
                bc = new SolidBrush(Color.White);
            }
            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    for (int z = 0; z < 8; z++)
                    {
                        g.FillRectangle(bc, x * size + z * width + size, 0 * width + 6, 13, 6);
                        g.FillRectangle(bc, x * size + z * width + size, 0 * width + 9 * size + 1, 13, 6);
                        g.FillRectangle(bc, x * size + z * width + size, 1 * width + 6, 13, 6);
                        g.FillRectangle(bc, x * size + z * width + size, 1 * width + 9 * size + 1, 13, 6);
                        g.FillRectangle(bc, x * size + z * width + size, 2 * width + 6, 13, 6);
                        g.FillRectangle(bc, x * size + z * width + size, 2 * width + 9 * size + 1, 13, 6);

                        g.FillRectangle(bc, 6 + z * width, y * size + 0 * width + size, 6, size - 1);
                        g.FillRectangle(bc, z * width + 9 * size + 1, y * size + 0 * width + size, 6, size - 1);
                        g.FillRectangle(bc, 6 + z * width, y * size + 1 * width + size, 6, size - 1);
                        g.FillRectangle(bc, z * width + 9 * size + 1, y * size + 1 * width + size, 6, size - 1);
                        g.FillRectangle(bc, 6 + z * width, y * size + 2 * width + size, 6, size - 1);
                        g.FillRectangle(bc, z * width + 9 * size + 1, y * size + 2 * width + size, 6, size - 1);

                        if (!data[frameNum, x, y, z])
                        {


                            g.FillRectangle(lg, x * size + z * width + size, y * size + 0 * width + size, size - 1, size - 1);
                            g.FillRectangle(lg, (7 - z) * size + x * width + size, y * size + 1 * width + size, size - 1, size - 1);
                            g.FillRectangle(lg, x * size + y * width + size, (7 - z) * size + 2 * width + size, size - 1, size - 1);
                        }
                        else
                        {
                            g.FillRectangle(lb, x * size + z * width + size, y * size + 0 * width + size, size - 1, size - 1);
                            g.FillRectangle(lb, (7 - z) * size + x * width + size, y * size + 1 * width + size, size - 1, size - 1);
                            g.FillRectangle(lb, x * size + y * width + size, (7 - z) * size + 2 * width + size, size - 1, size - 1);
                        }
                    }
                }
            }
            for (int i = 0; i < 28; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (rotData[i, j])
                    {
                        rg.FillRectangle(lb, i * size + 1, j * size + 1, size - 1, size - 1);
                    }
                    else
                    {
                        rg.FillRectangle(lg, i * size + 1, j * size + 1, size - 1, size - 1);
                    }
                }
            }
            rotBox.Image = rotArea;
            backImage.Image = drawArea;
            g.Dispose();
            rg.Dispose();
            if (serialOpen)
            {
                byte[] b = new byte[65];
                b[0] = 242;
                for (int m = 0; m < 8; m++)
                {
                    for (int n = 0; n < 8; n++)
                    {
                        for (int i = 0; i < 8; i++)
                        {
                            if (data[frameNum, m, 7-i,n])
                            {
                                b[m * 8 + n + 1] |= (byte)(((byte)1) << i);
                            }
                        }
                    }
                }
                sp1.Write(b, 0, 65);
            }
        }

        private void fwdBut_Click(object sender, EventArgs e)
        {
            if (frameNum < frameLim)
            {
                frameNum += 1;

                if (frameMax < frameNum)
                {
                    frameMax = frameNum;
                }
                maxLab.Text = (frameMax + 1).ToString();
                frameLab.Text = (frameNum + 1).ToString();
                update_gfx();
            }
        }

        private void backBut_Click(object sender, EventArgs e)
        {
            if (frameNum > 0)
            {
                frameNum -= 1;
            }
            frameLab.Text = (frameNum + 1).ToString();
            update_gfx();
        }

        private void ffBut_Click(object sender, EventArgs e)
        {
            frameNum = frameMax;
            frameLab.Text = (frameNum + 1).ToString();
            update_gfx();
        }

        private void bbBut_Click(object sender, EventArgs e)
        {
            frameNum = 0;
            frameLab.Text = (frameNum + 1).ToString();
            update_gfx();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void addBut_Click(object sender, EventArgs e)
        {
            animList.Items.Add(animName.Text);
        }

        private void backImage_MouseDown(object sender, MouseEventArgs e)
        {
            if (editBut.Checked == true)
            {
                mouseOn = true;
                int x, z, y, r, x1, y1, z1;
                z1 = (e.X - size) / width;
                x1 = (e.X - size - width * z1) / size;
                r = (e.Y - size) / width;
                y1 = (e.Y - size - width * r) / size;
                if (x1 < 8 && y1 < 8 && z1 < 8 && r < 3 && x1 >= 0 && y1 >= 0 && e.X - size >= 0 && e.Y - size >= 0)
                {
                    switch (r)
                    {
                        case 0:
                            x = x1;
                            y = y1;
                            z = z1;
                            break;
                        case 1:
                            x = z1;
                            y = y1;
                            z = 7 - x1;
                            break;
                        default:
                            x = x1;
                            y = z1;
                            z = 7 - y1;
                            break;
                    }
                    firstData = !data[frameNum, x, y, z];
                    data[frameNum, x, y, z] = firstData;
                }
                else
                {
                    if (e.X > 0)
                    { }
                }
                update_gfx();
            }
        }

        private void delBut_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete this animation?", "Confirm?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2).Equals(DialogResult.Yes))
            {
                animList.Items.RemoveAt(animList.SelectedIndex);
            }
        }

        private void backImage_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseOn)
            {
                int x, z, y, r, x1, y1, z1;
                z1 = (e.X - size) / width;
                x1 = (e.X - size - width * z1) / size;
                r = (e.Y - size) / width;
                y1 = (e.Y - size - width * r) / size;
                if (x1 < 8 && y1 < 8 && z1 < 8 && r < 3 && x1 >= 0 && y1 >= 0 && e.X - size >= 0 && e.Y - size >= 0)
                {
                    switch (r)
                    {
                        case 0:
                            x = x1;
                            y = y1;
                            z = z1;
                            break;
                        case 1:
                            x = z1;
                            y = y1;
                            z = 7 - x1;
                            break;
                        default:
                            x = x1;
                            y = z1;
                            z = 7 - y1;
                            break;
                    }
                    data[frameNum, x, y, z] = firstData;
                    update_gfx();
                }
            }
        }

        private void editBut_CheckedChanged(object sender, EventArgs e)
        {
            if (editBut.Checked)
            {
                allOnBut.Enabled = false;
                allOffBut.Enabled = false;
                delBut.Enabled = true;
                delFrameBut.Enabled = true;

                editBut.BackColor = Color.Red;
            }
            else
            {
                allOnBut.Enabled = true;
                allOffBut.Enabled = true;
                delBut.Enabled = false;
                delFrameBut.Enabled = false;

                editBut.BackColor = default(Color);
                editBut.UseVisualStyleBackColor = true;

            }
            update_gfx();
        }

        private void delFrameBut_Click(object sender, EventArgs e)
        {
            if (frameMax != 0)
            {
                int frame = 0;
                int index = 0;
                bool[, , ,] temp = data;
                data = new bool[100, 8, 8, 8];
                while (frame <= frameMax)
                {
                    if (frame != frameNum)
                    {
                        for (int x = 0; x < 8; x++)
                        {
                            for (int y = 0; y < 8; y++)
                            {
                                for (int z = 0; z < 8; z++)
                                {
                                    data[index, x, y, z] = temp[frame, x, y, z];
                                }
                            }
                        }
                        index++;
                    }
                    frame++;
                }
                if (frameNum == frameMax)
                {
                    frameNum--;
                }
                frameMax--;
                maxLab.Text = (frameMax + 1).ToString();
                frameLab.Text = (frameNum + 1).ToString();
                update_gfx();
            }
        }

        private void openBut_Click(object sender, EventArgs e)
        {
            byte dat;
            OpenFileDialog op = new OpenFileDialog();
            if (op.ShowDialog().Equals(DialogResult.OK))
            {
                animList.Items.Add(op.SafeFileName);
                System.IO.FileStream fs = new System.IO.FileStream(op.FileName, System.IO.FileMode.Open);
                frameMax = (int)fs.ReadByte();
                maxLab.Text = (frameMax + 1).ToString();
                for (int k = 0; k <= frameMax; k++)
                {
                    for (int x = 0; x < 8; x++)
                    {
                        for (int y = 0; y < 8; y++)
                        {
                            dat = Convert.ToByte(fs.ReadByte());
                            for (int z = 0; z < 8; z++)
                            {
                                data[k, x, y, z] = ((dat >> z) & 1) != 0;
                            }
                        }
                    }
                }
                fs.Close();
                update_gfx();
            }
        }

        private void saveBut_Click(object sender, EventArgs e)
        {
            byte[] b = new byte[64];
            SaveFileDialog sf = new SaveFileDialog();
            if (sf.ShowDialog().Equals(DialogResult.OK))
            {
                System.IO.FileStream fs = new System.IO.FileStream(sf.FileName, System.IO.FileMode.Create);
                fs.WriteByte((byte)frameMax);
                for (int k = 0; k <= frameMax; k++)
                {
                    b = new byte[64];
                    for (int m = 0; m < 8; m++)
                    {
                        for (int n = 0; n < 8; n++)
                        {
                            for (int i = 0; i < 8; i++)
                            {
                                if (data[k, m, n, i])
                                {
                                    b[m * 8 + n] |= (byte)(((byte)1) << i);
                                }
                            }
                        }
                    }
                    fs.Write(b, 0, 64);
                }
                fs.Close();
            }
        }

        private void playBut_Click(object sender, EventArgs e)
        {
            frameTimer.Start();
        }

        private void pauseBut_Click(object sender, EventArgs e)
        {
            frameTimer.Stop();
        }

        private void stopBut_Click(object sender, EventArgs e)
        {
            frameTimer.Stop();
            frameNum = 0;
            frameLab.Text = (frameNum + 1).ToString();
            update_gfx();
        }

        private void frameTimer_Tick(object sender, EventArgs e)
        {
            frameNum++;
            if (frameNum > frameMax)
            {
                frameNum = 0;
            }
            frameLab.Text = (frameNum + 1).ToString();
            update_gfx();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            frameTimer.Interval = trackBar1.Value;
        }

        private void connectBut_Click(object sender, EventArgs e)
        {
            sp1 = new System.IO.Ports.SerialPort(portList.Text, Convert.ToInt32(baudList.Text), System.IO.Ports.Parity.None, 8, System.IO.Ports.StopBits.One);
            sp1.Open();
            serialOpen = true;
        }

        private void refBut_Click(object sender, EventArgs e)
        {
            portList.Items.Clear();
            string[] ports = System.IO.Ports.SerialPort.GetPortNames();
            foreach (string p in ports)
            {
                portList.Items.Add(p);
            }
        }

        private void disconBut_Click(object sender, EventArgs e)
        {
            sp1.Close();
            serialOpen = false;
        }

        private void browseBut_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fo = new FolderBrowserDialog();
            fo.ShowDialog();
            
            if (fo.SelectedPath != "")
            {
                animList.Items.Clear();
                folderBox.Text = fo.SelectedPath;
                string[] anims = Directory.GetFiles(fo.SelectedPath);
                foreach (string a in anims)
                {
                    if (Path.GetExtension(a).Equals(".dat"))
                    {
                        animList.Items.Add(Path.GetFileNameWithoutExtension(a));
                    }
                }
            }
        }

        private void animList_SelectedIndexChanged(object sender, EventArgs e)
        {
            byte dat;
            System.IO.FileStream fs = new System.IO.FileStream(folderBox.Text + "\\" + animList.Text + ".dat", System.IO.FileMode.Open);
            frameMax = (int)fs.ReadByte();
            maxLab.Text = (frameMax + 1).ToString();
            for (int k = 0; k <= frameMax; k++)
            {
                for (int x = 0; x < 8; x++)
                {
                    for (int y = 0; y < 8; y++)
                    {
                        dat = Convert.ToByte(fs.ReadByte());
                        for (int z = 0; z < 8; z++)
                        {
                            data[k, x, y, z] = ((dat >> z) & 1) != 0;
                        }
                    }
                }
            }
            fs.Close();
            update_gfx();
        }

        private void rotBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (editBut.Checked == true)
            {
                mouseOn = true;
                int x, z, l, x1, y1;

                x = (e.X - 1) / size;
                l = x / 7;
                z = (e.Y - 1) / size;

                switch (l)
                {
                    case 0:
                        x1 = x;
                        y1 = 0;
                        break;
                    case 1:
                        x1 = 7;
                        y1 = x - 7;
                        break;
                    case 2:
                        y1 = 7;
                        x1 = 7 - (x - 14);
                        break;
                    default:
                        x1 = 0;
                        y1 = 7 - (x - 21);
                        break;
                }
                firstData = !rotData[x, z];
                rotData[x, z] = firstData;
                data[frameNum, y1, z, x1] = firstData;
                update_gfx();
            }
        }

        private void rotBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseOn)
            {
                int x, z, l, x1, y1;
                x = (e.X - 1) / size;
                l = x / 7;
                z = (e.Y - 1) / size;
                switch (l)
                {
                    case 0:
                        x1 = x;
                        y1 = 0;
                        break;
                    case 1:
                        x1 = 7;
                        y1 = x - 7;
                        break;
                    case 2:
                        y1 = 7;
                        x1 = 7 - (x - 14);
                        break;
                    default:
                        x1 = 0;
                        y1 = 7 - (x - 21);
                        break;
                }
                if (x1 < 8 && y1 < 8 && z < 8 && x1 >= 0 && y1 >= 0 && z >= 0 && x < 28)
                {
                    rotData[x, z] = firstData;
                    data[frameNum, y1, z, x1] = firstData;
                    update_gfx();
                }
            }
        }

        private void rotBox_MouseUp(object sender, MouseEventArgs e)
        {
            mouseOn = false;
        }

        private void revRotBut_Click(object sender, EventArgs e)
        {
            rotTimer.Start();

            direction = false;
        }

        private void fwdRotBut_Click(object sender, EventArgs e)
        {
            rotTimer.Start();
            direction = true;
        }

        private void rotPauseBut_Click(object sender, EventArgs e)
        {
            rotTimer.Stop();
        }

        private void rotStopBut_Click(object sender, EventArgs e)
        {
            rotTimer.Stop();
            rotPosition = 0;
            update_gfx();
        }

        private void rotTimer_Tick(object sender, EventArgs e)
        {
            rotPosition = (rotPosition + 1) % 8;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    for (int k = 0; k < 8; k++)
                    {
                        rotTemp[i, j, k] = data[frameNum, i, j, k];
                    }
                }
            }
            int[,] ringTemp;
            bool[, , ,] dataTemp = data;
            for (int k = 0; k < 4; k++)
            {
                if (k == 0 || (k == 1 && (rotPosition == 1 || rotPosition == 2 || rotPosition == 3 || rotPosition == 5 || rotPosition == 6)) || (k == 2 && (rotPosition == 1 || rotPosition == 4 || rotPosition == 6)) || (k == 3 && (rotPosition == 6)))
                {
                    switch (k)
                    {
                        case 0:
                            {
                                ringTemp = ring0;
                                break;
                            }
                        case 1:
                            {
                                ringTemp = ring1;
                                break;
                            }
                        case 2:
                            {
                                ringTemp = ring2;
                                break;
                            }
                        default:
                            {
                                ringTemp = ring3;
                                break;
                            }
                    }
                    
                    for (int j = 0; j < ringLengths[k]; j++)
                    {
                        for (int i = 0; i < 8; i++)
                        {
                            dataTemp[frameNum, ringTemp[j, 1], i, ringTemp[j, 0]] = data[frameNum, ringTemp[(j + 1) % ringLengths[k], 1], i, ringTemp[(j + 1) % ringLengths[k], 0]];
                        }
                    }
                    data = dataTemp;
                }
            }
            # region old rot code
            /*rotDataTemp = rotData;
                rotData = new bool[28, 8];
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        for (int k = 0; k < 8; k++)
                        {
                            rotTemp[i, j, k] = data[frameNum, i, j, k];
                        }
                    }
                }

                for (int z = 0; z < 8; z++)
                {
                    for (int i = 0; i < 28; i++)
                    {
                        int x1, y1, l, l1, x2, y2, j;
                        l = i / 7;
                        j = (i + rotPosition) % 28;
                        //if (j >= 28)
                        //{
                        //    j = 0;
                        //}
                        //if (j < 0)
                        //{
                        //    j = 27;
                        //}
                        rotData[j, z] = rotDataTemp[i, z];
                        l1 = j / 7;
                        switch (l)
                        {
                            case 0:
                                x1 = i;
                                y1 = 0;
                                break;
                            case 1:
                                x1 = 7;
                                y1 = i - 7;
                                break;
                            case 2:
                                y1 = 7;
                                x1 = 7 - (i - 14);
                                break;
                            default:
                                x1 = 0;
                                y1 = 7 - (i - 21);
                                break;
                        }

                        switch (l1)
                        {
                            case 0:
                                x2 = j;
                                y2 = 0;
                                break;
                            case 1:
                                x2 = 7;
                                y2 = j - 7;
                                break;
                            case 2:
                                y2 = 7;
                                x2 = 7 - (j - 14);
                                break;
                            default:
                                x2 = 0;
                                y2 = 7 - (j - 21);
                                break;
                        }
                        data[frameNum, x2, z, y2] = rotTemp[x1, z, y1];
                    }
                    if (rotPosition == 1 || rotPosition == 2 || rotPosition == 3 || rotPosition == 5 || rotPosition == 6)
                    {
                        for (int i = 0; i < 20; i++)
                        {
                            int x1, y1, l, l1, x2, y2, j;
                            l = i / 5;
                            j = (i + rotPosition) % 20;
                            l1 = j / 5;
                            switch (l)
                            {
                                case 0:
                                    x1 = i + 1;
                                    y1 = 1;
                                    break;
                                case 1:
                                    x1 = 6;
                                    y1 = i - 4;
                                    break;
                                case 2:
                                    y1 = 6;
                                    x1 = 6 - (i - 10);
                                    break;
                                default:
                                    x1 = 1;
                                    y1 = 6 - (i - 15);
                                    break;
                            }

                            switch (l1)
                            {
                                case 0:
                                    x2 = j + 1;
                                    y2 = 1;
                                    break;
                                case 1:
                                    x2 = 6;
                                    y2 = j - 4;
                                    break;
                                case 2:
                                    y2 = 6;
                                    x2 = 6 - (j - 10);
                                    break;
                                default:
                                    x2 = 1;
                                    y2 = 6 - (j - 15);
                                    break;
                            }
                            data[frameNum, x2, z, y2] = rotTemp[x1, z, y1];
                        }
                    }
                    if (rotPosition == 1 || rotPosition == 4 || rotPosition == 6)
                    {
                        for (int i = 0; i < 12; i++)
                        {
                            int x1, y1, l, l1, x2, y2, j;
                            l = i / 3;
                            if (direction)
                            {
                                j = i + 1;
                            }
                            else
                            {
                                j = i - 1;
                            }
                            if (j >= 12)
                            {
                                j = 0;
                            }
                            if (j < 0)
                            {
                                j = 11;
                            }
                            l1 = j / 3;
                            switch (l)
                            {
                                case 0:
                                    x1 = i + 2;
                                    y1 = 2;
                                    break;
                                case 1:
                                    x1 = 5;
                                    y1 = i - 1;
                                    break;
                                case 2:
                                    y1 = 5;
                                    x1 = 5 - (i - 6);
                                    break;
                                default:
                                    x1 = 2;
                                    y1 = 5 - (i - 9);
                                    break;
                            }

                            switch (l1)
                            {
                                case 0:
                                    x2 = j + 2;
                                    y2 = 2;
                                    break;
                                case 1:
                                    x2 = 5;
                                    y2 = j - 1;
                                    break;
                                case 2:
                                    y2 = 5;
                                    x2 = 5 - (j - 6);
                                    break;
                                default:
                                    x2 = 2;
                                    y2 = 5 - (j - 9);
                                    break;
                            }
                            data[frameNum, x2, z, y2] = rotTemp[x1, z, y1];
                        }
                    }
                    if (rotPosition == 6)
                    {
                        if (direction)
                        {
                            data[frameNum, 3, z, 3] = rotTemp[4, z, 3];
                            data[frameNum, 3, z, 4] = rotTemp[3, z, 3];
                            data[frameNum, 4, z, 4] = rotTemp[3, z, 4];
                            data[frameNum, 4, z, 3] = rotTemp[4, z, 4];
                        }
                        else
                        {
                            data[frameNum, 3, z, 3] = rotTemp[3, z, 4];
                            data[frameNum, 3, z, 4] = rotTemp[4, z, 4];
                            data[frameNum, 4, z, 4] = rotTemp[4, z, 3];
                            data[frameNum, 4, z, 3] = rotTemp[3, z, 3];
                        }
                    }
                }
                rotPosition++;
                if (rotPosition >= 7)
                {
                    rotPosition = 0;
                }
                 * */
            #endregion
            update_gfx();
        }

        private void musAdd_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Multiselect = true;
            op.ShowDialog();
            foreach (string file in op.FileNames)
            {
                playList.Items.Add(file);
            }
        }

        private void musPlay_Click(object sender, EventArgs e)
        {
            GetWaveForm();
            
            musTimer.Stop();
            Bass.BASS_StreamFree(currentStream);
            if (playList.Text != String.Empty)
            {
                // create the stream
                currentStream = Bass.BASS_StreamCreateFile(playList.Text, 0, 0, BASSFlag.BASS_SAMPLE_FLOAT | BASSFlag.BASS_STREAM_PRESCAN);
                if (currentStream != 0)
                {
                    // used in RMS
                    _30mslength = (int)Bass.BASS_ChannelSeconds2Bytes(currentStream, 0.03); // 30ms window
                    // latency from milliseconds to bytes
                    _deviceLatencyBytes = (int)Bass.BASS_ChannelSeconds2Bytes(currentStream, _deviceLatencyMS / 1000.0);

                    // set a DSP user callback method
                    //_myDSPAddr = new DSPPROC(MyDSPGain);
                    //Bass.BASS_ChannelSetDSP(_stream, _myDSPAddr, 0, 2);
                    // if you want to use the above two line instead (uncomment the above and comment below)



                    if (WF2 != null && WF2.IsRendered)
                    {
                        // make sure playback and wave form are in sync, since
                        // we rended with 16-bit but play here with 32-bit
                        WF2.SyncPlayback(currentStream);

                        long cuein = WF2.GetMarker("CUE");
                        long cueout = WF2.GetMarker("END");

                        int cueinFrame = WF2.Position2Frames(cuein);
                        int cueoutFrame = WF2.Position2Frames(cueout);
                        Console.WriteLine("CueIn at {0}sec.; CueOut at {1}sec.", WF2.Frame2Seconds(cueinFrame), WF2.Frame2Seconds(cueoutFrame));

                        if (cuein >= 0)
                        {
                            Bass.BASS_ChannelSetPosition(currentStream, cuein);
                        }
                        if (cueout >= 0)
                        {
                            Bass.BASS_ChannelRemoveSync(currentStream, _syncer);
                            _syncer = Bass.BASS_ChannelSetSync(currentStream, BASSSync.BASS_SYNC_POS, cueout, _sync, IntPtr.Zero);
                        }
                    }
                }
                if (currentStream != 0 && Bass.BASS_ChannelPlay(currentStream, false))
                {
                    musTimer.Start();
                    // get some channel info
                    BASS_CHANNELINFO info = new BASS_CHANNELINFO();
                    Bass.BASS_ChannelGetInfo(currentStream, info);
                }
                else
                {
                    Console.WriteLine("Error={0}", Bass.BASS_ErrorGetCode());
                }




                /////////////////////////////////
                 /* BASSActive ba = Bass.BASS_ChannelIsActive(currentStream);
                 if (ba == BASSActive.BASS_ACTIVE_PLAYING)
                 {
                     Bass.BASS_ChannelStop(currentStream);
                     Bass.BASS_StreamFree(currentStream);
                     currentStream = Bass.BASS_StreamCreateFile(playList.Text, 0L, 0L, BASSFlag.BASS_DEFAULT);
                     Bass.BASS_ChannelPlay(currentStream, false);
                     SYNCPROC syn = new SYNCPROC(songEnd);
                     Bass.BASS_ChannelSetSync(currentStream, BASSSync.BASS_SYNC_END, 0L, syn, new IntPtr(0));
                 }
                 else if(ba==BASSActive.BASS_ACTIVE_PAUSED)
                 {
                     Bass.BASS_ChannelPlay(currentStream, false);
                     SYNCPROC syn = new SYNCPROC(songEnd);
                     Bass.BASS_ChannelSetSync(currentStream, BASSSync.BASS_SYNC_END, 0L, syn, new IntPtr(0));
                 }
                 else
                 {
                     currentStream = Bass.BASS_StreamCreateFile(playList.Text, 0L, 0L, BASSFlag.BASS_DEFAULT); 
                     Bass.BASS_ChannelPlay(currentStream, false);
                     SYNCPROC syn = new SYNCPROC(songEnd);
                     Bass.BASS_ChannelSetSync(currentStream, BASSSync.BASS_SYNC_END, 0L, syn, new IntPtr(0));
                 }
                 long len = Bass.BASS_ChannelGetLength(currentStream);
                 double time = Bass.BASS_ChannelBytes2Seconds(currentStream, len);
                 */
                update_gfx();
                musTimer.Start();
            }
        }

        private void musStop_Click(object sender, EventArgs e)
        {
            Bass.BASS_ChannelPause(currentStream);
            currentStream = Bass.BASS_StreamCreateFile(playList.Text, 0L, 0L, BASSFlag.BASS_DEFAULT);
        }

        private void musPause_Click(object sender, EventArgs e)
        {
            Bass.BASS_ChannelPause(currentStream);
        }

        private void playList_SelectedIndexChanged(object sender, EventArgs e)
        {
            //GetWaveForm(); 
           //newStream = Bass.BASS_StreamCreateFile(playList.Text, 0L, 0L, BASSFlag.BASS_DEFAULT);
        }

        private void musTimer_Tick(object sender, EventArgs e)
        {
            			// here we gather info about the stream, when it is playing...
			if ( Bass.BASS_ChannelIsActive(currentStream) == BASSActive.BASS_ACTIVE_PLAYING )
			{
				// the stream is still playing...
			}
			else
			{
				// the stream is NOT playing anymore...
				musTimer.Stop();

				DrawWavePosition(-1, -1);
				

				return;
			}

			// from here on, the stream is for sure playing...
			_tickCounter++;
			long pos = Bass.BASS_ChannelGetPosition(currentStream); // position in bytes
			long len = Bass.BASS_ChannelGetLength(currentStream); // length in bytes

			if (_tickCounter == 5)
			{
				// display the position every 250ms (since timer is 50ms)
				_tickCounter = 0;
                double totaltime = Bass.BASS_ChannelBytes2Seconds(currentStream, len); // the total time length
                double elapsedtime = Bass.BASS_ChannelBytes2Seconds(currentStream, pos); // the elapsed time length
                double remainingtime = totaltime - elapsedtime;
			}
			
			// display the level bars
			int peakL = 0;
			int peakR = 0;
			// for testing you might also call RMS_2, RMS_3 or RMS_4
			RMS(currentStream, out peakL, out peakR);
            // level to dB
            double dBlevelL = Utils.LevelToDB(peakL, 65535);
            double dBlevelR = Utils.LevelToDB(peakR, 65535);
			//RMS_2(_stream, out peakL, out peakR);
			//RMS_3(_stream, out peakL, out peakR);
			//RMS_4(_stream, out peakL, out peakR);


			// update the wave position
			DrawWavePosition(pos, len);
			
            BASSActive status = Bass.BASS_ChannelIsActive(currentStream);
            if (currentStream != 0 && status == BASSActive.BASS_ACTIVE_PLAYING)
            {
                leftVol.Value = ((Bass.BASS_ChannelGetLevel(currentStream)) >> 16) & 0xffff;
                rightVol.Value = (Bass.BASS_ChannelGetLevel(currentStream)) & 0xffff;
                switch(visNum)
                {
                    case 0:
                        fillVisLevel();
                        break;
                    case 1:
                        fftSideVis();
                        break;
                    case 2:
                        fftSideVisFade();
                        break;
                    case 3:
                        midLevelVis();
                        break;
                    case 4:
                        break;

                }


                update_gfx();
            }
        }
        private void setHeight(int x, int y, int height)
        {
            if (height > 8)
            {
                throw new System.Exception("Height out of range");
            }
            for (int i = 0; i < height; i++)
            {
                data[frameNum, x, 7 - i, y] = true;
            }
            for (int i = height; i < 8; i++)
            {
                data[frameNum, x, 7 - i, y] = false;
            }
        }
        private void songEnd(int handle, int channel, int data, IntPtr user)
        {
            if (!InvokeRequired)
            {
                if (playList.SelectedIndex != playList.Items.Count-1)
                {
                    playList.SelectedIndex += 1;
                    musPlay.PerformClick();
                }
            }
            else
            {
                Invoke(new Action<int, int, int, IntPtr>(songEnd), 0, 0, 0, new IntPtr(0));
            }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (WF2 == null)
                return;

            long pos = WF2.GetBytePositionFromX(e.X, pictureBox1.Width, -1, -1);
            Bass.BASS_ChannelSetPosition(currentStream, pos);
        }
        private void DrawWavePosition(long pos, long len)
        {
            // Note: we might take the latency of the device into account here!
            // so we show the position as heard, not played.
            // That's why we called Bass.Bass_Init with the BASS_DEVICE_LATENCY flag
            // and then used the BASS_INFO structure to get the latency of the device

            if (len == 0 || pos < 0)
            {
                this.pictureBox1.Image = null;
                return;
            }

            Bitmap bitmap = null;
            Graphics g = null;
            Pen p = null;
            double bpp = 0;

            try
            {
                    // not zoomed: width = length of stream
                bpp = len / (double)this.pictureBox1.Width;  // bytes per pixel
                // we take the device latency into account
                // Not really needed, but if you have a real slow device, you might need the next line
                // so the BASS_ChannelGetPosition might return a position ahead of what we hear
                pos -= _deviceLatencyBytes;

                p = new Pen(Color.Red);
                bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                g = Graphics.FromImage(bitmap);
                g.Clear(Color.Black);
                int x = (int)Math.Round(pos / bpp);  // position (x) where to draw the line
                g.DrawLine(p, x, 0, x, pictureBox1.Height - 1);
                bitmap.MakeTransparent(Color.Black);
            }
            catch
            {
                bitmap = null;
            }
            finally
            {
                // clean up graphics resources
                if (p != null)
                    p.Dispose();
                if (g != null)
                    g.Dispose();
            }
            this.pictureBox1.Image = bitmap;
        }
        private void DrawWave()
        {
            if (WF2 != null)
                pictureBox1.BackgroundImage = WF2.CreateBitmap(pictureBox1.Width, pictureBox1.Height, -1, -1, true);
            else
                pictureBox1.BackgroundImage = null;
        }
        // zoom helper varibales

		private void GetWaveForm()
		{
			// unzoom...(display the whole wave form)
			
			// render a wave form
			WF2 = new WaveForm(playList.Text, new WAVEFORMPROC(MyWaveFormCallback), this);
			WF2.FrameResolution = 0.01f; // 10ms are nice
			WF2.CallbackFrequency = 2000; // every 30 seconds rendered (3000*10ms=30sec)
			WF2.ColorBackground = Color.WhiteSmoke;
			WF2.ColorLeft = Color.Gainsboro;
			WF2.ColorLeftEnvelope = Color.Gray;
			WF2.ColorRight = Color.LightGray;
			WF2.ColorRightEnvelope = Color.DimGray;
			WF2.ColorMarker = Color.DarkBlue;
			WF2.DrawWaveForm = WaveForm.WAVEFORMDRAWTYPE.Stereo;
			WF2.DrawMarker = WaveForm.MARKERDRAWTYPE.Line | WaveForm.MARKERDRAWTYPE.Name | WaveForm.MARKERDRAWTYPE.NamePositionAlternate;
			WF2.MarkerLength = 0.75f;
			// our playing stream will be in 32-bit float!
			// but here we render with 16-bit (default) - just to demo the WF2.SyncPlayback method
			WF2.RenderStart( true, BASSFlag.BASS_SAMPLE_FLOAT );
		}
        private void MyWaveFormCallback(int framesDone, int framesTotal, TimeSpan elapsedTime, bool finished)
		{
			if (finished)
			{
				Console.WriteLine( "Finished rendering in {0}sec.", elapsedTime);
				Console.WriteLine( "FramesRendered={0} of {1}", WF2.FramesRendered, WF2.FramesToRender);
				// eg.g use this to save the rendered wave form...
				//WF.WaveFormSaveToFile( @"C:\test.wf" );

				// auto detect silence at beginning and end
				long cuein  = 0;
				long cueout = 0;
				WF2.GetCuePoints(ref cuein, ref cueout, -25.0, -42.0, -1, -1);
				WF2.AddMarker( "CUE", cuein );
				WF2.AddMarker( "END", cueout );
			}
			// will be called during rendering...
			DrawWave();
		}
        private void RMS(int channel, out int peakL, out int peakR)
        {
            float maxL = 0f;
            float maxR = 0f;
            int length = _30mslength; // 30ms window already set at buttonPlay_Click
            int l4 = length / 4; // the number of 32-bit floats required (since length is in bytes!)

            // increase our data buffer as needed
            if (_rmsData == null || _rmsData.Length < l4)
                _rmsData = new float[l4];

            // Note: this is a special mechanism to deal with variable length c-arrays.
            // In fact we just pass the address (reference) to the first array element to the call.
            // However the .Net marshal operation will copy N array elements (so actually fill our float[]).
            // N is determined by the size of our managed array, in this case N=l4
            length = Bass.BASS_ChannelGetData(channel, _rmsData, length);

            l4 = length / 4; // the number of 32-bit floats received

            for (int a = 0; a < l4; a++)
            {
                float absLevel = Math.Abs(_rmsData[a]);
                // decide on L/R channel
                if (a % 2 == 0)
                {
                    // L channel
                    if (absLevel > maxL)
                        maxL = absLevel;
                }
                else
                {
                    // R channel
                    if (absLevel > maxR)
                        maxR = absLevel;
                }
            }

            // limit the maximum peak levels to +6bB = 0xFFFF = 65535
            // the peak levels will be int values, where 32767 = 0dB!
            // and a float value of 1.0 also represents 0db.
            peakL = (int)Math.Round(32767f * maxL) & 0xFFFF;
            peakR = (int)Math.Round(32767f * maxR) & 0xFFFF;
        }

        private void incVis_Click(object sender, EventArgs e)
        {
            visNum++;
            visLab.Text = visNum.ToString();
        }

        private void decVis_Click(object sender, EventArgs e)
        {
            visNum--;
            visLab.Text = visNum.ToString();
        }
        private void fillVisLevel()
        {
            int b = (leftVol.Value >> 12) & 0x7;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    setHeight(i, j, b);
                }
            }
        }
        private void fftSideVisFade()
        {

            float[] buf = new float[128];
            float[] bufBin = new float[8];
            Bass.BASS_ChannelGetData(currentStream, buf, (int)BASSData.BASS_DATA_FFT256);
            buf[1] = 0;
            for (int i = 0; i < 128; i++)
            {
                bufBin[i / 16] += buf[i];
            }
            for (int i = 0; i < 8; i++)
            {
                int h = (int)(Math.Sqrt(Math.Sqrt(bufBin[i])) * 8);
                if (h > 8) h = 8;
                setHeight(0, i, h);
                for (int j = 1; j < 8; j++)
                {
                    if (h > 0)
                    {
                        h--;
                        setHeight(j, i, h);
                    }
                    else
                    {
                        setHeight(j, i, 0);
                    }
                }
            }
        }
        private void fftSideVis()
        {
            float[] buf = new float[128];
            float[] bufBin = new float[8];
            Bass.BASS_ChannelGetData(currentStream, buf, (int)BASSData.BASS_DATA_FFT256);
            buf[1] = 0;
            for (int i = 0; i < 128; i++)
            {
                bufBin[i / 16] += buf[i];
            }
            for (int i = 0; i < 8; i++)
            {
                int h = (int)(Math.Sqrt(Math.Sqrt(bufBin[i])) * 8);
                if (h > 8) h = 8;
                for (int j = 0; j < 8; j++)
                {
                    setHeight(j, i, h);
                }
            }
        } 
        private void midLevelVis()
        {
            int b = ((leftVol.Value >> 13));
            if (b > 4) b = 4;
            setRing(3, b*2);
            if (b > 1)
            {
                setRing(2, b*2 - 2);
            }
            else
            {
                setRing(2, 0);
            }
            if (b > 2)
            {
                setRing(1, b*2 - 4);
            }
            else
            {
                setRing(1, 0);
            }
            if (b > 3)
            {
                setRing(0, b*2 - 6);
            }
            else
            {
                setRing(0, 0);
            }
        }
        private void setRing(int ringNo, int height)
        {
            int[,] ringData;
            switch (ringNo)
            {
                case 0:
                    ringData = ring0;
                    break;
                case 1:
                    ringData = ring1;
                    break;
                case 2:
                    ringData = ring2;
                    break;
                default:
                    ringData = ring3;
                    break;
            }
            for (int j = 0; j < ringData.GetLength(0); j++)
            {
                for (int i = 0; i < height; i++)
                {
                    data[frameNum, ringData[j,0], 7 - i, ringData[j,1]] = true;
                }
                for (int i = height; i < 8; i++)
                {
                    data[frameNum, ringData[j, 0], 7 - i, ringData[j, 1]] = false;
                }
            }
        }
        private void setSquare(int x1, int x2, int y1, int y2)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void musDel_Click(object sender, EventArgs e)
        {

        }

        private void musUp_Click(object sender, EventArgs e)
        {

        }

        private void musDown_Click(object sender, EventArgs e)
        {

        }
    }
}
