using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cnkj.Utility;

namespace jsbestop.Entity.Search
{
    public class SearchJobDetail : SearchBaseInfo
    {
        int cpJobTypeID = 0;

        public int CpJobTypeID
        {
            get { return cpJobTypeID; }
            set { cpJobTypeID = value; }
        }

        int isEnglish = 0;

        public int IsEnglish
        {
            get { return isEnglish; }
            set { isEnglish = value; }
        }

    }
}
