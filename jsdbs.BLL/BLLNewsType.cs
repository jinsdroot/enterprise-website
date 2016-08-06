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
    public class BLLNewsType:BLLExt<NewsType,SearchNewsType>
    {
        DALNewsType dal = new DALNewsType();
        public BLLNewsType()
        {
            base.TDALManager = dal;
        }
    }
}
