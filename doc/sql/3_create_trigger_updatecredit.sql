/* 创建触发器，以便完成自动统计学分的工作 */
create   trigger updateTotalCredit
on @{middle}_Reports@{no}
for insert,update,delete
as
begin
	select @{short}_Sno@{no} sno, sum(@{middle}_Courses@{no}.@{short}_Credit@{no}) total_credit into #inserted
		from inserted, @{middle}_OpenCourses@{no}, @{middle}_Courses@{no}
		where inserted.@{short}_Ono@{no} = @{middle}_OpenCourses@{no}.@{short}_Ono@{no} and
			@{middle}_OpenCourses@{no}.@{short}_Cono@{no} = @{middle}_Courses@{no}.@{short}_Cono@{no} and
			@{short}_Grade@{no} >= 60 group by inserted.@{short}_Sno@{no}
	update @{middle}_Students@{no} set @{short}_TotalCredit@{no} = @{short}_TotalCredit@{no} + (
		select total_credit from #inserted where #inserted.sno = @{middle}_Students@{no}.@{short}_Sno@{no}
	) where exists (
		select * from #inserted where #inserted.sno = @{middle}_Students@{no}.@{short}_Sno@{no}
	)
	select @{short}_Sno@{no} sno, sum(@{middle}_Courses@{no}.@{short}_Credit@{no}) total_credit into #deleted
	from deleted, @{middle}_OpenCourses@{no}, @{middle}_Courses@{no}
	where deleted.@{short}_Ono@{no} = @{middle}_OpenCourses@{no}.@{short}_Ono@{no} and
		@{middle}_OpenCourses@{no}.@{short}_Cono@{no} = @{middle}_Courses@{no}.@{short}_Cono@{no} and
		@{short}_Grade@{no} >= 60 group by deleted.@{short}_Sno@{no}
	update @{middle}_Students@{no} set @{short}_TotalCredit@{no} = @{short}_TotalCredit@{no} - (
		select total_credit from #deleted where #deleted.sno = @{middle}_Students@{no}.@{short}_Sno@{no}
	) where exists (
		select * from #deleted where #deleted.sno = @{middle}_Students@{no}.@{short}_Sno@{no}
	)
end