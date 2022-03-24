/*
*   Author  :   JackerKun
*   Date    :   Sunday, 20 March 2022 17:28:51
*   About   :
*/

using System.Data;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Loader;
using System.Xml.Linq;

namespace Jc.ToMD;

/// <summary>
/// 
/// </summary>
public class Utils
{
    /// <summary>
    /// table转模型
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="dt"></param>
    /// <returns></returns>
    public static List<T> GetModelFromDB<T>(DataTable dt)
    {
        List<T> data = new List<T>();
        foreach (DataRow row in dt.Rows)
        {
            T item = DataRowsConversion<T>(row);
            data.Add(item);
        }
        return data;
    }
    
    /// <summary>
    /// 遍历 Row
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="dr"></param>
    /// <returns></returns>
    public  static T DataRowsConversion<T>(DataRow dr)
    {
        try
        {
            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();
            foreach (DataColumn column in dr.Table.Columns)
            {
                foreach (PropertyInfo pro in temp.GetProperties())
                {
                    if (pro.Name.ToLower() == column.ColumnName.ToLower())
                    {
                        if (dr[column.ColumnName] == DBNull.Value)
                        {
                            pro.SetValue(obj, " ", null);
                            break;
                        }
                        else
                        {
                            pro.SetValue(obj, dr[column.ColumnName]);
                            break;
                        }
                    }
                }
            }
            return obj;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}