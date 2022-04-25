using System;
using System.IO;
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

            int linkLength = 79;
            string path = Directory.GetCurrentDirectory();
            path = Directory.GetParent(Directory.GetParent(path).FullName).FullName;
            string s = Clipboard.GetText().ToString(); // another way is to get text right from the clipboard
            Console.WriteLine(path);
            s = s.Replace("\n", "");

            int n = s.Length / linkLength; // 79 - legnth of the spotify link
            string[] temp = new string[n];
            int a = 0;
            for (int i = 0; i < n; i++)
            {
                temp[i] = s.Substring(a, linkLength);
                a += linkLength;
                //System.Diagnostics.Process.Start(@"spotdl.exe", $" -o C:\\Users\\{Environment.UserName}\\Desktop\\Music {temp[i]}");
                System.Diagnostics.Process.Start(path + "\\spotdl.exe", $" -o C:\\Users\\{Environment.UserName}\\Desktop\\Music {temp[i]}");
                System.Threading.Thread.Sleep(50);
                if ((i + 1) % 5 == 0)
                {
                    System.Threading.Thread.Sleep(20000);
                }
            }
        }
    }
}
