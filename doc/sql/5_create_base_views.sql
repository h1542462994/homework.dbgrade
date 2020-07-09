/*创建地区统计视图*/
create or alter view @{middle}_DestSummaryView@{no}
as
select
	@{middle}_Provinces@{no}.@{short}_Prno@{no} @{short}_Prno@{no},
	@{middle}_Provinces@{no}.@{short}_Name@{no} @{short}_PrName@{no},
	@{middle}_Provinces@{no}.@{short}_SummaryCount@{no} @{short}_PrSummaryCount@{no},
	@{middle}_Cities@{no}.@{short}_Cino@{no} @{short}_Cino@{no},
	@{middle}_Cities@{no}.@{short}_Name@{no} @{short}_CiName@{no},
	@{middle}_Cities@{no}.@{short}_SummaryCount@{no} @{short}_CiSummaryCount@{no}
from
	@{middle}_Provinces@{no} left join @{middle}_Cities@{no}
on
	@{middle}_Provinces@{no}.@{short}_Prno@{no} = @{middle}_Cities@{no}.@{short}_Prno@{no}


/*创建结构概览视图*/
/*创建班级概览视图*/
create or alter view @{middle}_StructView@{no}
as
select
	@{middle}_Professions@{no}.@{short}_Pno@{no} @{short}_Pno@{no},
	@{middle}_Professions@{no}.@{short}_Name@{no} @{short}_PName@{no},
	(select @{short}_Count@{no} from @{middle}_ProfessionSummaryView@{no} where @{middle}_Professions@{no}.@{short}_Pno@{no} = @{middle}_ProfessionSummaryView@{no}.@{short}_Pno@{no}) @{short}_PCount@{no},
	@{middle}_Xclasses@{no}.@{short}_Cno@{no} @{short}_Cno@{no},
	@{middle}_Xclasses@{no}.@{short}_Name@{no} @{short}_CName@{no},
	@{middle}_Xclasses@{no}.@{short}_Year@{no} @{short}_Year@{no},
	(select @{short}_Count@{no} from @{middle}_XclassSummaryView@{no} where @{middle}_Xclasses@{no}.@{short}_Cno@{no} = @{middle}_XclassSummaryView@{no}.@{short}_Cno@{no}) @{short}_CCount@{no}
from
	@{middle}_Professions@{no} left join @{middle}_Xclasses@{no} 
on	
	@{middle}_Professions@{no}.@{short}_Pno@{no} = @{middle}_Xclasses@{no}.@{short}_Pno@{no}

create or alter view @{middle}_XclassSummaryView@{no}
as
select 
	@{middle}_Xclasses@{no}.@{short}_Cno@{no} @{short}_Cno@{no},
	@{middle}_Xclasses@{no}.@{short}_Name@{no} @{short}_Name@{no},
	@{middle}_Xclasses@{no}.@{short}_Year@{no} @{short}_CYear@{no},
	@{middle}_Xclasses@{no}.@{short}_Pno@{no} @{short}_Pno@{no},
	studentSummary._count @{short}_Count@{no}
from
	@{middle}_Xclasses@{no} left join (
		select distinct @{short}_Cno@{no} @{short}_Cno@{no}, count(*)_count from @{middle}_Students@{no}
		group by @{short}_Cno@{no}
	) studentSummary
on 
	@{middle}_Xclasses@{no}.@{short}_Cno@{no} = studentSummary.@{short}_Cno@{no}

create or alter view @{middle}_ProfessionSummaryView@{no}
as
select
	@{middle}_Professions@{no}.@{short}_Pno@{no} @{short}_Pno@{no},
	@{middle}_Professions@{no}.@{short}_Name@{no} @{short}_PName@{no},
	studentSummary._count @{short}_Count@{no}
from
	@{middle}_Professions@{no} left join (
	select @{short}_Pno@{no} @{short}_Pno@{no}, count(*)_count from @{middle}_StudentsView@{no}
	group by @{short}_Pno@{no}
	) studentSummary
on
	@{middle}_Professions@{no}.@{short}_Pno@{no} = studentSummary.@{short}_Pno@{no}

