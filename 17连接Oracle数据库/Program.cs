using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _17连接Oracle数据库
{
    class Program
    {
        static void Main(string[] args)
        {

            DataSet dataSet = OracleHelper.GetDataSet("select  * from  FYERP.A_颜色停用 where rownum<2");
            DataTable dt = dataSet.Tables[0];
            DataRow dr = dt.Rows[0];
            Console.WriteLine(dr["XTWPYS"].ToString());


            var reader = OracleHelper.ExecuteReader("select * from   FYERP.A_颜色停用");



            string result = OracleHelper.GetConn().ToString();
            Console.WriteLine(result);
            Console.ReadKey();

        }
    }
}
