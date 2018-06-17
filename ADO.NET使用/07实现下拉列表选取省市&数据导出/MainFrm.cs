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
using System.IO;

///该项目中我们使用了一个新的sql命令执行方法ExecuteReader();
///cmd.ExecuteReader();他返回的是reader指针指向的行的数据
///注意ExecuteNoQuery为执行非查询命令，比如插入，删除等，返回值是受影响的行数
///注意ExecuteScalar查询结果返回的结果的第一个单元格的数值



///此项目中所使用的数据库中的表示AreaFull，你要去看这个表的构成，方便你理解代码
///AreaPid=0的是省份，市后面的AreaPid=的数字是他所在省份的AreaId
///这个表的创建文件AreaFull.sql，我已经放在本项目的DeBug文件夹中，方便项目移植时重新建立这个表



namespace _07实现下拉列表选取省市
{
    public partial class MainFrm : Form
    {
        public MainFrm()
        {
            InitializeComponent();

            #region 1.加载MainFrm时加载省的下拉列表
            string connStr = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    conn.Open();
                    cmd.Connection = conn;
                    //该sql查询语句是在选择表中的省份
                    cmd.CommandText = @"SELECT [AreaId],[AreaName],[AreaPid]FROM [db_Tome1].[dbo].[AreaFull] WHERE AreaPid=0";

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        // reader.Read()是行指针，第一次执行时指向第一行,当指向最后一行的后一行返回一个False
                        while (reader.Read())
                        {
                            //我们在此处新建一个类，把表中的每一行的数据作为这个类的属性
                            //这样我们就把表中的每一行存储为这个类的一个对象
                            AreaInfo areaInfo = new AreaInfo();
                            //注意，reader["AreaId"]返回的是当前指针指向的行的AreaId列的值
                            areaInfo.AreaId = int.Parse(reader["AreaId"].ToString());
                            areaInfo.AreaName = reader["AreaName"].ToString();
                            areaInfo.AreaPid = int.Parse(reader["AreaPid"].ToString());

                            //注意此处我们给cbxProvince.Items添加的是一个 AreaInfo的对象
                            //但是你要知道我们把AreaInfo类中的ToString ()函数重写了，
                            //我们使ToString()返回属性AreaName ，
                            //所以cbxProvince.Items.Add添加后显示的是AreaName
                            this.cbxProvince.Items.Add(areaInfo);
                        }//end while 
                    }//end using reader
                }//end using cmd
            }//end using conn

            this.cbxProvince.SelectedIndex = 0;//数据加载结束之后，我设置下拉表的默认选中项为第1项 
            #endregion
        }


        #region 2.选中省份后生成市的下拉表
        /// <summary>
        /// 选中省份后生成市的下拉表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        // private void cbxCity_SelectedIndexChanged(object sender, EventArgs e)
        private void cbxProvince_SelectedIndexChanged(object sender, EventArgs e)
        {
            //this.cbxProvince.SelectedItem 我们装的可是AreaInfo对象

            AreaInfo provinceAreaInfo = this.cbxProvince.SelectedItem as AreaInfo;
            //注意我们使用的判断语句是provinceAreaInfo ==null
            //当然我们也可以使用provinceAreaInfo !=null，然后在if的大括号中写我们想要执行的代码
            //但是我们为什么不这样呢？是因为我们为了减少代码的嵌套
            if (provinceAreaInfo == null)
            {
                return;
            }

            //下面这些代码和省份的是一样的，除了Sql查询语句不一样
            string connStr = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    conn.Open();
                    cmd.Connection = conn;
                    //根据选择的省份的对象provinceAreaInfo，的AreaPid 查询市
                    cmd.CommandText = string.Format("SELECT [AreaId],[AreaName],[AreaPid]FROM [db_Tome1].[dbo].[AreaFull] WHERE AreaPid={0}", provinceAreaInfo.AreaId);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        this.cbxCity.Items.Clear();

                        while (reader.Read())
                        {
                            AreaInfo areaInfo = new AreaInfo();
                            //注意，reader["AreaId"]返回的是当前指针指向的行的AreaId列的值
                            areaInfo.AreaId = int.Parse(reader["AreaId"].ToString());
                            areaInfo.AreaName = reader["AreaName"].ToString();
                            areaInfo.AreaPid = int.Parse(reader["AreaPid"].ToString());

                            this.cbxCity.Items.Add(areaInfo);

                        }//end while 
                    }//end using reader
                }//end using cmd
            }//end using conn

            this.cbxCity.SelectedIndex = 0;//设置下拉表的默认选中项为第1项
        }
        #endregion



        #region 3.从数据库查询数据写入到本地文件
        /// <summary>
        /// 从数据库查询数据写入到本地文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExport_Click(object sender, EventArgs e)
        {
            #region 1.让用户选择保存的路径
            //让用户选择保存的路径
            string fileName = string.Empty;
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Title = "选择文件保存路径";
                sfd.Filter = "文本文档|*.txt";

                if (sfd.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                fileName = sfd.FileName;
            }
            #endregion




            #region 2.实现数据的写入本地文件
            string connStr = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    conn.Open();
                    cmd.Connection = conn;
                    cmd.CommandText = "SELECT  [AreaId],[AreaName],[AreaPid]  FROM [db_Tome1].[dbo].[AreaFull] ";


                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        using (StreamWriter sWriter = new StreamWriter(fileName))
                        {

                            string temp = string.Empty;
                            while (reader.Read())
                            {
                                temp = reader["AreaId"] + "," + reader["AreaName"] + "," + reader["AreaPid"];

                                sWriter.WriteLine(temp);
                            }// end while 

                        }//end using sWriter
                    }// end using reader
                }//end using cmd
            }// end using conn 
            #endregion
        } 
        #endregion




    }
}
