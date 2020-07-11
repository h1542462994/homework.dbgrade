/*创建触发器，用于更改学生信息时调整cities表中的统计值，注意，必须按照流程初始化数据表*/
create or alter trigger Ttrigger_updateCitySummaryCount
on @{middle}_Students@{no}
for insert,update,delete
as
	update @{middle}_Cities@{no} set @{short}_SummaryCount@{no} = (
		select count(*) from @{middle}_Students@{no} where @{middle}_Students@{no}.@{short}_Cino@{no} = @{middle}_Cities@{no}.@{short}_Cino@{no} 
	) where @{middle}_Cities@{no}.@{short}_Cino@{no} in (
		select @{short}_Cino@{no} from inserted union select @{short}_Cino@{no} from deleted
	) 
go


/*创建触发器，用于更改cities表中的值时向上传递更新统计值到provinces*/
create or alter trigger Ttrigger_updateProvinceSummaryCount
on @{middle}_Cities@{no}
for update
as
	update @{middle}_Provinces@{no} set @{short}_SummaryCount@{no} = (
		select sum(@{middle}_Cities@{no}.@{short}_SummaryCount@{no}) from @{middle}_Cities@{no} where @{middle}_Cities@{no}.@{short}_Prno@{no} = @{middle}_Provinces@{no}.@{short}_Prno@{no}
	) where @{middle}_Provinces@{no}.@{short}_Prno@{no} in (
		select @{short}_Prno@{no} from inserted union select @{short}_Prno@{no} from deleted
	)
go

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

--插入的学生的班级必须与Report.OpenCourse对应的班级相同，否则拒绝插入。
create or alter trigger checkStudentCno
on @{middle}_Reports@{no}
for insert,update
as
begin
	select 
		case when (@{middle}_OpenCourses@{no}.@{short}_Cno@{no} = @{middle}_Students@{no}.@{short}_Cno@{no}) then 1 else 0 end equal
	into #inserted
	from inserted, @{middle}_OpenCourses@{no}, @{middle}_Students@{no}
	where 
		inserted.@{short}_Sno@{no} = @{middle}_Students@{no}.@{short}_Sno@{no} and
		inserted.@{short}_Ono@{no} = @{middle}_OpenCourses@{no}.@{short}_Ono@{no}

	if exists(select * from #inserted where equal = 0) begin
		print('插入的成绩对应的学生的班级必须与对应的开课的班级一致。')
		rollback
	end

end