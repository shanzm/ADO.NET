using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;


///DBNull.Value,, 表示的是数据库的表中插入的空值。
///string a=null;你只是定义了一个字符串类型的变量，并没有为他分配内存，你要使用时还要再对他进行赋值，a="abcd";也就是初始化
///               你要是在使用它时，不进行初始化，则编译时会显示未使用该变量
///string a=string.Empty;就相当于string a=null;a=" ";

///在这个项目中我们删除数据使用了表的删除标识DelFlag
///删除是进行的逻辑删除（软删除），删除只是把DelFlag改为1，
///（注意DelFlag 这一列



namespace _14使用SqlDataReader实现显示用户信息表
{
    public partial class MainFrm : Form
    {
        public MainFrm()
        {
            InitializeComponent();
        }



        private void Form1_Load(object sender, EventArgs e)
        {
            //我们把使用sql语句查询之后再使用SqlDataReader读取数据的整个过程封装成这个加载数据的函数
            LoadUserInfo();
        }

        /// <summary>
        /// 将UserInfo表中的数据加载到DataGridView中
        /// </summary>
        private void LoadUserInfo()
        {
            List<UserInfo> userInfoList = new List<UserInfo>();

            string connStr = SqlHelper.GetConnStr();
            using (SqlConnection conn = new SqlConnection(connStr))
            {

                using (SqlCommand cmd = conn.CreateCommand())
                {
                    conn.Open();
                    cmd.CommandText = "SELECT [Id],[UserName],[UserPwd],[LastErrorDateTime],[ErrorTimes],[DelFlag] FROM [db_Tome1].[dbo].[szmUserInfo] WHERE [DelFlag]=0";


                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        //注意一定要把数据封装到对象
                        while (reader.Read())
                        {
                            #region 把数据初始化为UserInfo对象
                            UserInfo user = new UserInfo();
                            user.Id = int.Parse(reader["Id"].ToString());
                            //表中数据为空则等于空，不为空则赋值
                            user.UserName = reader["UserName"] == DBNull.Value ? string.Empty : reader["UserName"].ToString();
                            user.UserPwd = reader["UserPwd"].ToString();
                            user.LastErrorDateTime = DateTime.Parse(reader["LastErrorDateTime"].ToString());
                            //注意如果数据库的表中这个列允许为空则我们应该做判断，我们使用一个三元运算符来判断赋值，若是空那就是等于0
                            user.ErrorTimes = reader["ErrorTimes"] == DBNull.Value ? 0 : int.Parse(reader["ErrorTImes"].ToString());
                            user.DelFlag = short.Parse(reader["DelFlag"].ToString());
                            userInfoList.Add(user);
                            #endregion
                        }//end while
                    }//end using reader
                }//end using cmd
            }//end using conn
            this.dgvUserInfo.DataSource = userInfoList;
        }


        /// <summary>
        /// 将SelectionModel属性设置为FullRowSelect,即选中就是选中整行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            //数据删除的逻辑
            //第一步拿到表格选择行的主键
            var rows = this.dgvUserInfo.SelectedRows;//注意虽然我们默认是选中一行，但是SelectedRows返回的是一个行的集合(注意不是数组，可以通过rows.Count确定，若是数组则是rows.Length） 
            StringBuilder sqlStr = new StringBuilder();

            List<SqlParameter> parameterList = new List<SqlParameter>();

            ///这里你要明白我们如果选的是多行，要进行删除就要使用多个update语句，循环就是对update语句的叠加
            ///所以，每句sql语句的末尾我们都写了";"
            ///多打断点进行调试你就明白了
            for (int i = 0; i < rows.Count; i++)
            {
                sqlStr.Append("update szmUserInfo set DelFlag=1 where Id=@UserId" + i + ";");

                //☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆
                //注意SqlParameter的使用方式
                //第一个参数是sql语句中要替换的参数，第二个是这个参数在数据库中的类型（使用SqlDBType这个枚举类型来选取）
                SqlParameter param = new SqlParameter("@UserId" + i, SqlDbType.Int);
                param.Value = int.Parse(rows[i].Cells["Id"].Value.ToString());
                parameterList.Add(param);

            }

            ///其实你也可以在上面的循环中每循环一次就执行删除的sql命令一次，但是你这样就会与数据库交互多次
            ///而我们现在是把所有的Sql删除命令放在一起，一次执行，就与数据库交互一次，更加高效



            //第二步根据主键删除行数据
            using (SqlConnection conn = new SqlConnection(SqlHelper.GetConnStr()))
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    conn.Open();
                    cmd.CommandText = sqlStr.ToString();
                    cmd.Parameters.AddRange(parameterList.ToArray());
                    int affectRows = cmd.ExecuteNonQuery();
                    LoadUserInfo();
                    MessageBox.Show("受影响行数：" + affectRows);
                }
            }
        }
    }
}
