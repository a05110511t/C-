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

namespace Arkanoid_pratice
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
            timer1.Enabled = true;
            //To Hide the Cursor:
            Cursor.Hide();
            //To Remove Borders:
            this.FormBorderStyle = FormBorderStyle.None;
            //To Bring The Form To The Front:
            this.TopMost = true;
            //To Make It Fullscreen:
            this.Bounds = Screen.PrimaryScreen.Bounds;
            //To Set The Position Of Racket
            racket1.Top = playground.Bottom - (playground.Bottom / 10);
            racket2.Top = playground.Bottom - (playground.Bottom / 10);
            racket3.Top = playground.Bottom - (playground.Bottom / 10);
            // To Set The Position Of Label to center:
            gameover_label.Left = (playground.Width / 2) - (gameover_label.Width / 2);
            gameover_label.Top = (playground.Height / 2) - (gameover_label.Height / 2);
            //To Hide Label When Game Is Running:
            gameover_lbl.Visible = false; 



        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Thread thread1 = new Thread(new ThreadStart(ball1));
            Thread thread2 = new Thread(new ThreadStart(ball2));
            Thread thread3 = new Thread(new ThreadStart(ball3));
            Thread thread4 = new Thread(new ThreadStart(ball4));
            Thread thread5 = new Thread(new ThreadStart(ball5));
            thread1.Start();
            thread2.Start();
            thread3.Start();
            thread4.Start();
            thread5.Start();
            thread1.Join();
            thread2.Join();
            thread3.Join();
            thread4.Join();
            thread5.Join();
            
        }
    public void ball1()//111111111111111111111
        {
            
            Graphics g = this.CreateGraphics();
            g.Clear(this.BackColor);
            Random rnd = new Random();
            stepx = rnd.Next(1, 1);
            stepy = rnd.Next(1, 1);
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
    public void ball2()//2222222222222222222222
    {
        
        Graphics g = this.CreateGraphics();
        g.Clear(this.BackColor);
        Random rnd = new Random();
        stepx = rnd.Next(5, 5);
        stepy = rnd.Next(5, 5);
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
        }
    }
    public void ball3()//33333333333333333333333
    {
        
        Graphics g = this.CreateGraphics();
        g.Clear(this.BackColor);
        Random rnd = new Random();
        stepx = rnd.Next(2, 3);
        stepy = rnd.Next(2, 3);
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
        }
    }
    public void ball4()//444444444444444444444444444
    {
        
        Graphics g = this.CreateGraphics();
        g.Clear(this.BackColor);
        Random rnd = new Random();
        stepx = rnd.Next(4, 4);
        stepy = rnd.Next(4, 4);
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
        }
    }
    public void ball5()//55555555555555555555
    {
        
        Graphics g = this.CreateGraphics();
        g.Clear(this.BackColor);
        Random rnd = new Random();
        stepx = rnd.Next(3, 3);
        stepy = rnd.Next(3, 3);
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
        }
    }

    private void pictureBox4_Click(object sender, EventArgs e)
    {
        
    }

    private void panel1_Paint(object sender, PaintEventArgs e)
    {

    }

    private void Score_label_Click(object sender, EventArgs e)
    {

    }

    private void label1_Click(object sender, EventArgs e)
    {

    }

    private void timer1_Tick(object sender, EventArgs e)
    {
        
    }

    private void pictureBox5_Click(object sender, EventArgs e)
    {
        ball.Left += speed_left;
        ball.Top += speed_top;
    }

    private void pictureBox2_Click(object sender, EventArgs e)
    {
        racket1.Left = Cursor.Position.X - (racket1.Width / 2);
        if (ball.Bottom >= racket.Top && ball.Bottom <= racket.Bottom && ball.Left >= racket.Left && ball.Right <= racket.Right)
        {
            speed_top += 2;
            speed_left += 2;
            speed_top = -speed_top;
            points += 1;
            points_lbl.Text = points.ToString();
            Random r = new Random();
            playground.BackColor = Color.FromArgb(r.Next(150, 255), r.Next(150, 255), r.Next(150, 255)); 
           
                if (ball.Left <= playground.Left)
                {
                    speed_left = -speed_left;
                }
                if (ball.Right >= playground.Right)
                {
                    speed_left = -speed_left;
                }    
                if (ball.Top <= playground.Top)
                {
                    speed_top = -speed_top;
                }
                //To Stop The Game When Ball Is Out
                if (ball.Bottom >= playground.Bottom)
                {
                    timer1.Enabled = false;
                    gameover_label.Visible = true;
                }
        }
    }

    private void pictureBox3_Click(object sender, EventArgs e)
    {
        racket2.Left = Cursor.Position.X - (racket2.Width / 2);
    }

    private void pictureBox1_Click(object sender, EventArgs e)
    {
        racket3.Left = Cursor.Position.X - (racket3.Width / 2);
    }

    private void pictureBox4_Click_1(object sender, EventArgs e)
    {

    }






















    }
}
