/* 创建触发器，以便完成自动统计学分的工作 */
create or alter trigger updateTotalCredit
on @{middle}_Reports@{no}
for insert,update,delete
as
begin
	select @{short}_Sno@{no} sno,sum(@{short}_Grade@{no}) sum_grade into #inserted
		from inserted group by @{short}_Sno@{no}
	update @{middle}_Students@{no} set @{short}_TotalCredit@{no} = @{short}_TotalCredit@{no} + (
		select sum_grade from #inserted where #inserted.sno = @{middle}_Students@{no}.@{short}_Sno@{no}
	) where exists (
		select * from #inserted where #inserted.sno = @{middle}_Students@{no}.@{short}_Sno@{no}
	)

	select @{short}_Sno@{no} sno,sum(@{short}_Grade@{no}) sum_grade into #deleted
		from inserted group by @{short}_Sno@{no}
	update @{middle}_Students@{no} set @{short}_TotalCredit@{no} = @{short}_TotalCredit@{no} - (
		select sum_grade from #deleted where #deleted.sno = @{middle}_Students@{no}.@{short}_Sno@{no}
	) where exists (
		select * from #deleted where #deleted.sno = @{middle}_Students@{no}.@{short}_Sno@{no}
	)
end