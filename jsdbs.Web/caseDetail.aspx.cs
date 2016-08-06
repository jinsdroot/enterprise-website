using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common;
using jsbestop.BLL;
using jsbestop.Entity;
using jsbestop.Entity.Search;

namespace jsbestop.Web
{
    public partial class caseDetail : PageBase
    {
        private int id = 0;
        private int type;
        protected void Page_Load(object sender, EventArgs e)
        {
            id = GetRequestQuery<int>("id", 0, Convert.ToInt32);
            type = GetRequestQuery<int>("type", 0, Convert.ToInt32);
            if (!IsPostBack)
            {
                ShowMenu();
                if (type == 15)
                {
                    qianzhui.Text = "生产";
                    houzhui.Text = "设备";
                    yingwen.Text = "PRODUCT RUN  EQUIPMENT";


                }
                else if (type == 14)
                {
                    qianzhui.Text = "成功";
                    houzhui.Text = "案例";
                    yingwen.Text = "SUCCESSFUL CASE";


                }
                else
                {
                    type = 15;
                    qianzhui.Text = "生产";
                    houzhui.Text = "设备";
                    yingwen.Text = "SUCCESSFUL CASE";
                }
            }
        }
        private void ShowMenu()
        {
            int IsEnglish = Session["isEnglish"] == null ? 1 : Convert.ToInt32(Session["isEnglish"]);
            string[] fileds = new string[] { "id", "IsEnglish" };
            object[] values = new object[] { id, IsEnglish };
            using (BLLSuccessStories BLL = new BLLSuccessStories())
            {
                SuccessStories obj = new SuccessStories();
                obj = BLL.GetSingle(fileds, values);
                if (obj != null)
                {
                    picpro.ImageUrl = obj.SSPic;
                    lblTitle.Text = obj.SSName;
                    lblContent.Text = obj.SSContent;
                }
            }

        }
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
    }
}