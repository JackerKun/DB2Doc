/*
*   Author  :   JackerKun
*   Date    :   Monday, 21 March 2022 12:05:39
*   About   :
*/

using System.Reflection;
 

namespace Jc.ToMD.APIToMd;

/// <summary>
///  。net WebApi
/// </summary>
public class WebApiToMd:IApiToMd
{
    private readonly string _assemblyPath;
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="assemblyPath"></param>
    public WebApiToMd(string assemblyPath)
    {
        _assemblyPath = assemblyPath;
    }

    /// <summary>
    /// 获取信息
    /// </summary>
    public void GetInfos()
    {
      
    }
}