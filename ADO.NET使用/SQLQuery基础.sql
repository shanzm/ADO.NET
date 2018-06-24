
--1.SQL中最常用的三个关键字：create（创建） drop（删除） alter（修改）

--2.注释使用--和/* */

--3.一条完整的SQL语句使用分号结尾,当然你只写了一句不写分号也可以
--   但是写了有益无害,不少资料上一句SQL语句他们不写分号,你知道就可以了

--4.当你写了多条语句时,你可以选中某一条,点击执行,则只执行这一句

--5.go 语句的使用就相当于提交执行go之前的所有SQL语句

--6.use +数据库名 表示在哪个数据库中执行SQL语句  

--7.一个表就相当于C#中的一个类,每一个列名就相当字段,所以表名的命名规范和C#类的命名规范一样

--8提示： SQL 语句和大小写
--请注意， SQL 语句不区分大小写，因此SELECT与select是相同的。同样，写成Select也没有关系。许多 SQL 开发人员喜欢对 SQL 关键字使用
--大写，而对列名和表名使用小写，这样做使代码更易于阅读和调试。不过，一定要认识到虽然 SQL 是不区分大小写的，但是表名、列名和值
--可能有所不同



----9.创建数据库db_test
--CREATE DATABASE db_test;

----10.删除数据库
--DROP DATABASE db_test;

--11.在数据库 db_Tome1中创建表

--USE db_Tome1
--GO

--CREATE TABLE Employee 
--(
-- EmpId INT IDENTITY(1,1) PRIMARY KEY not null,          --int类型 ，主键，不允许为空
--                                                        --注意IDENTITY(1,1)从1开始每行自动加1
-- Empname NVARCHAR(32) null,                             --nvarchar(32)类型，允许为空
-- EmpAge INT DEFAULT(18) not null,                       --int类型，默认值为18
-- DelFlag SMALLINT DEFAULT(0) not null                   --smalint类型，默认值为0
-- )
--GO

--12.删除表Employee
--DROP TABLE dbo.Employee
--GO


--13.
--检索某一列
--SELECT id FROM dbo.员工信息表;             --注意dbo可以省略,表明可以鼠标点住右侧对象资源管理器中的列一拖即可
----检索多列
--SELECT id, name ,sex FROM　dbo.员工信息表;
--检索所有列
--SELECT id, name, sex, birthday, married, party_member, school_age, dept, duty, salary FROM dbo.员工信息表;--直接拖住列文件夹移过来即可
--SELECT * FROM dbo.员工信息表;


--14.crud
--crud是指在做计算处理时的增加(Create)、读取查询(Retrieve)、更新(Update)和删除(Delete)几个单词的首字母简写
--简单地说就是增删改查





数据库的锁
共享锁（S 锁）
Share Locks
当你进行select查询时，会对该表建一个共享锁
如果事务T对数据A加上共享锁后，则其他事务只能对A再加共享锁，不能加排他锁。
获准共享锁的事务只能读数据，不能修改数据。
简而言之就在查询结束之前，你不能修改，删除，更新这张表

排它锁（X锁）
Exclusive Locks
若事务T对数据对象A加上X锁，则只允许T读取和修改A，其他任何事务都不能再对A加任何类型的锁，直到T释放A上的锁。
这就保证了其他事务在T释放A上的锁之前不能再读取和修改A。
简而言之就是当你修改数据库的表时，就不能在允许其他事务查询和修改表