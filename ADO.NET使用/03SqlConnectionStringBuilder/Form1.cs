using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace _03SqlConnectionStringBuilder
{
    public partial class MainFrm : Form
    {
        ///注意这个项目中使用的对象名
        ///conn是connection的缩写，表示连接
        ///4表示for
        ///prop是property的缩写，表示属性


        ///☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆
        ///这个winform项目中新学习了PropertyGrid控件
        ///学习了生成的文本直接默认复制到剪切板
        ///☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆

        public MainFrm()
        {
            InitializeComponent();
            SqlConnectionStringBuilder scsb = new SqlConnectionStringBuilder();
            this.propGrid4ConnString.SelectedObject = scsb;
           // 设置默认值
            scsb.UserID = "sa";//默认登录账号sa
            scsb.Password = "请输入密码";//默认密码
            scsb.DataSource = ".";//默认服务器为本机
            scsb.InitialCatalog = "请输入数据库名";//数据库名
            scsb.Pooling = true;//默认打开连接池
            scsb.MinPoolSize = 4;//默认连接池最小为4

        }

        /// <summary>
        /// 生成数据库的连接语句
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGetConnString_Click(object sender, EventArgs e)
        {
            string connString = this.propGrid4ConnString.SelectedObject.ToString();
            
            Clipboard.Clear ();//清空剪切板
            Clipboard .SetText(connString );

            MessageBox.Show ("已经复制到剪切板\n"+connString );
        }
    }
}
