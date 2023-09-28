using System;
using System.Data;

namespace _10_1DataView的RowFilter
{
    public static class Test
    {
        public static void DemonstrateRowVersion()
        {
            DataTable dtStudent = GetDataTable();
            dtStudent.AcceptChanges();

            Printer.PrintDataTable(dtStudent, "原始数据源Student表");

            //基于Student表创建一个视图
            DataView dataView = new DataView(dtStudent);
            //修改
            dtStudent.Rows[1]["Name"] = "小张";
            //新增
            dtStudent.Rows.Add("8", "小王");
            //删除
            dtStudent.Rows[2].Delete();

            //获取修改的row
            dataView.RowStateFilter = DataViewRowState.ModifiedCurrent;
            Printer.PrintDataTable(dataView.ToTable(), "这是修改了的row");
            //获取删除的row
            dataView.RowStateFilter = DataViewRowState.Deleted;
            Printer.PrintDataTable(dataView.ToTable(), "这是删除了的row");
            //获取新增的row
            dataView.RowStateFilter = DataViewRowState.Added;
            Printer.PrintDataTable(dataView.ToTable(), "这是新增的row");

            // Set filter to display only originals of modified rows.
            //dataView.RowStateFilter = DataViewRowState.ModifiedOriginal;
            //PrintView(dataView, "ModifiedOriginal");

            //// Delete three rows.
            //dtStudent.Rows[1].Delete();
            //dtStudent.Rows[2].Delete();
            //dtStudent.Rows[3].Delete();

            //// Set the RowStateFilter to display only deleted rows.
            //dataView.RowStateFilter = DataViewRowState.Deleted;
            //PrintView(dataView, "Deleted");

            //// Set filter to display only current rows.
            //dataView.RowStateFilter = DataViewRowState.CurrentRows;
            //PrintView(dataView, "Current");

            //// Set filter to display only unchanged rows.
            //dataView.RowStateFilter = DataViewRowState.Unchanged;
            //PrintView(dataView, "Unchanged");

            //// Set filter to display only original rows.
            //// Current values of unmodified rows are also returned.
            //dataView.RowStateFilter = DataViewRowState.OriginalRows;
            //PrintView(dataView, "OriginalRows");
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
