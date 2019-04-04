using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ExcelMerge
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            ExcelMergeManager.Instance.ShowFormat = Properties.Settings.Default.ShowFormat;

            if (args.Length == 2)
            {
                if (!ExcelMergeManager.Instance.OpenDiff(args[0], args[1]))
                {
                    return;
                }
            }
            else if (args.Length == 4)
            {

            }
            else
            {
                MessageBox.Show("Please run with arguments:\r\nExcelMerge.exe <file1> <file2>");
            }
            Application.Run(new FormMain());
        }
    }
}
