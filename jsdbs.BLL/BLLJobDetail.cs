using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using jsbestop.Entity;
using jsbestop.Entity.Search;
using jsbestop.DAL;
using Cnkj.Utility;
using System.Data;

namespace jsbestop.BLL
{
    public class BLLJobDetail : BLLExt<JobDetail, SearchJobDetail>
    {
        DALJobDetail dal = new DALJobDetail();
         public BLLJobDetail()
		{
			base.TDALManager = dal;
		}
    }
}
