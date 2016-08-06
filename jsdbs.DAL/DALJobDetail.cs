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
    public class DALJobDetail : DALExt<JobDetail, SearchJobDetail>
    {
        public override List<JobDetail> GetList(SearchJobDetail condition, string sortFieldName, DevNet.Common.ScriptQuery.SortEnum sortEnum)
        {
            throw new System.NotImplementedException();
        }

        public override List<JobDetail> GetList(SearchJobDetail condition)
        {
            Script.Select().ALL().From().Where();
            if (condition.CpJobTypeID > 0)
                Script.Where(JobDetail.JobTypeID_FieldName, condition.CpJobTypeID);
            if (condition.IsEnglish > 0)
            {
                Script.Where(JobDetail.IsEnglish_FieldName, condition.IsEnglish);
            }
            List<JobDetail> lists = Script.GetList<JobDetail>();
            return lists;
        }

        public override List<JobDetail> GetPageList(SearchJobDetail condition, DevNet.Common.Pagination pagination, string sortFieldName, DevNet.Common.ScriptQuery.SortEnum sortEnum)
        {
            Script.Select().ALL().From().Where();
            if (condition.CpJobTypeID > 0)
                Script.Where(JobDetail.JobTypeID_FieldName, condition.CpJobTypeID);
            if (condition.IsEnglish > 0)
            {
                Script.Where(JobDetail.IsEnglish_FieldName, condition.IsEnglish);
            }
            Script.AddOrderBy().OrderBy(sortFieldName, sortEnum);
            Script.PageIndex = pagination.PageIndex;
            Script.PageSize = pagination.PageSize;

            List<JobDetail> lists = Script.GetList<JobDetail>();
            pagination.RecordCount = Script.RecordCount;

            return lists;
        }

        public override List<JobDetail> GetPageList(SearchJobDetail condition, DevNet.Common.Pagination pagination)
        {
            throw new System.NotImplementedException();
        }

        public override System.Data.DataTable GetPageTable(SearchJobDetail condition, DevNet.Common.Pagination pagination, string sortFieldName, DevNet.Common.ScriptQuery.SortEnum sortEnum)
        {
            throw new System.NotImplementedException();
        }

        public override System.Data.DataTable GetPageTable(SearchJobDetail condition, DevNet.Common.Pagination pagination)
        {
            throw new System.NotImplementedException();
        }

        public override System.Data.DataTable GetTable(SearchJobDetail condition, string sortFieldName, DevNet.Common.ScriptQuery.SortEnum sortEnum)
        {
            throw new System.NotImplementedException();
        }

        public override System.Data.DataTable GetTable(SearchJobDetail condition)
        {
            throw new System.NotImplementedException();
        }
    }
}
