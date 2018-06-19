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
            string connStr = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;



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
                        //  cmd.CommandText = string.Format("select count(1) from userInfo where userName='{0}' and password='{1}'", txtUerName.Text.Trim(), txtPwd.Text.Trim());

                        //sql注入

                        // 什么时候最易受到sql注入攻击
                        // 当应用程序使用输入内容来构造动态sql语句以访问数据库时，会发生sql注入攻击。如果代码使用存储过程，而这些存储过程作为包含未筛选的用户输入的 字符串来传递，也会发生sql注入。

                        //这个项目中如果你按照上面那样写sql语句
                        //那么在登录时你输入用户名“a'or 1=1--”,就相当于
                        //“select count(1) from userInfo where userName='a'or 1=1-- and password='aaaaa' ”
                        //你要知道--在sql语句中表示注释，此时即使userName没有是a的但是1=1是一定为true的
                        //所以这个sql语句一定是有返回值的，所以你就可以登录系统了（具体看你的判断登录的代码）

                        //注意为了防止sql注入
                        //我们常常是把Sql语句参数化
                        //也就是代码中的sql语句带有变量时，我们是这样写的
                        //使用@txtUerName 和@UserPwd

                        cmd.CommandText = " select count(1) from userInfo where userName=@txtUerName  and password=@UserPwd";
                        cmd.Parameters.AddWithValue("@txtUerName ", txtUerName.Text.Trim());
                        cmd.Parameters.AddWithValue("@UserPwd", txtPwd.Text.Trim());

                        

                        object result = cmd.ExecuteScalar();//cmd.ExecuteScalar()执行的结果是你SQL语句查询结果的第一行第一列的那个值
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
