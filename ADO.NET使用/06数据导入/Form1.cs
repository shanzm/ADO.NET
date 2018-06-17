using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;
using System.Configuration;

namespace _06数据导入
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 文件选择窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOpen_Click(object sender, EventArgs e)
        {
            //注意此处我们使用OpenFIleDialog是使用using的，为了快速释放资源
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "文本文档|*.txt";
                ofd.Title = "选择数据文件";
                //注意我把弹出选择文件的窗口设置为当前项目程序集的窗口，只是因为我把数据文件放到那里了，没有其他原因
                ofd.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory;
                //ofd.ShowDialog();//因为我们下面使用了ofd.ShowDialog() == DialogResult.OK

                //如果选中文件
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    this.txtFileName.Text = Path.GetFileName(ofd.FileName);//注意在OpenFileDialog中FileName是指选中文件的全路径。而非文件名
                    ImportData(ofd.FileName);
                    MessageBox.Show("插入成功！");

                }
            }
        }

        /// <summary>
        /// 数据文件的读取和输入到数据库
        /// </summary>
        /// <param name="fileName"></param>
        private void ImportData(string fileName)
        {
            using (StreamReader sReader = new StreamReader(fileName, Encoding.Default))
            {
                string temp = string.Empty;
                sReader.ReadLine();//读取数据文件的第一行（列名）,这样就相当于去掉了第一行

                //string connStr = "server=.;database=db_Tome1;uid=sa;pwd=shanzm";
                string connStr = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        conn.Open();
                        cmd.Connection = conn;
                        
                        int affectRows = 0;//用来计算受影响的行数
                        while (!string.IsNullOrEmpty(temp = sReader.ReadLine()))
                        {
                            //注意我们使用的是var,var可以理解为匿名类型，我们可以认为它是一个声明变量的占位符。
                            //它主要用于在声明变量时，无法确定数据类型时使用。
                            //在此处其实就是String[]
                            var dataItem = temp.Split(',');
                            //注意 我们在表中的Id列是表示规范，所以是自动生成
                            string sqlCmd = string.Format("insert into szmDemo(Name,Address)values('{0}','{1}')", dataItem[1], dataItem[2]);
                            cmd.CommandText = sqlCmd;
                            cmd.ExecuteNonQuery();
                            affectRows++;

                        }//end while
                        MessageBox.Show(affectRows + "行受影响！");
                    }// end using cmd

                }//end using conn

            }//end using sReader
        }
    }
}
