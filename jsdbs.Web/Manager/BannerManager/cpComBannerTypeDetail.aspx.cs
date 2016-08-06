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
namespace jsbestop.Web.Manager.BannerManager
{
    public partial class cpComBannerTypeDetail : AdminPageBase
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
                using (BLLComBannerType bll = new BLLComBannerType())
                {
                    ComBannerType cpinfor = bll.GetSingle(id);
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
                        txtNewsTypeName.Text = cpinfor.ComBannerTypeName;
                        txtRemarks.Text = cpinfor.Remarks;
                    }
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            using (BLLComBannerType bll = new BLLComBannerType())
            {
                ComBannerType obj = new ComBannerType();

                if (id > 0)
                {
                    obj = bll.GetSingle(id);
                    obj.ID = id;
                }
                obj.ComBannerTypeName = txtNewsTypeName.Text.Trim().ToString();
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
                    JSMsg.ShowWinRedirect(this, "保存成功", "cpComBannerTypeList.aspx");
                }
            }
        }
    }
}