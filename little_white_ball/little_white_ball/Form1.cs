using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using Myball;

namespace little_white_ball
{
    public partial class Form1 : Form
    {
        int stepx;
        int stepy;
        int x;
        int y;

        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Thread thread1 = new Thread(new ThreadStart(ball));
            thread1.Start();
            thread1.Join();
            
        }

        public void ball()
        {
            Graphics g = this.CreateGraphics();
            g.Clear(this.BackColor);
            Random rnd = new Random();
            stepx = rnd.Next(1, 4);
            stepy = rnd.Next(1, 4);
            x = rnd.Next(0, this.ClientSize.Width - stepx);
            y = rnd.Next(0, this.ClientSize.Width - stepy);

            for (int i = 0; i < 2500; i++)
            {
                g.FillEllipse(Brushes.Red, x + stepx, stepy + y, 10, 10);
                Thread.Sleep(25);
                g.Clear(this.BackColor);
                x += stepx;
                y += stepy;
                if (y + stepy > this.ClientSize.Height)
                {
                    stepy = -stepy;
                }
                else if (y < 0)
                {
                    stepy = -stepy;
                }

                if (x + stepx > this.ClientSize.Width)
                {
                    stepx = -stepx;
                }
                else if (x < 0)
                {
                    stepx = -stepx;
                }
                this.Invalidate();
            }
        }
    }
}


