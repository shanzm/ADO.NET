using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.SqlTypes;

///涉及的数据库的连接的项目属性数据无法显示
///1.查看数据库连接字符串的变量名与配置文件的是否一致
///2.查看Sql语句
///  sql语句的语法是否正确，在数据库中进行测试
///  sql语句查询列是不是包含你要读取的列
///3.有可能是你的控件DateGridView属性被修改了，你可以删除原有的DateGridView，新建一个DateGridView
///
/// 
///this.dgvUserInfo .Rows[0].Selected = true;//默认选中DateGridView中第一行数据
///this.dgvUserInfo.ClearSelection();//清空选中绑定


namespace _15完整的数据库增删改查
{
    public partial class MainFrm : Form
    {
        //选中的行的Id
        private int SelectedId = 0;

        public MainFrm()
        {
            InitializeComponent();
        }

        private void MainFrm_Load(object sender, EventArgs e)
        {
            LoadUserInfo();
        }

        #region 1.加载数据到DateGridView
        /// <summary>
        /// 加载数据
        /// </summary>
        private void LoadUserInfo()
        {
            string sqlStr = @"SELECT [Id],[UserName],[UserPwd],[LastErrorDateTime],[ErrorTimes],[DelFlag] ,[CreateDate]FROM [db_Tome1].[dbo].[szmUserInfo] Where[DelFlag]=0 ";
            LoadUserInfoToDateGridView(sqlStr);
            //List<UserInfo> userInfoList = new List<UserInfo>();
            //string connStr = SqlHelper.GetConnStr();
            //using (SqlConnection conn = new SqlConnection(connStr))
            //{
            //    string sqlStr = @"SELECT [Id],[UserName],[UserPwd],[LastErrorDateTime],[ErrorTimes],[DelFlag] ,[CreateDate]FROM [db_Tome1].[dbo].[szmUserInfo] Where[DelFlag]=0 ";
            //    using (SqlDataAdapter adapter = new SqlDataAdapter(sqlStr, conn))
            //    {
            //        DataTable dt = new DataTable("UserInfo");
            //        adapter.Fill(dt);

            //        foreach (DataRow item in dt.Rows)
            //        {
            //            UserInfo user = new UserInfo();
            //            user.Id = int.Parse(item["id"].ToString());
            //            user.UserName = item["UserName"].ToString();
            //            user.UserPwd = item["UserPwd"].ToString();
            //            user.LastErrorDateTime = DateTime.Parse(item["LastErrorDateTime"].ToString());
            //            user.ErrorTimes = item["ErrorTimes"] == DBNull.Value ? 0 : int.Parse(item["ErrorTimes"].ToString());
            //            user.DelFlag = short.Parse(item["DelFlag"].ToString());
            //            //注意这一句代码中的SqlDateTime和MinValue
            //            user.CreateDate = DateTime.Parse(item["CreateDate"] == DBNull.Value ? SqlDateTime.MinValue.ToString() : item["CreateDate"].ToString());
            //            userInfoList.Add(user);
            //        }//end foreach
            //    }// end using adapter
            //}//end using conn
            //this.dgvUserInfo.DataSource = userInfoList;

        }
        #endregion

        #region 2.删除选中行

        /// <summary>
        /// 删除按钮
        /// DateGridView的FullColumnSelect属性改为FullColumnSelect(选中则选中整行）
        /// DateGridView的MultiSelect属性改为 False
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (this.dgvUserInfo.SelectedRows.Count <= 0)
            {
                MessageBox.Show("请选中要删除的行");
                return;
            }
            //MessageBox.Show("确认要删除吗？", "提醒消息",MessageBoxButtons .YesNo ,MessageBoxIcon.Warning );

            if (MessageBox.Show("确认要删除吗？", "提醒消息", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
            {
                return;
            }


            int deleteId = int.Parse(this.dgvUserInfo.SelectedRows[0].Cells["Id"].Value.ToString());

            string connStr = SqlHelper.GetConnStr();
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    conn.Open();
                    cmd.CommandText = @"UPDATE [db_Tome1].[dbo].[szmUserInfo]SET [DelFlag]=1 WHERE [Id]=@userId";
                    cmd.Parameters.AddWithValue("@userId", deleteId);
                    int affectRows = cmd.ExecuteNonQuery();
                    if (affectRows >= 1)
                    {
                        MessageBox.Show("删除成功");
                    }
                    //删除后重新加载数据，刷新表格
                    LoadUserInfo();
                }
            }

        }
        #endregion

