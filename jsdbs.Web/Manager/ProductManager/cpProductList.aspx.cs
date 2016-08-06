using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using Cnkj.Utility;
using jsbestop.BLL;
using jsbestop.Entity.Search;
using System.Data;
using jsbestop.Entity;
using DevNet.Common;
using System.IO;
using Common;

namespace jsbestop.Web.Manager.ProductManager
{
    public partial class cpProductList : AdminPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            pager.PageJump += new EventHandler(pager_PageJump);
            if (!IsPostBack)
            {
                bindList();
                getProtypeList();
                getProtypeList1();
            }
        }
        void pager_PageJump(object sender, EventArgs e)
        {
            bindList();
        }
        private void bindList()
        {
            SearchProductDetail con = new SearchProductDetail();
            if (ddlCpInforTypeName.SelectedValue != "")
            {
                con.ProTypeID = Convert.ToInt32(ddlCpInforTypeName.SelectedValue);
            }
            if (ddlCpInforSecondTypeName.SelectedValue != "")
            {
                con.ProSecondTypeID = Convert.ToInt32(ddlCpInforSecondTypeName.SelectedValue);
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
            using (BLLProductDetail bll = new BLLProductDetail())
            {
                List<ProductDetail> lists = bll.GetPageList(con, pagina, ProductDetail.ID_FieldName, ScriptQuery.SortEnum.DESC);

                pager.RecordCount = pagina.RecordCount;
                pager.PageCount = pagina.PageCount;

                grid_friendlink.DataSource = lists;
                grid_friendlink.DataBind();
            }

        }

        private void getProtypeList()
        {
            SearchProductType search = new SearchProductType();
            using (BLLProductType bll = new BLLProductType())
            {
                DataTable dt = bll.GetTable(search);
                if (dt != null)
                {
                    ddlCpInforTypeName.DataSource = dt;
                    ddlCpInforTypeName.DataTextField = ProductType.ProductTypeName_FieldName;
                    ddlCpInforTypeName.DataValueField = ProductType.ID_FieldName;
                    ddlCpInforTypeName.DataBind();
                    ddlCpInforTypeName.Items.Insert(0, new ListItem("==请选择类型==", "0"));
                }
            }
        }
        private void getProtypeList1()
        {
            SearchProductSecondType search = new SearchProductSecondType();
            using (BLLProductSecondType bll = new BLLProductSecondType())
            {
                DataTable dt = bll.GetTable(search);
                if (dt != null)
                {
                    ddlCpInforSecondTypeName.DataSource = dt;
                    ddlCpInforSecondTypeName.DataTextField = ProductSecondType.ProductSecondTypeName_FieldName;
                    ddlCpInforSecondTypeName.DataValueField = ProductSecondType.ID_FieldName;
                    ddlCpInforSecondTypeName.DataBind();
                    ddlCpInforSecondTypeName.Items.Insert(0, new ListItem("==请选择类型==", "0"));
                }
            }
        }
        [WebMethod]
        public static string OperateRecords(string ids, int op)
        {
            string[] array = ids.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            using (BLLProductDetail bll = new BLLProductDetail())
            {
                foreach (string id in array)
                {
                    switch (op)
                    {
                        case 7:
                            if (File.Exists(StringPlus.MapPath(bll.GetSingle(id).ProductPic)))
                            {
                                File.Delete(StringPlus.MapPath(bll.GetSingle(id).ProductPic));
                                if (File.Exists(StringPlus.MapPath(phoneImgUrl(bll.GetSingle(id).ProductPic))))
                                {
                                    File.Delete(StringPlus.MapPath(phoneImgUrl(bll.GetSingle(id).ProductPic)));
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

        protected void lnkBack_Click(object sender, EventArgs e)
        {
            bindList();
        }

        protected void IsEnglishLa_Change(object sender, EventArgs e)
        {
            bindList();
        }
    }
}