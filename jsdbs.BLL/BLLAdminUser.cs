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
	public class BLLAdminUser:BLLExt<AdminUser,SearchAdminUser>
	{
		DALAdminUser dal = new DALAdminUser();
		public BLLAdminUser()
		{
			base.TDALManager = dal;
		}
	}
}