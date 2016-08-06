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
    public class BLLSuccessStoriesType:BLLExt<SuccessStoriesType,SearchSuccessStoriesType>
    {
        DALSuccessStoriesType dal = new DALSuccessStoriesType();
        public BLLSuccessStoriesType()
        {
            base.TDALManager = dal;
        }
    }
}
