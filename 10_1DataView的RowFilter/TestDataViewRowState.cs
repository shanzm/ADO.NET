using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Reflection;

namespace _10_1DataView的RowFilter
{
    public static class TestDataViewRowState
    {
        //参考：https://learn.microsoft.com/zh-cn/dotnet/api/system.data.datarowview?view=net-6.0
        //参考：https://www.cnblogs.com/vaevvaev/p/6815274.html
        public static void Test()
        {
            DataTable dtStudent = GetDataTable();
            //这里若是不AcceptChanges(),则下面获取DataViewRowState.OriginalRows状态的数据为空
            dtStudent.AcceptChanges();

            Console.WriteLine(dtStudent);

            Printer.PrintDataTable(dtStudent, "原始数据源Student表");

            //基于Student表创建一个视图
            DataView dataView = new DataView(dtStudent);
            //修改
            dtStudent.Rows[1]["Name"] = "小张";
            //新增
            dtStudent.Rows.Add("8", "小王");
            //删除
            dtStudent.Rows[2].Delete();

            //打印所有修改了的行数据（包括新增和修改，不包括删除）
            Printer.PrintDataTable(dtStudent.GetChanges(), "GetChange()");

            //获取修改的row
            dataView.RowStateFilter = DataViewRowState.ModifiedCurrent;
            Printer.PrintDataTable(dataView.ToTable(), "这是修改了的row");
            //获取删除的row
            dataView.RowStateFilter = DataViewRowState.Deleted;
            Printer.PrintDataTable(dataView.ToTable(), "这是删除了的row");
            //获取新增的row
            dataView.RowStateFilter = DataViewRowState.Added;
            Printer.PrintDataTable(dataView.ToTable(), "这是新增的row");
            //获取未增删改查的原始数据
            dataView.RowStateFilter = DataViewRowState.OriginalRows;
            Printer.PrintDataTable(dataView.ToTable(), "获取Datatable原始数据");

            //接收所有的修改（即将所有的的DataRowState更新为Unchanged）
            dtStudent.AcceptChanges();
            //一旦AcceptChanges后,Datatable.GetChanges()为空
            Printer.PrintDataTable(dtStudent.GetChanges(), "AcceptChangeds()");

            Printer.PrintDataTable(dtStudent, "最终的数据");

            //说明：这里完整的展示了DataViewRowState的各种状态
            //那么这种状态到底是用在什么场景下，在使用OleDB访问数据库的时候，
            //可以直接将带有状态的DataTable作为参数进行Update()操作，
            //会自动对Deleted状态的进行删除，Modified进行更新，Added进行插入
            //OleDbDataAdapter oleDbDataAdapter = new OleDbDataAdapter();
            //oleDbDataAdapter.Update(dtStudent);

            //关于AdO 和 OleDb的区分：
            //参考：https://www.cnblogs.com/liuzhendong/archive/2012/01/29/2331189.html
            //OleDb是基于COM 实现的数据库访问层，可以对多种数据源（多种数据库）
            //ADO 则是对Ole Db 的封装（准确的说只封装了一个子集）,从而简化了对OleDb的Api调用方式

            //ADO.NET和ADO也不同的，简单说就是ADO.NET是基于.net重新实现的一套数据库访问技术，而非COM技术
            //ADO.NET中有五大对象：Connection对象、 Command对象、DataReader对象、DataApdapter对象和DataSet对象
            //ADO.NET支持多种数据库，比如说SqlConnection则对SQL server的连接，而OracleConnection则是对Oracle的连接
        }

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

            //设置主键列
            dt.PrimaryKey = new DataColumn[] { dcId };

            dt.Rows.Add(1, "'张三'", 17, false, "2023-9-27 20:10:00");
            dt.Rows.Add(2, "李四", 18, true, "2023-8-27 20:10:00");
            dt.Rows.Add(3, "王五", 19, false, "2023-7-27 20:10:00");
            dt.Rows.Add(4, "赵六", 19, true, "2023-6-27 20:10:00");
            dt.Rows.Add(5, "钱七", 20, false, "2023-5-27 20:10:00");
            dt.Rows.Add(6, "孙八", 21, false, "2023-4-27 20:10:00");
            dt.Rows.Add(7, "孙八", 21, false, "2023-4-27 20:10:00");

            return dt;
        }
    }
}
