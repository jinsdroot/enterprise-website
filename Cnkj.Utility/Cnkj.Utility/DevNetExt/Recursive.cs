using System;
using System.Collections.Generic;
using System.Data;
using DevNet.Common;
using DevNet.Common.Logger;
using DevNet.DBAccess;

namespace Cnkj.Utility
{
	/// <summary>
	/// �ݹ������
	/// </summary>
	public class Recursive
	{
		/// <summary>
		/// ���صݹ��ı�����飬�������ڰ���ָ��������ż����������ı�ţ��쳣�򷵻�ֻ����ָ������������
		/// </summary>
		/// <param name="dbCon">�������Ӷ���</param>
		/// <param name="tableName">���ݱ���</param>
		/// <param name="flagID">���ID���ֶ����ƣ�</param>
		/// <param name="flagIDValue">���ID��ֵ</param>
		/// <param name="flagParentID">������ֶ�����</param>
		/// <param name="condtion">������Ʃ�磺isdel=0 and nety_ischeck=1������Ϊ��</param>
		/// <param name="sortFieldName">�����ֶ�</param>
		/// <param name="sortEnum">����ö��</param>
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