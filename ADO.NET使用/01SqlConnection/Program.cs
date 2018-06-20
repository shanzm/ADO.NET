using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading;

///注意在ADO.Net 主要是使用的using System.Data.SqlClient命名空间
///我们常用就五个类
///SqlConnection、SqlCommand、SqlParameter、SqlDataReader、SqlDataAdapter




///SqlConnection对象只能被打开一次。
///但是在Close()后可以再进行Open()操作。
///但是在Dispose()之后就不能再Open()了。



namespace _01SqlConnection
{
    class Program
    {
        static void Main(string[] args)
        {
            //链接字符串
            //注意server值可以使用“.”和（local）和本机ip“127.0.0.1”和机器名\实例名"SHANZM-PC\\SQLEXPRESS"
            //database指的是链接的数据库
            string connStr = "server=.;uid=sa;pwd=shanzm;database=master";
            //新建链接对象
            SqlConnection conn = new SqlConnection(connStr);
            //链接
            conn.Open();
            Console.WriteLine("链接成功");
            //暂停2秒
            Thread.Sleep(2000);
            //关闭链接
            conn.Close();
            //释放资源
            Console.WriteLine("关闭链接");
            conn.Dispose();
            Console.ReadKey();

        }
    }
}
