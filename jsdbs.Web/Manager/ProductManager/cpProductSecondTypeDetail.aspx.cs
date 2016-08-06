using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using jsbestop.BLL;
using jsbestop.Entity;
using Cnkj.Utility;
using Common;
using jsbestop.Entity.Search;
using System.Data;

namespace jsbestop.Web.Manager.ProductManager
{
    public partial class cpProductSecondTypeDetail : AdminPageBase
    {
          private int id = 0;
          protected void Page_Load(object sender, EventArgs e)
          {
            id = GetRequestQuery<int>("id", 0, Convert.ToInt32);
            if (!IsPostBack)
            {
                getProtypeList();
                setInfo();
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
                      ddlProductTypeID.DataSource = dt;
                      ddlProductTypeID.DataTextField = ProductType.ProductTypeName_FieldName;
                      ddlProductTypeID.DataValueField = ProductType.ID_FieldName;
                      ddlProductTypeID.DataBind();
                  }
              }
          }
        private void setInfo()
        {
            if (id > 0)
            {
                using (BLLProductSecondType bll = new BLLProductSecondType())
                {
                    ProductSecondType prinfor = bll.GetSingle(id);
                    if (prinfor != null)
                    {
                        ddlProductTypeID.SelectedValue = prinfor.ProductTypeID.ToString();
                        txtProductSecondTypeName.Text = prinfor.ProductSecondTypeName;
                        txtAutoSort.Text = prinfor.AutoSort.ToString();
                        if (prinfor.IsEnglish == 1)
                        {
                            rbtnIsChinese.Checked = true;
                        }
                        else if (prinfor.IsEnglish == 2)
                        {
                            rbtnIsEnglish.Checked = true;
                        }
                    }
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            using (BLLProductSecondType bll = new BLLProductSecondType())
            {
                ProductSecondType obj = new ProductSecondType();

                if (id > 0)
                {
                    obj = bll.GetSingle(id);
                    obj.ID = id;
                }
                obj.ProductTypeID = Convert.ToInt32(ddlProductTypeID.SelectedValue) ;
                obj.ProductSecondTypeName = txtProductSecondTypeName.Text.Trim().ToString();
                obj.AutoSort = Convert.ToInt32(txtAutoSort.Text) ;
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
                    JSMsg.ShowWinRedirect(this, "保存成功", "cpProductSecondTypeList.aspx");
                }
            }
        }

    }
}