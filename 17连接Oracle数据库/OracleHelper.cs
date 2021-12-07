using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;
//using System.Data.OracleClient;

//参考：https://www.cnblogs.com/gdjlc/p/10965845.html
//只需要添加：Oracle.ManagedDataAccess.dll
//直接通过nuget安装：Oracle.ManagedDataAccess
//注意不要使用默认的System.Data.OracleClient，vs会提示过时


namespace _17连接Oracle数据库
{
    public class OracleHelper
    {
        private static readonly string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["connStringForOracle"].ToString();

        public static OracleConnection GetConn()
        {
            var conn = new OracleConnection(connectionString);
            conn.Open();
            return conn;
        }

        public static int ExecNonQuery(string sql)
        {
            using (var conn = GetConn())
            {
                var cmd = new OracleCommand(sql, conn);
                int result = cmd.ExecuteNonQuery();
                return result;
            }
        }

        public static int ExecuteScalar(string sql)
        {
            using (var conn = GetConn())
            {
                var cmd = new OracleCommand(sql, conn);
                object o = cmd.ExecuteScalar();
                return Convert.ToInt32(o.ToString());
            }
        }


        public static OracleDataReader ExecuteReader(string sql)
        {
            var conn = GetConn();
            var cmd = new OracleCommand(sql, conn);
            var myReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            return myReader;
        }

        public static DataSet GetDataSet(string sql)
        {
            using (var conn = GetConn())
            {
                var cmd = new OracleCommand(sql, conn);
                OracleDataAdapter da = new OracleDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }
        }

    }
}
