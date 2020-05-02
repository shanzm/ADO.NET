#region
// ===============================================================================
// Project Name        :    ThreeLayersWeb.DAL
// Project Description : 
// ===============================================================================
// Class Name          :    SqlHelper
// Class Version       :    v1.0.0.0
// Class Description   : 
// CLR                 :    4.0.30319.18408  
// Author              :    单志铭(shanzm)
// Create Time         :    2018-8-14 18:22:59
// Update Time         :    2018-8-14 18:22:59
// ===============================================================================
// Copyright © SHANZM-PC  2018 . All rights reserved.
// ===============================================================================
#endregion

using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace _16StoreProcedure
{
    public class SqlHelper
    {
        private static readonly string connStr =
            ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;

        /// <summary>
        /// 返回查询结果的的表
        /// </summary>
        /// <param name="sql">SQL语句或存储过程</param>
        /// <param name="type">执行类型</param>
        /// <param name="param">参数</param>
        /// <returns></returns>
        public static DataTable GetDataTable(string sql, CommandType type, params  SqlParameter[] param)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter(sql, conn))
                {
                    if (param != null)
                    {
                        adapter.SelectCommand.Parameters.AddRange(param);
                    }

                    adapter.SelectCommand.CommandType = type;
                    DataTable da = new DataTable();
                    adapter.Fill(da);
                    return da;
                }
            }
        }



        /// <summary>
        /// 返回影响行数
        /// </summary>
        /// <param name="sql">SQL语句或存储过程</param>
        /// <param name="type">执行类型</param>
        /// <param name="param">参数</param>
        /// <returns></returns>
        public static int ExecuteNonquery(string sql, CommandType type, params SqlParameter[] param)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    if (param != null)
                    {
                        cmd.Parameters.AddRange(param);
                    }
                    cmd.CommandType = type;
                    conn.Open();
                    return cmd.ExecuteNonQuery();

                }
            }

        }

        /// <summary>
        /// 返回查询结果的第一行第一个单元格的数据
        /// </summary>
        /// <param name="sql">SQL语句或存储过程</param>
        /// <param name="type">执行类型</param>
        /// <param name="param">参数</param>
        /// <returns></returns>
        public static object ExecuteScalar(string sql, CommandType type, params SqlParameter[] param)
        {
            using (SqlConnection conn=new SqlConnection (connStr ))
            {
                using (SqlCommand cmd=new SqlCommand (sql,conn))
                {
                    if (param !=null )
                    {
                        cmd.Parameters.AddRange(param);
                    }
                    cmd.CommandType = type ;
                    conn.Open();
                    return cmd.ExecuteScalar();
                }
            }
        }

    }
}
