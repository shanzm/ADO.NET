using Oracle.ManagedDataAccess.Client;
using System.Data;
using System.Data.SqlClient;
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


        //创建连接对象
        public static OracleConnection GetConn()
        {
            var conn = new OracleConnection(connectionString);
            conn.Open();
            return conn;
        }

        //执行非查询语句返回受影响行数
        public static int ExecuteNoQuery(string sql,CommandType type=CommandType.Text,params SqlParameter[] param)
        {
            using (var conn = GetConn())
            {
                using (OracleCommand cmd=new OracleCommand (sql,conn))
                {
                    if (null!=param)
                    {
                        cmd.Parameters.AddRange(param);
                    }
                    cmd.CommandType = type;
                    conn.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        //返回查询结果的第一行第一个单元格的数据
        public static object ExecuteScalar(string sql,CommandType type=CommandType.Text,params SqlParameter[] param)
        {
            using (var conn = GetConn())
            {
                using (OracleCommand cmd=new OracleCommand(sql,conn))
                {
                    if (null!=param)
                    {
                        cmd.Parameters.AddRange(param);
                    }
                    cmd.CommandType = type;
                    conn.Open();
                    return cmd.ExecuteScalar();
                }
            }
        }

        //返回查询结果集
        public static DataSet GetDataSet(string sql, CommandType type = CommandType.Text, params SqlParameter[] param)
        {
            using (var conn = GetConn())
            {
                using (OracleDataAdapter adapter = new OracleDataAdapter(sql, conn))
                {
                    if (null != param)
                    {
                        adapter.SelectCommand.Parameters.AddRange(param);
                    }
                    adapter.SelectCommand.CommandType = type;
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    return ds;
                }
            }
        }

        public static OracleDataReader ExecuteReader(string sql)
        {
            var conn = GetConn();
            var cmd = new OracleCommand(sql, conn);
            var myReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            return myReader;
        }

    }
}
