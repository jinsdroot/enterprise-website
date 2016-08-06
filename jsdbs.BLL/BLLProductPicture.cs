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
    public class BLLProductPicture : BLLExt<ProductPicture, SearchProductPicture>
    {
         DALProductPicture dal = new DALProductPicture();
         public BLLProductPicture()
        {
            base.TDALManager = dal;
        }
    }
}
