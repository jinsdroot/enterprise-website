using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using jsbestop.Entity;
using jsbestop.Entity.Search;
using Cnkj.Utility;

namespace jsbestop.DAL
{
    public class DALCompanyInformationType : DALExt<CompanyInformationType, SearchCompanyInformationType>
    {
        public override List<CompanyInformationType> GetList(SearchCompanyInformationType condition, string sortFieldName, DevNet.Common.ScriptQuery.SortEnum sortEnum)
        {
            throw new System.NotImplementedException();
        }

        public override List<CompanyInformationType> GetList(SearchCompanyInformationType condition)
        {
            throw new System.NotImplementedException();
        }

        public override List<CompanyInformationType> GetPageList(SearchCompanyInformationType condition, DevNet.Common.Pagination pagination, string sortFieldName, DevNet.Common.ScriptQuery.SortEnum sortEnum)
        {
            Script.Select().ALL().From().Where();
            if (!string.IsNullOrEmpty(condition.CpInforTypeName))
                Script.Like(CompanyInformationType.CompanyInformationName_FieldName, condition.CpInforTypeName);
            if (condition.IsEnglish>0)
            {
                Script.Where(CompanyInformationType.IsEnglish_FieldName,condition.IsEnglish);
            }
            Script.AddOrderBy().OrderBy(sortFieldName, sortEnum);
            Script.PageIndex = pagination.PageIndex;
            Script.PageSize = pagination.PageSize;

            List<CompanyInformationType> lists = Script.GetList<CompanyInformationType>();
            pagination.RecordCount = Script.RecordCount;

            return lists;
        }

        public override List<CompanyInformationType> GetPageList(SearchCompanyInformationType condition, DevNet.Common.Pagination pagination)
        {
            throw new System.NotImplementedException();
        }

        public override System.Data.DataTable GetPageTable(SearchCompanyInformationType condition, DevNet.Common.Pagination pagination, string sortFieldName, DevNet.Common.ScriptQuery.SortEnum sortEnum)
        {
            throw new System.NotImplementedException();
        }

        public override System.Data.DataTable GetPageTable(SearchCompanyInformationType condition, DevNet.Common.Pagination pagination)
        {
            throw new System.NotImplementedException();
        }

        public override System.Data.DataTable GetTable(SearchCompanyInformationType condition, string sortFieldName, DevNet.Common.ScriptQuery.SortEnum sortEnum)
        {
            throw new System.NotImplementedException();
        }

        public override System.Data.DataTable GetTable(SearchCompanyInformationType condition)
        {
            Script.Select().ALL().From().Where();

            Script.AddOrderBy().OrderBy(CompanyInformationType.ID_FieldName, DevNet.Common.ScriptQuery.SortEnum.DESC);
            return Script.GetDataTable();
        }
    }
}
