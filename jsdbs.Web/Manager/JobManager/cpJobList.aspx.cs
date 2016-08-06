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

namespace jsbestop.Web.Manager.JobManager
{
    public partial class cpJobList : AdminPageBase
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
            SearchJobType search = new SearchJobType();
            using (BLLJobType bll = new BLLJobType())
            {
                DataTable dt = bll.GetTable(search);
                if (dt != null)
                {
                    ddlJobType.DataSource = dt;
                    ddlJobType.DataTextField = JobType.JobTypeName_FieldName;
                    ddlJobType.DataValueField = JobType.ID_FieldName;
                    ddlJobType.DataBind();
                    ddlJobType.Items.Insert(0, new ListItem("==请选择类型==", "0"));
                }
            }
        }

        private void bindList()
        {
            SearchJobDetail con = new SearchJobDetail();
            if (ddlJobType.SelectedValue != "")
            {
                con.CpJobTypeID = Convert.ToInt32(ddlJobType.SelectedValue);
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
            using (BLLJobDetail bll = new BLLJobDetail())
            {
                List<JobDetail> lists = bll.GetPageList(con, pagina, JobDetail.ID_FieldName, ScriptQuery.SortEnum.DESC);

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
            using (BLLJobDetail bll = new BLLJobDetail())
            {
                foreach (string id in array)
                {
                    switch (op)
                    {
                        case 7:
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