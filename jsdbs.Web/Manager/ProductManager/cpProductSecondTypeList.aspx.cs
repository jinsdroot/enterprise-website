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
using Common;
using System.Data;


namespace jsbestop.Web.Manager.ProductManager
{
    public partial class cpProductSecondTypeList : AdminPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            pager.PageJump += new EventHandler(pager_PageJump);
            if (!IsPostBack)
            {
                getProtypeList();
                bindList();
            }
        }
        void pager_PageJump(object sender, EventArgs e)
        {
            bindList();
        }

        private void getProtypeList()
        {
            SearchProductType search = new SearchProductType();
            using (BLLProductType bll = new BLLProductType())
            {
                DataTable dt = bll.GetTable(search);
                if (dt != null)
                {
                    ddlProductTypeName.DataSource = dt;
                    ddlProductTypeName.DataTextField = ProductType.ProductTypeName_FieldName;
                    ddlProductTypeName.DataValueField = ProductType.ID_FieldName;
                    ddlProductTypeName.DataBind();
                    ddlProductTypeName.Items.Insert(0, new ListItem("==请选择类型==", "0"));
                }
            }
        }
        private void bindList()
        {
            SearchProductSecondType con = new SearchProductSecondType();
            con.ProductSecondTypeName = txtProductSecondTypeName.Text.Trim().ToString();
            if (ddlProductTypeName.SelectedValue != "")
            {
                con.ProductTypeID = Convert.ToInt32(ddlProductTypeName.SelectedValue) ;
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
            using (BLLProductSecondType bll = new BLLProductSecondType())
            {
                List<ProductSecondType> lists = bll.GetPageList(con, pagina, CompanyInformationType.ID_FieldName, ScriptQuery.SortEnum.DESC);

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
            using (BLLProductSecondType bll = new BLLProductSecondType())
            {
                foreach (string id in array)
                {
                    switch (op)
                    {
                        case 7:
                          SearchProductDetail cond = new SearchProductDetail();
                            cond.ProSecondTypeID = Convert.ToInt32(id);
                            using (BLLProductDetail jobbll = new BLLProductDetail())
                            {
                                 if (jobbll.GetList(cond).Count > 0)
                                 {
                                   return "有子类目不能删除；";

                                 }
                                 else
                                 {
                                  bll.Delete(id);
                                  break;
                                        
                                  }

                            }


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