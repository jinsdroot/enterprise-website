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
    public partial class contact : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                setContactsInfo();
                //Page.Title = "联系我们";

            }
        }
        private void setContactsInfo()
        {
            // 公司信息
            using (BLLCompanyInformationDetails bll = new BLLCompanyInformationDetails())
            {
                string[] fileds = new string[] { "CompanyInformationTypeID", "IsEnglish" };
                object[] values = new object[] { 44, 1 };
                CompanyInformationDetails cpinfor = bll.GetSingle(fileds, values);
                if (cpinfor != null)
                {
                    lblConatct.Text = cpinfor.CompanyInformationDetail;
                }

            }
        }
    }
}