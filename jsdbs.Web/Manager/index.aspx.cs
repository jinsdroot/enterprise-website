using System;

namespace jsbestop.Web.Manager
{
	public partial class index : jsbestop.Web.Manager.AdminPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
			Page.Title = PageTitle + "网站后台管理中心";
        }
    }
}
