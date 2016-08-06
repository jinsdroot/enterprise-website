using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cnkj.Utility;

namespace jsbestop.Entity.Search
{
    public class SearchDownLoad : SearchBaseInfo
    {
        int isEnglish = 0;

        public int IsEnglish
        {
            get { return isEnglish; }
            set { isEnglish = value; }
        }
        string cpDLName = string.Empty;

        public string CpDLName
        {
            get { return cpDLName; }
            set { cpDLName = value; }
        }
    }
}
