using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace _15完整的数据库增删改查
{
    public partial class EditUserInfoFrm : Form
    {
        //添加一个UserInfo类型的属性，注意我们不直接添加一个int类型的Id属性，
        //而是添加了一个UserInfo类型的对象,这样扩展性更强
        public UserInfo UserInfo { get; set; }

        //修改构造函数，为属性的赋值，注意这里我们
        //构造函数的参数改为一个Userinfo对象，扩展性更强
        public EditUserInfoFrm(UserInfo userInfo)
        {
            InitializeComponent();
            UserInfo = userInfo;

        }

        #region 1.窗体加载数据
        private void EditUserInfo_Load(object sender, EventArgs e)
        {
            //根据传来的Id查询数据
            #region 未优化的代码
            //using (SqlConnection conn = new SqlConnection(SqlHelper.GetConnStr()))
            //{

            //    using (SqlCommand cmd = conn.CreateCommand())
            //    {
            //        conn.Open();
            //        cmd.CommandText = @"SELECT [Id] ,[UserName],[UserPwd],[LastErrorDateTime],[ErrorTimes],[DelFlag],[CreateDate] FROM [db_Tome1].[dbo].[szmUserInfo]where [Id]=@Id";

            //        cmd.Parameters.AddWithValue("@Id", UserInfo.Id);
            //        using (SqlDataReader reader = cmd.ExecuteReader())
            //        {
            //            if (reader.Read())
            //            {
            //                this.txtUserName.Text = reader["UserName"].ToString();
            //                this.txtUserPwd.Text = reader["UserPwd"].ToString();
            //            }
            //        }
            //    }
            //} 

            string sqlStr = @"SELECT [Id] ,[UserName],[UserPwd],[LastErrorDateTime],[ErrorTimes],[DelFlag],[CreateDate] FROM [db_Tome1].[dbo].[szmUserInfo]where [Id]=@Id";
            using (SqlDataReader reader = SqlHelper.ExecuteDataReader(sqlStr, new SqlParameter("@Id", (object)UserInfo.Id)))
            {
                if (reader.Read())
                {
                    this.txtUserName.Text = reader["UserName"].ToString();
                    this.txtUserPwd.Text = reader["UserPwd"].ToString();
                }
            }



            #endregion
        }
        #endregion

        #region 2.保存按钮
        private void btnSave_Click(object sender, EventArgs e)
        {

            #region 未优化的源代码
            //using (SqlConnection conn = new SqlConnection(SqlHelper.GetConnStr()))
            //{
            //    using (SqlCommand cmd = conn.CreateCommand())
            //    {
            //        conn.Open();

            //        cmd.CommandText = @"UPDATE [db_Tome1].[dbo].[szmUserInfo]SET [UserName] =@Username ,[UserPwd] = @UserPwd WHERE [Id]=@Id ";

            //        cmd.Parameters.AddWithValue("@UserName", txtUserName.Text.Trim());
            //        cmd.Parameters.AddWithValue("@UserPwd", txtUserPwd.Text.Trim().Replace(" ", ""));//注意Trim()只能去除字符串前后的空格，使用Replace (" ","")是为了出去字符串中的空格   
            //        cmd.Parameters.AddWithValue("@Id", UserInfo.Id);



            //        if (cmd.ExecuteNonQuery() >= 0)
            //        {
            //            MessageBox.Show("保存成功！");
            //        }

            //        //关闭窗体
            //        this.Close();

            //    }
            //} 
            #endregion

            string sqlStr = @"UPDATE [db_Tome1].[dbo].[szmUserInfo]SET [UserName] =@Username ,[UserPwd] = @UserPwd WHERE [Id]=@Id ";
            List<SqlParameter> Listparameters = new List<SqlParameter>();

            var pUserName = new SqlParameter("@UserName", SqlDbType.NVarChar, 32);
            pUserName.Value = txtUserName.Text.Trim();
            Listparameters.Add(pUserName);

            var pUserPwd = new SqlParameter("@UserPwd", SqlDbType.NVarChar, 16);
            pUserPwd.Value = txtUserPwd.Text.Trim();
            Listparameters.Add(pUserPwd);

            var pId = new SqlParameter("@Id", SqlDbType.Int, 4);
            pId.Value = UserInfo.Id;
            Listparameters.Add(pId);


            int affectRows = SqlHelper.ExecuteNonQuery(sqlStr, Listparameters.ToArray());


            if (affectRows != 0)
            {
                MessageBox.Show("保存成功");
            }

            this.Close();
        }
        #endregion


        /// <summary>
        /// 在这个子窗体中加一个函数
        /// 这个函数的实现功能时给他一个函数类型的参数，当点击保存按钮后，触发这个事件处理程序
        /// </summary>
        /// <param name="btnSaveClickMethod"></param>
        public void RegisBtnSaveClickEventMethod(EventHandler btnSaveClickMethod)
        {
            if (btnSave != null)
            {
                this.btnSave.Click += btnSaveClickMethod;
            }
        }
    }
}
