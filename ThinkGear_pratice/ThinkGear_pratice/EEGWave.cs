using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using NeuroSky.ThinkGear;
using NeuroSky.ThinkGear.Algorithms;

namespace ThinkGear_pratice
{
    public partial class EEGWave : Form
    {
        int newX = 0, newY = 50, oldX = 0, oldY = 0, vol = 0, step = 20;
        int baseY = 100;
        Graphics myGraphic;
        Color myBackColor, myForeColor;
        SolidBrush myBrush;
        Pen myPen;
        Random rnd;


        public EEGWave()
        {
            InitializeComponent();
            
        }

        private void EEGWave_Load(object sender, EventArgs e)
        {
            myGraphic = this.CreateGraphics();
            myBackColor = Color.FromArgb(30, 0, 0, 0);
            myBrush = new SolidBrush(myBackColor);
            myForeColor = Color.FromArgb(255, 215, 0);
            myPen = new Pen(myForeColor);
            rnd = new Random();
            timer1.Interval = 100;
            timer1.Enabled = true;


        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            newY =baseY-rnd.Next(-100, 100);//value
            myGraphic.FillRectangle(myBrush,this.ClientRectangle);
            myGraphic.DrawLine(Pens.Blue, 0, baseY, this.ClientRectangle.Width, baseY);
            myGraphic.FillEllipse(Brushes.Blue, newX-10, newY-10, 20, 20);
            myGraphic.DrawLine(Pens.Blue, newX, newY, oldX, oldY);
            oldX = newX;
            oldY = newY; 
            newX = newX + step;
            if (newX >= this.ClientRectangle.Width)//若超出視窗就重頭開始畫
            {
                newX = 0;
                oldX = 0;
            }
        }

    }
}