        #region 3.显示修改信息在修改面板中
        /// <summary>
        /// 点击DateGridView中的行，显示数据在下面的修改面板上
        /// 注意你使用Click事件也可以，但是我们使用SelectionChanged
        /// 因为默认是选中第一行的，所以数据一加载出来，修改的面板中就有数据显示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvUserInfo_SelectionChanged(object sender, EventArgs e)
        {
            //☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆
            //一旦涉及到使用SelectionChanged，上来就做一个判断，不然索引老是出错
            if (dgvUserInfo.SelectedRows.Count <= 0)
            {
                return;
            }
            int selectedUpDateId = int.Parse(this.dgvUserInfo.SelectedRows[0].Cells["Id"].Value.ToString());
            //将选中的行的Id赋值给整个类的的字段，方便其他方法使用
            SelectedId = selectedUpDateId;
            //选择数据
            //法1.直接从DategridView中获取数据或是list中获取数据，但这样并不安全，因为协同开，你这边修改了，你家那边没法实时显示
            //法2.从数据库查询的来
            using (SqlConnection conn = new SqlConnection(SqlHelper.GetConnStr()))
            {

                using (SqlCommand cmd = conn.CreateCommand())
                {
                    conn.Open();
                    cmd.CommandText = @"SELECT [Id] ,[UserName],[UserPwd],[LastErrorDateTime],[ErrorTimes],[DelFlag],[CreateDate] FROM [db_Tome1].[dbo].[szmUserInfo]where [Id]=@Id";

                    cmd.Parameters.AddWithValue("@Id", selectedUpDateId);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            this.txtUserName.Text = reader["UserName"].ToString();
                            this.txtUserPwd.Text = reader["UserPwd"].ToString();
                        }
                    }
                }
            }




        }
        #endregion

        #region 4.主窗体操作面板-保存修改的数据

        /// <summary>
        /// 保存修改的数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {

            using (SqlConnection conn = new SqlConnection(SqlHelper.GetConnStr()))
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    conn.Open();
                    cmd.CommandText = @"UPDATE [db_Tome1].[dbo].[szmUserInfo]SET [UserName] =@Username ,[UserPwd] = @UserPwd WHERE [Id]=@Id ";

                    cmd.Parameters.AddWithValue("@UserName", txtUserName.Text.Trim());
                    cmd.Parameters.AddWithValue("@UserPwd", txtUserPwd.Text.Trim().Replace(" ", ""));//注意Trim()只能去除字符串前后的空格，使用Replace (" ","")是为了出去字符串中的空格   
                    cmd.Parameters.AddWithValue("@Id", SelectedId);

                    if (cmd.ExecuteNonQuery() >= 0)
                    {
                        MessageBox.Show("保存成功！");
                    }
                }
            } 
            //LoadUserInfo();
            //我们想在查询后，做修改，点保存按钮后，我们还是只显示查询出来的行，所以不使用数据加载函数LoadUserInfo()来刷新窗口
            //而是调用查询按钮的代码，我们没有给查询按钮的查询代码封装，但是我们直接在这里模拟点击按钮一下就可以了
            //注意输入的参数(this,null)
            btnSearch_Click(this,null);
        }
        #endregion

        #region 5.双击数据行弹出修改窗口，实现修改

        private void dgvUserInfo_DoubleClick(object sender, EventArgs e)
        {
            if (this.dgvUserInfo.SelectedRows.Count <= 0)
            {
                return;
            }

            //拿到修改行数据的Id
            int editRowId = int.Parse(this.dgvUserInfo.SelectedRows[0].Cells["Id"].Value.ToString());
            //新建一个UserInfo对象，把这个对象的Id初始化，之后把整个对象作为我们自己修改的EditFrm的构造函数的参数，弹出修改窗口，并把要修改的行的Id传到EditFrm窗口
            UserInfo userInfo = new UserInfo() { Id = editRowId };
            EditUserInfoFrm editFrm = new EditUserInfoFrm(userInfo);//在新建editFrm时，通过构造将数据从MainFrm传到EditFrm中

            //为 editFrm窗体的FormClosing事件绑定事件处理程序,
            //注意FormClosing表示窗体关闭前发生，FormClosed表示窗体关闭后发生
            editFrm.FormClosing += editFrm_FromClosing;


            //☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆
            //给editFrm窗口的点击保存按钮事件注册一个方法---------------（这里只是为了演示）
            editFrm.RegisBtnSaveClickEventMethod(MainFrm_AfterEditFrmBtnSaveClick);

            editFrm.Show();


        }

        #region 作为参数的函数

        /// <summary>
        /// 这个函数是绑定EditFrm窗口Closing事件的
        /// 实现：一旦用户点击关闭EditFrm时就会在主窗口中刷新DateGridView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void editFrm_FromClosing(object sender, FormClosingEventArgs e)
        {
            LoadUserInfo();
        }



        /// <summary>
        /// 这个函数是为了给点击子窗口EditFrm的保存按钮事件RegisBtnSaveClickEventMethod作参数的事件处理程序
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void MainFrm_AfterEditFrmBtnSaveClick(object sender, EventArgs e)
        {
            MessageBox.Show("这是你点击保存按钮所响应的事假处理程序");
        }

        #endregion



        #endregion

        #region 6.查询
        /// <summary>
        /// 实现查询按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            ///这段代码是查询非常规范的写法，其实就是对Sql语句中的where条件语句进行拼接
            ///举个例子，最终我们想要的是这样的Sql语句
            ///SELECT [Id],[UserName],[UserPwd],[LastErrorDateTime],[ErrorTimes],[DelFlag],[CreateDate] FROM [db_Tome1].[dbo].[szmUserInfo]   WHERE UserName LIKE '%1%' AND UserPwd LIKE '%23%'

            #region Sql查询语句的拼接
            string sqlStr = @"SELECT [Id],[UserName],[UserPwd],[LastErrorDateTime],[ErrorTimes],[DelFlag],[CreateDate] FROM [db_Tome1].[dbo].[szmUserInfo] where [DelFlag] = 0";
            List<string> whereList = new List<string>();
            List<SqlParameter> parameterList = new List<SqlParameter>();
            if (!string.IsNullOrEmpty(this.txtSearchName.Text.Trim()))
            {
                whereList.Add(" UserName like @UserName ");//注意在两端留下空格，不然拼接为Sql语句后不对
                SqlParameter parameter = new SqlParameter();
                parameter.ParameterName = "@UserName";
                parameter.Value = "%" + txtSearchName.Text.Trim() + "%";
                parameterList.Add(parameter);
            }

            if (!string.IsNullOrEmpty(this.txtSearchPwd.Text.Trim()))
            {
                whereList.Add("  UserPwd like @UserPwd  ");//注意在两端留下空格，不然拼接为Sql语句后不对
                SqlParameter parameter = new SqlParameter();
                parameter.ParameterName = "@UserPwd";
                parameter.Value = "%" + txtSearchPwd.Text.Trim() + "%";
                parameterList.Add(parameter);
            }
            ///如果还有其他查询条件，按照这个if的样子接着写



            if (whereList.Count > 0)
            {
                sqlStr += " and " + string.Join("and", whereList);
            }


            #endregion

            // 查询后把结果显示在DateGridView中
            LoadUserInfoToDateGridView(sqlStr, parameterList.ToArray());
            


        }

        /// <summary>
        /// 加载数据到DategridView中,
        /// ☆☆☆☆☆☆☆☆重构提取构造函数后，我把集合型参数改为了数组行，因为你可以把源代码中的集合.ToArray()
        /// ☆☆☆☆☆☆☆☆注意我在SqlParameter[] parameterList前加了关键字params,为啥，为了高效利用，
        /// ☆☆☆☆☆☆☆☆我在一开始加载数据函数LoadUserInfo中调用这个函数，但是没有给SqlParameter[] parameterList这个参数赋值，就因为前面有关键字params
        /// </summary>
        /// <param name="sqlStr"></param>
        /// <param name="parameterList"></param>
        private void LoadUserInfoToDateGridView(string sqlStr,  params SqlParameter[] parameterList)
        {
            string conn = SqlHelper.GetConnStr();
            List<UserInfo> userInfoList = new List<UserInfo>();
             
            using (SqlDataAdapter adapter = new SqlDataAdapter( sqlStr, conn))
            {
                //☆☆☆☆☆☆☆☆☆☆注意adapter的使用，给SqlStr语句中的参数赋值☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆
                adapter.SelectCommand.Parameters.AddRange(parameterList);

                DataTable dt = new DataTable();
                adapter.Fill(dt);

                if (dt == null)
                {
                    return;
                }

                foreach (DataRow item in dt.Rows)
                {
                    UserInfo user = new UserInfo();
                    user.Id = int.Parse(item["id"].ToString());
                    user.UserName = item["UserName"].ToString();
                    user.UserPwd = item["UserPwd"].ToString();
                    user.LastErrorDateTime = DateTime.Parse(item["LastErrorDateTime"].ToString());
                    user.ErrorTimes = item["ErrorTimes"] == DBNull.Value ? 0 : int.Parse(item["ErrorTimes"].ToString());
                    user.DelFlag = short.Parse(item["DelFlag"].ToString());
                    //注意这一句代码中的SqlDateTime和MinValue
                    user.CreateDate = DateTime.Parse(item["CreateDate"] == DBNull.Value ? SqlDateTime.MinValue.ToString() : item["CreateDate"].ToString());
                    userInfoList.Add(user);
                }//end foreach
                this.dgvUserInfo.DataSource = userInfoList;
            } this.dgvUserInfo.DataSource = userInfoList;
        }
        #endregion





    }
}
