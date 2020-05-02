using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace _10DataSet和DataTable
{
    class Program
    {
        static void Main(string[] args)
        {
            //新建一个数据集，名字就叫ds
            DataSet ds = new DataSet("ds");

            #region 表dt1

            //新建一个内存表，名字叫dt1
            DataTable dt1 = new DataTable("dt1");

            //把内存表放到数据集之中
            ds.Tables.Add(dt1);

            //新建列
            DataColumn dcName = new DataColumn("Name", typeof(string));
            DataColumn dcAge = new DataColumn("Age", typeof(int));
            DataColumn dcId = new DataColumn("Id", typeof(int));

            //把列放到表中
            dt1.Columns.AddRange(new DataColumn[] { dcId, dcName, dcAge });

            //给表按行添加数据
            dt1.Rows.Add(1, "张三", 24);
            dt1.Rows.Add(2, "李四", 24);
            dt1.Rows.Add(3, "王五", 24); 
            #endregion


            #region 表dt2

            //新建一个内存表，名字叫dt1
            DataTable dt2 = new DataTable("dt2");

            //把内存表放到数据集之中
            ds.Tables.Add(dt2);

            //新建列
            DataColumn dcName2 = new DataColumn("Name", typeof(string));
            DataColumn dcAge2 = new DataColumn("Age", typeof(int));
            DataColumn dcId2 = new DataColumn("Id", typeof(int));

            //把列放到表中
            dt2.Columns.AddRange(new DataColumn[] { dcId2, dcName2, dcAge2 });

            //给表按行添加数据
            dt2.Rows.Add(1, "张三2", 23);
            dt2.Rows.Add(2, "李四2", 24);
            dt2.Rows.Add(3, "王五2", 25);
            #endregion


            //打印数据集，先循环数据集的每个表再循环每个表的行
            foreach (DataTable  tb in ds.Tables  )
            {
                foreach (DataRow  dr in tb.Rows  )
                {
                    Console.WriteLine("{0}--{1}--{2}",dr[0],dr[1],dr[2]);
                    
                }
            }
            Console.ReadKey();
        }
    }
}
