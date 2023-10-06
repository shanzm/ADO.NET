using System;
using System.Data;
using System.Text;

namespace _10_1DataView的RowFilter
{
    public static class Printer
    {
        /// <summary>
        /// 控制台输出DataTable
        /// </summary>
        /// <param name="dt">目标DataTable</param>
        /// <param name="title">DataTable的标题</param>
        public static void PrintDataTable(DataTable dt, string title)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{title}");
            if (dt == null)
            {
                return;
            }
            //拼接列头
            string colName = "";
            foreach (DataColumn column in dt.Columns)
            {
                colName += "| " + PadRightEx(column.ColumnName, 20);
            }
            Console.WriteLine(colName);
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------");

            //循环打印每一行
            foreach (DataRow row in dt.Rows)
            {
                //跳过删除的行（否则报错："不能通过已删除的行访问该行的信息"）
                if (row.RowState == DataRowState.Deleted)
                {
                    continue;
                }

                //拼接行数据
                string strRow = "";
                foreach (object item in row.ItemArray)
                {
                    strRow += "| " + PadRightEx(item.ToString(), 20);
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
        public static string PadRightEx(string str, int totalByteCount)
        {
            Encoding coding = Encoding.GetEncoding("gb2312");
            int dcount = 0;
            foreach (char ch in str.ToCharArray())
            {
                if (coding.GetByteCount(ch.ToString()) == 2)
                {
                    dcount++;
                }
            }
            string w = str.PadRight(totalByteCount - dcount);
            return w;
        }
    }
}
