using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using jsbestop.Entity;
using jsbestop.Entity.Search;
using Cnkj.Utility;

namespace jsbestop.DAL
{
    public class DALProductSecondType : DALExt<ProductSecondType, SearchProductSecondType>
    {
        public override List<ProductSecondType> GetList(SearchProductSecondType condition, string sortFieldName, DevNet.Common.ScriptQuery.SortEnum sortEnum)
        {
            throw new System.NotImplementedException();
        }

        public override List<ProductSecondType> GetList(SearchProductSecondType condition)
        {
            Script.Select().ALL().From().Where();
            if (condition.ProductTypeID > 0)
            {
                Script.Where(ProductSecondType.ProductTypeID_FieldName, condition.ProductTypeID);
            }
            if (condition.IsEnglish > 0)
            {
                Script.Where(ProductSecondType.IsEnglish_FieldName, condition.IsEnglish);
            }
            Script.AddOrderBy().OrderBy(ProductSecondType.AutoSort_FieldName, DevNet.Common.ScriptQuery.SortEnum.DESC);
            List<ProductSecondType> lists = Script.GetList<ProductSecondType>();
            return lists;
        }
        public override List<ProductSecondType> GetPageList(SearchProductSecondType condition, DevNet.Common.Pagination pagination, string sortFieldName, DevNet.Common.ScriptQuery.SortEnum sortEnum)
        {
            Script.Select().ALL().From().Where();
            if (condition.ProductTypeID > 0)
            {
                Script.Where(ProductSecondType.ProductTypeID_FieldName, condition.ProductTypeID);
            }
            if (!string.IsNullOrEmpty(condition.ProductSecondTypeName))
            {
                Script.Like(ProductSecondType.ProductSecondTypeName_FieldName, condition.ProductSecondTypeName);
            }
            if (condition.IsEnglish > 0)
            {
                Script.Where(ProductSecondType.IsEnglish_FieldName, condition.IsEnglish);
            }
            Script.AddOrderBy().OrderBy(sortFieldName, sortEnum);
            Script.PageIndex = pagination.PageIndex;
            Script.PageSize = pagination.PageSize;

            List<ProductSecondType> lists = Script.GetList<ProductSecondType>();
            pagination.RecordCount = Script.RecordCount;
            return lists;
        }

        public override List<ProductSecondType> GetPageList(SearchProductSecondType condition, DevNet.Common.Pagination pagination)
        {
            throw new System.NotImplementedException();
        }

        public override System.Data.DataTable GetPageTable(SearchProductSecondType condition, DevNet.Common.Pagination pagination, string sortFieldName, DevNet.Common.ScriptQuery.SortEnum sortEnum)
        {
            throw new System.NotImplementedException();
        }

        public override System.Data.DataTable GetPageTable(SearchProductSecondType condition, DevNet.Common.Pagination pagination)
        {
            throw new System.NotImplementedException();
        }

        public override System.Data.DataTable GetTable(SearchProductSecondType condition, string sortFieldName, DevNet.Common.ScriptQuery.SortEnum sortEnum)
        {
            throw new System.NotImplementedException();
        }

        public override System.Data.DataTable GetTable(SearchProductSecondType condition)
        {
            Script.Select().ALL().From().Where();
            if (condition.ProductTypeID>0)
            {
                Script.Where(ProductSecondType.ProductTypeID_FieldName, condition.ProductTypeID);
            }
            Script.AddOrderBy().OrderBy(ProductSecondType.ID_FieldName, DevNet.Common.ScriptQuery.SortEnum.DESC);
            return Script.GetDataTable();
        }
    }
}
