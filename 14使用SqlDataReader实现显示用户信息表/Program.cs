using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace _14使用SqlDataReader实现显示用户信息表
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainFrm());
        }
    }
}
