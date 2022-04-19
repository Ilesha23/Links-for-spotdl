using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lfs
{
    internal class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            /*Stream input = Console.OpenStandardInput();
            byte[] bytes = new byte[10000];
            input.Read(bytes, 0, 10000);
            string s = input.ToString();*/ // one way is to increase buffer because ReadLine is too small

            string s = Clipboard.GetText().ToString(); // another way is to get text right from the clipboard
            Console.WriteLine(s);
            s = s.Replace("\n", "");

            int n = s.Length / 79; // 79 - legnth of the spotify link
            string[] temp = new string[n];
            int a = 0;
            for (int i = 0; i < n; i++)
            {
                temp[i] = s.Substring(a, 79);
                a += 79;
                System.Diagnostics.Process.Start("spotdl.exe ", "-o C:\\Users\\Win10\\Desktop\\Music " + temp[i]);
                System.Threading.Thread.Sleep(50);
                if ((i + 1) % 5 == 0)
                {
                    System.Threading.Thread.Sleep(20000);
                }
            }
        }
    }
}
