----15.CASE WHEN  用法1
--SELECT * ,
--CASE DELFLAG
--   WHEN 0 THEN N'未删除'
--   WHEN 1 THEN N'删除'
--   END AS 删除状态
--   ,Id     
--FROM szmUserInfo  


--用法2
--SELECT UserName,Id,CreateDate,
--CASE 
--WHEN CreateDate>convert(varchar(10),'2018-06-18',120) then N'老用户'
--WHEN CreateDate<convert(varchar(10),'2018-06-20',120) then N'新用户'
--END as 用户等级,
--UserName
-- FROM szmUserInfo



--Select *,
--CASE	
--when (DATEDIFF([d],CreateDate,GETDATE()))>8  then N'老用户'
--when (DATEDIFF([d],CreateDate,GETDATE()))<3  then N'新用户'
--END as 用户等级,
--UserName
-- FROM szmUserInfo

 
----16.分页查询1
----比如说一页三条,我查第1页 
--select top 3 * from szmUserInfo ;

----第二页
--select top 3 * from szmUserInfo where Id not in
--(select top ((2-1)*3) Id  from szmUserInfo order by Id)--这就是第一页的Id
--order by Id;

----第三页
--select top 3 * from szmUserInfo where Id not in
--(select top ((3-1)*3) Id  from szmUserInfo order by Id)--这就是前二页的Id
--order by Id;


----分页查询2
--一页三行，查询得二页
select * from
(select * ,ROW_NUMBER() over(order by Id)as 行号  from szmUserInfo) as T--先按Id进行排序，排序完后，给每条数据进行编号，形成一个新列“行号”--over()称为开窗函数
where T.行号 between 4 and 6

--查询第三页
select * from
(select * ,ROW_NUMBER() over(order by Id)as 行号  from szmUserInfo) as T
where T.行号 between ((3-1)*3)+1 and (3*4)




----开窗函数的使用
----select *,AVG(ErrorTimes) over() from szmUserInfo