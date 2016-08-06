using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace jsbestop.Entity.Search
{
    public class SearchComBanner
    {
        int comBannerTypeID = 0;
        public int ComBannerTypeID
        {
            get { return comBannerTypeID; }
            set { comBannerTypeID = value; }
        }

        int isEnglish = 0;
        public int IsEnglish
        {
            get { return isEnglish; }
            set { isEnglish = value; }
        }
    }
}
