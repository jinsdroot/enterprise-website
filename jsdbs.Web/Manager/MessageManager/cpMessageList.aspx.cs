using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cnkj.Utility;
using Common;
using DevNet.Common;
using jsbestop.BLL;
using jsbestop.Entity;
using jsbestop.Entity.Search;
using System.Web.Services;

namespace jsbestop.Web.Manager.MessageManager
{
    public partial class cpMessageList : AdminPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            pager.PageJump += new EventHandler(pager_PageJump);

            if (!IsPostBack)
            {
                bindList();
            }

            //base.SetheaderInfo(head1);
        }

        void pager_PageJump(object sender, EventArgs e)
        {
            bindList();
        }

        private void bindList()
        {
            SearchMessages cond = new SearchMessages();
            cond.MesTitle = txtMessageName.Text.Trim().ToString();
            Pagination pagina = new Pagination(pager.PageIndex, pager.PageSize, 0);
            using (BLLMessages bll = new BLLMessages())
            {
                List<Messages> lists = bll.GetPageList(cond, pagina);
                pager.RecordCount = pagina.RecordCount;
                pager.PageCount = pagina.PageCount;

                grid.DataSource = lists;
                grid.DataBind();
            }
        }

        [WebMethod]
        public static string OperateRecords(string ids, int op)
        {
            string[] array = ids.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            using (BLLMessages bll = new BLLMessages())
            {
                foreach (string id in array)
                {
                    switch (op)
                    {
                        case 7: //delete

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

        protected void lnkBack_Click(object sender, EventArgs e)
        {
            bindList();
        }

        protected void imgSearch_Click(object sender, ImageClickEventArgs e)
        {
            bindList();
        }
    }
}