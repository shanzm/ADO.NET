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

            //执行查询语句
            DataTable result1 = SqlHelper.ExecuteDataset(connStr, CommandType.Text, "select * from Person").Tables[0];

            //参数化查询
            SqlParameter[] sqlParameters =
            {
                new SqlParameter ("@Id",2),
                new SqlParameter ("@Age",6)
            };
            DataTable result2 = SqlHelper.ExecuteDataset(connStr, CommandType.StoredProcedure, "dbo.pro_GetPersonByIdAndAge", sqlParameters).Tables[0];

            //执行存储过程
            DataTable result3 = SqlHelper.ExecuteDataset(connStr, CommandType.StoredProcedure, "sp_tables").Tables[0];
            DataTable result4 = SqlHelper.ExecuteDataset(connStr, CommandType.StoredProcedure, "pro_GetPerson").Tables[0];

            //获取存储过程的参数集

            SqlParameter[] parameters = SqlHelperParameterCache.GetSpParameterSet(connStr, "dbo.pro_GetPersonByIdAndAge");//获取指定存储过程的参数集
            //parameters[0].Value = 2;
            //parameters[1].Value = 6;
            ////为参数指定方向
            //////paras[0].Direction = ParameterDirection.Output;
            //////paras[1].Direction = ParameterDirection.ReturnValue;
            //DataTable result5 = SqlHelper.ExecuteDataset(connStr, CommandType.StoredProcedure, "dbo.pro_GetPersonByIdAndAge", parameters).Tables[0];

            Console.ReadKey();
        }
    }
}
