using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using jsbestop.Entity;
using jsbestop.Entity.Search;
using Cnkj.Utility;

namespace jsbestop.DAL
{
    public class DALProductPicture : DALExt<ProductPicture, SearchProductPicture>
    {
        public override List<ProductPicture> GetList(SearchProductPicture condition, string sortFieldName, DevNet.Common.ScriptQuery.SortEnum sortEnum)
        {
            throw new System.NotImplementedException();
        }

        public override List<ProductPicture> GetList(SearchProductPicture condition)
        {
            throw new System.NotImplementedException();
        }

        public override List<ProductPicture> GetPageList(SearchProductPicture condition, DevNet.Common.Pagination pagination, string sortFieldName, DevNet.Common.ScriptQuery.SortEnum sortEnum)
        {
            throw new System.NotImplementedException();
        }

        public override List<ProductPicture> GetPageList(SearchProductPicture condition, DevNet.Common.Pagination pagination)
        {
            throw new System.NotImplementedException();
        }

        public override System.Data.DataTable GetPageTable(SearchProductPicture condition, DevNet.Common.Pagination pagination, string sortFieldName, DevNet.Common.ScriptQuery.SortEnum sortEnum)
        {
            throw new System.NotImplementedException();
        }

        public override System.Data.DataTable GetPageTable(SearchProductPicture condition, DevNet.Common.Pagination pagination)
        {
            throw new System.NotImplementedException();
        }

        public override System.Data.DataTable GetTable(SearchProductPicture condition, string sortFieldName, DevNet.Common.ScriptQuery.SortEnum sortEnum)
        {
            throw new System.NotImplementedException();
        }

        public override System.Data.DataTable GetTable(SearchProductPicture condition)
        {
            throw new System.NotImplementedException();
        }
    }
}

