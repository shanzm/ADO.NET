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

///注意这个项目中我们使用了配置文件App.config（在DeBug文件夹中）
///我们右键项目添加->新建项->应用程序配置文件
///同时我们要给项目添加引用->.Net->System.configuration
///添加命名空间using System.Configuration;
///使用ConfigurationMansger.Appsetting["节点名"]调用



namespace _04用户登录
{
    public partial class LogInFrm : Form
    {
        public LogInFrm()
        {
            InitializeComponent();
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            //string connStr = "server=.;database=db_Tome1;uid=sa;pwd=shanzm";
            //我们直接把connStr放到配置文件APP.config 中，使用时直接调用
            //不仅写起来方便，主要是便于项目移植时进行修改
            string connStr = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString ;



            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    //拿到窗体中的数据做判断用户输入为空
                    if (string.IsNullOrEmpty(txtUerName.Text.Trim()) || string.IsNullOrEmpty(txtPwd.Text.Trim()))
                    {
                        MessageBox.Show("用户名不为空！");
                    }

                    //输入不为空时，根据窗体中的输入拿取数据库中的数据
                    else
                    {

                        conn.Open();
                        cmd.Connection = conn;
                        //注意string.Format的使用，一种拼接字符串的方法
                        //比如说你想在一个字符串中插入一个其他的字符串或变量，你就可以在想要插入的地方用一个占位符，最后把字符串或变量写在后面
                        cmd.CommandText = string.Format("select count(1) from userInfo where userName='{0}' and password='{1}'", txtUerName.Text.Trim(), txtPwd.Text.Trim());
                        //cmd.ExecuteScalar()执行的结果是你SQL语句查询结果的第一行第一列的那个值
                        object result = cmd.ExecuteScalar();
                        int rows = int.Parse(result.ToString());

                        //判断依据就是我们去数据库的用户表userInfo中查找该用户名admin和密码12345，如果出现（也就是行数！=0）,就说明输入正确
                        if (rows != 0)
                        {
                            MessageBox.Show("登录成功");
                        }
                        else
                        {
                            MessageBox.Show("请输入正确的用户名和密码");
                        }
                    }

                }
            }
        }
    }
}
