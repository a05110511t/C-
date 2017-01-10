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
using System.Threading;

namespace Mouse01
{
    public partial class Form1 : Form
    {
        Graphics g;
        bool checker;
        bool record;
        bool QQ;
        int oX = 0, oY = 0;
        int newX = 0, newY = 0;
        string xx,yy;
        

        StreamWriter log = new StreamWriter("log.txt");//create file

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //
            this.MouseMove += Form1_MouseMove;
            this.MouseDown += Form1_MouseDown;
            this.MouseUp += Form1_MouseUp;
        }

        void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            checker = false;
            oX = 0;
            oY = 0;
            
        }

        void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            g = this.CreateGraphics();
            //g.Clear(BackColor);
            checker = true;
            
            
        }

        void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            this.Text = e.X + "." + e.Y + " " + checker;
            
            xx = e.X.ToString();
            yy = e.Y.ToString();

            if(checker == true)
            {
                if (oX == 0)
                    oX = e.X;
                if (oY == 0)
                    oY = e.Y;
                g.DrawLine(Pens.Red, oX, oY, e.X, e.Y);
                oX = e.X;
                oY = e.Y;

            }
            if(record == true)
            {
                //timestamp
                string xxx = xx;
                string yyy = yy;
                long myTicks = DateTime.Now.Ticks;
                DateTime dtime = new DateTime(myTicks);
                log.WriteLine(myTicks.ToString() +","+ checker +","+ xxx+","+yyy);
            }
        }

        private void button1_Click(object sender, EventArgs e)//記錄
        {
            record = true;
            if (log.BaseStream == null)
            {
                g.Clear(BackColor);
                log = new StreamWriter("log.txt");//create file
            }
        }

        private void button2_Click(object sender, EventArgs e)//重播
        {
            //清乾淨
            g.Clear(BackColor);
            //讀內容
            StreamReader fs = new StreamReader("log.txt", System.Text.Encoding.Default);
            string str = "";
            int oldX=0, oldY=0;
            while ((str = fs.ReadLine()) != null)//迴圈一行一行讀log
            {
                //用Split切開字串 int.parse
                string[] rec = str.Split(',');
                newX = int.Parse(rec[2]);
                newY = int.Parse(rec[3]);
                QQ = bool.Parse(rec[1]);
                //重複畫線程式
                if (QQ == true)
                {
                    if (oldX == 0)
                        oldX = newX;
                    if (oldY == 0)
                        oldY = newY;
                    g.DrawLine(Pens.Red, oldX, oldY, newX, newY);
                    oldX = newX;
                    oldY = newY;
                    Thread.Sleep(10);
                }
                if(QQ == false)
                {
                    oldX = 0;
                    oldY = 0;
                }
            }
            fs.Close();//close
            
        }
        private void button3_Click(object sender, EventArgs e)//停止
        {
            record = false;
            log.Close(); // close the file
        }
    }
}
