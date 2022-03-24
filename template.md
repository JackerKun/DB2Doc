

# API Demo

### 1.用户登陆
###### API说明
> 获取制定项目的分类信息

###### API属性

| 名称           |类型| 方式   |
|--------------|---|------|
| APIName      |Json| Post |

###### 请求参数

> 数据类型：```List<Parm>```

|参数|必选|类型|说明|
|:-----  |:-------|:-----|-----                               |
|name    |ture    |string|请求的项目名                          |
|type    |true    |int   |请求项目的类型。1：类型一；2：类型二 。|

###### 返回字段

> 数据类型：```ResultObj<List<result>>```

|返回字段|字段类型|说明                              |
|:-----   |:------|:-----------------------------   |
|status   |int    |返回结果状态。0：正常；1：错误。   |
|company  |string | 所属公司名                      |
|category |string |所属类型                         |

###### 返回参示例
``` javascript
{
    "statue": 0,
    "company": "可口可乐",
    "category": "饮料",
}
```

# Table Demo

## 数据库信息

### t_cfg_menu
***菜单表***

| 字段名                                  | 数据类型       | 默认值 | 允许空   | 是否主键 | 注释  |
|:-------------------------------------|------------|-----|-------|------|-----|
| F_MENU_ID                            | bigint(50) |     | NO    | YES | 菜单ID |
| F_MENU_IDddddddssssssssssssssssssss  | bigint(50) |     | NO    | YES | 菜单ID |
 