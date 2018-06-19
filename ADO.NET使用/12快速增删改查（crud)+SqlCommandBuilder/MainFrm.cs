using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;


namespace _12快速增删改查_crud__SqlCommandBuilder
{
    public partial class MainFrm : Form
    {
        public MainFrm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 加载窗口的时候读取数据库的数据显示在DataGridView中
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {

            string connStr = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string sqlStr = @"SELECT [Id],[UserName],[UserPwd],[LastErrorDateTime],[ErrorTimes] FROM [db_Tome1].[dbo].[szmUserInfo]";


                using (SqlDataAdapter adapter = new SqlDataAdapter(sqlStr, connStr))
                {

                    #region 1.使用配置器SqlDataAdapter将sql查询的结果放在DataTable中
                    //新建一张内存表
                    DataTable dt =  new DataTable("dt");
                    //Fill()填充方法Fill()填充方法,可以用来填充表格和DataGridView
                    adapter.Fill(dt);
                    //绑定dgvUserInfo数据源
                    //之前我们知道DataGridView的数据源可以是list（CSharp_XML/对XML文件的处理/XML-6增删改查-应用练习/）
                    //这里我们新知道数据源还可以是Datatable)
                    this.dgvUserInfo.DataSource = dt;
                    #endregion
                }
            }
        }


        /// <summary>
        /// 点击按钮时，将你在DataGridView中做的修改和插入，保存到数据库中
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            //拿到连接语句，注意这只是为了给new SqlDataAdapter(sqlStr, connStr)做参数
            //不需要在重新新建数据库连接conn
            string connStr = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;
            //注意修改的代码中Sql语句一定要和查询的语句一样
            string sqlStr = @"SELECT [Id],[UserName],[UserPwd],[LastErrorDateTime],[ErrorTimes] FROM [db_Tome1].[dbo].[szmUserInfo]";

            using (SqlDataAdapter adapter = new SqlDataAdapter(sqlStr, connStr))
            {
                DataTable dt = this.dgvUserInfo.DataSource as DataTable;

                using (SqlCommandBuilder cmdBuilder = new SqlCommandBuilder(adapter))
                {
                    adapter.Update(dt);
                }
            }
            MessageBox.Show("保存成功！");
        }

    }
}
