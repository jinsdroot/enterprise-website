using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cnkj.Utility;

namespace jsbestop.Entity.Search
{
    public class SearchProductDetail:SearchBaseInfo
    {
        int proTypeID = 0;
        public int ProTypeID
        {
            get { return proTypeID; }
            set { proTypeID = value; }
        }

        int proSecondTypeID = 0;
        public int ProSecondTypeID
        {
            get { return proSecondTypeID; }
            set { proSecondTypeID = value; }
        }

        int isEnglish = 0;
        public int IsEnglish
        {
            get { return isEnglish; }
            set { isEnglish = value; }
        }
        string productName=string.Empty;
        public string ProductName
        {
            get { return productName; }
            set { productName = value; }
        }
    }
}
