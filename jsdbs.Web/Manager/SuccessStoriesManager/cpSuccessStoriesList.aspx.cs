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
using System.Data;
using System.IO;
using Common;

namespace jsbestop.Web.Manager.SuccessStoriesManager
{
    public partial class cpSuccessStoriesList : AdminPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            pager.PageJump += new EventHandler(pager_PageJump);
            if (!IsPostBack)
            {
                bindList();
                getProtypeList();
            }
        }

        void pager_PageJump(object sender, EventArgs e)
        {
            bindList();
        }

        private void getProtypeList()
        {
            SearchSuccessStoriesType search = new SearchSuccessStoriesType();
            using (BLLSuccessStoriesType bll = new BLLSuccessStoriesType())
            {
                DataTable dt = bll.GetTable(search);
                if (dt != null)
                {
                    ddlSuccessStoriesType.DataSource = dt;
                    ddlSuccessStoriesType.DataTextField = SuccessStoriesType.SSTypeName_FieldName;
                    ddlSuccessStoriesType.DataValueField = SuccessStoriesType.ID_FieldName;
                    ddlSuccessStoriesType.DataBind();
                    ddlSuccessStoriesType.Items.Insert(0, new ListItem("==请选择类型==", "0"));
                }
            }
        }

        private void bindList()
        {
            SearchSuccessStories con = new SearchSuccessStories();
            if (ddlSuccessStoriesType.SelectedValue != "")
            {
                con.SSType = Convert.ToInt32(ddlSuccessStoriesType.SelectedValue);
            }
            if (rbtnIsChinese.Checked == true)
            {
                con.IsEnglish = 1;
            }
            else if (rbtnIsEnglish.Checked == true)
            {
                con.IsEnglish = 2;
            }
            Pagination pagina = new Pagination(pager.PageIndex, pager.PageSize, 0);
            using (BLLSuccessStories bll = new BLLSuccessStories())
            {
                List<SuccessStories> lists = bll.GetPageList(con, pagina, SuccessStoriesType.ID_FieldName, ScriptQuery.SortEnum.DESC);

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
            using (BLLSuccessStories bll = new BLLSuccessStories())
            {
                foreach (string id in array)
                {
                    switch (op)
                    {
                        case 7:
                            if (File.Exists(StringPlus.MapPath(bll.GetSingle(id).SSPic)))
                            {
                                File.Delete(StringPlus.MapPath(bll.GetSingle(id).SSPic));
                                if (File.Exists(StringPlus.MapPath(phoneImgUrl(bll.GetSingle(id).SSPic))))
                                {
                                    File.Delete(StringPlus.MapPath(phoneImgUrl(bll.GetSingle(id).SSPic)));
                                }
                                bll.Delete(id);
                            }
                            else
                            {
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

        protected void imgSearch_Click(object sender, ImageClickEventArgs e)
        {
            bindList();
        }
    }
}