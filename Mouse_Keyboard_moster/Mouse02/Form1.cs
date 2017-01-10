using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MouseKeyboardActivityMonitor;
using MouseKeyboardActivityMonitor.WinApi;//+
using WindowsInput;//+
using System.Runtime.InteropServices;//+//使用外部動態函式庫，需要參考這個物件
using System.Threading;//+
using System.IO;

namespace Mouse02
{
    public partial class Form1 : Form
    {
        bool record;
        string mouseupdown;
        string keyupdownpress;
        int newX = 0, newY = 0;
        string undefined;

        // First, a MouseHookListener object must exist in the class
        private MouseHookListener m_mouseListener;//監聽滑鼠
        private KeyboardHookListener k_keyboardListener;//監聽鍵盤
        int counter = 0;

        StreamWriter log = new StreamWriter("log.txt");//create file
        private static int ScrollValue;


        public Form1()
        {
            InitializeComponent();

            //
            /*this.MouseMove += Form1_MouseMove;
            this.MouseDown += Form1_MouseDown;
            this.MouseUp += Form1_MouseUp;*/
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Application.DoEvents();
            Activate();
        }



        [DllImport("user32.dll")]
        static extern void mouse_event(int dwFlags, int dx, int dy, int dwData, int dwExtraInfo);

        [Flags]
        public enum MouseEventFlags
        {
            LEFTDOWN = 0x00000002,
            LEFTUP = 0x00000004,
            MIDDLEDOWN = 0x00000020,
            MIDDLEUP = 0x00000040,
            MOVE = 0x00000001,
            ABSOLUTE = 0x00008000,
            RIGHTDOWN = 0x00000008,
            RIGHTUP = 0x00000010,
            WHEEL = 0x00000800
        }

        public static void ClickDOWN(int x, int y)
        {
            Cursor.Position = new System.Drawing.Point(x, y);
            mouse_event((int)(MouseEventFlags.LEFTDOWN), 0, 0, 0, 0);
        }

        public static void LeftClick(int x, int y)
        {
            Cursor.Position = new System.Drawing.Point(x, y);
            mouse_event((int)(MouseEventFlags.LEFTDOWN), 0, 0, 0, 0);
            mouse_event((int)(MouseEventFlags.LEFTUP), 0, 0, 0, 0);
        }

        public static void ClickUP(int x, int y)
        {
            Cursor.Position = new System.Drawing.Point(x, y);
            mouse_event((int)(MouseEventFlags.LEFTUP), 0, 0, 0, 0);
        }

        public static void Move(int x, int y)
        {
            Cursor.Position = new System.Drawing.Point(x, y);
            mouse_event((int)(MouseEventFlags.MOVE), 0, 0, 0, 0);
        }

        public static void Wheel(int ScrollValue)
        {

            mouse_event((int)(MouseEventFlags.WHEEL), 0, 0, ScrollValue, 0);

        }

        // Subroutine for activating the hook
        public void Activate()
        {
            // Note: for an application hook, use the AppHooker class instead
            m_mouseListener = new MouseHookListener(new GlobalHooker());
            k_keyboardListener = new KeyboardHookListener(new GlobalHooker());

            // The listener is not enabled by default
            m_mouseListener.Enabled = true;
            k_keyboardListener.Enabled = true;
            // Set the event handler
            // recommended to use the Extended handlers, which allow input suppression among other additional information
            m_mouseListener.MouseDownExt += MouseListener_MouseDownExt;//mousedown
            m_mouseListener.MouseMoveExt += m_mouseListener_MouseMoveExt;//mousemove
            m_mouseListener.MouseUp += m_mouseListener_MouseUpExt;

            k_keyboardListener.KeyPress += k_keyboardListener_KeyPress;//按
            k_keyboardListener.KeyDown += k_keyboardListener_KeyDown;//壓住
            k_keyboardListener.KeyUp += k_keyboardListener_KeyUp;//放開
        }

