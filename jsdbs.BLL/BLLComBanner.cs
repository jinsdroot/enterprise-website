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
    public class BLLComBanner : BLLExt<ComBanner, SearchComBanner>
    {
        DALComBanner dal = new DALComBanner();
        public BLLComBanner()
		{
			base.TDALManager = dal;
		}
    }
}
