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
    public partial class ContactUS : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                setContactsInfo();

            }
        }
        private void setContactsInfo()
        {
            using (BLLContact bll = new BLLContact())
            {
                Contact contact = bll.GetSingle(1);
                if (contact != null)
                {
                    lblFax.Text = contact.ConFax;
                    lblAddress.Text = contact.ConAddress;
                    lblTel.Text = contact.ConTel;
                    //lblWeb.Text = contact.ConWebsite;
                    //lblEmail.Text = contact.ConEmail;
                    //lblFax.Text = contact.ConFax;
                    lblName.Text = contact.ConName;
                    //numbertongji = contact.BaiDuCount.ToString();
                }
            }
        }
    }
}