        //keyboard
        void k_keyboardListener_KeyUp(object sender, KeyEventArgs e)
        {
            richTextBox2.Text += (string.Format("\nKeydown :{0} ;", e.KeyValue.ToString()));
            if (record == true)
            {
                //timestamp
                long myTicks = DateTime.Now.Ticks;
                DateTime dtime = new DateTime(myTicks);
                keyupdownpress = "KeyUp";
                log.WriteLine(myTicks.ToString() + "," + (string.Format("{0},{1}", 0, 0) + "," + "Mouse" + "," + keyupdownpress + "," + (string.Format("{0}", e.KeyCode.ToString()))));

            }
        }

        void k_keyboardListener_KeyDown(object sender, KeyEventArgs e)
        {
            richTextBox2.Text += (string.Format("\nKeydown :{0} ;", e.KeyCode.ToString()));
            if (record == true)
            {
                //timestamp
                long myTicks = DateTime.Now.Ticks;
                DateTime dtime = new DateTime(myTicks);
                keyupdownpress = "KeyDown";
                log.WriteLine(myTicks.ToString() + "," + (string.Format("{0},{1}", 0, 0) + "," + "Mouse" + "," + keyupdownpress + "," + (string.Format("{0}", e.KeyCode.ToString()))));

            }
        }

        void k_keyboardListener_KeyPress(object sender, KeyPressEventArgs e)
        {
            richTextBox2.Text += (string.Format("\nKeypress :{0} ;", e.KeyChar.ToString()));
            if (record == true)
            {
                //timestamp
                long myTicks = DateTime.Now.Ticks;
                DateTime dtime = new DateTime(myTicks);
                keyupdownpress = "KeyPress";
                //log.WriteLine(myTicks.ToString() + "," + (string.Format("{0},{1}", 0, 0) + "," + "Mouse" + "," + keyupdownpress + "," + (string.Format("{0}", e.KeyChar.ToString()))));

            }
        }

        //mouse
        void m_mouseListener_MouseMoveExt(object sender, MouseEventExtArgs e)//mousemove
        {
            richTextBox1.Text = (string.Format("MouseMove: X:{0},{1}; \t System Timestamp: \t{1}", e.X, e.Y, e.Timestamp));
            if (record == true)
            {
                //timestamp
                long myTicks = DateTime.Now.Ticks;
                DateTime dtime = new DateTime(myTicks);
                mouseupdown = "MouseMove";
                log.WriteLine(myTicks.ToString() + "," + (string.Format("{0},{1}", e.X, e.Y) + "," + mouseupdown + ", " + "mouse1" + ", " + "mouse2"));

            }
        }

        void m_mouseListener_MouseUpExt(object sender, MouseEventArgs e)
        {

            if (record == true)
            {
                //timestamp
                long myTicks = DateTime.Now.Ticks;
                DateTime dtime = new DateTime(myTicks);
                mouseupdown = "MouseUp";
                log.WriteLine(myTicks.ToString() + "," + (string.Format("{0},{1}", e.X, e.Y) + "," + mouseupdown + ", " + "mouse1" + ", " + "mouse2"));
            }
        }

        public void Deactivate()
        {
            m_mouseListener.Dispose();
            k_keyboardListener.Dispose();
        }

        private void MouseListener_MouseDownExt(object sender, MouseEventExtArgs e)//mousedown
        {
            // log the mouse click
            counter++;
            if (counter % 10 == 9)
                richTextBox1.Text = "";
            richTextBox1.Text += (string.Format("MouseDown: \t{0}; \t System Timestamp: \t{1}", e.Button, e.Timestamp));

            if (record == true)
            {
                //timestamp
                long myTicks = DateTime.Now.Ticks;
                DateTime dtime = new DateTime(myTicks);

                if (e.IsMouseKeyDown == true)
                {
                    mouseupdown = "MouseDownDown";
                }
                log.WriteLine(myTicks.ToString() + "," + (string.Format("{0},{1}", e.X, e.Y) + "," + mouseupdown + ", " + "mouse1" + ", " + "mouse2"));




            }



            // uncommenting the following line with suppress a middle mouse button click
            // if (e.Buttons == MouseButtons.Middle) { e.Handled = true; }
        }

