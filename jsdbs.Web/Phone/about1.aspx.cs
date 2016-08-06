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
    public partial class about1 : PageBase
    {
        private int type;
        protected void Page_Load(object sender, EventArgs e)
        {
            type = GetRequestQuery<int>("type", 0, Convert.ToInt32);
            if (!Page.IsPostBack)
            {
                bindinfo();
                setInfo();
            }
        }
        private void bindinfo()
        {
            using (BLLCompanyInformationDetails bll = new BLLCompanyInformationDetails())
            {

                //if (type == 5)
                //{
                //    type = 5;
                //    jianjie.Text = "公司简介";
                //    jianjie1.Text = "COMPANY PROFILE";
                //}
                //else if (type == 58)
                //{

                //    jianjie.Text = "销售网络";
                //    jianjie1.Text = " SALES NETWORK";
                //}
                //else if (type == 44)
                //{
                //    jianjie.Text = "联系我们";
                //    jianjie1.Text = "CONTACT US";
                //}
                //else
                //{
                //    type = 5;
                //    jianjie.Text = "公司简介";
                //    jianjie1.Text = "COMPANY PROFILE";
                //}
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
                    //companyintroduce.Text = cpinfor.CompanyInformationDetail;
                }
                else
                {
                }
            }
        }
    }
}