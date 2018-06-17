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

namespace _05用户注册
{
    ///读取用户在Winform中输入的用户名和密码
    ///放在数据库中的userInfo表中进行匹配
    ///若在不存在该用户就把用户名和密码插入到数据库userInfo表中，显示注册成功
    
    public partial class SignUPFrm : Form
    {
        public SignUPFrm()
        {
            InitializeComponent();
        }

        private void btnSignIN_Click(object sender, EventArgs e)
        {
            //string connStr = "server=.;database=db_Tome1;uid=sa;pwd=shanzm";
            //先写入配置文件App.config，项目中使用在从配置文件中读取
            string connStr = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlCommand cmd = new SqlCommand())
                {

                    if (string.IsNullOrEmpty(txtUserName.Text.Trim()) || string.IsNullOrEmpty(txtPsw.Text.Trim()))
                    {
                        MessageBox.Show("用户名和密码不能为空！");
                    }

                    conn.Open();
                    cmd.Connection = conn;
                    cmd.CommandText = string.Format("select count(1) from userInfo where userName='{0}'", txtUserName.Text.Trim());

                    int rows = int.Parse(cmd.ExecuteScalar().ToString());

                    if (rows > 0)
                    {
                        MessageBox.Show("该用户名以存在");
                    }

                    cmd.CommandText = string.Format("insert into userInfo (userName,password)values('{0}','{1}');", txtUserName.Text.Trim(), txtPsw.Text.Trim());
                    int infulenceRow = cmd.ExecuteNonQuery();
                    MessageBox.Show("注册成功");

                }//end using cmd

            }//end using conn
        }
    }
}
