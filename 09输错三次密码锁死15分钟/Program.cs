using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace _09输错三次密码锁死15分钟
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
           // Application.Run(new MainFrm());


            //实现登录成功后关闭LogInFrm,弹出TestFrm窗口
            LogInFrm logInFrm = new LogInFrm();
            if (logInFrm .ShowDialog ()==DialogResult .OK )
            {
                Application.Run(new TestFrm ());
            }
         
        }
    }
}
