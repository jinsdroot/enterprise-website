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
    public partial class about : PageBase
    {
        private int type;
        protected void Page_Load(object sender, EventArgs e)
        {
            type = GetRequestQuery<int>("type", 0, Convert.ToInt32);
            if (!Page.IsPostBack)
            {
               
                setInfo();
              
            }
        }
     
        private void setInfo()
        {
            // 公司信息
            using (BLLCompanyInformationDetails bll = new BLLCompanyInformationDetails())
            {
                
                if (type == 5)
                {
                   
                    qianzhui.Text = "公司";
                    houzhui.Text = "介绍";
                    yingwen.Text = "ABOUT  US";
                }

                else if (type == 58)
                {
                    
                    qianzhui.Text = "人才";
                    houzhui.Text = "招聘";
                    yingwen.Text = "Recruitment of talents";
                }
                else if (type == 62)
                {

                    qianzhui.Text = "企业";
                    houzhui.Text = "文化";
                    yingwen.Text = "BUSINESS CULTURE;";
                }
               else  if (type == 44)
                {
                   
                    qianzhui.Text = "联系";
                    houzhui.Text = "我们";
                    yingwen.Text = "CONTACT  US";
                }
                else
                {
                    type = 5;
                    qianzhui.Text = "公司";
                    houzhui.Text = "简介";
                    yingwen.Text = "ABOUT  US";
                }
                string[] fileds = new string[] { "CompanyInformationTypeID", "IsEnglish" };
                object[] values = new object[] { type, 1 };

                // 公司简介
                CompanyInformationDetails cpinfor = bll.GetSingle(fileds, values);
                if (cpinfor != null)
                {
                    companyintroduce.Text = cpinfor.CompanyInformationDetail;
                }
                else
                {
                }

            }

        }

        //private void setnews()
        //{
        //    SearchNewsDetail snt = new SearchNewsDetail();
        //    snt.IsEnglish = 1;
        //    if (type == 0)
        //    { }
        //    else
        //    {
        //        //snt.NewsTypeID = type;
        //    }
            
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