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
using System.Timers;

using NeuroSky.ThinkGear;
using NeuroSky.ThinkGear.Algorithms;

namespace Arknoid_pratice_2
{
    public partial class Form1 : Form
    {
        int drops = 0;
        int points = 0;
        int times = 0;
        int t=0;
        Random rnd = new Random();
        System.Windows.Forms.Timer timer;

        static Connector connector;
        int ATT, MED, DEL, EYE;

        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;

            // Initialize a new Connector and add event handlers
            CheckForIllegalCrossThreadCalls = false;
            connector = new Connector();
            connector.DeviceConnected += new EventHandler(OnDeviceConnected);
            connector.DeviceConnectFail += new EventHandler(OnDeviceFail);
            connector.DeviceValidating += new EventHandler(OnDeviceValidating);

            // Scan for devices across COM ports
            // The COM port named will be the first COM port that is checked.
            connector.ConnectScan("COM40");

            // Blink detection needs to be manually turned on
            connector.setBlinkDetectionEnabled(true);
            //Thread.Sleep(450000);
            this.DoubleBuffered = true;
        }

        // Called when a device is connected 

        private void OnDeviceConnected(object sender, EventArgs e)
        {

            Connector.DeviceEventArgs de = (Connector.DeviceEventArgs)e;

            this.label3.Text += "Device found on: " + de.Device.PortName;
            de.Device.DataReceived += Device_DataReceived;

        }

        // Called when scanning fails

        private void OnDeviceFail(object sender, EventArgs e)
        {

            Console.WriteLine("No devices found! :(");

        }



        // Called when each port is being validated

        private void OnDeviceValidating(object sender, EventArgs e)
        {

            Console.WriteLine("Validating: ");

        }


