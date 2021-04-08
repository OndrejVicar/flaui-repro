using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace winforms
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Task.Run(() =>
            {
                var count = 0;
                while (true)
                {
                    count++;
                    Console.WriteLine($"{count}");
                    System.Threading.Thread.Sleep(100);
                }
            });
            Application.Run(new Form1());
        }
    }
}
