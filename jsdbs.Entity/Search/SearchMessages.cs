using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cnkj.Utility;

namespace jsbestop.Entity.Search
{
    public class SearchMessages : SearchBaseInfo
    {
        int isEnglish = 0;

        public int IsEnglish
        {
            get { return isEnglish; }
            set { isEnglish = value; }
        }

        string mesTitle = string.Empty;
        public string MesTitle
        {
            get { return mesTitle; }
            set { mesTitle = value; }
        }
    }
}
