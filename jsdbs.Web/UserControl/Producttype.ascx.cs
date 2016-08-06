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
namespace jsbestop.Web.UserControl
{
    public partial class Producttype : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                setContactsInfo();
                ShowMenu();
            }
        }
        protected string GetStrByByteLength(string str, int byteLength, bool isDot)
        {
            return StringPlus.GetStrByByteLength(str, byteLength, isDot);
        }
        private void ShowMenu()
        {
            SearchProductType snt = new SearchProductType();
            snt.IsEnglish = 1;
            //Pagination pagination = new DevNet.Common.Pagination(1,10, 0);
            using (BLLProductType bll = new BLLProductType())
            {
                List<ProductType> lists = bll.GetList(snt);
                rptProducttype.DataSource = lists;
                rptProducttype.DataBind();
            }
        }
        private void setContactsInfo()
        {
            using (BLLContact bll = new BLLContact())
            {
                Contact contact = bll.GetSingle(1);
                if (contact != null)
                {
                    lblAddress.Text = contact.ConAddress;
                    lblTel.Text = contact.ConTel;
                    lblName.Text = contact.ConName;
                    lblPhone.Text = contact.ConPhone;
                    lblEmail.Text = contact.ConEmail;
                    lblFax.Text = contact.ConFax;
                    //numbertongji = contact.BaiDuCount.ToString();
                }
            }
        }
    }
}