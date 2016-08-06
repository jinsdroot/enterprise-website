using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cnkj.Utility;

namespace jsbestop.Entity.Search
{
    public class SearchSuccessStories:SearchBaseInfo
    {
        int sSType = 0;
        public int SSType
        {
            get { return sSType; }
            set { sSType = value; }
        }

        int isEnglish = 0;
        public int IsEnglish
        {
            get { return isEnglish; }
            set { isEnglish = value; }
        }
    }
}
