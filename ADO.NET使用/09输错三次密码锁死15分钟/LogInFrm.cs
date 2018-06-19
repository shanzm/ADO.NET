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

namespace _09输错三次密码锁死15分钟
{

    ///本项目使用的表是szmUserInfo。我已经把创建表的文件放在了DeBug文件夹中了
    ///这个项目是当用户输入错误自己的密码后，15分钟不能登录
    ///思路：
    ///1.什么情况允许登陆？错误次数少于3次||错误时间大于15分钟
    ///2.首先根据用户在winform中输入的用户名和密码在szmUserInfo表中查询数据
    ///3.若是没有查询出数据，则用户名或密码错误
    ///4.若是查询到数据，则进行后续判断
    ///错误次数小于3次且错误时间小于15分钟，则满足登录
    ///不满足则，显示提示
    ///


    public partial class LogInFrm : Form
    {
        public LogInFrm()
        {
          
            InitializeComponent();
 
        }

        /// <summary>
        /// 光标焦点设置在txtUserName
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainFrm_Activated(object sender, EventArgs e)
        {
            this.txtUserName.Focus();
        }


        private void btnSignIN_Click(object sender, EventArgs e)
        {


            string connStr = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    conn.Open();
                    cmd.CommandText = string.Format(@"SELECT [Id],[UserName],[UserPwd],[LastErrorDateTime],[ErrorTimes] FROM [db_Tome1].[dbo].[szmUserInfo] where UserName='{0}'", txtUserName.Text.Trim());


                    UserInfo userInfo = null;
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        #region 注释：关于为什么不在using reader的花括号中直接新建一个sqlcmd来修改数据表呢
                        ////注意HasRows是一个reader的属性，他返回的是一个布尔变量
                        ////如果有数据则返回true,无数据则返回false
                        //if (！reader.HasRows)//没有查询到数据
                        //{
                        //    //修改数据库中错误次数和错误时间
                        //    //cmd.CommandText ="修改数据库中错误次数和错误时间";
                        //    //cmd.ExecuteNonQuery ();
                        //    //但是你要注意，在using reader这个括号中，reader一直是没有释放，所以数据库的连接conn一直在使用，那没其他的cmd就没法使用
                        //    //而我们修改数据错中的错误次数和错误时间，需要SQLcmd，我们要是在重新在此处声明一个SqlConnection就会太浪费资源了
                        //    //我们希望的是一直使用现在的conn对象,所以我们把新的SQLcmd（修改错误次数和时间），放在这个using reader的花括号外面
                        //} 
                        #endregion

                        //如果查询到数据则指针指向的行数据存储到UserInfo类的对象中
                        //UesrInfo 的对象声明放在外面，便于后续使用

                        if (reader.Read())
                        {
                            userInfo = new UserInfo();
                            userInfo.Id = int.Parse(reader["Id"].ToString());
                            userInfo.UserName = reader["UserName"].ToString();
                            userInfo.ErrorTimes = int.Parse(reader["ErrorTimes"].ToString());
                            userInfo.LastErrorDateTime = DateTime.Parse(reader["LastErrorDateTime"].ToString());
                        }


                    }

                    if (userInfo == null)//如果没有查询到数据，所以对象userInfo为空
                    {
                        cmd.CommandText = string.Format(@"UPDATE [db_Tome1].[dbo].[szmUserInfo]SET [LastErrorDateTime] =GETDATE(),[ErrorTimes] = ErrorTimes +1 WHERE UserName='{0}'", txtUserName.Text.Trim());
                        cmd.ExecuteNonQuery();
                         MessageBox.Show("用户名或密码错误");
                        return;
                    }

                    else if (userInfo.ErrorTimes < 3 && DateTime.Now.Subtract(userInfo.LastErrorDateTime).Minutes > 15)
                    {
                        MessageBox.Show("登录成功！");
                        cmd.CommandText = string.Format(@"UPDATE [db_Tome1].[dbo].[szmUserInfo]SET [LastErrorDateTime] =GETDATE(),[ErrorTimes] = 0 WHERE UserId='{0}'", userInfo.Id);

                        //这句代码是为了实现登录成功后关闭LogInFrm,弹出TestFrm窗口
                        //具体实现代码是在Program.cs中
                 
                        this.DialogResult = DialogResult.OK;
                        
                      
                    }
                    else
                    {
                        MessageBox.Show("登录失败！账号锁定,15分钟后再登录");
                    }
                }
            }

        }

   

   

    }
}
