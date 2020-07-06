set xact_abort on
begin transaction Tinsert_seeds
delete from @{middle}_Students@{no};
delete from @{middle}_Cities@{no};
delete from @{middle}_Provinces@{no};
delete from @{middle}_Xclasses@{no};
delete from @{middle}_Professions@{no};

--枚举定义
--sex 男：0；女：1
--level（教师职称） 讲师：0；副教授：1；教授：2
--term 上学期：0；下学期：1
--way 考核方式 考试：0；考察：1

/* 添加种子数据 省市 */
insert into @{middle}_Provinces@{no} values ('浙江省', 0);
insert into @{middle}_Provinces@{no} values ('江苏省', 0);
declare @provinces int
select @provinces = @{short}_Prno@{no} from @{middle}_Provinces@{no} where @{short}_Name@{no} = '浙江省';
insert into @{middle}_Cities@{no} values ('杭州市', @provinces, 0);
insert into @{middle}_Cities@{no} values ('宁波市', @provinces, 0);
insert into @{middle}_Cities@{no} values ('温州市', @provinces, 0);
insert into @{middle}_Cities@{no} values ('嘉兴市', @provinces, 0);
insert into @{middle}_Cities@{no} values ('湖州市', @provinces, 0);
insert into @{middle}_Cities@{no} values ('绍兴市', @provinces, 0);
insert into @{middle}_Cities@{no} values ('金华市', @provinces, 0);
insert into @{middle}_Cities@{no} values ('衢州市', @provinces, 0);
insert into @{middle}_Cities@{no} values ('舟山市', @provinces, 0);
insert into @{middle}_Cities@{no} values ('台州市', @provinces, 0);
insert into @{middle}_Cities@{no} values ('丽水市', @provinces, 0);
insert into @{middle}_Cities@{no} values ('舟山群岛新区', @provinces, 0);
select @provinces = @{short}_Prno@{no} from @{middle}_Provinces@{no} where @{short}_Name@{no} = '江苏省';
insert into @{middle}_Cities@{no} values ('南京市', @provinces, 0);
insert into @{middle}_Cities@{no} values ('无锡市', @provinces, 0);
insert into @{middle}_Cities@{no} values ('徐州市', @provinces, 0);
insert into @{middle}_Cities@{no} values ('常州市', @provinces, 0);
insert into @{middle}_Cities@{no} values ('苏州市', @provinces, 0);
insert into @{middle}_Cities@{no} values ('南通市', @provinces, 0);
insert into @{middle}_Cities@{no} values ('连云港市', @provinces, 0);
insert into @{middle}_Cities@{no} values ('淮安市', @provinces, 0);
insert into @{middle}_Cities@{no} values ('盐城市', @provinces, 0);
insert into @{middle}_Cities@{no} values ('扬州市', @provinces, 0);
insert into @{middle}_Cities@{no} values ('镇江市', @provinces, 0);
insert into @{middle}_Cities@{no} values ('泰州市', @provinces, 0);
insert into @{middle}_Cities@{no} values ('宿迁市', @provinces, 0);

/* 添加种子数据 专业和班级 */
insert into @{middle}_Professions@{no} values('实验班')
insert into @{middle}_Professions@{no} values('软件工程');
insert into @{middle}_Professions@{no} values('网络工程');
insert into @{middle}_Professions@{no} values('数字媒体技术');
insert into @{middle}_Professions@{no} values('物联网工程');
insert into @{middle}_Professions@{no} values('数据科学与大数据技术');
insert into @{middle}_Professions@{no} values('计算机科学与技术');

declare @profession int
select @profession = @{short}_Pno@{no} from @{middle}_Professions@{no} where @{short}_Name@{no} = '实验班';
insert into @{middle}_Xclasses@{no} values('1班', @profession, 2016);
insert into @{middle}_Xclasses@{no} values('1班', @profession, 2017);
insert into @{middle}_Xclasses@{no} values('1班', @profession, 2018);

select @profession = @{short}_Pno@{no} from @{middle}_Professions@{no} where @{short}_Name@{no} = '软件工程';
insert into @{middle}_Xclasses@{no} values('1班', @profession, 2016);
insert into @{middle}_Xclasses@{no} values('2班', @profession, 2016);
insert into @{middle}_Xclasses@{no} values('3班', @profession, 2016);
insert into @{middle}_Xclasses@{no} values('4班', @profession, 2016);
insert into @{middle}_Xclasses@{no} values('5班', @profession, 2016);
insert into @{middle}_Xclasses@{no} values('1班', @profession, 2017);
insert into @{middle}_Xclasses@{no} values('2班', @profession, 2017);
insert into @{middle}_Xclasses@{no} values('3班', @profession, 2017);
insert into @{middle}_Xclasses@{no} values('4班', @profession, 2017);
insert into @{middle}_Xclasses@{no} values('5班', @profession, 2017);
insert into @{middle}_Xclasses@{no} values('1班', @profession, 2018);
insert into @{middle}_Xclasses@{no} values('2班', @profession, 2018);
insert into @{middle}_Xclasses@{no} values('3班', @profession, 2018);
insert into @{middle}_Xclasses@{no} values('4班', @profession, 2018);
insert into @{middle}_Xclasses@{no} values('5班', @profession, 2018);