        // Called when data is received from a device
        private void Device_DataReceived(object sender, EventArgs e)
        {
            //Device d = (Device)sender;

            Device.DataEventArgs de = (Device.DataEventArgs)e;
            NeuroSky.ThinkGear.DataRow[] tempDataRowArray = de.DataRowArray;

            TGParser tgParser = new TGParser();//解析
            tgParser.Read(de.DataRowArray);



            /* Loops through the newly parsed data of the connected headset*/
            // The comments below indicate and can be used to print out the different data outputs. 

            for (int i = 0; i < tgParser.ParsedData.Length; i++)
            {

                if (tgParser.ParsedData[i].ContainsKey("Raw"))
                {

                    //Console.WriteLine("Raw Value:" + tgParser.ParsedData[i]["Raw"]);
                    //this.richTextBox1.Text += "Raw Value:" + tgParser.ParsedData[i]["Raw"];


                }

                if (tgParser.ParsedData[i].ContainsKey("PoorSignal"))
                {

                    //The following line prints the Time associated with the parsed data
                    //Console.WriteLine("Time:" + tgParser.ParsedData[i]["Time"]);

                    //A Poor Signal value of 0 indicates that your headset is fitting properly
                    //Console.WriteLine("Poor Signal:" + tgParser.ParsedData[i]["PoorSignal"]);

                    //this.richTextBox1.Text = "Poor Signal:" + tgParser.ParsedData[i]["PoorSignal"] + "\n";

                }


                if (tgParser.ParsedData[i].ContainsKey("Attention"))
                {

                    //Console.WriteLine("Att Value:" + tgParser.ParsedData[i]["Attention"]);
                    //this.richTextBox1.Text += "Att Value:" + tgParser.ParsedData[i]["Attention"] + "\n";
                    //ATT = Convert.ToInt32(tgParser.ParsedData[i]["Attention"]);

                }


                if (tgParser.ParsedData[i].ContainsKey("Meditation"))
                {

                    //Console.WriteLine("Med Value:" + tgParser.ParsedData[i]["Meditation"]);
                    //this.richTextBox1.Text += "Med Value:" + tgParser.ParsedData[i]["Meditation"] + "\n";
                    //MED = Convert.ToInt32(tgParser.ParsedData[i]["Meditation"]);
                }


                if (tgParser.ParsedData[i].ContainsKey("EegPowerDelta"))
                {

                    //Console.WriteLine("Delta: " + tgParser.ParsedData[i]["EegPowerDelta"]);
                    //this.richTextBox1.Text += "Delta: " + tgParser.ParsedData[i]["EegPowerDelta"] + "\n";
                    DEL = Convert.ToInt32(tgParser.ParsedData[i]["EegPowerDelta"]);
                    if (DEL > 0)
                        move_board.Left += 25;
                }

                if (tgParser.ParsedData[i].ContainsKey("BlinkStrength"))
                {
                    //Console.WriteLine("Eyeblink " + tgParser.ParsedData[i]["BlinkStrength"]);
                    //this.richTextBox1.Text += "Eyeblink " + tgParser.ParsedData[i]["BlinkStrength"] + "\n";
                    EYE = Convert.ToInt32(tgParser.ParsedData[i]["BlinkStrength"]);
                    if (EYE > 0)
                        move_board.Left -= 40;
                }


            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.DoEvents();
            Application.EnableVisualStyles();
            timer = new System.Windows.Forms.Timer();
            timer.Interval = 1000;//times gap
            timer.Tick += new EventHandler(timer_TickTock);
            timer.Enabled = true;
            timer.Start();


            Thread thread1 = new Thread(new ThreadStart(ball));
            thread1.Start();


            /*Thread thread2 = new Thread(new ThreadStart(ball2));
            thread2.Start();


            Thread thread3 = new Thread(new ThreadStart(ball3));
            thread3.Start();


            Thread thread4 = new Thread(new ThreadStart(ball4));
            thread4.Start();


            Thread thread5 = new Thread(new ThreadStart(ball5));
            thread5.Start();*/


            

            /*if(drops > 4)//>=five ball drop gg
            {
                MessageBox.Show("GAME OVER!!");
                timer.Dispose();
                timer.Enabled = false;
                timer.Stop();//can't use.........
                System.Threading.Thread.Sleep(5000);
            }*/

        }

        public void ball()
        {
            int x = rnd.Next(100, 500);
            int y = rnd.Next(100, 500);

            int stepx = 1;
            int stepy = 1;
            

            while(true)
            {
                Graphics g = this.CreateGraphics();
                g.Clear(this.BackColor);
                g.FillEllipse(Brushes.Red, x, y, 15, 15);
                x += stepx;
                y += stepy;

                //time
                //times += 1;
                //timer_label.Text = times.ToString();

                if (x > this.ClientRectangle.Width)
                {
                    stepx = -1;
                }
                if (0 > x)
                {
                    stepx = 1;
                }
                if (y > this.ClientRectangle.Height)
                {
                    g.Clear(BackColor);
                    drops += 1;
                }
                if (0 > y)
                {
                    stepy = 1;
                }
                //blue1
                if (y == blue1.Top && y < blue1.Bottom && x > blue1.Left && x < blue1.Right)
                {

                    stepy = -stepy;
                }
                if (y > blue1.Top && y == blue1.Bottom && x > blue1.Left && x < blue1.Right)
                {

                    stepy = -stepy;
                }
                if (y > blue1.Top && y < blue1.Bottom && x == blue1.Left && x < blue1.Right)
                {

                    stepx = -stepx;
                }
                if (y > blue1.Top && y < blue1.Bottom && x > blue1.Left && x == blue1.Right)
                {

                    stepx = -stepx;
                }
                //blue2
                if (y == blue2.Top && y < blue2.Bottom && x > blue2.Left && x < blue2.Right)
                {

                    stepy = -stepy;
                }
                if (y > blue2.Top && y == blue2.Bottom && x > blue2.Left && x < blue2.Right)
                {

                    stepy = -stepy;
                }
                if (y > blue2.Top && y < blue2.Bottom && x == blue2.Left && x < blue2.Right)
                {

                    stepx = -stepx;
                }
                if (y > blue2.Top && y < blue2.Bottom && x > blue2.Left && x == blue2.Right)
                {

                    stepx = -stepx;
                }
                //blue3
                if (y == blue3.Top && y < blue3.Bottom && x > blue3.Left && x < blue3.Right)
                {

                    stepy = -stepy;
                }
                if (y > blue3.Top && y == blue3.Bottom && x > blue3.Left && x < blue3.Right)
                {

                    stepy = -stepy;
                }
                if (y > blue3.Top && y < blue3.Bottom && x == blue3.Left && x < blue3.Right)
                {

                    stepx = -stepx;
                }
                if (y > blue3.Top && y < blue3.Bottom && x > blue3.Left && x == blue3.Right)
                {

                    stepx = -stepx;
                }

                //move_board
                if (y == move_board.Top && y < move_board.Bottom && x > move_board.Left && x < move_board.Right)
                {

                    stepy = -stepy;
                    points += 1;
                    points_label.Text = points.ToString();
                }
                if (y > move_board.Top && y == move_board.Bottom && x > move_board.Left && x < move_board.Right)
                {

                    stepy = -stepy;
                    points += 1;
                    points_label.Text = points.ToString();
                }
                if (y > move_board.Top && y < move_board.Bottom && x == move_board.Left && x < move_board.Right)
                {

                    stepx = -stepx;
                    points += 1;
                    points_label.Text = points.ToString();
                }
                if (y > move_board.Top && y < move_board.Bottom && x > move_board.Left && x == move_board.Right)
                {

                    stepx = -stepx;
                    points += 1;
                    points_label.Text = points.ToString();
                }
                
                

                Thread.Sleep(30);
            }
        }

        //ball2
        /*public void ball2()
        {
            int x = rnd.Next(100, 500);
            int y = rnd.Next(100, 500);

            int dx = 1;
            int dy = 1;


            while (true)
            {
                Graphics g = this.CreateGraphics();
                g.Clear(this.BackColor);
                g.FillEllipse(Brushes.Red, x, y, 15, 15);
                x += dx;
                y += dy;

                //time
                //times += 1;
                //timer_label.Text = times.ToString();

                if (x > this.ClientRectangle.Width)
                {
                    dx = -1;
                }
                if (0 > x)
                {
                    dx = 1;
                }
                if (y > this.ClientRectangle.Height)
                {
                    g.Clear(BackColor);
                    drops += 1;
                }
                if (0 > y)
                {
                    dy = 1;
                }
                //blue1
                if (y == blue1.Top && y < blue1.Bottom && x > blue1.Left && x < blue1.Right)
                {

                    dy = -dy;
                }
                if (y > blue1.Top && y == blue1.Bottom && x > blue1.Left && x < blue1.Right)
                {

                    dy = -dy;
                }
                if (y > blue1.Top && y < blue1.Bottom && x == blue1.Left && x < blue1.Right)
                {

                    dx = -dx;
                }
                if (y > blue1.Top && y < blue1.Bottom && x > blue1.Left && x == blue1.Right)
                {

                    dx = -dx;
                }
                //blue2
                if (y == blue2.Top && y < blue2.Bottom && x > blue2.Left && x < blue2.Right)
                {

                    dy = -dy;
                }
                if (y > blue2.Top && y == blue2.Bottom && x > blue2.Left && x < blue2.Right)
                {

                    dy = -dy;
                }
                if (y > blue2.Top && y < blue2.Bottom && x == blue2.Left && x < blue2.Right)
                {

                    dx = -dx;
                }
                if (y > blue2.Top && y < blue2.Bottom && x > blue2.Left && x == blue2.Right)
                {

                    dx = -dx;
                }
                //blue3
                if (y == blue3.Top && y < blue3.Bottom && x > blue3.Left && x < blue3.Right)
                {

                    dy = -dy;
                }
                if (y > blue3.Top && y == blue3.Bottom && x > blue3.Left && x < blue3.Right)
                {

                    dy = -dy;
                }
                if (y > blue3.Top && y < blue3.Bottom && x == blue3.Left && x < blue3.Right)
                {

                    dx = -dx;
                }
                if (y > blue3.Top && y < blue3.Bottom && x > blue3.Left && x == blue3.Right)
                {

                    dx = -dx;
                }

                //move_board
                if (y == move_board.Top && y < move_board.Bottom && x > move_board.Left && x < move_board.Right)
                {

                    dy = -dy;
                    points += 1;
                    points_label.Text = points.ToString();
                }
                if (y > move_board.Top && y == move_board.Bottom && x > move_board.Left && x < move_board.Right)
                {

                    dy = -dy;
                    points += 1;
                    points_label.Text = points.ToString();
                }
                if (y > move_board.Top && y < move_board.Bottom && x == move_board.Left && x < move_board.Right)
                {

                    dx = -dx;
                    points += 1;
                    points_label.Text = points.ToString();
                }
                if (y > move_board.Top && y < move_board.Bottom && x > move_board.Left && x == move_board.Right)
                {

                    dx = -dx;
                    points += 1;
                    points_label.Text = points.ToString();
                }



                Thread.Sleep(15);
            }
        }
        //ball3
        public void ball3()
        {
            int x = rnd.Next(100, 500);
            int y = rnd.Next(100, 500);

            int dx = 1;
            int dy = 1;


            while (true)
            {
                Graphics g = this.CreateGraphics();
                g.Clear(this.BackColor);
                g.FillEllipse(Brushes.Red, x, y, 15, 15);
                x += dx;
                y += dy;

                //time
                //times += 1;
                //timer_label.Text = times.ToString();

                if (x > this.ClientRectangle.Width)
                {
                    dx = -1;
                }
                if (0 > x)
                {
                    dx = 1;
                }
                if (y > this.ClientRectangle.Height)
                {
                    g.Clear(BackColor);
                    drops += 1;
                }
                if (0 > y)
                {
                    dy = 1;
                }
                //blue1
                if (y == blue1.Top && y < blue1.Bottom && x > blue1.Left && x < blue1.Right)
                {

                    dy = -dy;
                }
                if (y > blue1.Top && y == blue1.Bottom && x > blue1.Left && x < blue1.Right)
                {

                    dy = -dy;
                }
                if (y > blue1.Top && y < blue1.Bottom && x == blue1.Left && x < blue1.Right)
                {

                    dx = -dx;
                }
                if (y > blue1.Top && y < blue1.Bottom && x > blue1.Left && x == blue1.Right)
                {

                    dx = -dx;
                }
                //blue2
                if (y == blue2.Top && y < blue2.Bottom && x > blue2.Left && x < blue2.Right)
                {

                    dy = -dy;
                }
                if (y > blue2.Top && y == blue2.Bottom && x > blue2.Left && x < blue2.Right)
                {

                    dy = -dy;
                }
                if (y > blue2.Top && y < blue2.Bottom && x == blue2.Left && x < blue2.Right)
                {

                    dx = -dx;
                }
                if (y > blue2.Top && y < blue2.Bottom && x > blue2.Left && x == blue2.Right)
                {

                    dx = -dx;
                }
                //blue3
                if (y == blue3.Top && y < blue3.Bottom && x > blue3.Left && x < blue3.Right)
                {

                    dy = -dy;
                }
                if (y > blue3.Top && y == blue3.Bottom && x > blue3.Left && x < blue3.Right)
                {

                    dy = -dy;
                }
                if (y > blue3.Top && y < blue3.Bottom && x == blue3.Left && x < blue3.Right)
                {

                    dx = -dx;
                }
                if (y > blue3.Top && y < blue3.Bottom && x > blue3.Left && x == blue3.Right)
                {

                    dx = -dx;
                }

                //move_board
                if (y == move_board.Top && y < move_board.Bottom && x > move_board.Left && x < move_board.Right)
                {

                    dy = -dy;
                    points += 1;
                    points_label.Text = points.ToString();
                }
                if (y > move_board.Top && y == move_board.Bottom && x > move_board.Left && x < move_board.Right)
                {

                    dy = -dy;
                    points += 1;
                    points_label.Text = points.ToString();
                }
                if (y > move_board.Top && y < move_board.Bottom && x == move_board.Left && x < move_board.Right)
                {

                    dx = -dx;
                    points += 1;
                    points_label.Text = points.ToString();
                }
                if (y > move_board.Top && y < move_board.Bottom && x > move_board.Left && x == move_board.Right)
                {

                    dx = -dx;
                    points += 1;
                    points_label.Text = points.ToString();
                }

                Thread.Sleep(15);
            }
        }
        //ball4
        public void ball4()
        {
            int x = rnd.Next(100, 500);
            int y = rnd.Next(100, 500);

            int dx = 1;
            int dy = 1;


            while (true)
            {
                Graphics g = this.CreateGraphics();
                g.Clear(this.BackColor);
                g.FillEllipse(Brushes.Red, x, y, 15, 15);
                x += dx;
                y += dy;

                //time
                //times += 1;
                //timer_label.Text = times.ToString();

                if (x > this.ClientRectangle.Width)
                {
                    dx = -1;
                }
                if (0 > x)
                {
                    dx = 1;
                }
                if (y > this.ClientRectangle.Height)
                {
                    g.Clear(BackColor);
                    drops += 1;
                }
                if (0 > y)
                {
                    dy = 1;
                }
                //blue1
                if (y == blue1.Top && y < blue1.Bottom && x > blue1.Left && x < blue1.Right)
                {

                    dy = -dy;
                }
                if (y > blue1.Top && y == blue1.Bottom && x > blue1.Left && x < blue1.Right)
                {

                    dy = -dy;
                }
                if (y > blue1.Top && y < blue1.Bottom && x == blue1.Left && x < blue1.Right)
                {

                    dx = -dx;
                }
                if (y > blue1.Top && y < blue1.Bottom && x > blue1.Left && x == blue1.Right)
                {

                    dx = -dx;
                }
                //blue2
                if (y == blue2.Top && y < blue2.Bottom && x > blue2.Left && x < blue2.Right)
                {

                    dy = -dy;
                }
                if (y > blue2.Top && y == blue2.Bottom && x > blue2.Left && x < blue2.Right)
                {

                    dy = -dy;
                }
                if (y > blue2.Top && y < blue2.Bottom && x == blue2.Left && x < blue2.Right)
                {

                    dx = -dx;
                }
                if (y > blue2.Top && y < blue2.Bottom && x > blue2.Left && x == blue2.Right)
                {

                    dx = -dx;
                }
                //blue3
                if (y == blue3.Top && y < blue3.Bottom && x > blue3.Left && x < blue3.Right)
                {

                    dy = -dy;
                }
                if (y > blue3.Top && y == blue3.Bottom && x > blue3.Left && x < blue3.Right)
                {

                    dy = -dy;
                }
                if (y > blue3.Top && y < blue3.Bottom && x == blue3.Left && x < blue3.Right)
                {

                    dx = -dx;
                }
                if (y > blue3.Top && y < blue3.Bottom && x > blue3.Left && x == blue3.Right)
                {

                    dx = -dx;
                }

                //move_board
                if (y == move_board.Top && y < move_board.Bottom && x > move_board.Left && x < move_board.Right)
                {

                    dy = -dy;
                    points += 1;
                    points_label.Text = points.ToString();
                }
                if (y > move_board.Top && y == move_board.Bottom && x > move_board.Left && x < move_board.Right)
                {

                    dy = -dy;
                    points += 1;
                    points_label.Text = points.ToString();
                }
                if (y > move_board.Top && y < move_board.Bottom && x == move_board.Left && x < move_board.Right)
                {

                    dx = -dx;
                    points += 1;
                    points_label.Text = points.ToString();
                }
                if (y > move_board.Top && y < move_board.Bottom && x > move_board.Left && x == move_board.Right)
                {

                    dx = -dx;
                    points += 1;
                    points_label.Text = points.ToString();
                }



                Thread.Sleep(15);
            }
        }
        //ball5
        public void ball5()
        {
            int x = rnd.Next(100, 500);
            int y = rnd.Next(100, 500);

            int dx = 1;
            int dy = 1;


            while (true)
            {
                Graphics g = this.CreateGraphics();
                g.Clear(this.BackColor);
                g.FillEllipse(Brushes.Red, x, y, 15, 15);
                x += dx;
                y += dy;

                //time
                //times += 1;
                //timer_label.Text = times.ToString();

                if (x > this.ClientRectangle.Width)
                {
                    dx = -1;
                }
                if (0 > x)
                {
                    dx = 1;
                }
                if (y > this.ClientRectangle.Height)
                {
                    g.Clear(BackColor);
                    drops += 1;
                }
                if (0 > y)
                {
                    dy = 1;
                }
                //blue1
                if (y == blue1.Top && y < blue1.Bottom && x > blue1.Left && x < blue1.Right)
                {

                    dy = -dy;
                }
                if (y > blue1.Top && y == blue1.Bottom && x > blue1.Left && x < blue1.Right)
                {

                    dy = -dy;
                }
                if (y > blue1.Top && y < blue1.Bottom && x == blue1.Left && x < blue1.Right)
                {

                    dx = -dx;
                }
                if (y > blue1.Top && y < blue1.Bottom && x > blue1.Left && x == blue1.Right)
                {

                    dx = -dx;
                }
                //blue2
                if (y == blue2.Top && y < blue2.Bottom && x > blue2.Left && x < blue2.Right)
                {

                    dy = -dy;
                }
                if (y > blue2.Top && y == blue2.Bottom && x > blue2.Left && x < blue2.Right)
                {

                    dy = -dy;
                }
                if (y > blue2.Top && y < blue2.Bottom && x == blue2.Left && x < blue2.Right)
                {

                    dx = -dx;
                }
                if (y > blue2.Top && y < blue2.Bottom && x > blue2.Left && x == blue2.Right)
                {

                    dx = -dx;
                }
                //blue3
                if (y == blue3.Top && y < blue3.Bottom && x > blue3.Left && x < blue3.Right)
                {

                    dy = -dy;
                }
                if (y > blue3.Top && y == blue3.Bottom && x > blue3.Left && x < blue3.Right)
                {

                    dy = -dy;
                }
                if (y > blue3.Top && y < blue3.Bottom && x == blue3.Left && x < blue3.Right)
                {

                    dx = -dx;
                }
                if (y > blue3.Top && y < blue3.Bottom && x > blue3.Left && x == blue3.Right)
                {

                    dx = -dx;
                }

                //move_board
                if (y == move_board.Top && y < move_board.Bottom && x > move_board.Left && x < move_board.Right)
                {

                    dy = -dy;
                    points += 1;
                    points_label.Text = points.ToString();
                }
                if (y > move_board.Top && y == move_board.Bottom && x > move_board.Left && x < move_board.Right)
                {

                    dy = -dy;
                    points += 1;
                    points_label.Text = points.ToString();
                }
                if (y > move_board.Top && y < move_board.Bottom && x == move_board.Left && x < move_board.Right)
                {

                    dx = -dx;
                    points += 1;
                    points_label.Text = points.ToString();
                }
                if (y > move_board.Top && y < move_board.Bottom && x > move_board.Left && x == move_board.Right)
                {

                    dx = -dx;
                    points += 1;
                    points_label.Text = points.ToString();
                }



                Thread.Sleep(15);
            }
        }*/

        void timer_TickTock(object sender, EventArgs e)
        {
            timer_label.Text =  times.ToString();
            times++;
            t = times;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            Application.DoEvents();
            if (e.KeyCode == Keys.A)
                move_board.Left -= 15;
            if (e.KeyCode == Keys.D)
                move_board.Left += 15;
        }

    }
}
