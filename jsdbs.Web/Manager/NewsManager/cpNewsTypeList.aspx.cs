using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cnkj.Utility;
using jsbestop.BLL;
using System.Web.Services;
using jsbestop.Entity.Search;
using DevNet.Common;
using jsbestop.Entity;

namespace jsbestop.Web.Manager.NewsManager
{
    public partial class cpNewsTypeList : AdminPageBase
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
            SearchNewsType con = new SearchNewsType();
            con.NewsTypeName= txtNewsTypeName.Text.Trim().ToString();
            if (rbtnIsChinese.Checked == true)
            {
                con.IsEnglish = 1;
            }
            else if (rbtnIsEnglish.Checked == true)
            {
                con.IsEnglish = 2;
            }
            Pagination pagina = new Pagination(pager.PageIndex, pager.PageSize, 0);
            using (BLLNewsType bll = new BLLNewsType())
            {
                List<NewsType> lists = bll.GetPageList(con, pagina, NewsType.ID_FieldName, ScriptQuery.SortEnum.DESC);

                pager.RecordCount = pagina.RecordCount;
                pager.PageCount = pagina.PageCount;

                grid_friendlink.DataSource = lists;
                grid_friendlink.DataBind();
            }

        }

        protected void IsEnglishLa_Change(object sender, EventArgs e)
        {
            bindList();
        }

        protected void lnkBack_Click(object sender, EventArgs e)
        {
            bindList();
        }

        [WebMethod]
        public static string OperateRecords(string ids, int op)
        {
            string[] array = ids.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            using (BLLNewsType bll = new BLLNewsType())
            {
                foreach (string id in array)
                {
                    switch (op)
                    {
                        case 7:

                            using (BLLNewsDetail blls1 = new BLLNewsDetail())
                            {
                                SearchNewsDetail con3 = new SearchNewsDetail();
                                con3.NewsTypeID = Convert.ToInt32(id);

                                if (blls1.GetList(con3).Count > 0)
                                {
                                    return "此新闻类型下有相应的新闻，不能删除！";
                                }
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
    }
}