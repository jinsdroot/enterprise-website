using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using jsbestop.BLL;
using jsbestop.Entity;
using jsbestop.Entity.Search;
using System.Data;
using Cnkj.Utility;
using Common;

namespace jsbestop.Web.Manager.CpInformationManager
{
    public partial class CompanyInformationDetail : AdminPageBase
    {
        private int id = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            id = GetRequestQuery<int>("id", 0, Convert.ToInt32);
            if (!IsPostBack)
            {
                setInfo();
                getProtypeList();
            }
        }
        private void getProtypeList()
        {
            SearchCompanyInformationType search = new SearchCompanyInformationType();
            using (BLLCompanyInformationType bll = new BLLCompanyInformationType())
            {
                DataTable dt = bll.GetTable(search);
                if (dt != null)
                {
                    ddlCompanyInforType.DataSource = dt;
                    ddlCompanyInforType.DataTextField = CompanyInformationType.CompanyInformationName_FieldName;
                    ddlCompanyInforType.DataValueField = CompanyInformationType.ID_FieldName;
                    ddlCompanyInforType.DataBind();
                }
            }
        }

        private void setInfo()
        {
            if (id > 0)
            {
                using (BLLCompanyInformationDetails bll = new BLLCompanyInformationDetails())
                {
                    CompanyInformationDetails cpinfor = bll.GetSingle(id);
                    if (cpinfor != null)
                    {
                        ddlCompanyInforType.SelectedValue = cpinfor.CompanyInformationTypeID.ToString();
                        txtContent.Value = cpinfor.CompanyInformationDetail;
                        txtRemarks.Text = cpinfor.Remarks;
                        if (cpinfor.IsEnglish == 1)
                        {
                            rbtnIsChinese.Checked = true;
                        }
                        else if (cpinfor.IsEnglish == 2)
                        {
                            rbtnIsEnglish.Checked = true;
                        }
                    }
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            using (BLLCompanyInformationDetails bll = new BLLCompanyInformationDetails())
            {
                CompanyInformationDetails obj = new CompanyInformationDetails();
                if (id>0)
                {
                    obj = bll.GetSingle(id);
                }
                obj.CompanyInformationTypeID = Convert.ToInt32(ddlCompanyInforType.SelectedValue);
                obj.CompanyInformationDetail = txtContent.Value;
                obj.Remarks = txtRemarks.Text.ToString();
                obj.AddTime = System.DateTime.Now;
                if (rbtnIsChinese.Checked == true)
                {
                    obj.IsEnglish = 1;
                }
                else if (rbtnIsEnglish.Checked == true)
                {
                    obj.IsEnglish = 2;
                }
                else
                {
                    ShowMsg("请选择语言类别！");
                    return;
                }

                bll.Save(obj);

                if (bll.IsFail)
                {
                    ExceptionManager.ShowErrorMsg(this, bll.DevNetException);
                }
                else
                {
                    JSMsg.ShowWinRedirect(this, "保存成功", "CompanyInformationList.aspx");
                }

            }
        }
    }
}