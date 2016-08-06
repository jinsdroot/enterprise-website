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
    public class BLLProductSecondType : BLLExt<ProductSecondType, SearchProductSecondType>
    {
        DALProductSecondType dal = new DALProductSecondType();
        public BLLProductSecondType()
        {
            base.TDALManager = dal;
        }
    }
}
