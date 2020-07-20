# homework.dbgrade
 实验-大二短 | 数据库课程设计-成绩管理系统

## 相关文档

- [课程设计的内容](./doc/request.md)

- [数据库系统系统课程设计考核与答辩程序](./doc/procedure.md)

- [报告模板](./doc/post.md)

- [需求分析](./doc/require.md)

- [概念结构设计](./doc/abstract.md)

- [结构设计](./doc/logical_struct.md)

- [应用系统开发](./doc/program.md)

## 工作周期

- 分析业务处理流程，给出数据流图。
- 进行分析画出e-r图。
- 给出关系模式
- 根据关系模式确定各个属性的范围，确定需要的约束和触发器，创建数据表。
- 根据业务的流程确定需要的视图，定义视图。
- 进行后端接口的设计和编写
- 进行前台界面的设计和编写

## sqlcreator

一个附带的工具，用于提供方便的模板替换。

打开`sqlcreator.exe`之后，会生成`data`文件夹。

请修改`config.json`中的`args`为自己的配置，也可以自己添加变量。

关闭，并将需要修改的文件放入`\data\source`内，其会将所有满足`@{arg}`的部分替换，替换规则遵循`args`的配置。

### 自动拷贝

在`config.json`中添加以下代码可以完成自动拷贝工作（仅拷贝`source`文件夹内的文件）

```json
{
    "options": {
        "autocopy": true,
        "autocopy-target": "${directoryUri}"
    }
}
```

## 注意事项

- 在后端系统中已经写好了自动重命名的服务，让数据库奇怪的命名方式对代码透明。

- 在系统中出现难以解决的问题，请提交至[Issue](https://github.com/h1542462994/homework.dbgrade/issues)