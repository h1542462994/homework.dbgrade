/*创建触发器，用于更改学生信息时调整cities表中的统计值，注意，必须按照流程初始化数据表*/
create or alter trigger Ttrigger_updateCitySummaryCount
on @{middle}_Students@{no}
for delete,update,insert
as
	select @{short}_Cino@{no} @{short}_Cino@{no}, count(*)_count into #inserted from inserted group by @{short}_Cino@{no}
	update @{middle}_Cities@{no} set @{short}_SummaryCount@{no} = @{short}_SummaryCount@{no} + (
		select _count from #inserted where #inserted.@{short}_Cino@{no} = @{middle}_Cities@{no}.@{short}_Cino@{no}
	) where exists (select * from #inserted where #inserted.@{short}_Cino@{no} = @{middle}_Cities@{no}.@{short}_Cino@{no})
	select @{short}_Cino@{no} @{short}_Cino@{no}, count(*)_count into #deleted from deleted group by @{short}_Cino@{no}
	update @{middle}_Cities@{no} set @{short}_SummaryCount@{no} = @{short}_SummaryCount@{no} - (
		select _count from #deleted where #deleted.@{short}_Cino@{no} = @{middle}_Cities@{no}.@{short}_Cino@{no}
	) where exists (select * from #deleted where #deleted.@{short}_Cino@{no} = @{middle}_Cities@{no}.@{short}_Cino@{no})
go
/*创建触发器，用于更改cities表中的值时向上传递更新统计值到provinces*/
create or alter trigger Ttrigger_updateProvinceSummaryCount
on @{middle}_Cities@{no}
for update
as
	select @{short}_Prno@{no} @{short}_Prno@{no}, sum(@{short}_SummaryCount@{no})_count into #updated from inserted group by @{short}_Prno@{no}
	select @{short}_Prno@{no} @{short}_Prno@{no}, sum(@{short}_SummaryCount@{no})_count into #deleted from deleted group by @{short}_Prno@{no}
	update #updated set _count = _count - (
		select _count from #deleted where #deleted.@{short}_Prno@{no} = #updated.@{short}_Prno@{no}
	)
	update @{middle}_Provinces@{no} set @{short}_SummaryCount@{no} = @{short}_SummaryCount@{no} + (
		select _count from #updated where #updated.@{short}_Prno@{no} = @{middle}_Provinces@{no}.@{short}_Prno@{no}
	) where exists (
		select * from #updated where #updated.@{short}_Prno@{no} = @{middle}_Provinces@{no}.@{short}_Prno@{no}
	)
go