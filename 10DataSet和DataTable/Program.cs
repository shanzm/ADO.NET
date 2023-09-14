using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace _10DataSet和DataTable
{
    internal class Program
    {
        private static void Main(string[] args)
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
            foreach (DataTable tb in ds.Tables)
            {
                foreach (DataRow dr in tb.Rows)
                {
                    Console.WriteLine("{0}--{1}--{2}", dr[0], dr[1], dr[2]);
                }
            }

            #region 案例：用于熟悉DataTable中的各个对象

            //先来建立ds数据库
            DataSet myds = new DataSet("ds");
            //再来建立tbClass和tbStudent两个数据表
            DataTable tbClass = new DataTable("tbClass");
            DataTable tbStudent = new DataTable("tbStudent");
            //把两个数据表tbClass和tbStudent加入数据库
            ds.Tables.Add(tbClass);
            ds.Tables.Add(tbStudent);

            //建立tbClass两列
            DataColumn ClassID = new DataColumn("ClassID", typeof(System.String));
            DataColumn ClassName = new DataColumn("ClassName", typeof(System.String));
            //设定ClassID列不允许为空
            ClassID.AllowDBNull = false;
            //把列加入tbClass表
            tbClass.Columns.Add(ClassID);
            tbClass.Columns.Add(ClassName);
            //设定tdClass表的主键
            tbClass.PrimaryKey = new DataColumn[] { ClassID };

            //建立tbStudent的三列
            DataColumn StudentID = new DataColumn("StudentID", typeof(System.String));
            DataColumn StudentName = new DataColumn("StudentName", typeof(System.String));
            DataColumn StudentClassID = new DataColumn("StudentClassID", typeof(System.String));
            //设定StudentID列不允许为空
            StudentID.AllowDBNull = false;
            //把列加入tbStudent表
            tbStudent.Columns.Add(StudentID);
            tbStudent.Columns.Add(StudentName);
            tbStudent.Columns.Add(StudentClassID);
            //设定tbStudent表的主键
            tbStudent.PrimaryKey = new DataColumn[] { StudentID };

            // 为两个表各加入5条记录
            for (int i = 1; i <= 5; i++)
            {
                //实例化tbClass表的行
                DataRow tbClassRow = tbClass.NewRow();
                //为行中每一列赋值
                tbClassRow["ClassID"] = Guid.NewGuid();
                tbClassRow["ClassName"] = string.Format("班级{0}", i);
                //把行加入tbClass表
                tbClass.Rows.Add(tbClassRow);
                //实例化tbStudent表的行
                DataRow tbStudentRow = tbStudent.NewRow();
                //为行中每一列赋值
                tbStudentRow["StudentID"] = Guid.NewGuid();
                tbStudentRow["StudentName"] = string.Format("学生{0}", i);
                tbStudentRow["StudentclassID"] = tbClassRow["ClassID"];
                //把行加入tbStudent表
                tbStudent.Rows.Add(tbStudentRow);
            }

            foreach (DataRow row in tbClass.Rows)
            {
                Console.WriteLine("{0}-----{1}", row[0], row[1]);
            }

            foreach (DataRow row in tbStudent.Rows)
            {
                Console.WriteLine("{0}-----{1}-----{2}", row[0], row[1], row[2]);
            }

            #endregion

            Console.ReadKey();
        }
    }
}
