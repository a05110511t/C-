using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Threadpratice
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread thread1 = new Thread(new ThreadStart(AAA));
            Thread thread2 = new Thread(new ThreadStart(BBB));
            Thread thread3 = new Thread(new ThreadStart(CCC));
            thread1.Start();
            thread2.Start();
            thread1.Join();
            thread2.Join();
        }

        static void AAA()
        {
            Thread.Sleep(100);
            Console.WriteLine('A');
        }

        static void BBB()
        {
            Thread.Sleep(1000);
            Console.WriteLine('B');
        }

        static void CCC()
        {
            Thread.Sleep(1000);
            Console.WriteLine('C');
        }
    }
}
