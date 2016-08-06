using System;
using System.Collections.Generic;
using System.Data;
using DevNet.Common;
using DevNet.Common.Logger;
using DevNet.DBAccess;

namespace Cnkj.Utility
{
	/// <summary>
	/// 递归帮助类
	/// </summary>
	public class Recursive
	{
		/// <summary>
		/// 返回递归后的编号数组，该数组内包含指定参数编号及所有子类别的编号，异常则返回只包含指定参数的数组
		/// </summary>
		/// <param name="dbCon">数据连接对象</param>
		/// <param name="tableName">数据表名</param>
		/// <param name="flagID">标记ID的字段名称，</param>
		/// <param name="flagIDValue">标记ID的值</param>
		/// <param name="flagParentID">父标记字段名称</param>
		/// <param name="condtion">条件（譬如：isdel=0 and nety_ischeck=1）可以为空</param>
		/// <param name="sortFieldName">排序字段</param>
		/// <param name="sortEnum">排序枚举</param>
		/// <returns></returns>
		public  static object[] GetRecurArray(DBConnect dbCon, string tableName, string flagID, object flagIDValue, string flagParentID,string condtion,string sortFieldName,DevNet.Common.ScriptQuery.SortEnum sortEnum)
		{
			List<object> lists = new List<object>();
			lists.Add(flagIDValue);
			bool needOpen = (dbCon.ConnState != ConnectionState.Open);
			try
			{
				if (needOpen)
				{
					dbCon.OpenConn();
				}
				ScriptQuery script = new ScriptQuery(dbCon, tableName);
				script.Select().Select(flagID).From().Where(flagParentID, flagIDValue);
				if(!string.IsNullOrEmpty(condtion))
				{
					script.AddSqlText(" and " + condtion);
				}
				DataTable dt = script.AddOrderBy().OrderBy(sortFieldName,sortEnum).GetDataTable();
				foreach (DataRow dr in dt.Rows)
				{
					lists.Add(dr[flagID]);
					addChild(script, dr, flagID, flagParentID,condtion, lists,sortFieldName,sortEnum);
				}
			}
			catch (Exception ex)
			{
				Log.Error(ex.Message, ex);
				lists.Clear();
				lists.Add(flagIDValue);
     		}
			finally
			{
				if (needOpen)
				{
					dbCon.CloseConn();
				}
			}
			return lists.ToArray();
		}

		private static void addChild(ScriptQuery script, DataRow dr, string flagID, string flagParentID,string condition, List<object> lists,string sortFieldName,DevNet.Common.ScriptQuery.SortEnum sortEnum)
		{
			script.Select().Select(flagID).From().Where(flagParentID, dr[flagID]);
			if(!string.IsNullOrEmpty(condition))
			{
				script.AddSqlText(" and " + condition);
			}
			DataTable dt =
				script.AddOrderBy().OrderBy(sortFieldName, sortEnum).
					GetDataTable();
			foreach (DataRow ddr in dt.Rows)
			{
				lists.Add(ddr[flagID]);
				addChild(script, ddr, flagID, flagParentID,condition, lists, sortFieldName, sortEnum);
			}
		}
	}
}