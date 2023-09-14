using System;
using System.Data;

namespace _10_1DataView的RowFilter
{
    internal class Program
    {
        //参考：DataView RowFilter 的语法：https://blog.csdn.net/lingxyd_0/article/details/44490351
        private static void Main(string[] args)
        {
            DataView dataView = GetDataTable().DefaultView;

            dataView.RowFilter = "Id=5";
            PrintDataTable(dataView.ToTable());
            PrintDataTable(dataView.Table);
            //注意区分：ToTable()和Table
            //DataView和DataTable的区别、联系、以及相互转化方法:https://blog.csdn.net/sihsd/article/details/104096324
            Console.ReadKey();
        }

        //构建测试数据源

        private static DataTable GetDataTable()
        {
            DataTable dt = new DataTable("Student");
            DataColumn dcId = new DataColumn("Id", typeof(int));
            DataColumn dcName = new DataColumn("Name", typeof(string));
            DataColumn dcAge = new DataColumn("Age", typeof(int));
            DataColumn dcGender = new DataColumn("Gender", typeof(bool));

            DataColumn[] dataColumns = new DataColumn[] { dcId, dcName, dcAge, dcGender };
            dt.Columns.AddRange(dataColumns);

            for (int i = 0; i < 20; i++)
            {
                DataRow row = dt.NewRow();
                row["Id"] = i;
                row["Name"] = "学生" + i;
                row["Age"] = 10 + i;
                row["Gender"] = i % 2 == 0;
                dt.Rows.Add(row);
            }

            return dt;
        }

        private static void PrintDataTable(DataTable dt)
        {
            foreach (DataRow row in dt.Rows)
            {
                Console.WriteLine($"Id:{row[0]}---Name:{row[1]}---Age:{row[2]}----Gender:{row[3]}");
            }
        }
    }
}