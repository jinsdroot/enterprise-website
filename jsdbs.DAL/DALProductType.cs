using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using jsbestop.Entity;
using jsbestop.Entity.Search;
using Cnkj.Utility;

namespace jsbestop.DAL
{
    public class DALProductType:DALExt<ProductType,SearchProductType>
    {
        public override List<ProductType> GetList(SearchProductType condition, string sortFieldName, DevNet.Common.ScriptQuery.SortEnum sortEnum)
        {
            throw new System.NotImplementedException();
        }

        public override List<ProductType> GetList(SearchProductType condition )
        {
            
            Script.Select().ALL().From().Where();
            if (!string.IsNullOrEmpty(condition.ProductTypeName))
                Script.Like(ProductType.ProductTypeName_FieldName, condition.ProductTypeName);
            if (condition.IsEnglish > 0)
            {
                Script.Where(ProductType.IsEnglish_FieldName, condition.IsEnglish);
            }
            Script.AddOrderBy().OrderBy(ProductType.AutoSort_FieldName, DevNet.Common.ScriptQuery.SortEnum.DESC).OrderBy(ProductType.ID_FieldName, DevNet.Common.ScriptQuery.SortEnum.ASC);
            List<ProductType> lists = Script.GetList<ProductType>();
            return lists;
        }

        public override List<ProductType> GetPageList(SearchProductType condition, DevNet.Common.Pagination pagination, string sortFieldName, DevNet.Common.ScriptQuery.SortEnum sortEnum)
        {
            Script.Select().ALL().From().Where();
            if (!string.IsNullOrEmpty(condition.ProductTypeName))
                Script.Like(ProductType.ProductTypeName_FieldName, condition.ProductTypeName);
            if (condition.IsEnglish > 0)
            {
                Script.Where(ProductType.IsEnglish_FieldName, condition.IsEnglish);
            }
            Script.AddOrderBy().OrderBy(sortFieldName, sortEnum);
            Script.PageIndex = pagination.PageIndex;
            Script.PageSize = pagination.PageSize;

            List<ProductType> lists = Script.GetList<ProductType>();
            pagination.RecordCount = Script.RecordCount;

            return lists;
        }

        public override List<ProductType> GetPageList(SearchProductType condition, DevNet.Common.Pagination pagination)
        {
            Script.Select().ALL().From().Where();
            if (!string.IsNullOrEmpty(condition.ProductTypeName))
                Script.Like(ProductType.ID_FieldName, condition.ProductId);
            if (condition.IsEnglish > 0)
            {
                Script.Where(ProductType.IsEnglish_FieldName, condition.IsEnglish);
            };
            Script.AddOrderBy().OrderBy(ProductType.AutoSort_FieldName, DevNet.Common.ScriptQuery.SortEnum.DESC).OrderBy(ProductType.ID_FieldName, DevNet.Common.ScriptQuery.SortEnum.ASC);
            Script.PageIndex = pagination.PageIndex;
            Script.PageSize = pagination.PageSize;
            List<ProductType> lists = Script.GetList<ProductType>();
            pagination.RecordCount = Script.RecordCount;

            return lists;
        }

        public override System.Data.DataTable GetPageTable(SearchProductType condition, DevNet.Common.Pagination pagination, string sortFieldName, DevNet.Common.ScriptQuery.SortEnum sortEnum)
        {
            throw new System.NotImplementedException();
        }

        public override System.Data.DataTable GetPageTable(SearchProductType condition, DevNet.Common.Pagination pagination)
        {
            throw new System.NotImplementedException();
        }

        public override System.Data.DataTable GetTable(SearchProductType condition, string sortFieldName, DevNet.Common.ScriptQuery.SortEnum sortEnum)
        {
            throw new System.NotImplementedException();
        }

        public override System.Data.DataTable GetTable(SearchProductType condition)
        {
            Script.Select().ALL().From().Where();

            Script.AddOrderBy().OrderBy(ProductType.ID_FieldName, DevNet.Common.ScriptQuery.SortEnum.DESC);
            return Script.GetDataTable();
        }
    }
}
