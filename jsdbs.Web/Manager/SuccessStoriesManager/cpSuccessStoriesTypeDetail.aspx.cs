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

namespace jsbestop.Web.Manager.SuccessStoriesManager
{
    public partial class cpSuccessStoriesTypeDetail : AdminPageBase
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
                using (BLLSuccessStoriesType bll = new BLLSuccessStoriesType())
                {
                    SuccessStoriesType cpinfor = bll.GetSingle(id);
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
                        txtSSTypeName.Text = cpinfor.SSTypeName;
                        txtRemarks.Text = cpinfor.Remarks;
                        txtAutoSort.Text = cpinfor.AutoSort.ToString();
                    }
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            using (BLLSuccessStoriesType bll = new BLLSuccessStoriesType())
            {
                SuccessStoriesType obj = new SuccessStoriesType();

                if (id > 0)
                {
                    obj = bll.GetSingle(id);
                    obj.ID = id;
                }
                obj.SSTypeName = txtSSTypeName.Text.Trim().ToString();
                obj.Remarks = txtRemarks.Text.ToString();
                obj.AutoSort = Convert.ToInt32(txtAutoSort.Text);
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
                    JSMsg.ShowWinRedirect(this, "保存成功", "cpSuccessStoriesTypeList.aspx");
                }
            }
        }
    }
}