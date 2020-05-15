using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16StoreProcedure
{
    class Program
    {
        static void Main(string[] args)
        {
            TransferAccounts();
         //   ReturnDataTable();
        }

        //使用存储过程实现转账
        private static void TransferAccounts()
        {
            //转出账户的Id
            int from = 1;
            //转入账户的Id
            int to = 2;
            //转账金额
            decimal balance = 10;

            SqlParameter[] param =
            {
                //new SqlParameter ("@from",System.Data.SqlDbType.BigInt) {Value=2 },
                //new SqlParameter("@to",System.Data.SqlDbType.BigInt) {Value=1 },
                //new SqlParameter ("@balance",System.Data.SqlDbType.Decimal) {Value=10 },

                new SqlParameter ("@from",from),
                new SqlParameter("@to",to),
                new SqlParameter ("@balance",balance),
                //设置为输出参数(注意输入输出参数的参数化只能按照下面的书写方式)
                new SqlParameter ("@returnNum",System.Data.SqlDbType.Int) {Direction=System.Data.ParameterDirection.Output }
                //错误方式：new SqlParameter ("@returnNum",ParameterDirection.Output)
            };

            SqlHelper.ExecuteNonquery("pro_transfer_szmbank", System.Data.CommandType.StoredProcedure, param);

            //根据输出参数判断
            int outPutparam = Convert.ToInt16(param[3].Value);
            switch (outPutparam)
            {
                case 1: Console.WriteLine($"success:从Id:{from}转账{balance}元到Id：{to}"); break;
                case 2: Console.WriteLine("error"); break;
                case 3: Console.WriteLine("余额不足"); break;
            }
            Console.ReadKey();
        }

        //使用存储过程返回DataTable
        private static void ReturnDataTable()
        {
            DataTable dt = SqlHelper.GetDataTable("pro_ReturnDataTable", CommandType.StoredProcedure);

            foreach (DataRow row in dt.Rows)
            {
                Console.WriteLine(row["用户ID"].ToString() + ":" + row["余额"].ToString());
            }
            Console.ReadKey();
        }
    }
}
