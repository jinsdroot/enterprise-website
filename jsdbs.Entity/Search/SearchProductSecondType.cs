using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cnkj.Utility;

namespace jsbestop.Entity.Search
{
    public class SearchProductSecondType : SearchBaseInfo
    {
        int productTypeid = 0;
        public int ProductTypeID
        {
            get { return productTypeid; }
            set { productTypeid = value; }
        }

        string productSecondTypeName = string.Empty;
        public string ProductSecondTypeName
        {
            get { return productSecondTypeName; }
            set { productSecondTypeName = value; }
        }

        int isEnglish = 0;
        public int IsEnglish
        {
            get { return isEnglish; }
            set { isEnglish = value; }
        }
    }
}