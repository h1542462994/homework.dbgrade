/* 创建各个数据表 */
set xact_abort on
begin transaction Tcreate_tables
create table @{middle}_Professions@{no} (
    @{short}_Pno@{no} int primary key identity,
    @{short}_Name@{no} varchar(20) not null,
)

create table @{middle}_Xclasses@{no} (
    @{short}_Cno@{no} int primary key identity,
    @{short}_Name@{no} varchar(20) not null,
    @{short}_Pno@{no} int not null foreign key references @{middle}_Professions@{no},
    @{short}_Year@{no} int not null
)

create table @{middle}_Provinces@{no} (
    @{short}_Prno@{no} int primary key identity,
    @{short}_Name@{no} varchar(20) not null,
    @{short}_SummaryCount@{no} int default(0)
)

create table @{middle}_Cities@{no} (
    @{short}_Cino@{no} int primary key identity,
    @{short}_Name@{no} varchar(20) not null,
    @{short}_Prno@{no} int not null foreign key references @{middle}_Provinces@{no},
    @{short}_SummaryCount@{no} int default(0)
)

create table @{middle}_Students@{no} (
    @{short}_Sno@{no} varchar(20) primary key,
    @{short}_Name@{no} varchar(20) not null,
    @{short}_Sex@{no} int default(0) check(@{short}_Sex@{no} in (0,1)),
    @{short}_Age@{no} int not null check(@{short}_Age@{no} > 0),
    @{short}_TotalCredit@{no} float default(0),
    @{short}_Cno@{no} int not null foreign key references @{middle}_Xclasses@{no} ,
    @{short}_Cino@{no} int not null foreign key references @{middle}_Cities@{no} 
)

create table @{middle}_Teachers@{no} (
    @{short}_Tno@{no} varchar(20) primary key,
    @{short}_Name@{no} varchar(20) not null,
    @{short}_Sex@{no} int default(0) check(@{short}_Sex@{no} in (0,1)),
    @{short}_Age@{no} int default(0) check(@{short}_Age@{no} > 0),
    @{short}_Level@{no} int default(0) check(@{short}_Level@{no} in (0,1,2)),
    @{short}_Phone@{no} varchar(11) not null,
)

create table @{middle}_Terms@{no} (
    @{short}_Year@{no} int not null check(@{short}_Year@{no} > 0),
    @{short}_Term@{no} int not null check(@{short}_Term@{no} in (0,1)),
    primary key (@{short}_Year@{no}, @{short}_Term@{no})
)

create table @{middle}_Courses@{no} (
    @{short}_Cono@{no} int primary key identity,
    @{short}_Name@{no} varchar(20) not null,
    @{short}_Period@{no} int not null check(@{short}_Period@{no} > 0),
    @{short}_Way@{no} int not null check(@{short}_Way@{no} in (0,1)),
    @{short}_Credit@{no} float default(0) check (@{short}_Credit@{no} > 0)
)

create table @{middle}_OpenCourses@{no} (
    @{short}_Ono@{no} int primary key identity,
    @{short}_Cono@{no} int not null foreign key references @{middle}_Courses@{no} ,
    @{short}_Cno@{no} int not null foreign key references @{middle}_Xclasses@{no} ,
    unique (@{short}_Cono@{no}, @{short}_Cno@{no}),
    @{short}_Year@{no} int not null,
    @{short}_Term@{no} int not null,
    foreign key (@{short}_Year@{no}, @{short}_Term@{no}) references @{middle}_Terms@{no} ,
    @{short}_Tno@{no} varchar(20) not null foreign key references @{middle}_Teachers@{no} 
)

create table @{middle}_Reports@{no} (
    @{short}_Ono@{no} int not null foreign key references @{middle}_OpenCourses@{no} ,
    @{short}_Sno@{no} varchar(20) not null foreign key references @{middle}_Students@{no} ,
    @{short}_Grade@{no} float not null check (@{short}_Grade@{no} >= 0 and @{short}_Grade@{no} <= 100),
    primary key (@{short}_Ono@{no}, @{short}_Sno@{no})
)

create index index_OpenCourse_Cno
on @{middle}_OpenCourses@{no}(@{short}_Cno@{no})

create index index_OpenCourse_Cono
on @{middle}_OpenCourses@{no}(@{short}_Cono@{no})

create index index_Report_Ono on
@{middle}_Reports@{no}(@{short}_Ono@{no})

create index index_Report_Sno on
@{middle}_Reports@{no}(@{short}_Sno@{no})

commit