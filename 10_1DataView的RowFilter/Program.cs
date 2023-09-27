using System;
using System.Data;
using System.Text;

namespace _10_1DataView的RowFilter
{
    internal class Program
    {
        //参考：DataView RowFilter 的语法：https://blog.csdn.net/lingxyd_0/article/details/44490351
        //DataView和DataTable的区别、联系、以及相互转化方法:https://blog.csdn.net/sihsd/article/details/104096324

        private static void Main(string[] args)
        {
            //TestToTable();
            TestColumnFilter();

            Console.ReadKey();
        }

        //1.关于DataView的ToTable()和Table属性
        //参考：https://blog.csdn.net/sihsd/article/details/104096324
        private static void TestToTable()
        {
            DataTable dt = GetDataTable();
            DataView dataView = dt.DefaultView;
            dataView.RowFilter = "Id=6";
            //DataView的Table属性获取的该DataView原始数据源
            PrintDataTable(dataView.Table, "dataView.Table");

            //DataView的ToTable方法获取的是DataView经过了RowFilter的数据（即：根据现有的DataView中的数据创建一个新的DataTable）
            PrintDataTable(dataView.ToTable(), "dataView.ToTable()");

            dataView.RowFilter = "";
            //注意：★dataView.ToTable()是根据最近一次的rowFilter对原始数据筛选的结果创建DataTable
            //这里我需要对原始数据去重并创建一个新的Datatable，所以我将rowFilter=""置空
            //DataView的ToTable方法可以去重创建DataTable
            PrintDataTable(dataView.ToTable(true), "对当前DataView去重并创建一个DataTable");

            //DataView的ToTable方法可以选择指定的字段创建DataTbale
            PrintDataTable(dataView.ToTable(false, new string[] { "Name", "Age" }), "选择指定字段创建一个DataTable");
        }

        //2.关于对指定列进行筛选：筛选表达式的基本语法和SQL语法相似
        private static void TestColumnFilter()
        {
            DataTable dt = GetDataTable();
            DataView dataView = dt.DefaultView;

            //1.列名中有特殊字符则可以将列名使用[]包裹
            dataView.RowFilter = "Id=4 AND [Name]='赵六'";
            PrintDataTable(dataView.ToTable(), "Id=4 AND [Name]='赵六'");

            //2.列值是字符串类型，则值需要使用单引号包裹
            //列值中包含单引号，则需要替换为两个单引号''
            dataView.RowFilter = $"Name='{"''张三''"}'";
            dataView.RowFilter = $"Name='{"'张三'".Replace("'", "''")}'";
            PrintDataTable(dataView.ToTable(), $"Name='{"''张三''"}'");

            //3.列值是时间，则使用##或''
            dataView.RowFilter = $"CreateTime=#{"2023-8-27 20:10:00"}#";
            dataView.RowFilter = $"CreateTime='2023-8-27 20:10:00'";
            PrintDataTable(dataView.ToTable(), $"CreateTime=#{"2023-8-27 20:10:00"}#");

            //4.运行符In
            dataView.RowFilter = $"Id IN (1,2) OR CreateTime IN ('2023-7-27 20:10:00')";
            PrintDataTable(dataView.ToTable(), $"Id IN (1,2) OR CreateTime IN ('2023-7-27 20:10:00')");

            //5.运行符Like
            dataView.RowFilter = $"Name like '%钱%' OR Name like '孙*'";
            PrintDataTable(dataView.ToTable(), $"Name like '%钱%' OR Name like '孙*'");

            //6.Boolean运行符
            dataView.RowFilter = $"Age>=19 And Name <> '钱七' And Id Not In (6)";
            PrintDataTable(dataView.ToTable(), $"Age>=19 And Name <> '钱七' And Id Not In (6)");

            //7.算术运算符
            dataView.RowFilter = $"Age+10>30";
            PrintDataTable(dataView.ToTable(), $"Age+10>30");

            //8.
        }

        //构建测试数据源
        private static DataTable GetDataTable()
        {
            DataTable dt = new DataTable("Student");
            DataColumn dcId = new DataColumn("Id", typeof(int));
            DataColumn dcName = new DataColumn("Name", typeof(string));
            DataColumn dcAge = new DataColumn("Age", typeof(int));
            DataColumn dcGender = new DataColumn("Gender", typeof(bool));
            DataColumn dcCreateTime = new DataColumn("CreateTime", typeof(DateTime));
            DataColumn[] dataColumns = new DataColumn[] { dcId, dcName, dcAge, dcGender, dcCreateTime };
            dt.Columns.AddRange(dataColumns);

            dt.Rows.Add(1, "'张三'", 17, false, "2023-9-27 20:10:00");
            dt.Rows.Add(2, "李四", 18, true, "2023-8-27 20:10:00");
            dt.Rows.Add(3, "王五", 19, false, "2023-7-27 20:10:00");
            dt.Rows.Add(4, "赵六", 19, true, "2023-6-27 20:10:00");
            dt.Rows.Add(5, "钱七", 20, false, "2023-5-27 20:10:00");
            dt.Rows.Add(6, "孙八", 21, false, "2023-4-27 20:10:00");
            dt.Rows.Add(6, "孙八", 21, false, "2023-4-27 20:10:00");

            return dt;
        }

        #region 打印DataTable辅助函数

        /// <summary>
        /// 控制台输出DataTable
        /// </summary>
        /// <param name="dt">目标DataTable</param>
        /// <param name="title">DataTable的标题</param>
        private static void PrintDataTable(DataTable dt, string title)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{title}");
            //拼接列头
            string colName = "";
            foreach (DataColumn column in dt.Columns)
            {
                colName += "|" + PadRightEx(column.ColumnName, 20);
            }
            Console.WriteLine(colName);
            Console.WriteLine("--------------------------------------------------------------------------------------------------------");

            //循环打印每一行
            foreach (DataRow row in dt.Rows)
            {
                //拼接行数据
                string strRow = "";
                foreach (var item in row.ItemArray)
                {
                    strRow += "|" + PadRightEx(item.ToString(), 20);
                }
                Console.WriteLine(strRow);
            }
            Console.WriteLine("");
        }

        /// <summary>
        /// 用空格将字符串拼接到指定的长度
        /// 参考：https://www.cnblogs.com/chenjiahong/articles/2705437.html
        /// 中文和英文字符占位宽度不一样，进行调整
        /// </summary>
        /// <param name="str">目标字符串</param>
        /// <param name="totalByteCount">拼接后的字符串长度</param>
        /// <returns></returns>
        private static string PadRightEx(string str, int totalByteCount)
        {
            Encoding coding = Encoding.GetEncoding("gb2312");
            int dcount = 0;
            foreach (char ch in str.ToCharArray())
            {
                if (coding.GetByteCount(ch.ToString()) == 2)
                    dcount++;
            }
            string w = str.PadRight(totalByteCount - dcount);
            return w;
        }

        #endregion
    }
}