using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cnkj.Utility;

namespace jsbestop.Entity.Search
{
	public class SearchAdminUser : SearchBaseInfo
	{
		string acount = string.Empty;
		string trueName = string.Empty;

		public string TrueName
		{
			get { return trueName; }
			set { trueName = value; }
		}

		public string Account
		{
			get { return acount; }
			set { acount = value; }
		}
	}
}
