/*
*   Author  :   JackerKun
*   Date    :   DATE TIME
*   About   :
*/

using System.Data;
using Jc.ToMD.Model;
using Jc.ToMD.Model.MysqlInfo;

namespace Jc.ToMD.DbToMd;

public interface IDbToMd
{
    public (List<M_TableInfo> tableInfos, List<M_CollumInfo> collumInfos )? GetInfos();
}