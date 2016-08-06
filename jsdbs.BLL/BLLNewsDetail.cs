using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cnkj.Utility;
using jsbestop.Entity.Search;
using jsbestop.Entity;
using jsbestop.DAL;

namespace jsbestop.BLL
{
    public class BLLNewsDetail:BLLExt<NewsDetail,SearchNewsDetail>
    {
        DALNewsDetail dal = new DALNewsDetail();
        public BLLNewsDetail()
        {
            base.TDALManager = dal;
        }
        public List<NewsDetail> GetOtherList(SearchNewsDetail condition)
        {
            return dal.GetOtherList(condition);
        }

        public NewsDetail GetListOn(int ID)
        {
            return dal.GetListOn(ID);
        }

        public NewsDetail GetListNext(int ID)
        {
            return dal.GetListNext(ID);
        }
        public List<NewsDetail> GetTopList(SearchNewsDetail condition)
        {
            return dal.GetTopList(condition);

        }
    }
}
