using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cnkj.Utility;
using jsbestop.Entity;
using jsbestop.Entity.Search;

namespace jsbestop.DAL
{
    public class DALComBanner : DALExt<ComBanner, SearchComBanner>
    {
        public override List<ComBanner> GetList(SearchComBanner condition, string sortFieldName, DevNet.Common.ScriptQuery.SortEnum sortEnum)
        {
            throw new System.NotImplementedException();
        }

        public override List<ComBanner> GetList(SearchComBanner condition)
        {
            Script.Select().ALL().From().Where();
            if (condition.ComBannerTypeID > 0)
                Script.Where(ComBanner.ComBannerTypeID_FieldName, condition.ComBannerTypeID);
            List<ComBanner> lists = Script.GetList<ComBanner>();
            return lists;
        }

        public override List<ComBanner> GetPageList(SearchComBanner condition, DevNet.Common.Pagination pagination, string sortFieldName, DevNet.Common.ScriptQuery.SortEnum sortEnum)
        {
            Script.Select().ALL().From().Where();
            Script.PageIndex = pagination.PageIndex;
            Script.PageSize = pagination.PageSize;
            List<ComBanner> lists = Script.GetList<ComBanner>();
            pagination.RecordCount = Script.RecordCount;

            return lists;
        }

        public override List<ComBanner> GetPageList(SearchComBanner condition, DevNet.Common.Pagination pagination)
        {
            throw new System.NotImplementedException();
        }

        public override System.Data.DataTable GetPageTable(SearchComBanner condition, DevNet.Common.Pagination pagination, string sortFieldName, DevNet.Common.ScriptQuery.SortEnum sortEnum)
        {
            throw new System.NotImplementedException();
        }

        public override System.Data.DataTable GetPageTable(SearchComBanner condition, DevNet.Common.Pagination pagination)
        {
            throw new System.NotImplementedException();
        }

        public override System.Data.DataTable GetTable(SearchComBanner condition, string sortFieldName, DevNet.Common.ScriptQuery.SortEnum sortEnum)
        {
            throw new System.NotImplementedException();
        }

        public override System.Data.DataTable GetTable(SearchComBanner condition)
        {
            throw new System.NotImplementedException();
        }
    }
}
