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
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        public string BestopLink;
        public  string phone;
        public string tel;
        public string address;
        public string fax;
        public string name;
        public string people;
        public string website;


        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!Page.IsPostBack)
            {
                MeunBind();
                BannerBind();
                setContactsInfo();
                Page.Title = ConfigHelper.GetAppString("Title");
                BestopLink = ConfigHelper.GetAppString("BestopLink");

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
        private void BannerBind()
        {
            SearchComBanner scb = new SearchComBanner();
            scb.ComBannerTypeID = 4;
            using (BLLComBanner bll = new BLLComBanner())
            {
                List<ComBanner> lists = bll.GetList(scb);
                rptBanner.DataSource = lists;
                rptBanner.DataBind();
            }
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
        private void setContactsInfo()
        {
            using (BLLContact bll = new BLLContact())
            {
                Contact contact = bll.GetSingle(1);
                if (contact != null)
                {
                    address = contact.ConAddress;
                    tel = contact.ConTel;
                    ////lblTel1.Text = contact.ConTel;
                    name= contact.ConCompany;
                    //Lblcomname1.Text = contact.ConCompany;
                    
                    phone = contact.ConPhone;
                    //lblEmail.Text = contact.ConEmail;
                    fax = contact.ConFax;
                    website = contact.ConWebsite;
                    people = contact.ConName;
                    //numbertongji = contact.BaiDuCount.ToString();
                }
            }
        }

    }
}