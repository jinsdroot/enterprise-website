using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using jsbestop.Entity;
using jsbestop.Entity.Search;
using Cnkj.Utility;

namespace jsbestop.DAL
{
    public class DALSuccessStoriesType:DALExt<SuccessStoriesType,SearchSuccessStoriesType>
    {
        public override List<SuccessStoriesType> GetList(SearchSuccessStoriesType condition, string sortFieldName, DevNet.Common.ScriptQuery.SortEnum sortEnum)
        {
            throw new System.NotImplementedException();
        }

        public override List<SuccessStoriesType> GetList(SearchSuccessStoriesType condition)
        {
            Script.Select().ALL().From().Where();
            if (!string.IsNullOrEmpty(condition.SSTypeName))
                Script.Like(SuccessStoriesType.SSTypeName_FieldName, condition.SSTypeName);
            if (condition.IsEnglish > 0)
            {
                Script.Where(SuccessStoriesType.IsEnglish_FieldName, condition.IsEnglish);
            }
            Script.AddOrderBy().OrderBy(SuccessStoriesType.AutoSort_FieldName, DevNet.Common.ScriptQuery.SortEnum.DESC).OrderBy(SuccessStoriesType.ID_FieldName, DevNet.Common.ScriptQuery.SortEnum.ASC);
            List<SuccessStoriesType> lists = Script.GetList<SuccessStoriesType>();

            return lists;
        }

        public override List<SuccessStoriesType> GetPageList(SearchSuccessStoriesType condition, DevNet.Common.Pagination pagination, string sortFieldName, DevNet.Common.ScriptQuery.SortEnum sortEnum)
        {
            Script.Select().ALL().From().Where();
            if (!string.IsNullOrEmpty(condition.SSTypeName))
                Script.Like(SuccessStoriesType.SSTypeName_FieldName, condition.SSTypeName);
            if (condition.IsEnglish > 0)
            {
                Script.Where(SuccessStoriesType.IsEnglish_FieldName, condition.IsEnglish);
            }
            Script.AddOrderBy().OrderBy(sortFieldName, sortEnum);
            Script.PageIndex = pagination.PageIndex;
            Script.PageSize = pagination.PageSize;

            List<SuccessStoriesType> lists = Script.GetList<SuccessStoriesType>();
            pagination.RecordCount = Script.RecordCount;

            return lists;
        }

        public override List<SuccessStoriesType> GetPageList(SearchSuccessStoriesType condition, DevNet.Common.Pagination pagination)
        {
            Script.Select().ALL().From().Where();
            if (!string.IsNullOrEmpty(condition.SSTypeName))
                Script.Like(SuccessStoriesType.SSTypeName_FieldName, condition.SSTypeName);
            if (condition.IsEnglish > 0)
            {
                Script.Where(SuccessStoriesType.IsEnglish_FieldName, condition.IsEnglish);
            }
            Script.AddOrderBy().OrderBy(SuccessStoriesType.AutoSort_FieldName, DevNet.Common.ScriptQuery.SortEnum.DESC).OrderBy(SuccessStoriesType.ID_FieldName, DevNet.Common.ScriptQuery.SortEnum.ASC);
            Script.PageIndex = pagination.PageIndex;
            Script.PageSize = pagination.PageSize;
            List<SuccessStoriesType> lists = Script.GetList<SuccessStoriesType>();
            pagination.RecordCount = Script.RecordCount;

            return lists;
        }

        public override System.Data.DataTable GetPageTable(SearchSuccessStoriesType condition, DevNet.Common.Pagination pagination, string sortFieldName, DevNet.Common.ScriptQuery.SortEnum sortEnum)
        {
            throw new System.NotImplementedException();
        }

        public override System.Data.DataTable GetPageTable(SearchSuccessStoriesType condition, DevNet.Common.Pagination pagination)
        {
            throw new System.NotImplementedException();
        }

        public override System.Data.DataTable GetTable(SearchSuccessStoriesType condition, string sortFieldName, DevNet.Common.ScriptQuery.SortEnum sortEnum)
        {
            throw new System.NotImplementedException();
        }

        public override System.Data.DataTable GetTable(SearchSuccessStoriesType condition)
        {
            Script.Select().ALL().From().Where();

            Script.AddOrderBy().OrderBy(SuccessStoriesType.ID_FieldName, DevNet.Common.ScriptQuery.SortEnum.DESC);
            return Script.GetDataTable();
        }
    }
}
