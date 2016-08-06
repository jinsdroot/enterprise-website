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
    public class BLLDownLoad : BLLExt<DownLoad, SearchDownLoad>
    {
        DALDownLoad dal = new DALDownLoad();
        public BLLDownLoad()
		{
			base.TDALManager = dal;
		}
    }
}
