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
    public class BLLProductDetail:BLLExt<ProductDetail,SearchProductDetail>
    {
        DALProductDetail dal = new DALProductDetail();
        public BLLProductDetail()
        {
            base.TDALManager = dal;
        }
    }
}
