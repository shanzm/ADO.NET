using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading;


namespace _02SqlCommand
{
    class Program
    {
        static void Main(string[] args)
        {

            #region 1.使用SQL命令的try-finally写法
            //string conStr = "server=.;database=db_Tome1;uid=sa;pwd=shanzm";
            //SqlConnection conn = new SqlConnection(conStr);
            //conn.Open();//注意一定不要忘记此句


            //  try
            //  {
            //      //新建一个sql命令对象
            //      SqlCommand cmd = new SqlCommand();
            //      //指定连接对象
            //      cmd.Connection = conn;
            //      //赋值sql脚本,注意这个SQL命令是非查询语句
            //      //在表dbo.szmDemo中新插入一行
            //      cmd.CommandText = "insert into dbo.szmDemo([ID], [Name], [Address]) values('4','赵六','中国江苏')";
            //      //执行非查询语句，返回受影响的行数
            //      int n1 = cmd.ExecuteNonQuery();

            //      Console.WriteLine("{0}行受影响", n1);

            //      Thread.Sleep(2000);

            //      //删除指定的某一行
            //      cmd.CommandText = "delete from dbo.szmDemo where ID='4'";
            //      int n2 = cmd.ExecuteNonQuery();

            //      Console.WriteLine("{0}行受影响", n2);
            //  }

            /////z在try-catch-finally 中 finally可以没有，要有也只能有一个。
            //  ///无论有没有发生异常，它总会在这个异常处理结构的最后运行。
            //  ///即使你在try块内用return返回了，在返回前，finally总是要执行，
            //  ///这以便让你有机会能够在异常处理最后做一些清理工作。如关闭数据库连接等等。
            //  finally
            //  {
            //      //注意使用完数据库一定要关闭数据库链接
            //      conn.Close();
            //  } 
            #endregion

            #region 2.使用SQL命令的using写法

            ///使用using(){}可以自动释放资源，比较优雅，尽量使用using

            string conStr = "server=.;database=db_Tome1;uid=sa;pwd=shanzm";
            using (SqlConnection conn = new SqlConnection(conStr))
            {
                conn.Open();//using可以自动释放资源，但你别忘了自己打开呀
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "insert into dbo.szmDemo([ID], [Name], [Address]) values('4','赵六','中国江苏')";
                    int n1 = cmd.ExecuteNonQuery();
                    Console.WriteLine("添加数据，{0}行受影响",n1 );

                    Thread.Sleep(2000);

                    cmd.CommandText = "delete from dbo.szmDemo where ID='4'";
                    int n2 = cmd.ExecuteNonQuery();

                    Console.WriteLine("删除数据，{0}行受影响", n2);
                }
            }

            #endregion

            Console.ReadKey();

        }

    }
}
