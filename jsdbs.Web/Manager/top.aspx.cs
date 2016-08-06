using System;
using System.Web.UI;
using jsbestop.Entity;

namespace jsbestop.Web.Manager
{
    public partial class top : AdminPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            btnquit.Click += new ImageClickEventHandler(btnquit_Click);
            
            	AdminUser adminuser = GetAdminUser();
				if (adminuser != null)
                    lblUser.Text = adminuser.TrueName + "&nbsp;&nbsp;&nbsp;&nbsp;欢迎您使用后台管理系统";
				else
					lblUser.Text = "";
                      
        }

        void btnquit_Click(object sender, ImageClickEventArgs e)
        {
        	Session.Abandon();
        	Session.Clear();
			Common.JSMsg.ShowTopRedirect(this,"", "login.aspx");
        }
    }
}
