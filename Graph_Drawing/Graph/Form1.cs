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

namespace Graph
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }

        public void button1_Click(object sender, EventArgs e)
        {
            //Rectangle r = new Rectangle();
            Graphics g = this.CreateGraphics();
            //g.DrawEllipse(Pens.Black, 10, 10, 20, 10);
            //g.DrawLine(Pens.Blue,  20, 20, 100, 100);
            Random r = new Random();
            for (int i = 0; i <= 100; i++)
            {
                Color color = Color.FromArgb(r.Next(1, 254), r.Next(1, 254), r.Next(1, 254));
                SolidBrush sb = new SolidBrush(color);
                g.FillEllipse(sb, r.Next(0, 254), r.Next(0, 254), r.Next(0, 254), r.Next(0, 254));
                
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;//跨執行緒執行
        }

        public void button2_Click(object sender, EventArgs e)
        {
            
            for (int i = 0; i <= 500; i+=100)
            {
                Graphics cir = this.CreateGraphics();
                for(int j = 0; j <= 400; j+=100)
                {
                    cir.FillEllipse(Brushes.Red, i, j, 60, 60);
                }    
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {   
            for (int i = 0; i <= 5; i++) 
            {
                Thread thread1 = new Thread(new ThreadStart(AAA));
                Thread thread2 = new Thread(new ThreadStart(BBB));
            
                thread1.Start();
                thread2.Start();
                thread1.Join();
                thread2.Join();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                this.CreateGraphics().Clear(Form1.ActiveForm.BackColor);
                MessageBox.Show("Clear");
            }
            catch (Exception ex)
            {
               Console.WriteLine(ex.Message);
            }
        }
        public void AAA()
        {
            Thread.Sleep(100);
            Graphics rec = this.CreateGraphics();
            Random r = new Random();
            Color color = Color.FromArgb(r.Next(1, 254), r.Next(1, 254), r.Next(1, 254));
            SolidBrush sb = new SolidBrush(color);
            rec.FillRectangle(sb, r.Next(0, 254), r.Next(0, 254), r.Next(0, 254), r.Next(0, 254));
        }

        public void BBB()
        {
            Thread.Sleep(1000);
            Graphics g = this.CreateGraphics();
            Random r = new Random();
            Color color = Color.FromArgb(r.Next(1, 254), r.Next(1, 254), r.Next(1, 254));
            SolidBrush sb = new SolidBrush(color);
            g.FillEllipse(sb, r.Next(0, 254), r.Next(0, 254), r.Next(0, 254), r.Next(0, 254));         
        }
        
    }
}
