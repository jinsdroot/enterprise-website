using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using jsbestop.BLL;
using jsbestop.Entity;
using jsbestop.Entity.Search;
using System.Data;
using Cnkj.Utility;
using Common;
using DevNet.Common;

namespace jsbestop.Web.Manager.NewsManager
{
    public partial class cpNewsDetail : AdminPageBase
    {
        private int id = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            id = GetRequestQuery<int>("id", 0, Convert.ToInt32);
            if (!IsPostBack)
            {
                setInfo();
                getProtypeList();
            }
        }

        private void getProtypeList()
        {
            SearchNewsType search = new SearchNewsType();
            using (BLLNewsType bll = new BLLNewsType())
            {
                DataTable dt = bll.GetTable(search);//ScriptQuery.SortEnum.DESC
                if (dt != null)
                {
                    ddlNewsType.DataSource = dt;
                    ddlNewsType.DataTextField = NewsType.NewsTypeName_FieldName;
                    ddlNewsType.DataValueField = NewsType.ID_FieldName;
                    ddlNewsType.DataBind();
                }
            }
        }

        private void setInfo()
        {
            if (id > 0)
            {
                using (BLLNewsDetail bll = new BLLNewsDetail())
                {
                    NewsDetail cpinfor = bll.GetSingle(id);
                    if (cpinfor != null)
                    {
                        ddlNewsType.SelectedValue = cpinfor.NewsTypeID.ToString();
                        txtNewsTitle.Text = cpinfor.NewsTitle;
                        txtContent.Value = cpinfor.NewsContent;
                        txtRemarks.Text = cpinfor.Remarks;
                        txtAutoSort.Text= cpinfor.AutoSort.ToString();
                        if (cpinfor.IsEnglish == 1)
                        {
                            rbtnIsChinese.Checked = true;
                        }
                        else if (cpinfor.IsEnglish == 2)
                        {
                            rbtnIsEnglish.Checked = true;
                        }
                    }
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            using (BLLNewsDetail bll = new BLLNewsDetail())
            {
                NewsDetail obj = new NewsDetail();
                if (id > 0)
                {
                    obj = bll.GetSingle(id);
                }
                obj.NewsTypeID = Convert.ToInt32(ddlNewsType.SelectedValue);
                obj.NewsTitle = txtNewsTitle.Text.ToString();
                obj.NewsContent = txtContent.Value;
                obj.Remarks = txtRemarks.Text.ToString();
                obj.AddTime = Convert.ToDateTime(System.DateTime.Now.ToShortDateString());
                if (txtAutoSort.Text.ToString()=="")
                {
                    obj.AutoSort = 0;
                }
                else
                {
                    obj.AutoSort = Convert.ToInt32(txtAutoSort.Text.Trim().ToString());
                }
                if (rbtnIsChinese.Checked == true)
                {
                    obj.IsEnglish = 1;
                }
                else if (rbtnIsEnglish.Checked == true)
                {
                    obj.IsEnglish = 2;
                }
                else
                {
                    ShowMsg("请选择语言类别！");
                    return;
                }

                bll.Save(obj);

                if (bll.IsFail)
                {
                    ExceptionManager.ShowErrorMsg(this, bll.DevNetException);
                }
                else
                {
                    JSMsg.ShowWinRedirect(this, "保存成功", "cpNewsList.aspx");
                }

            }
        }
    }
}