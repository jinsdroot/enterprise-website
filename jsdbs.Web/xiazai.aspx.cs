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

namespace jsbestop.Web.Phone
{
    public partial class xiazai : PageBase
    {
        private string type;
        protected void Page_Load(object sender, EventArgs e)
        {
            pager.PageJump += new EventHandler(pager_PageJump);
            type = GetRequestQuery<string>("type", "", Convert.ToString);
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
        protected string GetStrByByteLength(string str, int byteLength, bool isDot)
        {
            return StringPlus.GetStrByByteLength(str, byteLength, isDot);
        }
        private void setnews()
        {
            SearchDownLoad snt = new SearchDownLoad();
            snt.IsEnglish = 1;
            if (type == "")
            { }
            else
            {
                snt.CpDLName = type;
            }
            Pagination pagination = new DevNet.Common.Pagination(pager.PageIndex, pager.PageSize, 0);
            using (BLLDownLoad bll = new BLLDownLoad())
            {
                List<DownLoad> lists = bll.GetPageList(snt, pagination);
                pager.RecordCount = pagination.RecordCount;
                rptNews.DataSource = lists;
                rptNews.DataBind();
            }
        }
    }
}