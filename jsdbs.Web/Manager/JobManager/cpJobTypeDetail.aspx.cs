using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using jsbestop.BLL;
using jsbestop.Entity;
using Cnkj.Utility;
using Common;


namespace jsbestop.Web.Manager.JobManager
{
    public partial class cpJobTypeDetail : AdminPageBase
    {
        private int id = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            id = GetRequestQuery<int>("id", 0, Convert.ToInt32);
            if (!IsPostBack)
            {
                setInfo();
            }
        }

        private void setInfo()
        {
            if (id > 0)
            {
                using (BLLJobType bll = new BLLJobType())
                {
                    JobType cpinfor = bll.GetSingle(id);
                    if (cpinfor != null)
                    {
                        if (cpinfor.IsEnglish == 1)
                        {
                            rbtnIsChinese.Checked = true;
                        }
                        else if (cpinfor.IsEnglish == 2)
                        {
                            rbtnIsEnglish.Checked = true;
                        }
                        txtJobTypeName.Text = cpinfor.JobTypeName;
                        txtRemarks.Text = cpinfor.Remarks;
                    }
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            using (BLLJobType bll = new BLLJobType())
            {
                JobType obj = new JobType();

                if (id > 0)
                {
                    obj = bll.GetSingle(id);
                    obj.ID = id;
                }
                obj.JobTypeName = txtJobTypeName.Text.Trim().ToString();
                obj.Remarks = txtRemarks.Text.ToString();
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
                    JSMsg.ShowWinRedirect(this, "保存成功", "cpJobTypeList.aspx");
                }
            }
        }

    }
}