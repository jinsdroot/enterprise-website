using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using jsbestop.DAL;
using Cnkj.Utility;
using jsbestop.Entity;
using jsbestop.Entity.Search;

namespace jsbestop.BLL
{
   public  class BLLComBannerType :BLLExt<ComBannerType, SearchComBannerType>
    {
        DALComBannerType dal = new DALComBannerType();
        public BLLComBannerType()
        {
            base.TDALManager = dal;
        }
    }
}
