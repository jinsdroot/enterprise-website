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
using System.IO;

namespace jsbestop.Web.Manager.DownLoadManager
{
    public partial class cpDownLoadList : AdminPageBase
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
            SearchDownLoad con = new SearchDownLoad();
            con.CpDLName = txtCpInforTypeName.Text.Trim().ToString();
            if (rbtnIsChinese.Checked == true)
            {
                con.IsEnglish = 1;
            }
            else if (rbtnIsEnglish.Checked == true)
            {
                con.IsEnglish = 2;
            }
            Pagination pagina = new Pagination(pager.PageIndex, pager.PageSize, 0);
            using (BLLDownLoad bll = new BLLDownLoad())
            {
                List<DownLoad> lists = bll.GetPageList(con, pagina, DownLoad.ID_FieldName, ScriptQuery.SortEnum.DESC);

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
            using (BLLDownLoad bll = new BLLDownLoad())
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

        //WriteFile实现下载
        protected void fileup_Click(object sender, EventArgs e)
        {
            string path = ((LinkButton)sender).CommandArgument;
            string fileName = Path.GetFileName(path) ;//客户端保存的文件名
            string filePath = Server.MapPath(path);//路径
            FileInfo fileInfo = new FileInfo(filePath);
            Response.Clear();
            Response.ClearContent();
            Response.ClearHeaders();
            Response.AddHeader("Content-Disposition", "attachment ;fileName=" + fileName);
            Response.AddHeader("Content-Length", fileInfo.Length.ToString());
            Response.AddHeader("Content-Transfer-Encoding", "binary");
            Response.ContentType = "application/octet-stream";

            Response.ContentEncoding = System.Text.Encoding.GetEncoding("UTF-8");
            Response.WriteFile(fileInfo.FullName);
            Response.Flush();
            Response.End();
           
        }
    }
}