select @profession = @{short}_Pno@{no} from @{middle}_Professions@{no} where @{short}_Name@{no} = '网络工程';
insert into @{middle}_Xclasses@{no} values('1班', @profession, 2016);
insert into @{middle}_Xclasses@{no} values('2班', @profession, 2016);
insert into @{middle}_Xclasses@{no} values('3班', @profession, 2016);
insert into @{middle}_Xclasses@{no} values('4班', @profession, 2016);
insert into @{middle}_Xclasses@{no} values('5班', @profession, 2016);
insert into @{middle}_Xclasses@{no} values('1班', @profession, 2017);
insert into @{middle}_Xclasses@{no} values('2班', @profession, 2017);
insert into @{middle}_Xclasses@{no} values('3班', @profession, 2017);
insert into @{middle}_Xclasses@{no} values('4班', @profession, 2017);
insert into @{middle}_Xclasses@{no} values('5班', @profession, 2017);
insert into @{middle}_Xclasses@{no} values('1班', @profession, 2018);
insert into @{middle}_Xclasses@{no} values('2班', @profession, 2018);
insert into @{middle}_Xclasses@{no} values('3班', @profession, 2018);
insert into @{middle}_Xclasses@{no} values('4班', @profession, 2018);
insert into @{middle}_Xclasses@{no} values('5班', @profession, 2018);

select @profession = @{short}_Pno@{no} from @{middle}_Professions@{no} where @{short}_Name@{no} = '数字媒体技术';
insert into @{middle}_Xclasses@{no} values('1班', @profession, 2016);
insert into @{middle}_Xclasses@{no} values('2班', @profession, 2016);
insert into @{middle}_Xclasses@{no} values('3班', @profession, 2016);
insert into @{middle}_Xclasses@{no} values('4班', @profession, 2016);
insert into @{middle}_Xclasses@{no} values('5班', @profession, 2016);
insert into @{middle}_Xclasses@{no} values('1班', @profession, 2017);
insert into @{middle}_Xclasses@{no} values('2班', @profession, 2017);
insert into @{middle}_Xclasses@{no} values('3班', @profession, 2017);
insert into @{middle}_Xclasses@{no} values('4班', @profession, 2017);
insert into @{middle}_Xclasses@{no} values('5班', @profession, 2017);
insert into @{middle}_Xclasses@{no} values('1班', @profession, 2018);
insert into @{middle}_Xclasses@{no} values('2班', @profession, 2018);
insert into @{middle}_Xclasses@{no} values('3班', @profession, 2018);
insert into @{middle}_Xclasses@{no} values('4班', @profession, 2018);
insert into @{middle}_Xclasses@{no} values('5班', @profession, 2018);

select @profession = @{short}_Pno@{no} from @{middle}_Professions@{no} where @{short}_Name@{no} = '物联网工程';
insert into @{middle}_Xclasses@{no} values('1班', @profession, 2016);
insert into @{middle}_Xclasses@{no} values('2班', @profession, 2016);
insert into @{middle}_Xclasses@{no} values('3班', @profession, 2016);
insert into @{middle}_Xclasses@{no} values('4班', @profession, 2016);
insert into @{middle}_Xclasses@{no} values('5班', @profession, 2016);
insert into @{middle}_Xclasses@{no} values('1班', @profession, 2017);
insert into @{middle}_Xclasses@{no} values('2班', @profession, 2017);
insert into @{middle}_Xclasses@{no} values('3班', @profession, 2017);
insert into @{middle}_Xclasses@{no} values('4班', @profession, 2017);
insert into @{middle}_Xclasses@{no} values('5班', @profession, 2017);
insert into @{middle}_Xclasses@{no} values('1班', @profession, 2018);
insert into @{middle}_Xclasses@{no} values('2班', @profession, 2018);
insert into @{middle}_Xclasses@{no} values('3班', @profession, 2018);
insert into @{middle}_Xclasses@{no} values('4班', @profession, 2018);
insert into @{middle}_Xclasses@{no} values('5班', @profession, 2018);

