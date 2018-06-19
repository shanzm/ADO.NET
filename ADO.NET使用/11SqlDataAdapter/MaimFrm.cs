using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

///SqlDataAdapter是 DataSet和 SQL Server之间的桥接器。称作数据访问配置器。
///SqlDataAdapter通过对数据源使用适当的SQL语句映射 Fill（它可填充DataSet中的数据以匹配数据源中的数据）
///和 Update（它可更改数据源中的数据以匹配 DataSet中的数据）来提供这一桥接。
///当SqlDataAdapter填充 DataSet时，它为返回的数据创建必需的表和列（如果这些表和列尚不存在）。

///注意SqlDataReader建立数据库连接后一直是保持连接的，要是读取数据只能一次读取当前reader指向的那一行
///而SalDataAdapter是一次把数据库中相应的表的数据一次全部读取到内存中，然后数据库连接就断开了



namespace _11SqlDataAdapter
{
    public partial class MaimFrm : Form
    {
        public MaimFrm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string connStr = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string sqlStr = @"SELECT [Id],[UserName],[UserPwd],[LastErrorDateTime],[ErrorTimes] FROM [db_Tome1].[dbo].[szmUserInfo];
                                 SELECT [ID],[Name],[Address] FROM [db_Tome1].[dbo].[szmDemo]";

                using (SqlDataAdapter adapter = new SqlDataAdapter(sqlStr, conn))//这里的参数也可以这样写，new SqlDataAdapter(sqlStr, connStr)，因为有不同的重载
                {

                    #region 1.使用配置器SqlDataAdapter将sql查询的结果放在DataTable中
                    //新建一张内存表
                    DataTable dt = new DataTable("dt");
                    //Fill()填充方法Fill()填充方法,可以用来填充表格和DataGridView
                    adapter.Fill(dt);
                    //绑定dgvUserInfo数据源
                    //之前我们知道DataGridView的数据源可以是list（CSharp_XML/对XML文件的处理/XML-6增删改查-应用练习/）
                    //这里我们新知道数据源还可以是Datatable)
                    this.dgvUserInfo1.DataSource = dt; 
                    #endregion


                    #region 2.将DataTable的数据放在新建一个类的对象中，方便后续使用
                    //最后你要注意：
                    //尽量要把DataTable封装成强类型的对象
                    //也就是新建一个类来存储DataTable的数据，如下
                    //这样当你需要在使用这些数据时就方便多了

                    List<UserInfo> uerInfoList = new List<UserInfo>();
                    foreach (DataRow item in dt.Rows)
                    {
                        uerInfoList.Add(new UserInfo()
                        {//对你新建的UserInfo类型的对象直接初始化
                            Id = int.Parse(item["Id"].ToString()),
                            UserName = item["UserName"].ToString(),
                            UserPwd = item["UserPwd"].ToString(),
                            LastErrorDateTime = DateTime.Parse(item["LastErrorDateTime"].ToString()),
                            ErrorTimes = int.Parse(item["ErrorTimes"].ToString())
                        });
                    }

                    this.dgvUserInfo2.DataSource = uerInfoList;
                    #endregion


                    #region 3.使用配置器SqlDataAdapter将sql查询的结果新建一张表放在DataSet中

                    //许多时候我们的Sql查询语句的结果不一定就是一张表，有可能是多张表
                    //这样我们就可以把多张表都放在这个DataSet中

                    //新建一个数据集
                    DataSet ds = new DataSet("dataSet");
                    //将返回的数据不管几张表我们都把他放在这个DataSet中，每张表的索引为0,1,2。。。
                    adapter.Fill(ds);
                    //将DataGridView的数据源绑定为数据集第2张表
                    this.dgvUserInfo3.DataSource = ds.Tables[1]; 

                    #endregion


                
                }
            }
        }
    }
}
