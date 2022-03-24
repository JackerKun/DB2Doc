/*
*   Author  :   JackerKun
*   Date    :   Thursday, 17 March 2022 14:32:43
*   About   :
*/

using Jc.ToMD.APIToMd;

namespace Jc.ToMD;

public class ApiToMD
{
    public ApiToMD(IApiToMd apiToMd)
    {
        apiToMd.GetInfos();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="filePath"></param>
    /// <returns></returns>
    public bool OutToFile(string filePath)
    {
        bool result = false;
        try
        {
            
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        return result;
    }
    
    public string? OutToString()
    {
        string? result = null;
        try
        {
            
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        return result;
    }

    private void CreateFile()
    {
        
    }
}