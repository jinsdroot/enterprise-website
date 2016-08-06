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
    public partial class about : PageBase
    {
        private int type;
        public string Title;
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
                if (type == 0)
                {
                    type = 5;
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
            using (BLLCompanyInformationType bll = new BLLCompanyInformationType())
            {
                string[] fileds = new string[] { "CompanyInformationTypeID", "IsEnglish" };
                object[] values = new object[] { type, 1 };
                CompanyInformationType contype = bll.GetSingle(type);
                if (contype != null)
                {
                    Title = contype.CompanyInformationName;
                }
                
            }
        }
    }
}