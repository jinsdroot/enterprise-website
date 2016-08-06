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
    public partial class news_detail : PageBase
    {
        private int id;
        protected void Page_Load(object sender, EventArgs e)
        {
            id = GetRequestQuery<int>("id", 0, Convert.ToInt32);
            if (!IsPostBack)
            {
                Bind();
                //Page.Title = "新闻内页";
            }
        }
        private void Bind()
        {
            string[] fileds = new string[] { "id", "IsEnglish" };
            object[] values = new object[] { id, 1 };
            using (BLLNewsDetail BLL = new BLLNewsDetail())
            {
                NewsDetail obj = new NewsDetail();
                obj = BLL.GetSingle(fileds, values);
                if (obj != null)
                {
                    lblTitle.Text =GetStrByByteLength(obj.NewsTitle,30,true);
                    lblcontent.Text = obj.NewsContent;
                    Time.Text = string.Format("{0:D}", obj.AddTime);
                }
            }

        }
    }
}