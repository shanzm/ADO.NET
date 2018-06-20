using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace _13观察者模式_非委托实现__中介者模式
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
