using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Delegate_practice
{
     class myPublisher
    {
        public delegate string myDelegate(string message);
        // Define an Event based on the above Delegate
        public event myDelegate myEvent;

        Thread myThread;

        public myPublisher()
        {
            myThread = new Thread(run);//宣告執行緒
            myThread.Start();
        }
        
        void run()
        {
            int count = 0;
            for(int i =1; i<=10;i++)
            {
                for (int j = 10; j > 0; j--)
                {
                    fireEvent(i.ToString());
                    Thread.Sleep(10);
                    fireEvent(j.ToString());
                    Thread.Sleep(10);
                    if(i == j)
                    {
                       Console.WriteLine("QQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQ");
                       count++;
                    }
                }
            }
            Console.WriteLine("\nTotal Repeat:");
            Console.WriteLine(count);
            Console.ReadKey();
        }

        protected void fireEvent(string message)
        {
            if (myEvent != null)
            {
                myEvent(message);
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Print 1 to 10 and 10 to 1, if the same print QQQQQQQQ...");

            myPublisher m = new myPublisher();
            m.myEvent += new myPublisher.myDelegate(eventHandler);//註冊

            

        }
        public static string eventHandler(string s)
        {
            Console.WriteLine(s);
            return s;
        }

    }
}
