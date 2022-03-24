/*
*   Author  :   JackerKun
*   Date    :   Sunday, 13 March 2022 16:37:07
*   About   :
*/

using System.Data;
using Jc.Db.Mysql;
using Jc.ToMD.Model;
using Jc.ToMD.Model.MysqlInfo;
using MySql.Data.MySqlClient;

namespace Jc.ToMD.DbToMd;

/// <summary>
/// 数据库生成文档模块
/// </summary>
public class MysqlToMd : IDbToMd
{

	/// <summary>
	/// 数据库连接字符串
	/// </summary>
	private readonly string _conn;

	/// <summary>
	/// 数据库名字
	/// </summary>
	private readonly string _dbName;

	/// <summary>
	/// db数据库对象
	/// </summary>
	private readonly Jc.Db.Mysql.DbMysql _dbMysql;

	/// <summary>
	/// 连接数据库
	/// </summary>
	/// <param name="host"></param>
	/// <param name="dbName"></param>
	/// <param name="uid"></param>
	/// <param name="pwd"></param>
	/// <param name="port"></param>
	public MysqlToMd(string host, string dbName, string uid, string pwd, int port = 3306)
	{
		try
		{
			_dbName = dbName;
			_conn = $"server={host};port={port};database={dbName};uid={uid};pwd={pwd};Charset=utf8;";
			_dbMysql = new DbMysql(_conn);
		}
		catch (Exception e)
		{
			Console.WriteLine(e);
			throw;
		}
	}

	/// <summary>
	/// 获取信息
	/// table[0]:表信息
	/// table[1]:字段信息
	/// </summary>
	/// <returns></returns>
	public (List<M_TableInfo> tableInfos, List<M_CollumInfo> collumInfos )? GetInfos()
	{
		List<M_TableInfo> _tables = null;
		List<M_CollumInfo> _colums = null;
		try
		{
			DataSet dts =
				_dbMysql.Query(
					$"SELECT * FROM information_schema.Tables WHERE  TABLE_SCHEMA ='{_dbName}';SELECT *  FROM information_schema. COLUMNS WHERE  TABLE_SCHEMA = '{_dbName}';");
			if (dts.Tables.Count > 0 && dts.Tables.Count == 2)
			{
				_tables = Utils.GetModelFromDB<M_TableInfo>(dts.Tables[0]);
				_colums = Utils.GetModelFromDB<M_CollumInfo>(dts.Tables[1]);
			}
		}
		catch (Exception e)
		{
			Console.WriteLine(e);
			throw;
		}

		return (_tables, _colums);
	}
}