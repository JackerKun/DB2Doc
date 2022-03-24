/*
*   Author  :   JackerKun
*   Date    :   Thursday, 17 March 2022 14:31:18
*   About   :
*/

using System.Net;
using System.Text;
using Jc.ToMD.DbToMd;
 
using Jc.ToMD.Model.MysqlInfo;

namespace Jc.ToMD;

public class DBToMD
{

    /// <summary>
    /// 表头:和表格是对应关系 需要手动改写代码
    /// </summary>
    private List<string> _hearders = new List<string>()
    {
        "字段名",
        "数据类型",
        "默认值",
        "是否空",
        "是否主键",
        "注释"
    };
    
    /// <summary>
    /// 设置title
    /// </summary>
    /// <param name="Hearder"></param>
    // public void SetHearder(List<string> Hearder)
    // {
    //     if (Hearder != null && Hearder.Count > 0)
    //     {
    //         _hearders = Hearder;
    //     }
    // }

    private readonly List<M_TableInfo> _tables;
    private readonly List<M_CollumInfo> _collum;
    
    /// <summary>
    /// 实例化
    /// </summary>
    /// <param name="dbToMd"></param>
    public DBToMD(IDbToMd dbToMd)
    {
        try
        {
            var res= dbToMd.GetInfos();
            if (res != null)
            {
                _tables= res.Value.tableInfos;
                _collum= res.Value.collumInfos;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    /// <summary>
    /// 保存到文件
    /// </summary>
    /// <param name="filePath"></param>
    /// <returns></returns>
    public bool OutToFile(string filePath)
    {
        bool result = false;
        try
        {
            if (_tables != null && _collum != null)
            {
                if (CreateMDFile(_tables, _collum, filePath) == null)
                {
                    result = false;
                }
                else
                {
                    result = true;
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            result = false;
            throw;
        }
        return result;
    }

    /// <summary>
    /// 返回字符串
    /// </summary>
    /// <returns></returns>
    public string? OutToString()
    {
        string? result = null;
        try
        {
            if (_tables != null && _collum != null)
            {
               result= CreateMDFile(_tables, _collum, null);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        return result;
    }

    /// <summary>
    /// 创建信息
    /// </summary>
    /// <param name="tableInfos"></param>
    /// <param name="collumInfos"></param>
    /// <param name="filePath"></param>
    /// <returns></returns>
    private string? CreateMDFile(
        List<M_TableInfo> tableInfos,
        List<M_CollumInfo> collumInfos,
        string? filePath)
    {
        string? result = null;
        try
        {
            //头部模板
            string strHearder = MdTableHeader(_hearders);
            StringBuilder resultStr = new StringBuilder();
            //dbname
            if (tableInfos.Count > 0)
            {
                resultStr.Append($"# {tableInfos[0].TABLE_SCHEMA} \r\n\r\n");
            }
            foreach (var t in tableInfos)
            {
                resultStr.Append(MdTableTitle(t));
                resultStr.Append(strHearder);
                resultStr.Append(MdTableColums(collumInfos, t.TABLE_NAME));
            }
            result = resultStr.ToString();
            if (filePath != null)
            {
                System.IO.File.WriteAllText(filePath, result);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        return result;
    }

    /// <summary>
    /// 表信息
    /// </summary>
    /// <param name="tableInfo"></param>
    /// <returns></returns>
    private string MdTableTitle(M_TableInfo tableInfo)
    {
        return $"### {tableInfo.TABLE_NAME}\r\n\r\n ***{tableInfo.TABLE_COMMENT}***\t {(tableInfo.TABLE_TYPE=="BASE TABLE"?"":"View")}\r\n\r\n";
    }

    /// <summary>
    /// 计算头部
    /// </summary>
    /// <param name="Hearders"></param>
    /// <returns></returns>
    private string MdTableHeader(List<string> Hearders)
    {
        StringBuilder str = new StringBuilder();
        str.Append("|"+string.Join("|", _hearders.ToArray())+"|\r\n");
        str.Append("|");
        for (int i = 0; i < _hearders.Count; i++)
        {
            str.Append("---|");
        }
        str.Append("\r\n");
        return str.ToString();
    }

    /// <summary>
    /// 表格信息
    /// </summary>
    /// <param name="collumInfos"></param>
    /// <param name="tableName"></param>
    /// <returns></returns>
    private string MdTableColums(List<M_CollumInfo> collumInfos, string tableName)
    {
        StringBuilder str = new StringBuilder();
        List<M_CollumInfo> infos = collumInfos.FindAll(t => t.TABLE_NAME == tableName);
        if (infos != null && infos.Count > 0)
        {
            foreach (var t in infos)
            {
                str.Append($"|{EmptySpace(t.column_name)}|{EmptySpace(t.column_type)}|{EmptySpace(t.column_default)}|{EmptySpace(t.is_nullable)}|{EmptySpace(t.column_key)}|{EmptySpace(t.column_comment)}|\r\n");
            }
        }
        str.Append("\r\n");
        return str.ToString();
    }

    /// <summary>
    /// 空位 补充空格
    /// 特殊字符 替换
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    private string EmptySpace(string value)
    {
        if (value.Trim() == "")
        {
            return " ";
        }
        else
        {
            //将数据中的|半角，替换成全角｜ 否则md会解析
            return value.Replace("|","｜");
        }
    }

}