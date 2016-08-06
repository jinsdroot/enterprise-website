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
    public class BLLSuccessStories:BLLExt<SuccessStories,SearchSuccessStories>
    {
        DALSuccessStories dal = new DALSuccessStories();
        public BLLSuccessStories()
        {
            base.TDALManager = dal;
        }
    }
}
