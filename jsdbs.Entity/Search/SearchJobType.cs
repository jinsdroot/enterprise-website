using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cnkj.Utility;

namespace jsbestop.Entity.Search
{
    public class SearchJobType : SearchBaseInfo
    {
        int isEnglish = 0;

        public int IsEnglish
        {
            get { return isEnglish; }
            set { isEnglish = value; }
        }

        string cpJobTypeName = string.Empty;

        public string CpJobTypeName
        {
            get { return cpJobTypeName; }
            set { cpJobTypeName = value; }
        }
    }
}
