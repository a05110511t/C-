using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.IO.Ports;
using System.Threading;
using System.Windows.Forms;

using NeuroSky.ThinkGear;
using NeuroSky.ThinkGear.Algorithms;


namespace ThinkGear_pratice
{
    public partial class Form1 : Form
    {
        static Connector connector;
        int newX = 0, newY = 50, oldX = 0, oldY = 0, vol = 0, step = 20;
        int baseY = 100;



        Graphics myGraphic;
        Color myBackColor, myForeColor, myWhiteColor;
        SolidBrush myBrush, myWhite;
        Pen myPen;
        Random rnd;
        int ATT, MED, DEL, EYE;
        

        public Form1()
        {
            InitializeComponent();

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

            

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            myGraphic = this.CreateGraphics();
            myBackColor = Color.FromArgb(30, 0, 0, 0);
            myBrush = new SolidBrush(myBackColor);
            myForeColor = Color.FromArgb(255, 215, 0);
            myPen = new Pen(myForeColor);
            rnd = new Random();
            timer1.Interval = 100;
            timer1.Enabled = true;


            myWhiteColor = Color.FromArgb(30, 0, 0, 0);
            myWhite = new SolidBrush(Color.White);
            
        }


        // Called when a device is connected 

        private void OnDeviceConnected(object sender, EventArgs e) {

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

                    this.richTextBox1.Text = "Poor Signal:" + tgParser.ParsedData[i]["PoorSignal"] + "\n";
                    
                }


                if (tgParser.ParsedData[i].ContainsKey("Attention"))
                {

                    //Console.WriteLine("Att Value:" + tgParser.ParsedData[i]["Attention"]);
                    this.richTextBox1.Text += "Att Value:" + tgParser.ParsedData[i]["Attention"] + "\n";
                    ATT = Convert.ToInt32(tgParser.ParsedData[i]["Attention"]);
                    
                }


                if (tgParser.ParsedData[i].ContainsKey("Meditation"))
                {

                    //Console.WriteLine("Med Value:" + tgParser.ParsedData[i]["Meditation"]);
                    this.richTextBox1.Text += "Med Value:" + tgParser.ParsedData[i]["Meditation"] + "\n";
                    MED = Convert.ToInt32(tgParser.ParsedData[i]["Meditation"]);
                }


                if (tgParser.ParsedData[i].ContainsKey("EegPowerDelta"))
                {

                    //Console.WriteLine("Delta: " + tgParser.ParsedData[i]["EegPowerDelta"]);
                    this.richTextBox1.Text += "Delta: " + tgParser.ParsedData[i]["EegPowerDelta"] + "\n";
                    DEL = Convert.ToInt32(tgParser.ParsedData[i]["EegPowerDelta"]);
                }

                if (tgParser.ParsedData[i].ContainsKey("BlinkStrength"))
                {
                    //Console.WriteLine("Eyeblink " + tgParser.ParsedData[i]["BlinkStrength"]);
                    this.richTextBox1.Text += "Eyeblink " + tgParser.ParsedData[i]["BlinkStrength"] + "\n";
                    EYE = Convert.ToInt32(tgParser.ParsedData[i]["BlinkStrength"]);
                }


            }
        }

        


        private void timer1_Tick_1(object sender, EventArgs e)
        {
            newY = baseY - ATT;
            myGraphic.FillRectangle(myBrush, this.ClientRectangle);//折線
            myGraphic.DrawLine(Pens.Blue, 0, baseY, this.ClientRectangle.Width, baseY);
            myGraphic.FillEllipse(Brushes.Blue, newX - 10, newY - 10, 20, 20);
            myGraphic.DrawLine(Pens.Blue, newX, newY, oldX, oldY);

            
            myGraphic.FillRectangle(myWhite, new Rectangle(10, baseY - ATT + 325, 50, 600));//長條 ATT
            myGraphic.FillRectangle(myWhite, new Rectangle(70, baseY - MED + 325, 50, 600));//長條 MED
            myGraphic.FillRectangle(myWhite, new Rectangle(130, baseY - DEL/10000 + 325, 50, 600));//長條 DEL
            myGraphic.FillRectangle(myWhite, new Rectangle(190, baseY - EYE + 325, 50, 600));//長條 EYE

            
            
            //
            oldX = newX;
            oldY = newY;
            newX = newX + step;
            if (newX >= this.ClientRectangle.Width)//超過邊緣回到左邊繼續
            {
                newX = 0;
                oldX = 0;
            }


            
            

 

        }
    }
}

