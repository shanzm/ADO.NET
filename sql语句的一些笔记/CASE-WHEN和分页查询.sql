----15.CASE WHEN  �÷�1
--SELECT * ,
--CASE DELFLAG
--   WHEN 0 THEN N'δɾ��'
--   WHEN 1 THEN N'ɾ��'
--   END AS ɾ��״̬
--   ,Id     
--FROM szmUserInfo  


--�÷�2
--SELECT UserName,Id,CreateDate,
--CASE 
--WHEN CreateDate>convert(varchar(10),'2018-06-18',120) then N'���û�'
--WHEN CreateDate<convert(varchar(10),'2018-06-20',120) then N'���û�'
--END as �û��ȼ�,
--UserName
-- FROM szmUserInfo



--Select *,
--CASE	
--when (DATEDIFF([d],CreateDate,GETDATE()))>8  then N'���û�'
--when (DATEDIFF([d],CreateDate,GETDATE()))<3  then N'���û�'
--END as �û��ȼ�,
--UserName
-- FROM szmUserInfo

 
----16.��ҳ��ѯ1
----����˵һҳ����,�Ҳ��1ҳ 
--select top 3 * from szmUserInfo ;

----�ڶ�ҳ
--select top 3 * from szmUserInfo where Id not in
--(select top ((2-1)*3) Id  from szmUserInfo order by Id)--����ǵ�һҳ��Id
--order by Id;

----����ҳ
--select top 3 * from szmUserInfo where Id not in
--(select top ((3-1)*3) Id  from szmUserInfo order by Id)--�����ǰ��ҳ��Id
--order by Id;


----��ҳ��ѯ2
--һҳ���У���ѯ�ö�ҳ
select * from
(select * ,ROW_NUMBER() over(order by Id)as �к�  from szmUserInfo) as T--�Ȱ�Id��������������󣬸�ÿ�����ݽ��б�ţ��γ�һ�����С��кš�--over()��Ϊ��������
where T.�к� between 4 and 6

--��ѯ����ҳ
select * from
(select * ,ROW_NUMBER() over(order by Id)as �к�  from szmUserInfo) as T
where T.�к� between ((3-1)*3)+1 and (3*4)




----����������ʹ��
----select *,AVG(ErrorTimes) over() from szmUserInfo