using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cnkj.Utility;
using DevNet.Common.Entity;
using jsbestop.Entity.Search;
using jsbestop.Entity;
using System.Data;

namespace jsbestop.DAL
{
	public class DALAdminUser:DALExt<AdminUser,SearchAdminUser>
	{
		public override List<AdminUser> GetList(SearchAdminUser condition, string sortFieldName, DevNet.Common.ScriptQuery.SortEnum sortEnum)
		{
			throw new System.NotImplementedException();
		}

		public override List<AdminUser> GetList(SearchAdminUser condition)
		{
			throw new System.NotImplementedException();
		}

		public override List<AdminUser> GetPageList(SearchAdminUser condition, DevNet.Common.Pagination pagination, string sortFieldName, DevNet.Common.ScriptQuery.SortEnum sortEnum)
		{
			Script.Select().ALL().From().Where();
			if (!string.IsNullOrEmpty(condition.Account))
				Script.Like(AdminUser.Account_FieldName, condition.Account);
			
			if (!string.IsNullOrEmpty(condition.TrueName))
			{
				Script.Like(AdminUser.TrueName_FieldName, condition.TrueName);
			}
			
			Script.AddOrderBy().OrderBy(sortFieldName, sortEnum);

			Script.PageIndex = pagination.PageIndex;
			Script.PageSize = pagination.PageSize;

			List<AdminUser> lists = Script.GetList<AdminUser>();
			pagination.RecordCount = Script.RecordCount;

			return lists;
		}

		public override List<AdminUser> GetPageList(SearchAdminUser condition, DevNet.Common.Pagination pagination)
		{
			return GetPageList(condition, pagination, AdminUser.AddDate_FieldName, DevNet.Common.ScriptQuery.SortEnum.ASC);
		}

		public override System.Data.DataTable GetPageTable(SearchAdminUser condition, DevNet.Common.Pagination pagination, string sortFieldName, DevNet.Common.ScriptQuery.SortEnum sortEnum)
		{
			throw new System.NotImplementedException();
		}

		public override System.Data.DataTable GetPageTable(SearchAdminUser condition, DevNet.Common.Pagination pagination)
		{
			throw new System.NotImplementedException();
		}

		public override System.Data.DataTable GetTable(SearchAdminUser condition, string sortFieldName, DevNet.Common.ScriptQuery.SortEnum sortEnum)
		{
			throw new System.NotImplementedException();
		}

		public override System.Data.DataTable GetTable(SearchAdminUser condition)
		{
			throw new System.NotImplementedException();
		}

        public int GetMaxID()
        {


            string q = Script.Max(AdminUser.ID_FieldName).ToString();

            return 0;
        }

	}
}