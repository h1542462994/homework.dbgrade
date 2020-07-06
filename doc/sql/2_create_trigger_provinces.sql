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