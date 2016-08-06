using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cnkj.Utility;
using jsbestop.Entity;
using jsbestop.Entity.Search;

namespace jsbestop.DAL
{
    public class DALCompanyInformationDetails : DALExt<CompanyInformationDetails, SearchCompanyInformationDetails>
    {
        public override List<CompanyInformationDetails> GetList(SearchCompanyInformationDetails condition, string sortFieldName, DevNet.Common.ScriptQuery.SortEnum sortEnum)
        {
            throw new System.NotImplementedException();
        }

        public override List<CompanyInformationDetails> GetList(SearchCompanyInformationDetails condition)
        {
            Script.Select().ALL().From().Where();
            if (condition.CpInforType > 0)
                Script.Where(CompanyInformationDetails.CompanyInformationTypeID_FieldName, condition.CpInforType);
            List<CompanyInformationDetails> list = Script.GetList<CompanyInformationDetails>();
            return list;
        }

        public override List<CompanyInformationDetails> GetPageList(SearchCompanyInformationDetails condition, DevNet.Common.Pagination pagination, string sortFieldName, DevNet.Common.ScriptQuery.SortEnum sortEnum)
        {
            Script.Select().ALL().From().Where();
            if (condition.CpInforType>0)
                Script.Where(CompanyInformationDetails.CompanyInformationTypeID_FieldName, condition.CpInforType);
            if (condition.IsEnglish > 0)
            {
                Script.Where(CompanyInformationDetails.IsEnglish_FieldName, condition.IsEnglish);
            }
            Script.AddOrderBy().OrderBy(sortFieldName, sortEnum);
            Script.PageIndex = pagination.PageIndex;
            Script.PageSize = pagination.PageSize;

            List<CompanyInformationDetails> lists = Script.GetList<CompanyInformationDetails>();
            pagination.RecordCount = Script.RecordCount;

            return lists;
        }

        public override List<CompanyInformationDetails> GetPageList(SearchCompanyInformationDetails condition, DevNet.Common.Pagination pagination)
        {
            throw new System.NotImplementedException();
        }

        public override System.Data.DataTable GetPageTable(SearchCompanyInformationDetails condition, DevNet.Common.Pagination pagination, string sortFieldName, DevNet.Common.ScriptQuery.SortEnum sortEnum)
        {
            throw new System.NotImplementedException();
        }

        public override System.Data.DataTable GetPageTable(SearchCompanyInformationDetails condition, DevNet.Common.Pagination pagination)
        {
            throw new System.NotImplementedException();
        }

        public override System.Data.DataTable GetTable(SearchCompanyInformationDetails condition, string sortFieldName, DevNet.Common.ScriptQuery.SortEnum sortEnum)
        {
            throw new System.NotImplementedException();
        }

        public override System.Data.DataTable GetTable(SearchCompanyInformationDetails condition)
        {
            throw new System.NotImplementedException();
        }
    }
}
