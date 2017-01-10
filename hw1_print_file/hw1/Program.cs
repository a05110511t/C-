using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*列出C:\Windows\ 底下的檔案 寫入文字檔
再將文字檔從console印出
*for / while / 逐步 read */
namespace hw1
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string cwindows = @"C:\Windows\";
                List<string> dirs = new List<string>(Directory.GetFileSystemEntries(cwindows));
                System.IO.StreamWriter sw = new System.IO.StreamWriter(@"C:\Users\user\Documents\visual studio 2013\Projects\hw1\hw1" + @"\hw1.txt");
                var standardOutput = Console.Out;
                foreach (var dir in dirs)
                {
                    Console.WriteLine("{0}", dir.Substring(dir.LastIndexOf("\\") + 1));
                    sw.WriteLine(dir.Substring(dir.LastIndexOf("\\") + 1)); // output the reslut to the file //(WriteLine or Write)
                }
                sw.WriteLine("{0} Files found.", dirs.Count);
                sw.Close(); // close the file
            }
            catch (UnauthorizedAccessException UAEx)
            {
                Console.WriteLine(UAEx.Message);
            }
            catch (PathTooLongException PathEx)
            {
                Console.WriteLine(PathEx.Message);
            }
            Console.ReadLine();
        }
    }
}