/*创建学生详细视图*/
create or alter view @{middle}_StudentsView@{no}
as
	select 
		@{middle}_Students@{no}.@{short}_Sno@{no} @{short}_Sno@{no}, --学号
		@{middle}_Students@{no}.@{short}_Name@{no} @{short}_Name@{no}, --姓名
		@{middle}_Students@{no}.@{short}_Sex@{no} @{short}_Sex@{no}, --性别
		@{middle}_Students@{no}.@{short}_Age@{no} @{short}_Age@{no}, --年龄
		@{middle}_Students@{no}.@{short}_TotalCredit@{no} @{short}_TotalCredit@{no}, --总学分
		@{middle}_Students@{no}.@{short}_Cno@{no} @{short}_Cno@{no}, --班级号
		@{middle}_Xclasses@{no}.@{short}_Name@{no} @{short}_CName@{no}, --班级名
		@{middle}_Xclasses@{no}.@{short}_Year@{no} @{short}_CYear@{no}, --班级届数
		@{middle}_Xclasses@{no}.@{short}_Pno@{no} @{short}_Pno@{no}, --专业号
		@{middle}_Professions@{no}.@{short}_Name@{no} @{short}_PName@{no}, --专业名
		@{middle}_Students@{no}.@{short}_Cino@{no} @{short}_Cino@{no}, --城市号
		@{middle}_Cities@{no}.@{short}_Name@{no} @{short}_CiName@{no}, --城市名
		@{middle}_Cities@{no}.@{short}_Prno@{no} @{short}_Prno@{no}, --省号
		@{middle}_Provinces@{no}.@{short}_Name@{no} @{short}_PrName@{no} --省名
	from
		@{middle}_Students@{no}, @{middle}_Xclasses@{no}, @{middle}_Professions@{no},
		@{middle}_Cities@{no}, @{middle}_Provinces@{no}
	where
		@{middle}_Students@{no}.@{short}_Cno@{no} = @{middle}_Xclasses@{no}.@{short}_Cno@{no} and @{middle}_Xclasses@{no}.@{short}_Pno@{no} = @{middle}_Professions@{no}.@{short}_Pno@{no} and
		@{middle}_Students@{no}.@{short}_Cino@{no} = @{middle}_Cities@{no}.@{short}_Cino@{no} and @{middle}_Cities@{no}.@{short}_Prno@{no} = @{middle}_Provinces@{no}.@{short}_Prno@{no}
	
/*创建开设课程详细视图*/
create or alter view @{middle}_OpenCoursesView@{no}
as
select
	@{middle}_OpenCourses@{no}.@{short}_Ono@{no} @{short}_Ono@{no},
	@{middle}_Courses@{no}.@{short}_Cono@{no} @{short}_Cono@{no},
	@{middle}_Courses@{no}.@{short}_Name@{no} @{short}_CoName@{no},
	@{middle}_Courses@{no}.@{short}_Credit@{no} @{short}_Credit@{no},
	@{middle}_Courses@{no}.@{short}_Period@{no} @{short}_Period@{no},
	@{middle}_Courses@{no}.@{short}_Way@{no} @{short}_Way@{no},
	@{middle}_OpenCourses@{no}.@{short}_Year@{no} @{short}_Year@{no},
	@{middle}_OpenCourses@{no}.@{short}_Term@{no} @{short}_Term@{no},
	@{middle}_Xclasses@{no}.@{short}_Cno@{no} @{short}_Cno@{no},
	@{middle}_Xclasses@{no}.@{short}_Name@{no} @{short}_CName@{no},
	@{middle}_Xclasses@{no}.@{short}_Year@{no} @{short}_CYear@{no},
	@{middle}_Teachers@{no}.@{short}_Tno@{no} @{short}_Tno@{no},
	@{middle}_Teachers@{no}.@{short}_Name@{no} @{short}_TName@{no},
	@{middle}_Teachers@{no}.@{short}_Age@{no} @{short}_Age@{no},
	@{middle}_Teachers@{no}.@{short}_Sex@{no} @{short}_Sex@{no},
	@{middle}_Teachers@{no}.@{short}_Level@{no} @{short}_Level@{no},
	@{middle}_Teachers@{no}.@{short}_Phone@{no} @{short}_Phone@{no}
