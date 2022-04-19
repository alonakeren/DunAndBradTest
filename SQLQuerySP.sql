--1 stored procedure

create procedure GetSumAgentCodeByYear(@ORD_DATE int) as 
select top 1 AGENT_CODE, sum(ADVANCE_AMOUNT) as SUM_ADVANCE_AMOUNT from ORDERS 
where year(ORD_DATE) = @ORD_DATE and month(ORD_DATE) between 1 and 3 
group by AGENT_CODE order by SUM_ADVANCE_AMOUNT desc
go;

execute GetSumAgentCodeByYear 2021 
go;



--2

create procedure GetAgentCodeByRowNumber(@Top_Rows_Count int, @AGENT_CODE_list varchar(max), @Rownumentered int) as 
select * from
(select TOP (@Top_Rows_Count) ROW_NUMBER() OVER (partition by agent_code ORDER BY ORD_DATE) AS RowNumber, 
ORD_NUM, ORD_AMOUNT, ADVANCE_AMOUNT, ORD_DATE, CUST_CODE, AGENT_CODE, ORD_DESCRIPTION
from ORDERS order by AGENT_CODE asc, ORD_DATE asc) a
where RowNumber = @Rownumentered and AGENT_CODE in (SELECT value FROM STRING_SPLIT( @AGENT_CODE_list, ','))
order by AGENT_CODE,RowNumber
go

execute GetAgentCodeByRowNumber 30, 'A008,A004,A009', 2 
go



--3 

create procedure GetAgentsByQtyOrders(@Numentered int, @Yearentered int) as 
select distinct(a.AGENT_CODE), a.AGENT_NAME, a.PHONE_NO
from AGENTS a
left join ORDERS o
on a.AGENT_CODE = o.AGENT_CODE
where year(o.ORD_DATE) = @Yearentered 
group by a.AGENT_CODE, AGENT_NAME, PHONE_NO
having count (o.ORD_NUM) >= @Numentered
go;

execute GetAgentsByQtyOrders 2, 2021
go
