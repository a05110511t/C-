using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace hw1_1
{
    class Program
    {
        static System.IO.StreamWriter sw;
        static void DirSearch(string dir)
        {
                     
            try
            {
                foreach (var f in Directory.GetFiles(dir, "*?"))
                {
                    Console.WriteLine(f.Substring(f.LastIndexOf("\\") + 1));
                    sw.WriteLine(f.Substring(f.LastIndexOf("\\") + 1));
                }
                
                foreach (var d in Directory.GetDirectories(dir))
                {
                    Console.WriteLine(d.Substring(d.LastIndexOf("\\") + 1));
                    DirSearch(d);
                }
            }
            catch (System.Exception ex)
            { 
                Console.WriteLine(ex.Message);
            }
        }

        static void Main(string[] args)
        {
            string d = @"C:\windows\";
            sw = new System.IO.StreamWriter(@"C:\Users\user\Desktop" + @"\hw1_1.txt", true);
            DirSearch(d);
            sw.Close();
            Console.ReadKey();
        }
    }
}
