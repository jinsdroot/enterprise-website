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
   public class BLLJobType : BLLExt<JobType, SearchJobType>
    {
        DALJobType dal = new DALJobType();
        public BLLJobType()
		{
			base.TDALManager = dal;
		}
    }
}
