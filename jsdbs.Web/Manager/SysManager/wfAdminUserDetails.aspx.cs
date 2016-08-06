using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cnkj.Utility;
using jsbestop.BLL;
using jsbestop.Entity;
using Common;
using System.Data;
using jsbestop.Entity.Search;
using System.Data.OleDb;

namespace jsbestop.Web.Manager.SysManager
{
	public partial class wfAdminUserDetails : AdminPageBase
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
				using (BLLAdminUser bll = new BLLAdminUser())
				{
					AdminUser admin = bll.GetSingle(id);
					if (admin != null)
					{
						txtAccount.Text = admin.Account;
						txtTrueName.Text = admin.TrueName;

						lblPwd.Text = "<span style=\"color:Red;\">*如不修改密码请留空</span> ";
						lblAgin.Text = "<span style=\"color:Red;\">*如不修改密码请留空</span> ";
					}
				}
			}
		}

		protected void btnSubmit_Click(object sender, EventArgs e)
		{
            if (txtAccount.Text.Trim() == "")
            {
                ShowMsg("请输入登录帐号");
                return;
            }

            if (id == 0)
            {
                if (txtPwd.Text.Trim() == "")
                {
                    ShowMsg("请输入登录密码");
                    return;
                }
            }

            if (txtPwd.Text.Trim() != txtPwdAgain.Text.Trim())
            {
                ShowMsg("两次输入密码不一致");
                return;
            }
            using (BLLAdminUser bll = new BLLAdminUser())
            {               
                AdminUser admin = new AdminUser();
                if (id>0)
                {
                    admin = bll.GetSingle(id);
                }
                admin.ID = id;
                admin.Account = txtAccount.Text.Trim();
                admin.TrueName = txtTrueName.Text;
                if (txtPwd.Text.Trim() != "")
                {
                    admin.PassWord = WebCommon.Md5Enctry(txtPwd.Text.Trim());
                }
                else
                {
                    admin.PassWord = admin.PassWord;
                }

                bll.Save(admin);
                
                if (bll.IsFail)
                {
                    ExceptionManager.ShowErrorMsg(this, bll.DevNetException);
                }
                else
                {
                    JSMsg.ShowWinRedirect(this, "保存成功", "wfAdminUser.aspx");
                }
            }
		}
	}
}