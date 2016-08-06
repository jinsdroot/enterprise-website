using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using jsbestop.Entity;
using jsbestop.Entity.Search;
using Cnkj.Utility;

namespace jsbestop.DAL
{
    public class DALNewsType : DALExt<NewsType, SearchNewsType>
    {
        public override List<NewsType> GetList(SearchNewsType condition, string sortFieldName, DevNet.Common.ScriptQuery.SortEnum sortEnum)
        {
            throw new System.NotImplementedException();
        }

        public override List<NewsType> GetList(SearchNewsType condition)
        {
            Script.Select().ALL().From().Where();
            if (!string.IsNullOrEmpty(condition.NewsTypeName))
                Script.Like(NewsType.NewsTypeName_FieldName, condition.NewsTypeName);
            if (condition.IsEnglish > 0)
            {
                Script.Where(NewsType.IsEnglish_FieldName, condition.IsEnglish);
            }
            Script.AddOrderBy().OrderBy(NewsType.ID_FieldName, DevNet.Common.ScriptQuery.SortEnum.ASC);

            List<NewsType> lists = Script.GetList<NewsType>();

            return lists;
        }

        public override List<NewsType> GetPageList(SearchNewsType condition, DevNet.Common.Pagination pagination, string sortFieldName, DevNet.Common.ScriptQuery.SortEnum sortEnum)
        {
            Script.Select().ALL().From().Where();
            if (!string.IsNullOrEmpty(condition.NewsTypeName))
                Script.Like(NewsType.NewsTypeName_FieldName, condition.NewsTypeName);
            if (condition.IsEnglish > 0)
            {
                Script.Where(NewsType.IsEnglish_FieldName, condition.IsEnglish);
            }
            Script.AddOrderBy().OrderBy(sortFieldName, sortEnum);
            Script.PageIndex = pagination.PageIndex;
            Script.PageSize = pagination.PageSize;

            List<NewsType> lists = Script.GetList<NewsType>();
            pagination.RecordCount = Script.RecordCount;

            return lists;
        }

        public override List<NewsType> GetPageList(SearchNewsType condition, DevNet.Common.Pagination pagination)
        {
            Script.Select().ALL().From().Where();
            if (!string.IsNullOrEmpty(condition.NewsTypeName))
                Script.Like(NewsType.NewsTypeName_FieldName, condition.NewsTypeName);
            if (condition.IsEnglish > 0)
            {
                Script.Where(NewsType.IsEnglish_FieldName, condition.IsEnglish);
            }
            Script.AddOrderBy().OrderBy(NewsType.ID_FieldName, DevNet.Common.ScriptQuery.SortEnum.ASC);

            List<NewsType> lists = Script.GetList<NewsType>();

            return lists;
        }

        public override System.Data.DataTable GetPageTable(SearchNewsType condition, DevNet.Common.Pagination pagination, string sortFieldName, DevNet.Common.ScriptQuery.SortEnum sortEnum)
        {
            throw new System.NotImplementedException();
        }

        public override System.Data.DataTable GetPageTable(SearchNewsType condition, DevNet.Common.Pagination pagination)
        {
            throw new System.NotImplementedException();
        }

        public override System.Data.DataTable GetTable(SearchNewsType condition, string sortFieldName, DevNet.Common.ScriptQuery.SortEnum sortEnum)
        {
            throw new System.NotImplementedException();
        }

        public override System.Data.DataTable GetTable(SearchNewsType condition)
        {
            Script.Select().ALL().From().Where();

            Script.AddOrderBy().OrderBy(NewsType.ID_FieldName, DevNet.Common.ScriptQuery.SortEnum.DESC);
            return Script.GetDataTable();
        }
    }
}
