/*添加省，市信息的存储过程*/
create or alter proc addDest(
	@province varchar(20),
	@city varchar(20)
)
as
	declare @provinceId int
	select @provinceId = @{short}_Prno@{no} from @{middle}_Provinces@{no} where @{short}_Name@{no} = @province
	if(@provinceId is null)
	begin
		insert into @{middle}_Provinces@{no} values(@province, 0)
		select  @provinceId = @{short}_Prno@{no} from @{middle}_Provinces@{no} last
	end
	if(not exists(select @{short}_Cino@{no} from @{middle}_Cities@{no} where @{short}_Prno@{no} = @provinceId and @{short}_Name@{no} = @city))
	begin
		insert into @{middle}_Cities@{no} values(@city, @provinceId, 0)
	end

/*添加专业，班级的存储过程*/
create or alter proc addStruct(
	@profession varchar(20),
	@class varchar(20),
	@year int
)
as
	declare @professionId int
	select @professionId = @{short}_Pno@{no} from @{middle}_Professions@{no} where @{middle}_Professions@{no}.@{short}_Name@{no} = @profession
	if(@professionId is null)
	begin
		insert into @{middle}_Professions@{no} values(@profession)
		select @professionId = @{short}_Pno@{no} from @{middle}_Professions@{no} last
	end
	if(not exists(select @{short}_Cno@{no} from @{middle}_Xclasses@{no} where @{middle}_Xclasses@{no}.@{short}_Pno@{no} = @professionId and @{middle}_Xclasses@{no}.@{short}_Name@{no} = @class))
	begin
		insert into @{middle}_Xclasses@{no} values(@class, @year, @professionId)
	end

/*添加学生的存储过程*/
create or alter proc addStudent(
	@sno varchar(20),
	@name varchar(20),
	@sex int,
	@age int,
	@cno int,
	@cino int
)
as
	if(exists(select * from @{middle}_Students@{no} where @{middle}_Students@{no}.@{short}_Sno@{no} = @sno))
	begin
		print('该学生已存在，拒绝插入数据')
	end
	else
	begin
		insert into @{middle}_Students@{no} values(@sno, @name, @sex, @age, 0, @cno, @cino);
	end

/*添加教师的存储过程*/
create or alter proc addTeacher (
	@tno varchar(20),
	@name varchar(20),
	@sex int,
	@age int,
	@level int,
	@phone varchar(11)
) as
begin
	insert into @{middle}_Teachers@{no} values (@tno, @name, @sex, @age, @level, @phone)
end

/*添加学期的存储过程*/
create or alter proc addTerm(
	@year int,
	@term int
) as 
begin
	insert into @{middle}_Terms@{no} values (@year, @term)
end

/*添加课程的存储过程*/
create or alter proc addCourse (
	@name varchar(20),
	@period int,
	@way int,
	@credit float
) as
begin
	insert into @{middle}_Courses@{no} values(@name, @period, @way, @credit)
end

/*添加开课的存储过程*/
create or alter proc addOpenCourse
(
	@cono int,
	@cno int,
	@year int,
	@term int,
	@tno varchar(20)
) as
begin
	insert into @{middle}_OpenCourses@{no} values (@cono, @cno, @year, @term, @tno)
end

/*添加报告的存储过程*/
create or alter proc addReport
(
	@sno varchar(20), --学生
	@cono int, --课程号
	@grade float --成绩
) as 
begin
	declare @cno int
	declare @ono int
	select @cno = @{middle}_Students@{no}.@{short}_Cno@{no} from @{middle}_Students@{no} where @{middle}_Students@{no}.@{short}_Sno@{no} = @sno /*根据学生找到班级*/
	select @ono = @{middle}_OpenCourses@{no}.@{short}_Ono@{no} from @{middle}_OpenCourses@{no} where @{middle}_OpenCourses@{no}.@{short}_Cno@{no} = @cno and @{middle}_OpenCourses@{no}.@{short}_Cono@{no} = @cono /*根据课程和班级找到开课*/
	insert into @{middle}_Reports@{no} values (@ono, @sno, @grade)
end