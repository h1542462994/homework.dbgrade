create or alter trigger TupdateCitiesSummaryCount
on @{middle}_Students@{no}
for delete,update,insert
as
begin
	select @{short}_Cino@{no}, count(*)_count into #inserted from inserted group by @{short}_Cino@{no}
	update @{middle}_Cities@{no} set @{short}_Cino@{no} = @{short}_Cino@{no} + (
		select _count from #inserted where #inserted.@{short}_Cno@{no} = @{middle}_Cities@{no}.@{short}_Cino@{no} 
	) where exists (
		select * from #inserted where #inserted.@{short}_Cino@{no} = @{middle}_Cities@{no}.@{short}_Cino@{no}
	);
	select @{short}_Cino@{no}, count(*)_count into #deleted from deleted group by @{short}_Cino@{no}
	update @{middle}_Cities@{no} set @{short}_Cino@{no} = @{short}_Cino@{no} - (
		select _count from #deleted where #deleted.@{short}_Cno@{no} = @{middle}_Cities@{no}.@{short}_Cino@{no} 
	) where exists (
		select * from #deleted where #deleted.@{short}_Cino@{no} = @{middle}_Cities@{no}.@{short}_Cino@{no}
	);
end
go
create or alter trigger TupdateProvincesSummaryCount
on @{middle}_Cities@{no}
for update
as
begin
	select @{short}_Cino@{no} cino,0 oldCount,@{short}_SummaryCount@{no} newCount into #changlog from inserted
	update #changlog set oldCount = (
		select @{short}_SummaryCount@{no} from deleted where #changlog.cino = deleted.@{short}_Cino@{no}
	)
end
go