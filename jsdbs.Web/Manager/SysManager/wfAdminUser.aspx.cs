using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cnkj.Utility;
using Common;
using DevNet.Common;
using jsbestop.BLL;
using jsbestop.Entity;
using jsbestop.Entity.Search;

namespace jsbestop.Web.Manager.SysManager
{
	public partial class wfAdminUser : AdminPageBase
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			pager.PageJump += new EventHandler(pager_PageJump);
			if (!IsPostBack)
			{
				bindList();
			}
		}

		void pager_PageJump(object sender, EventArgs e)
		{
			bindList();
		}

		private void bindList()
		{
			SearchAdminUser cond = new SearchAdminUser();
			cond.Account = txtAccount.Text.Trim();
			cond.TrueName = txtTrueName.Text.Trim();

			string sortby = ViewState["sort"] as string;
			if (String.IsNullOrEmpty(sortby))
			{
				sortby = AdminUser.AddDate_FieldName + " , DESC";
			}
			string[] sorts = sortby.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

			Pagination pagina = new Pagination(pager.PageIndex, pager.PageSize, 0);
			using (BLLAdminUser bll = new BLLAdminUser())
			{
				List<AdminUser> lists = bll.GetPageList(cond, pagina, sorts[0].Trim(),
														   (ScriptQuery.SortEnum)
														   Enum.Parse(typeof(ScriptQuery.SortEnum), sorts[1].Trim(), true));

				pager.RecordCount = pagina.RecordCount;
				pager.PageCount = pagina.PageCount;

				grid_friendlink.DataSource = lists;
				grid_friendlink.DataBind();
			}

		}

		protected void lnkBack_Click(object sender, EventArgs e)
		{
			bindList();
		}

		[WebMethod]
		public static string OperateRecords(string ids, int op)
		{
			string[] array = ids.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
			using (BLLAdminUser bll = new BLLAdminUser())
			{
				foreach (string id in array)
				{
					switch (op)
					{
						case 7: //delete
							if(bll.GetList().Count<2)
							{
								return "最后一个管理员不能删除";
							}
							bll.Delete(id);

							break;
					}
				}

				if (bll.IsFail)
				{
					return ExceptionManager.GetErrorMsg(bll.DevNetException);
				}

			}
			return string.Empty;
		}

		protected void imgSearch_Click(object sender, ImageClickEventArgs e)
		{
			bindList();
		}

		protected void grid_Sorting(object sender, GridViewSortEventArgs e)
		{
			ViewState["sort"] = GridViewTool.GetSortExpress(grid_friendlink, e);
			bindList();
		}
	}
}