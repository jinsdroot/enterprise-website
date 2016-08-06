using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cnkj.Utility;
using jsbestop.Entity;
using jsbestop.Entity.Search;

namespace jsbestop.DAL
{
    public class DALSuccessStories:DALExt<SuccessStories,SearchSuccessStories>
    {
        public override List<SuccessStories> GetList(SearchSuccessStories condition, string sortFieldName, DevNet.Common.ScriptQuery.SortEnum sortEnum)
        {
            throw new System.NotImplementedException();
        }

        public override List<SuccessStories> GetList(SearchSuccessStories condition)
        {
            Script.Select().ALL().From().Where();
            if (condition.IsEnglish > 0)
            {
                Script.Where(SuccessStories.IsEnglish_FieldName, condition.IsEnglish);
            }
            if (condition.SSType>0)
            {
                Script.Where(SuccessStories.SSType_FieldName,condition.SSType);
            }
            Script.AddOrderBy().OrderBy(SuccessStories.AutoSort_FieldName, DevNet.Common.ScriptQuery.SortEnum.DESC).OrderBy(SuccessStories.ID_FieldName, DevNet.Common.ScriptQuery.SortEnum.DESC);
            List<SuccessStories> list = Script.GetList<SuccessStories>();
            return list;
        }

        public override List<SuccessStories> GetPageList(SearchSuccessStories condition, DevNet.Common.Pagination pagination, string sortFieldName, DevNet.Common.ScriptQuery.SortEnum sortEnum)
        {
            Script.Select().ALL().From().Where();
            if (condition.SSType > 0)
                Script.Where(SuccessStories.SSType_FieldName, condition.SSType);
            if (condition.IsEnglish > 0)
            {
                Script.Where(SuccessStories.IsEnglish_FieldName, condition.IsEnglish);
            }
            Script.AddOrderBy().OrderBy(sortFieldName, sortEnum);
            Script.PageIndex = pagination.PageIndex;
            Script.PageSize = pagination.PageSize;

            List<SuccessStories> lists = Script.GetList<SuccessStories>();
            pagination.RecordCount = Script.RecordCount;

            return lists;
        }

        public override List<SuccessStories> GetPageList(SearchSuccessStories condition, DevNet.Common.Pagination pagination)
        {
            Script.Select().ALL().From().Where();
            if (condition.SSType > 0)
                Script.Where(SuccessStories.SSType_FieldName, condition.SSType);
            if (condition.IsEnglish > 0)
            {
                Script.Where(SuccessStories.IsEnglish_FieldName, condition.IsEnglish);
            }
            Script.PageIndex = pagination.PageIndex;
            Script.PageSize = pagination.PageSize;
            Script.AddOrderBy().OrderBy(SuccessStories.AutoSort_FieldName, DevNet.Common.ScriptQuery.SortEnum.DESC).OrderBy(SuccessStories.ID_FieldName, DevNet.Common.ScriptQuery.SortEnum.DESC);
            List<SuccessStories> lists = Script.GetList<SuccessStories>();
            pagination.RecordCount = Script.RecordCount;
            return lists;
        }

        public override System.Data.DataTable GetPageTable(SearchSuccessStories condition, DevNet.Common.Pagination pagination, string sortFieldName, DevNet.Common.ScriptQuery.SortEnum sortEnum)
        {
            throw new System.NotImplementedException();
        }

        public override System.Data.DataTable GetPageTable(SearchSuccessStories condition, DevNet.Common.Pagination pagination)
        {
            throw new System.NotImplementedException();
        }

        public override System.Data.DataTable GetTable(SearchSuccessStories condition, string sortFieldName, DevNet.Common.ScriptQuery.SortEnum sortEnum)
        {
            throw new System.NotImplementedException();
        }

        public override System.Data.DataTable GetTable(SearchSuccessStories condition)
        {
            throw new System.NotImplementedException();
        }
    }
}
