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
    public partial class news_detail : PageBase
    {
        private int id;
        protected void Page_Load(object sender, EventArgs e)
        {
            id = GetRequestQuery<int>("id", 0, Convert.ToInt32);
            if (!IsPostBack)
            {
                Bind();
                //setnews1();
                //MeunBind();
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
                    lblTitle.Text = obj.NewsTitle;
                    lblcontent.Text = obj.NewsContent;
                    lblTime.Text = string.Format("{0:D}", obj.AddTime);
                }
            }

        }

        //private void setnews1()
        //{
        //    SearchNewsDetail snt = new SearchNewsDetail();
        //    snt.IsEnglish = 1;

        //    using (BLLNewsDetail bll = new BLLNewsDetail())
        //    {
        //        List<NewsDetail> lists = bll.GetList(snt);

        //        rptNews.DataSource = lists;
        //        rptNews.DataBind();
                
        //    }
        //    //更新时间没有绑定
        //}
        //private void MeunBind()
        //{
        //    using (BLLProductType bll = new BLLProductType())
        //    {
        //        SearchProductType cond = new SearchProductType();
        //        cond.IsEnglish = 1;
        //        List<ProductType> lists = bll.GetList(cond);
        //        rptProType.DataSource = lists;
        //        rptProType.DataBind();
        //    }
        //}
    }
}