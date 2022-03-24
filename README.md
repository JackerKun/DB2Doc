# Jc.ToMD

一个转markdown的模块

#### 数据库转MarkDown

1。Mysql to Md    <font color=#0099ff>已完成</font>

2。Sqlserver to Md

3。Sqlite to md

#### API 转 MarkDown

1。net core api to md

2。swagger json to md

#### 实例化
```c#
    Jc.ToMD.DBToMD md = new Jc.ToMD.DBToMD(new Jc.ToMD.DbToMd.MysqlToMd(
        "192.168.1.114",
        "YTKHOS",
        "root",
        "password"
    ));
    
    /// <summary>
    /// MysqlToMd:连接数据库
    /// </summary>
    /// <param name="host"></param>
    /// <param name="dbName"></param>
    /// <param name="uid"></param>
    /// <param name="pwd"></param>
    /// <param name="port"></param>
    public MysqlToMd(string host, string dbName, string uid, string pwd, int port = 3306)
```


#### 保存到文件
```c#
md.OutToFile("1.md");
```

#### 返回字符串内容
```c#
string result = md.OutToString();
```

# 返回MD示例

### t_cfg_menu

***菜单表***

|字段名|数据类型|默认值|是否空|是否主键|注释|
|---|---|---|---|---|---|
|F_MENU_ID|bigint(50)| |NO|PRI|菜单ID|
|F_MENU_NAME|varchar(255)| |YES| |菜单名称|
|F_MENU_URL|varchar(255)| |YES| |菜单相对路径|
|F_MENU_PARENT_ID|bigint(50)|0|YES| |父菜单ID|
|F_REMARK|text| |YES| |备注信息|
|F_ISDELETED|int(2)|0|YES| |是否删除|

### t_cfg_role

***角色表***

|字段名|数据类型|默认值|是否空|是否主键|注释|
|---|---|---|---|---|---|
|F_ROLE_ID|bigint(50)| |NO|PRI|角色ID|
|F_ROLE_Name|varchar(255)| |YES| |角色名称|
|F_CREATETIME|bigint(50)| |YES| |创建时间|
|F_ISDELETE|int(2)|0|YES| |是否删除|