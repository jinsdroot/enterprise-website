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
    public class DALContact : DALExt<Contact, SearchContact>
    {
        public override List<Contact> GetList(SearchContact condition, string sortFieldName, DevNet.Common.ScriptQuery.SortEnum sortEnum)
        {
            throw new System.NotImplementedException();
        }

        public override List<Contact> GetList(SearchContact condition)
        {
            throw new System.NotImplementedException();
        }

        public override List<Contact> GetPageList(SearchContact condition, DevNet.Common.Pagination pagination, string sortFieldName, DevNet.Common.ScriptQuery.SortEnum sortEnum)
        {
            throw new System.NotImplementedException();
        }

        public override List<Contact> GetPageList(SearchContact condition, DevNet.Common.Pagination pagination)
        {
            throw new System.NotImplementedException();
        }

        public override System.Data.DataTable GetPageTable(SearchContact condition, DevNet.Common.Pagination pagination, string sortFieldName, DevNet.Common.ScriptQuery.SortEnum sortEnum)
        {
            throw new System.NotImplementedException();
        }

        public override System.Data.DataTable GetPageTable(SearchContact condition, DevNet.Common.Pagination pagination)
        {
            throw new System.NotImplementedException();
        }

        public override System.Data.DataTable GetTable(SearchContact condition, string sortFieldName, DevNet.Common.ScriptQuery.SortEnum sortEnum)
        {
            throw new System.NotImplementedException();
        }

        public override System.Data.DataTable GetTable(SearchContact condition)
        {
            throw new System.NotImplementedException();
        }
    }
}
