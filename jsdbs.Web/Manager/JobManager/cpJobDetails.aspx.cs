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

namespace jsbestop.Web.Manager.JobManager
{
    public partial class cpJobDetails : AdminPageBase
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
            SearchJobType search = new SearchJobType();
            using (BLLJobType bll = new BLLJobType())
            {
                DataTable dt = bll.GetTable(search);
                if (dt != null)
                {
                    ddlJobTypeID.DataSource = dt;
                    ddlJobTypeID.DataTextField = JobType.JobTypeName_FieldName;
                    ddlJobTypeID.DataValueField = JobType.ID_FieldName;
                    ddlJobTypeID.DataBind();
                }
            }
        }

        private void setInfo()
        {
            if (id > 0)
            {
                using (BLLJobDetail bll = new BLLJobDetail())
                {
                    JobDetail jobdetail = bll.GetSingle(id);
                    if (jobdetail != null)
                    {
                        ddlJobTypeID.SelectedValue = jobdetail.JobTypeID.ToString();
                        txtJobName.Text = jobdetail.JobName;
                        txtContent.Value = jobdetail.JobContent;
                        txtJobNumber.Text = jobdetail.JobNumber;
                        txtJobTreatment.Text = jobdetail.JobTreatment;
                        txtCandidatesway.Text = jobdetail.Candidatesway;
                        txtJobEndDate.Value = jobdetail.JobEndDate.ToString();
                        txtRemarks.Text = jobdetail.Remarks;
                        if (jobdetail.IsEnglish == 1)
                        {
                            rbtnIsChinese.Checked = true;
                        }
                        else if (jobdetail.IsEnglish == 2)
                        {
                            rbtnIsEnglish.Checked = true;
                        }
                    }
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            using (BLLJobDetail bll = new BLLJobDetail())
            {
                JobDetail obj = new JobDetail();
                if (id > 0)
                {
                    obj = bll.GetSingle(id);
                }
                obj.JobTypeID = Convert.ToInt32(ddlJobTypeID.SelectedValue);
                obj.JobName = txtJobName.Text;
                obj.JobNumber = txtJobNumber.Text;
                obj.JobContent = txtContent.Value;
                obj.JobTreatment = txtJobTreatment.Text;
                obj.Candidatesway = txtCandidatesway.Text;
                obj.Remarks = txtRemarks.Text.ToString();
                obj.JobEndDate = Convert.ToDateTime(txtJobEndDate.Value);
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
                    JSMsg.ShowWinRedirect(this, "保存成功", "cpJobList.aspx");
                }

            }
        }
    }
}