from @{middle}_OpenCourses@{no}, @{middle}_Courses@{no}, @{middle}_Teachers@{no}, @{middle}_Xclasses@{no}
where 
	@{middle}_OpenCourses@{no}.@{short}_Cono@{no} = @{middle}_Courses@{no}.@{short}_Cono@{no} and
	@{middle}_OpenCourses@{no}.@{short}_Tno@{no} = @{middle}_Teachers@{no}.@{short}_Tno@{no} and
	@{middle}_OpenCourses@{no}.@{short}_Cno@{no} = @{middle}_Xclasses@{no}.@{short}_Cno@{no}

create or alter view @{middle}_ReportsView@{no}
as
select distinct
	@{middle}_Reports@{no}.@{short}_Grade@{no} @{short}_Grade@{no},
	@{middle}_StudentsView@{no}.@{short}_Sno@{no} @{short}_Sno@{no}, --学号
	@{middle}_StudentsView@{no}.@{short}_Name@{no} @{short}_SName@{no}, --姓名
	@{middle}_StudentsView@{no}.@{short}_Sex@{no} @{short}_SSex@{no}, --性别
	@{middle}_StudentsView@{no}.@{short}_Age@{no} @{short}_SAge@{no}, --年龄
	@{middle}_StudentsView@{no}.@{short}_TotalCredit@{no} @{short}_TotalCredit@{no}, --总学分
	@{middle}_StudentsView@{no}.@{short}_Cno@{no} @{short}_Cno@{no}, --班级号
	@{middle}_StudentsView@{no}.@{short}_CYear@{no} @{short}_CYear@{no},
	@{middle}_StudentsView@{no}.@{short}_CName@{no} @{short}_CName@{no}, --班级名
	@{middle}_StudentsView@{no}.@{short}_Pno@{no} @{short}_Pno@{no}, --专业号
	@{middle}_StudentsView@{no}.@{short}_PName@{no} @{short}_PName@{no}, --专业名
	@{middle}_StudentsView@{no}.@{short}_Cino@{no} @{short}_Cino@{no}, --城市号
	@{middle}_StudentsView@{no}.@{short}_CiName@{no} @{short}_CiName@{no}, --城市名
	@{middle}_StudentsView@{no}.@{short}_Prno@{no} @{short}_Prno@{no}, --省号
	@{middle}_StudentsView@{no}.@{short}_PrName@{no} @{short}_PrName@{no}, --省名
	@{middle}_OpenCoursesView@{no}.@{short}_Ono@{no} @{short}_Ono@{no},
	@{middle}_OpenCoursesView@{no}.@{short}_Cono@{no} @{short}_Cono@{no},
	@{middle}_OpenCoursesView@{no}.@{short}_CoName@{no} @{short}_CoName@{no},
	iif(@{middle}_OpenCoursesView@{no}.@{short}_Credit@{no}>=60, @{middle}_OpenCoursesView@{no}.@{short}_Credit@{no}, 0) @{short}_Credit@{no},
	@{middle}_OpenCoursesView@{no}.@{short}_Period@{no} @{short}_Period@{no},
	@{middle}_OpenCoursesView@{no}.@{short}_Way@{no} @{short}_Way@{no},
	@{middle}_OpenCoursesView@{no}.@{short}_Year@{no} @{short}_Year@{no},
	@{middle}_OpenCoursesView@{no}.@{short}_Term@{no} @{short}_Term@{no},
	@{middle}_OpenCoursesView@{no}.@{short}_Tno@{no} @{short}_Tno@{no},
	@{middle}_OpenCoursesView@{no}.@{short}_TName@{no} @{short}_TName@{no},
	@{middle}_OpenCoursesView@{no}.@{short}_Age@{no} @{short}_TAge@{no},
	@{middle}_OpenCoursesView@{no}.@{short}_Sex@{no} @{short}_TSex@{no},
	@{middle}_OpenCoursesView@{no}.@{short}_Level@{no} @{short}_Level@{no},
	@{middle}_OpenCoursesView@{no}.@{short}_Phone@{no} @{short}_Phone@{no}
from
	@{middle}_Reports@{no}, @{middle}_StudentsView@{no}, @{middle}_OpenCoursesView@{no}
where
	@{middle}_Reports@{no}.@{short}_Sno@{no} = @{middle}_StudentsView@{no}.@{short}_Sno@{no} and
	@{middle}_Reports@{no}.@{short}_Ono@{no} = @{middle}_OpenCoursesView@{no}.@{short}_Ono@{no}