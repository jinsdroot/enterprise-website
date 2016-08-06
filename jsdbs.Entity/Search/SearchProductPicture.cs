using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cnkj.Utility;

namespace jsbestop.Entity.Search
{
    public class SearchProductPicture : SearchBaseInfo
    {
        int proDetailID = 0;
        public int ProDetailID
        {
            get { return proDetailID; }
            set { proDetailID = value; }
        }
    }
}
