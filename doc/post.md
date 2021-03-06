# 实验报告模板

## 1 需求分析

先介绍系统开发意义、可行性和应用环境等。

### 1.1 数据需求描述 

分析系统的数据需求，用数据字典和数据流图描述系统的数据需求，一般要求有2级（初级和详细级）数据流图，并确定系统开发边界。

### 1.2 系统功能需求 

系统功能框架介绍，处理模块描述。

### 1.3 其他性能需求

其他性能分析，如并发用户数、响应时间和存储需求描述等。

## 2 概念结构设计

### 2.1 局部E-R图

画出局部的E-R图，进一步进行解释说明。

### 2.2 全局E-R图

合并成全局的E-R图，进一步进行解释说明。
### 2.3 优化E-R图

对全局的的E-R图进行优化设计，进一步进行解释说明。

## 3 逻辑结构设计

### 3.1 关系模式设计

将E-R图转换为关系模式，定义实体型、属性及其联系。

### 3.2 数据类型定义
    对关系模式中的属性定义类型、长度和约束
### 3.3 关系模式的优化

对关系模式进行规范化处理，对关系模式进行评价与修正

## 4 物理结构设计

### 4.1 聚簇设计
   
   确定每个关系需要或不需要聚簇索引，为什么需要聚簇索引，在哪些列上建立聚簇索引。

### 4.2 索引设计
   确定每个关系需要或不需要聚簇索引，为什么需要聚簇索引，在哪些列上建立聚簇索引。

### 4.3 分区设计
数据库文件和日志文件的分区问题。

## 5 数据库实施
（全部操作都要在SQL Server的查询分析器或SQL Server的SSMS环境中用命令实现，并要求截图）比如如图5-1所示。
 
图5-1 创建基本表”学生sjl”

### 5.1 基本表建立

### 5.2 视图的建立

### 5.3 索引的建立

### 5.4 触发器建立 

### 5.5 建存储过程

## 6 应用系统开发与试运行

### 6.1 开发平台和开发环境介绍。

### 6.2 前台界面与后台数据库连接说明，代码实现。

### 6.3 系统各功能设计和运行界面截图。
   学生名词排定结果如图6-4所示
 
图6-4 学生名词排定结果展示图

## 7 实验总结

### 7.1 遇到的问题和解决的办法

### 7.2 系统设计的不足

### 7.3 进一步改进思路和体会