select @profession = @{short}_Pno@{no} from @{middle}_Professions@{no} where @{short}_Name@{no} = '数据科学与大数据技术';
insert into @{middle}_Xclasses@{no} values('1班', @profession, 2016);
insert into @{middle}_Xclasses@{no} values('2班', @profession, 2016);
insert into @{middle}_Xclasses@{no} values('3班', @profession, 2016);
insert into @{middle}_Xclasses@{no} values('4班', @profession, 2016);
insert into @{middle}_Xclasses@{no} values('5班', @profession, 2016);
insert into @{middle}_Xclasses@{no} values('1班', @profession, 2017);
insert into @{middle}_Xclasses@{no} values('2班', @profession, 2017);
insert into @{middle}_Xclasses@{no} values('3班', @profession, 2017);
insert into @{middle}_Xclasses@{no} values('4班', @profession, 2017);
insert into @{middle}_Xclasses@{no} values('5班', @profession, 2017);
insert into @{middle}_Xclasses@{no} values('1班', @profession, 2018);
insert into @{middle}_Xclasses@{no} values('2班', @profession, 2018);
insert into @{middle}_Xclasses@{no} values('3班', @profession, 2018);
insert into @{middle}_Xclasses@{no} values('4班', @profession, 2018);
insert into @{middle}_Xclasses@{no} values('5班', @profession, 2018);

select @profession = @{short}_Pno@{no} from @{middle}_Professions@{no} where @{short}_Name@{no} = '计算机科学与技术';
insert into @{middle}_Xclasses@{no} values('1班', @profession, 2016);
insert into @{middle}_Xclasses@{no} values('2班', @profession, 2016);
insert into @{middle}_Xclasses@{no} values('3班', @profession, 2016);
insert into @{middle}_Xclasses@{no} values('4班', @profession, 2016);
insert into @{middle}_Xclasses@{no} values('5班', @profession, 2016);
insert into @{middle}_Xclasses@{no} values('1班', @profession, 2017);
insert into @{middle}_Xclasses@{no} values('2班', @profession, 2017);
insert into @{middle}_Xclasses@{no} values('3班', @profession, 2017);
insert into @{middle}_Xclasses@{no} values('4班', @profession, 2017);
insert into @{middle}_Xclasses@{no} values('5班', @profession, 2017);
insert into @{middle}_Xclasses@{no} values('1班', @profession, 2018);
insert into @{middle}_Xclasses@{no} values('2班', @profession, 2018);
insert into @{middle}_Xclasses@{no} values('3班', @profession, 2018);
insert into @{middle}_Xclasses@{no} values('4班', @profession, 2018);
insert into @{middle}_Xclasses@{no} values('5班', @profession, 2018);

declare @class int
declare @city int
select top 1 @class = @{short}_Cno@{no} from @{middle}_Xclasses@{no}
select top 1 @city = @{short}_Cino@{no} from @{middle}_Cities@{no}
/* 添加学生的种子数据 */
insert into @{middle}_Students@{no} values('S000001', '学生1', 0, 18, 0.0, @class, @city);
insert into @{middle}_Students@{no} values('S000002', '学生2', 1, 17, 0.0, @class, @city);
insert into @{middle}_Students@{no} values('S000003', '学生3', 1, 18, 0.0, @class, @city);
insert into @{middle}_Students@{no} values('S000004', '学生4', 0, 18, 0.0, @class, @city);
insert into @{middle}_Students@{no} values('S000005', '学生5', 0, 18, 0.0, @class, @city);
insert into @{middle}_Students@{no} values('S000006', '学生6', 1, 18, 0.0, @class, @city);
insert into @{middle}_Students@{no} values('S000007', '学生7', 1, 19, 0.0, @class, @city);
insert into @{middle}_Students@{no} values('S000008', '学生8', 1, 18, 0.0, @class, @city);
insert into @{middle}_Students@{no} values('S000009', '学生9', 1, 20, 0.0, @class, @city);

/* 添加教师的种子数据 */
insert into @{middle}_Teachers@{no} values('T000001', '教师1', 0, 34, 0, '13000000000');
insert into @{middle}_Teachers@{no} values('T000002', '教师2', 0, 34, 0, '13000000000');
insert into @{middle}_Teachers@{no} values('T000003', '教师3', 0, 34, 0, '13000000000');
insert into @{middle}_Teachers@{no} values('T000004', '教师4', 0, 34, 0, '13000000000');
insert into @{middle}_Teachers@{no} values('T000005', '教师5', 0, 34, 0, '13000000000');

/* 添加学期的种子数据 */
insert into @{middle}_Terms@{no} values(2020, 0)
insert into @{middle}_Terms@{no} values(2020, 1)

/* 添加课程的种子数据 */
insert into @{middle}_Courses@{no} values('计算机组成原理', 48, 0, 3.0)
insert into @{middle}_Courses@{no} values('数据库原理与应用', 48, 0, 3.0)

declare @tno varchar(20)
declare @cono int
select top 1 @tno = @{short}_Tno@{no} from @{middle}_Teachers@{no}
select top 1 @cono = @{short}_Cono@{no} from @{middle}_Courses@{no}

/* 添加开课的种子数据 */
insert into @{middle}_OpenCourses@{no} values(@cono, @class, 2020, 0, @tno)

declare @ono int
select top 1 @ono = @{short}_Ono@{no} from @{middle}_OpenCourses@{no}
declare @sno varchar(20)
select top 1 @sno = @{short}_Sno@{no} from @{middle}_Students@{no}

/* 添加报告的数据 */
insert into @{middle}_Reports@{no} values (@ono, @sno, 93)

commit

