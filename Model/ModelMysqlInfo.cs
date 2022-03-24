/*
*   Author  :   JackerKun
*   Date    :   Sunday, 20 March 2022 17:27:31
*   About   :
*/

namespace Jc.ToMD.Model.MysqlInfo;

/// <summary>
/// 表字段信息
/// </summary>
public class M_CollumInfo
{
    public override string ToString()
    {
        return column_name+"\t"+column_comment;
    }
    
    /// <summary>
    /// 字段名称
    /// </summary>
    public string column_name { get; set; }

    /// <summary>
    /// 字段注释
    /// </summary>
    public string column_comment { get; set; }

    /// <summary>
    /// 数据类型
    /// </summary>
    public string data_type { get; set; }

    /// <summary>
    /// 数据类型：带长度
    /// int(10)
    /// </summary>
    public string column_type { get; set; }

    /// <summary>
    /// 是否可空
    /// YES｜NO
    /// </summary>
    public string is_nullable { get; set; }

    /// <summary>
    /// 默认值
    /// </summary>
    public string column_default { get; set; }

    /// <summary>
    /// 是否主键
    /// PRI｜null
    /// </summary>
    public string column_key { get; set; }

    public object CHARACTER_MAXIMUM_LENGTH { get; set; }

    public object NUMERIC_PRECISION { get; set; }

    /// <summary>
    /// 表名字
    /// </summary>
    public string TABLE_NAME { get; set; }
}

/// <summary>
/// 表信息
/// </summary>
public class M_TableInfo
{
    public override string ToString()
    {
        return TABLE_NAME+"\t"+TABLE_COMMENT;
    }
    /// <summary>
    /// 表所在数据库
    /// </summary>
    public string TABLE_SCHEMA { get; set;}

    /// <summary>
    /// 表名，视图名
    /// </summary>
    public string TABLE_NAME { get; set; }

    /// <summary>
    /// 表注释：
    /// 视图 没有注释
    /// </summary>
    public string TABLE_COMMENT { get; set; }

    /// <summary>
    /// 表类型：
    /// BASE TABLE
    /// VIEW
    /// </summary>
    public string TABLE_TYPE { get; set; }
 
    /// <summary>
    /// 数据库引擎
    /// </summary>
    public string ENGINE { get; set; }

    /// <summary>
    /// 表编码
    /// </summary>
    public string TABLE_COLLATION { get; set; }
}