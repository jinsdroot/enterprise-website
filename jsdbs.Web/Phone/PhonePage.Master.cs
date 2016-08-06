using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common;
using jsbestop.Entity.Search;
using jsbestop.BLL;
using jsbestop.Entity;

namespace jsbestop.Web.Phone
{
    public partial class PhonePage : System.Web.UI.MasterPage
    {
        public string BestopLink;
        public string tel;
        public string sms;
        public string phone;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BannerBind();
                setContactsInfo();
                MeunBind();
            }
            Page.Title = ConfigHelper.GetAppString("Title");
            BestopLink = ConfigHelper.GetAppString("BestopLink");
        }
        protected string GetStrByByteLength(string str, int byteLength, bool isDot)
        {
            return StringPlus.GetStrByByteLength(str, byteLength, isDot);
        }
        private void MeunBind()
        {
            using (BLLProductType bll = new BLLProductType())
            {
                SearchProductType cond = new SearchProductType();
                cond.IsEnglish = 1;
                List<ProductType> lists = bll.GetList(cond);
                rptProType.DataSource = lists;
                rptProType.DataBind();
            }
        }
        private void BannerBind()
        {
            SearchComBanner scb = new SearchComBanner();
            scb.ComBannerTypeID = 3;
            using (BLLComBanner bll = new BLLComBanner())
            {
                List<ComBanner> lists = bll.GetList(scb);
                //rptBanner.DataSource = lists;
                //rptBanner.DataBind();
            }
        }
        private void setContactsInfo()
        {
            using (BLLContact bll = new BLLContact())
            {
                Contact contact = bll.GetSingle(1);
                if (contact != null)
                {
                    tel = contact.ConPhone;
                    sms = contact.ConTel;
                    phone= contact.ConTel;
                }
            }
        }
    }
}