#region
// ===============================================================================
// Project Name        :    _15完整的数据库增删改查
// Project Description :   
// ===============================================================================
// Class Name          :    SqlHelper
// Class Version       :    v1.0.0.0
// Class Description   :   
// Author              :    shanzm
// Create Time         :    2018-6-21 21:40:28
// Update Time         :    2018-6-21 21:40:28
// ===============================================================================
// Copyright © SHANZM-PC 2018 . All rights reserved.
// ===============================================================================
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace _15完整的数据库增删改查
{
    public class SqlHelper
    {
        #region 返回数据库连接字符串
        /// <summary>
        /// 返回数据库连接字符串
        /// </summary>
        /// <returns>返回数据库连接字符串</returns>
        public static string GetConnStr()
        {
            return ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;
        }
        #endregion

        #region 执行Sql语句，返回受影响行数
        //一定要注意第二个参数是数组，因为外面的集合可以同过ToArray()转化到数组，且关键字params,确保没有这个参数时也可以调用这个函数
        /// <summary>
        /// 执行Sql语句，返回受影响行数
        /// </summary>
        /// <param name="sqlStr">执行的sql命令</param>
        /// <param name="parameters">sql命令中的参数数组</param>
        /// <returns>返回受影响的行数</returns>
        public static int ExecuteNonQuery(string sqlStr, params SqlParameter[] parameters)
        {
            using (SqlConnection conn = new SqlConnection(GetConnStr()))
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    conn.Open();
                    cmd.CommandText = sqlStr;
                    cmd.Parameters.AddRange(parameters);
                    return cmd.ExecuteNonQuery();
                }
            }
        }
        #endregion

        #region  执行Sql查询语句，返回查询结果的第一行第一列的值
        /// <summary>
        /// 执行Sql查询语句，返回查询结果的第一行第一列的值
        /// </summary>
        /// <param name="sqlStr">执行的sql命令</param>
        /// <param name="parameters">sql命令中的参数数组</param>
        /// <returns>返回查询结果的第一行第一列的值</returns>
        public static object ExecuteScalar(string sqlStr, params SqlParameter[] parameters)
        {
            using (SqlConnection conn = new SqlConnection(GetConnStr()))
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    conn.Open();
                    cmd.CommandText = sqlStr;
                    cmd.Parameters.AddRange(parameters);
                    return cmd.ExecuteScalar();
                }
            }
        }


        #region 泛型写法
        //public static T ExecuteScalar<T>(string sqlStr, params SqlParameter[] parameters)
        //    where T : UserInfo //对泛型的约束，T必须是UserInfo类，
        //    ///where T:class //表示T必须是类
        //    ///where T:new () //要求T必须有构造函数
        //{
        //    using (SqlConnection conn = new SqlConnection(GetConnStr()))
        //    {
        //        using (SqlCommand cmd = conn.CreateCommand())
        //        {
        //            conn.Open();
        //            cmd.CommandText = sqlStr;
        //            cmd.Parameters.AddRange(parameters);
        //            return (T)cmd.ExecuteScalar()  ;
        //        }
        //    }
        //} 
        #endregion

        #endregion

        #region 执行Sql查询语句，返回查询结果以DataTable的形式

        /// <summary>
        /// 执行Sql查询语句，返回查询结果以DataTable的形式
        /// </summary>
        /// <param name="sqlStr">执行的sql命令</param>
        /// <param name="paramters">sql命令中的参数数组</param>
        /// <returns>返回查询结果以DataTable的形式</returns>
        public static DataTable ExecuteDataTable(string sqlStr, params SqlParameter[] paramters)
        {
            using (SqlDataAdapter adapter = new SqlDataAdapter(sqlStr, GetConnStr()))
            {
                DataTable dt = new DataTable();
                //☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆
                //注意adapter 添加sql命令中参数值的方式
                adapter.SelectCommand.Parameters.AddRange(paramters);
                adapter.Fill(dt);
                return dt;
            }
        }
        #endregion

        #region  执行Sql查询语句，返回结果是表的行指针
        /// <summary>
        /// 执行Sql查询语句，返回结果是表的行指针
        /// </summary>
        /// <param name="sqlStr">Sql命令</param>
        /// <param name="paramters">sql命令中的参数数组</param>
        /// <returns>返回结果是表的行指针</returns>
        public static SqlDataReader ExecuteDataReader(string sqlStr, params SqlParameter[] paramters)
        {
            //SqlDataReader要求，它在读取数据时，必须独占他自己的SqlConnection，而且SqlConnection必须是打开状态
            //故此处的SqlConnection不使用Using管理，而是一直保持连接状态
            SqlConnection conn = new SqlConnection(GetConnStr());
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = sqlStr;
            cmd.Parameters.AddRange(paramters);
            //CommandBehavior .CloseConnection 表示当SqlDateReader释放时，顺便把SqlConnection对象释放
            return cmd.ExecuteReader(CommandBehavior.CloseConnection);
        } 
        #endregion
    }
}
