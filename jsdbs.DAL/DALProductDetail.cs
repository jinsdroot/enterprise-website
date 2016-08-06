using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cnkj.Utility;
using jsbestop.Entity;
using jsbestop.Entity.Search;

namespace jsbestop.DAL
{
    public class DALProductDetail:DALExt<ProductDetail,SearchProductDetail>
    {
        public override List<ProductDetail> GetList(SearchProductDetail condition, string sortFieldName, DevNet.Common.ScriptQuery.SortEnum sortEnum)
        {
            throw new System.NotImplementedException();
        }

        public override List<ProductDetail> GetList(SearchProductDetail condition)
        {
            Script.Select().ALL().From().Where();
            if (condition.ProTypeID > 0)
            {
                Script.Where(ProductDetail.ProTypeID_FieldName, condition.ProTypeID);
            }
            if (condition.ProSecondTypeID > 0)
            {
                Script.Where(ProductDetail.ProSecondTypeID_FieldName, condition.ProSecondTypeID);
            }
            if (condition.IsEnglish > 0)
            {
                Script.Where(ProductDetail.IsEnglish_FieldName, condition.IsEnglish);
            }
            Script.AddOrderBy().OrderBy(ProductDetail.AutoSort_FieldName, DevNet.Common.ScriptQuery.SortEnum.DESC).OrderBy(ProductDetail.ID_FieldName, DevNet.Common.ScriptQuery.SortEnum.DESC);
            List<ProductDetail> lists = Script.GetList<ProductDetail>();
            return lists;
        }

        public override List<ProductDetail> GetPageList(SearchProductDetail condition, DevNet.Common.Pagination pagination, string sortFieldName, DevNet.Common.ScriptQuery.SortEnum sortEnum)
        {
            Script.Select().ALL().From().Where();
            if (condition.ProTypeID > 0)
                Script.Where(ProductDetail.ProTypeID_FieldName, condition.ProTypeID);
            if (condition.IsEnglish > 0)
            {
                Script.Where(ProductDetail.IsEnglish_FieldName, condition.IsEnglish);
            }
           
            Script.AddOrderBy().OrderBy(sortFieldName, sortEnum);
            Script.PageIndex = pagination.PageIndex;
            Script.PageSize = pagination.PageSize;

            List<ProductDetail> lists = Script.GetList<ProductDetail>();
            pagination.RecordCount = Script.RecordCount;

            return lists;
        }

        public override List<ProductDetail> GetPageList(SearchProductDetail condition, DevNet.Common.Pagination pagination)
        {
            Script.Select().ALL().From().Where();
            if (condition.ProTypeID > 0)
                Script.Where(ProductDetail.ProTypeID_FieldName, condition.ProTypeID);
            if (condition.IsEnglish > 0)
            {
                Script.Where(ProductDetail.IsEnglish_FieldName, condition.IsEnglish);
            }
            if (condition.ProductName != "")
            {
                Script.Like(ProductDetail.ProductName_FieldName, condition.ProductName);
            }
            if (condition.ProSecondTypeID > 0)
            {
                Script.Where(ProductDetail.ProSecondTypeID_FieldName, condition.ProSecondTypeID);
            }
            Script.AddOrderBy().OrderBy(ProductDetail.AutoSort_FieldName, DevNet.Common.ScriptQuery.SortEnum.DESC).OrderBy(ProductDetail.ID_FieldName,DevNet.Common.ScriptQuery.SortEnum.DESC);
            Script.PageIndex = pagination.PageIndex;
            Script.PageSize = pagination.PageSize;
            List<ProductDetail> lists = Script.GetList<ProductDetail>();
            pagination.RecordCount = Script.RecordCount;

            return lists;
        }

        public override System.Data.DataTable GetPageTable(SearchProductDetail condition, DevNet.Common.Pagination pagination, string sortFieldName, DevNet.Common.ScriptQuery.SortEnum sortEnum)
        {
            throw new System.NotImplementedException();
        }

        public override System.Data.DataTable GetPageTable(SearchProductDetail condition, DevNet.Common.Pagination pagination)
        {
            throw new System.NotImplementedException();
        }

        public override System.Data.DataTable GetTable(SearchProductDetail condition, string sortFieldName, DevNet.Common.ScriptQuery.SortEnum sortEnum)
        {
            throw new System.NotImplementedException();
        }

        public override System.Data.DataTable GetTable(SearchProductDetail condition)
        {
            throw new System.NotImplementedException();
        }
    }
}
