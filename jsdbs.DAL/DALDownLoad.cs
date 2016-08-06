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
    public class DALDownLoad : DALExt<DownLoad, SearchDownLoad>
    {
        public override List<DownLoad> GetList(SearchDownLoad condition, string sortFieldName, DevNet.Common.ScriptQuery.SortEnum sortEnum)
        {
            throw new System.NotImplementedException();
        }

        public override List<DownLoad> GetList(SearchDownLoad condition)
        {
            throw new System.NotImplementedException();
        }

        public override List<DownLoad> GetPageList(SearchDownLoad condition, DevNet.Common.Pagination pagination, string sortFieldName, DevNet.Common.ScriptQuery.SortEnum sortEnum)
        {
            Script.Select().ALL().From().Where();
            if (!string.IsNullOrEmpty(condition.CpDLName))
                Script.Where(DownLoad.DLName_FieldName, condition.CpDLName);
            if (condition.IsEnglish > 0)
            {
                Script.Where(DownLoad.IsEnglish_FieldName, condition.IsEnglish);
            }
            Script.AddOrderBy().OrderBy(sortFieldName, sortEnum);
            Script.PageIndex = pagination.PageIndex;
            Script.PageSize = pagination.PageSize;

            List<DownLoad> lists = Script.GetList<DownLoad>();
            pagination.RecordCount = Script.RecordCount;

            return lists;
        }

        public override List<DownLoad> GetPageList(SearchDownLoad condition, DevNet.Common.Pagination pagination)
        {
            Script.Select().ALL().From().Where();
            if (!string.IsNullOrEmpty(condition.CpDLName))
                Script.Where(DownLoad.DLName_FieldName, condition.CpDLName);
            if (condition.IsEnglish > 0)
            {
                Script.Where(DownLoad.IsEnglish_FieldName, condition.IsEnglish);
            }
       
            Script.PageIndex = pagination.PageIndex;
            Script.PageSize = pagination.PageSize;

            List<DownLoad> lists = Script.GetList<DownLoad>();
            pagination.RecordCount = Script.RecordCount;

            return lists;
        }

        public override System.Data.DataTable GetPageTable(SearchDownLoad condition, DevNet.Common.Pagination pagination, string sortFieldName, DevNet.Common.ScriptQuery.SortEnum sortEnum)
        {
            throw new System.NotImplementedException();
        }

        public override System.Data.DataTable GetPageTable(SearchDownLoad condition, DevNet.Common.Pagination pagination)
        {
            throw new System.NotImplementedException();
        }

        public override System.Data.DataTable GetTable(SearchDownLoad condition, string sortFieldName, DevNet.Common.ScriptQuery.SortEnum sortEnum)
        {
            throw new System.NotImplementedException();
        }

        public override System.Data.DataTable GetTable(SearchDownLoad condition)
        {
            throw new System.NotImplementedException();
        }
    }
}
