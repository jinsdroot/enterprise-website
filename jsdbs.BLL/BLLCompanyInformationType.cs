using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using jsbestop.Entity;
using jsbestop.Entity.Search;
using Cnkj.Utility;
using jsbestop.DAL;

namespace jsbestop.BLL
{
    public class BLLCompanyInformationType : BLLExt<CompanyInformationType, SearchCompanyInformationType>
    {
        DALCompanyInformationType dal = new DALCompanyInformationType();
        public BLLCompanyInformationType()
		{
			base.TDALManager = dal;
		}
    }
}
