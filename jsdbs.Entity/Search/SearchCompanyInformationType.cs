using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cnkj.Utility;

namespace jsbestop.Entity.Search
{
    public class SearchCompanyInformationType : SearchBaseInfo
    {
        int isEnglish = 0;

        public int IsEnglish
        {
            get { return isEnglish; }
            set { isEnglish = value; }
        }

        string cpInforTypeName = string.Empty;

        public string CpInforTypeName
        {
            get { return cpInforTypeName; }
            set { cpInforTypeName = value; }
        }

    }
}
