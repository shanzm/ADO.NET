using MyHelper;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace _00微软SqlHelper类
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string connStr = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;

            DataTable result1 = SqlHelper.ExecuteDataset(connStr, CommandType.Text, "select * from Person").Tables[0];
            //SqlParameter[] sqlParameters =
            //{
            //    new SqlParameter ("@Id",2),
            //    new SqlParameter ("@Age",6)
            //};
            //DataTable result2 = SqlHelper.ExecuteDataset(connStr, CommandType.StoredProcedure, "dbo.pro_GetPersonByIdAndAge",sqlParameters).Tables[0];
            DataTable result3 = SqlHelper.ExecuteDataset(connStr, CommandType.StoredProcedure, "sp_tables").Tables[0];
            DataTable result4 = SqlHelper .ExecuteDataset(connStr, CommandType.StoredProcedure, "pro_GetPerson").Tables[0];
            Console.ReadKey();
        }
    }
}
