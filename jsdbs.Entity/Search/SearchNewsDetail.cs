using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cnkj.Utility;

namespace jsbestop.Entity.Search
{
    public class SearchNewsDetail : SearchBaseInfo
    {
        int newsTypeID = 0;
        public int NewsTypeID
        {
            get { return newsTypeID; }
            set { newsTypeID = value; }
        }

        int isEnglish = 0;
        public int IsEnglish
        {
            get{ return isEnglish; }
            set { isEnglish = value; }
        }
    }
}
