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
    public class BLLContact : BLLExt<Contact, SearchContact>
    {
        DALContact dal = new DALContact();
        public BLLContact()
		{
			base.TDALManager = dal;
		}
    }
}
