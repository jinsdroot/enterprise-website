using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using jsbestop.Entity.Search;
using jsbestop.BLL;
using jsbestop.Entity;
using System.Text.RegularExpressions;
using DevNet.Common;
using Common;

namespace jsbestop.Web
{
    public partial class news : PageBase
    {
        private int type;
        protected void Page_Load(object sender, EventArgs e)
        {
            type = GetRequestQuery<int>("type", 0, Convert.ToInt32);
            pager.PageJump += new EventHandler(pager_PageJump);
            if (!Page.IsPostBack)
            {
                setnews();
              
                //Page.Title = "新闻中心";
            }
        }
        void pager_PageJump(object sender, EventArgs e)
        {
            setnews();
        }
        /// <summary>
        /// 加载新闻
        /// </summary>
        private void setnews()
        {
            SearchNewsDetail snt = new SearchNewsDetail();
            snt.IsEnglish = 1;
            if (type == 0)
            { }
            else
            {
                snt.NewsTypeID = type;
            }
            Pagination pagination = new DevNet.Common.Pagination(pager.PageIndex, pager.PageSize, 0);
            using (BLLNewsDetail bll = new BLLNewsDetail())
            {
                List<NewsDetail> lists = bll.GetPageList(snt, pagination);
                pager.RecordCount = pagination.RecordCount;
                pager.PageCount = pagination.PageCount;
                rptNews.DataSource = lists;
                rptNews.DataBind();
            }
        }
        /// <summary>
        /// 按字节长度剪切字符串
        /// </summary>
        /// <param name="str"></param>
        /// <param name="byteLength"></param>
        /// <param name="isDot">是否末尾加  ...</param>
        /// <returns></returns>
        protected string GetStrByByteLength(string str, int byteLength, bool isDot)
        {
            return StringPlus.GetStrByByteLength(str, byteLength, isDot);
        }
    
    }
}