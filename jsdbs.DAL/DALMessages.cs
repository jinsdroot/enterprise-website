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
   public class DALMessages : DALExt<Messages, SearchMessages>
    {
        public override List<Messages> GetList(SearchMessages condition, string sortFieldName, DevNet.Common.ScriptQuery.SortEnum sortEnum)
        {
            throw new System.NotImplementedException();
        }

        public override List<Messages> GetList(SearchMessages condition)
        {
            throw new System.NotImplementedException();
        }
        //public override List<Messages> GetPageList(SearchMessages condition, DevNet.Common.Pagination pagination)
        //{
        //    //throw new System.NotImplementedException();
        //    Script.Select().ALL().From().Where();

        //    Script.PageIndex = pagination.PageIndex;
        //    Script.PageSize = pagination.PageSize;

        //    List<Messages> lists = Script.GetList<Messages>();
        //    pagination.RecordCount = Script.RecordCount;

        //    return lists;
        //}

        public override List<Messages> GetPageList(SearchMessages condition, DevNet.Common.Pagination pagination, string sortFieldName, DevNet.Common.ScriptQuery.SortEnum sortEnum)
        {
            throw new System.NotImplementedException();
        }

        public override List<Messages> GetPageList(SearchMessages condition, DevNet.Common.Pagination pagination)
        {

            Script.Select().ALL().From().Where();
            if (!string.IsNullOrEmpty(condition.MesTitle))
                Script.Like(Messages.MesTitle_FieldName, condition.MesTitle);

            Script.AddOrderBy().OrderBy(Messages.MesDate_FieldName, DevNet.Common.ScriptQuery.SortEnum.DESC);
            Script.PageIndex = pagination.PageIndex;
            Script.PageSize = pagination.PageSize;

            List<Messages> lists = Script.GetList<Messages>();
            pagination.RecordCount = Script.RecordCount;

            return lists;

        }

        public override System.Data.DataTable GetPageTable(SearchMessages condition, DevNet.Common.Pagination pagination, string sortFieldName, DevNet.Common.ScriptQuery.SortEnum sortEnum)
        {
            throw new System.NotImplementedException();
        }

        public override System.Data.DataTable GetPageTable(SearchMessages condition, DevNet.Common.Pagination pagination)
        {
            throw new System.NotImplementedException();
        }

        public override System.Data.DataTable GetTable(SearchMessages condition, string sortFieldName, DevNet.Common.ScriptQuery.SortEnum sortEnum)
        {
            throw new System.NotImplementedException();
        }

        public override System.Data.DataTable GetTable(SearchMessages condition)
        {
            throw new System.NotImplementedException();
        }
    }
}

