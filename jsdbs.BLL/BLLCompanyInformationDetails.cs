using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cnkj.Utility;
using jsbestop.Entity.Search;
using jsbestop.Entity;
using jsbestop.DAL;

namespace jsbestop.BLL
{
    public class BLLCompanyInformationDetails : BLLExt<CompanyInformationDetails, SearchCompanyInformationDetails>
    {
        DALCompanyInformationDetails dal = new DALCompanyInformationDetails();
        public BLLCompanyInformationDetails()
		{
			base.TDALManager = dal;
		}
    }
}
