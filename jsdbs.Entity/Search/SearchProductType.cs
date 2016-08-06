using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cnkj.Utility;

namespace jsbestop.Entity.Search
{
    public class SearchProductType : SearchBaseInfo
    {
        string productTypeName = string.Empty;
        public string ProductTypeName
        {
            get { return productTypeName; }
            set { productTypeName = value; }
        }

        int isEnglish = 0;
        public int IsEnglish
        {
            get { return isEnglish; }
            set { isEnglish = value; }
        }
        int publicId = 0;
        public int ProductId
        {
            get { return publicId; }
            set { publicId = value; }
        }
    }
}
