using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using jsbestop.Entity.Search;
using DevNet.Common;
using jsbestop.BLL;
using jsbestop.Entity;
using System.Web.Services;
using Cnkj.Utility;
using System.IO;
using Common;

namespace jsbestop.Web.Manager.BannerManager
{
    public partial class cpBannerSet : AdminPageBase
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
            SearchComBanner con = new SearchComBanner();
           
            Pagination pagina = new Pagination(pager.PageIndex, pager.PageSize, 0);
            using (BLLComBanner bll = new BLLComBanner())
            {
                List<ComBanner> lists = bll.GetPageList(con, pagina, ComBanner.ID_FieldName, ScriptQuery.SortEnum.ASC);

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
            using (BLLComBanner bll = new BLLComBanner())
            {
                foreach (string id in array)
                {
                    switch (op)
                    {
                        case 7:
                            if (File.Exists(StringPlus.MapPath(bll.GetSingle(id).BannerPic)))
                            {
                                File.Delete(StringPlus.MapPath(bll.GetSingle(id).BannerPic));
                                bll.Delete(id);
                            }
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
    }
}