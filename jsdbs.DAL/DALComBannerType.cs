using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cnkj.Utility;
using jsbestop.Entity;
using jsbestop.Entity.Search;

namespace jsbestop.DAL
{
  public class DALComBannerType : DALExt<ComBannerType, SearchComBannerType>
    {
        public override List<ComBannerType> GetList(SearchComBannerType condition, string sortFieldName, DevNet.Common.ScriptQuery.SortEnum sortEnum)
        {
            throw new System.NotImplementedException();
        }

        public override List<ComBannerType> GetList(SearchComBannerType condition)
        {
            throw new System.NotImplementedException();
        }

        public override List<ComBannerType> GetPageList(SearchComBannerType condition, DevNet.Common.Pagination pagination, string sortFieldName, DevNet.Common.ScriptQuery.SortEnum sortEnum)
        {
            Script.Select().ALL().From().Where();
            if (!string.IsNullOrEmpty(condition.ComBannerTypeName))
                Script.Like(ComBannerType.ComBannerTypeName_FieldName, condition.ComBannerTypeName);
            if (condition.IsEnglish > 0)
            {
                Script.Where(ComBannerType.IsEnglish_FieldName, condition.IsEnglish);
            }
            Script.AddOrderBy().OrderBy(sortFieldName, sortEnum);
            Script.PageIndex = pagination.PageIndex;
            Script.PageSize = pagination.PageSize;

            List<ComBannerType> lists = Script.GetList<ComBannerType>();
            pagination.RecordCount = Script.RecordCount;

            return lists;
        }

        public override List<ComBannerType> GetPageList(SearchComBannerType condition, DevNet.Common.Pagination pagination)
        {
            throw new System.NotImplementedException();
        }

        public override System.Data.DataTable GetPageTable(SearchComBannerType condition, DevNet.Common.Pagination pagination, string sortFieldName, DevNet.Common.ScriptQuery.SortEnum sortEnum)
        {
            throw new System.NotImplementedException();
        }

        public override System.Data.DataTable GetPageTable(SearchComBannerType condition, DevNet.Common.Pagination pagination)
        {
            throw new System.NotImplementedException();
        }

        public override System.Data.DataTable GetTable(SearchComBannerType condition, string sortFieldName, DevNet.Common.ScriptQuery.SortEnum sortEnum)
        {
            throw new System.NotImplementedException();
        }

        public override System.Data.DataTable GetTable(SearchComBannerType condition)
        {
            Script.Select().ALL().From().Where();

            Script.AddOrderBy().OrderBy(ComBannerType.ID_FieldName, DevNet.Common.ScriptQuery.SortEnum.DESC);
            return Script.GetDataTable();
        }
    }
}
