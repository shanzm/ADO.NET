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
using System.IO;
using System.Xml;



///注意参照以前使用Dom模式创建Xml
///数据库中的表生成文件AreaFull.sql，我放在Debug文件中了



namespace _08数据导出到xml文件
{
    public partial class MainFrm : Form
    {
        public MainFrm()
        {
            InitializeComponent();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            #region 1.使用SaveFileDiaLog选择保存路径
            string fileName = string.Empty;
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Title = "选择保存路径";
                sfd.Filter = "Xml|*.xml";
                //☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆这是注意设置要保存的文件的默认文件名
                sfd.FileName = "AreaInfo.xml";//虽然只是给了文件的默认名，但是是自动生成全路径的
                if (sfd.ShowDialog() != DialogResult.OK)
                {
                    return;
                }
                fileName = sfd.FileName;//获取的是全路径

            } 
            #endregion

            #region 2.从数据库查询数据写入XML
            string connStr = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlCommand cmd = conn.CreateCommand ())//new SqlCommand())
                {
                    conn.Open();
                    //cmd.Connection = conn;

                    cmd.CommandText = "SELECT  [AreaId],[AreaName],[AreaPid] FROM [db_Tome1].[dbo].[AreaFull]";

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {

                        XmlDocument doc = new XmlDocument();
                        XmlDeclaration dec = doc.CreateXmlDeclaration("1.0", "utf-8", null);

                        doc.AppendChild(dec);

                        XmlElement Areas = doc.CreateElement("Areas");
                        doc.AppendChild(Areas);

                        while (reader.Read())
                        {
                            //注意我们是使用DOM的方式写入到XML文件的
                            //所以我们新建了一个AreaInfo类
                            int areaId = int.Parse(reader["AreaId"].ToString());
                            string areaName = reader["AreaName"].ToString();
                            int areaPid = int.Parse(reader["AreaPid"].ToString());
                            AreaInfo temp = new AreaInfo(areaId, areaName, areaPid);

                            
                            XmlElement Area = doc.CreateElement("Area");
                            Area.SetAttribute("ID", temp.AreaId.ToString());
                            Areas.AppendChild(Area);

                            XmlElement AreaName = doc.CreateElement("AreaName");
                            AreaName.InnerXml = temp.AreaName;
                            Area.AppendChild(AreaName);

                            XmlElement AreaPid = doc.CreateElement("AreaPid");
                            AreaPid.InnerXml = temp.AreaPid.ToString();
                            Area.AppendChild(AreaPid);

                        }
                        doc.Save(fileName);//注意这个fileName 是全路径，包括了文件的名字
                        MessageBox.Show("保存成功！");
                    }//end using reader
                }//end using cmd
            }//end using conn 
            #endregion
        }
    }
}