        private void button1_Click(object sender, EventArgs e)//自動
        {
            //richTextBox3.Focus();//取得焦點
            Thread.Sleep(2000);
            LeftClick(513, 875);//點選當前小畫家
            Thread.Sleep(2000);
            LeftClick(5, 154);//左上點一點
            /*Thread.Sleep(2000);
            //畫畫
            LeftClick(113, 172);
            Thread.Sleep(2000);*/

            //ShoutHello();


        }

        public void ShoutHello()
        {
            // Simulate each key stroke
            InputSimulator.SimulateKeyDown(VirtualKeyCode.SHIFT);
            InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_H);
            InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_E);
            InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_L);
            InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_L);
            InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_O);
            InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_1);
            InputSimulator.SimulateKeyUp(VirtualKeyCode.SHIFT);

            // Alternatively you can simulate text entry to acheive the same end result
            InputSimulator.SimulateTextEntry("HELLO!");
        }

        private void button2_Click(object sender, EventArgs e)//
        {
            LeftClick(211, 888);//點選開始列視窗(當前為高鐵訂票頁面)
            Thread.Sleep(1000);
            LeftClick(246, 462);//出發
            Thread.Sleep(1000);
            LeftClick(239, 592);//選台中
            Thread.Sleep(1000);
            LeftClick(241, 495);//到達
            Thread.Sleep(1000);
            LeftClick(243, 535);//選台北
            Thread.Sleep(1000);
            LeftClick(652, 484);//立即查詢
            Thread.Sleep(3000);
            //滾輪往下往上
            Wheel(-500);//下
            Thread.Sleep(3000);
            Wheel(500);//上
            Thread.Sleep(1000);
            LeftClick(23, 60);//上一頁

        }

        private void button3_Click(object sender, EventArgs e)//紀錄
        {
            record = true;
            if (log.BaseStream == null)
            {
                log = new StreamWriter("log.txt");//create file

            }
        }

        private void button4_Click(object sender, EventArgs e)//停止
        {
            record = false;
            log.Close(); // close the file
        }

        private void button5_Click(object sender, EventArgs e)//重播
        {
            StreamReader fs = new StreamReader("log.txt", System.Text.Encoding.Default);
            string str = "";
            while ((str = fs.ReadLine()) != null)//迴圈一行一行讀log
            {
                //用Split切開字串 int.parse
                string[] rec = str.Split(',');
                newX = int.Parse(rec[1]);
                newY = int.Parse(rec[2]);
                mouseupdown = rec[3];//
                keyupdownpress = rec[4];//
                undefined = rec[5];//key


                //重複
                //mouse
                if (record == false)
                {
                    Thread.Sleep(10);
                    if (mouseupdown == "MouseMove")
                    {
                        Move(newX, newY);
                    }
                    if (mouseupdown == "MouseDownDown")
                    {
                        ClickDOWN(newX, newY);
                    }
                    if (mouseupdown == "MouseUp")
                    {
                        ClickUP(newX, newY);
                    }
                }
                //keyboard
                if (record == false)
                {
                    Thread.Sleep(10);

                    if (keyupdownpress == "KeyDown")
                    {
                        if (undefined == "LShiftKey" || undefined == "RShiftKey")//大小寫判斷GG
                        {
                            InputSimulator.SimulateKeyDown(VirtualKeyCode.SHIFT);
                        }
                        SendKeys.Send(undefined);
                    }
                    if (keyupdownpress == "KeyUp")
                    {
                        if (undefined == "LShiftKey" || undefined == "RShiftKey")
                        {
                            //do nothing
                        }
                    }
                }
                      
            }
            fs.Close();//close
        }
    }
}
