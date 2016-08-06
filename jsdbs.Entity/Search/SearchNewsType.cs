using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cnkj.Utility;

namespace jsbestop.Entity.Search
{
    public class SearchNewsType:SearchBaseInfo
    {
        string newsTypeName = string.Empty;
        public string NewsTypeName
        {
            get { return newsTypeName; }
            set { newsTypeName = value; }
        }

        int isEnglish = 0;
        public int IsEnglish
        {
            get { return isEnglish; }
            set { isEnglish = value; }
        }
    }
}
