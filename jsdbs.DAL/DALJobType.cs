using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using jsbestop.Entity;
using jsbestop.Entity.Search;
using Cnkj.Utility;

namespace jsbestop.DAL
{
    public class DALJobType : DALExt<JobType, SearchJobType>
    {
        public override List<JobType> GetList(SearchJobType condition, string sortFieldName, DevNet.Common.ScriptQuery.SortEnum sortEnum)
        {
            throw new System.NotImplementedException();
        }

        public override List<JobType> GetList(SearchJobType condition)
        {
            throw new System.NotImplementedException();
        }

        public override List<JobType> GetPageList(SearchJobType condition, DevNet.Common.Pagination pagination, string sortFieldName, DevNet.Common.ScriptQuery.SortEnum sortEnum)
        {
            Script.Select().ALL().From().Where();
            if (!string.IsNullOrEmpty(condition.CpJobTypeName))
                Script.Like(JobType.JobTypeName_FieldName, condition.CpJobTypeName);
            if (condition.IsEnglish > 0)
            {
                Script.Where(JobType.IsEnglish_FieldName, condition.IsEnglish);
            }
            Script.AddOrderBy().OrderBy(sortFieldName, sortEnum);
            Script.PageIndex = pagination.PageIndex;
            Script.PageSize = pagination.PageSize;

            List<JobType> lists = Script.GetList<JobType>();
            pagination.RecordCount = Script.RecordCount;

            return lists;
        }

        public override List<JobType> GetPageList(SearchJobType condition, DevNet.Common.Pagination pagination)
        {
            throw new System.NotImplementedException();
        }

        public override System.Data.DataTable GetPageTable(SearchJobType condition, DevNet.Common.Pagination pagination, string sortFieldName, DevNet.Common.ScriptQuery.SortEnum sortEnum)
        {
            throw new System.NotImplementedException();
        }

        public override System.Data.DataTable GetPageTable(SearchJobType condition, DevNet.Common.Pagination pagination)
        {
            throw new System.NotImplementedException();
        }

        public override System.Data.DataTable GetTable(SearchJobType condition, string sortFieldName, DevNet.Common.ScriptQuery.SortEnum sortEnum)
        {
            throw new System.NotImplementedException();
        }

        public override System.Data.DataTable GetTable(SearchJobType condition)
        {
            Script.Select().ALL().From().Where();

            Script.AddOrderBy().OrderBy(JobType.ID_FieldName, DevNet.Common.ScriptQuery.SortEnum.DESC);
            return Script.GetDataTable();
        }
    }
}
