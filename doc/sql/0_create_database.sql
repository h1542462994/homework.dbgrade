/* 创建数据库 */
create database @{full}MIS@{no}
on (
    name = @{full}MIS@{no}_data,
    filename = '@{root}\@{full}MIS@{no}.mdf',
    size = 10,
    maxsize = 50,
    filegrowth = 5
)
log on (
    name = @{full}MIS@{no}_log,
    filename = '@{root}\@{full}MIS@{no}.ldf',
    size = 5,
    maxsize = 25,
    filegrowth = 5
)
go

alter database @{full}MIS@{no} collate Chinese_PRC_CI_AS