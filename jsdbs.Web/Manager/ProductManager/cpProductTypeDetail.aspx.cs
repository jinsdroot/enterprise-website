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
using System.IO;
using DevNet.Common;
namespace jsbestop.Web.Manager.ProductManager
{
    public partial class cpProductTypeDetail : AdminPageBase
    {
        private int id = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            id = GetRequestQuery<int>("id", 0, Convert.ToInt32);
            if (!IsPostBack)
            {
                setInfo();
            }
        }

        private void setInfo()
        {
            if (id > 0)
            {
                using (BLLProductType bll = new BLLProductType())
                {
                    ProductType prinfor = bll.GetSingle(id);
                    if (prinfor != null)
                    {
                        if (prinfor.IsEnglish == 1)
                        {
                            rbtnIsChinese.Checked = true;
                        }
                        else if (prinfor.IsEnglish == 2)
                        {
                            rbtnIsEnglish.Checked = true;
                        }
                        txtProductTypeName.Text = prinfor.ProductTypeName;
                        txtAutoSort.Text = prinfor.AutoSort.ToString();
                        if (prinfor.IsHaveSecondTpye == 1)
                        {
                             rbhave.Checked = true;
                        }
                        else if (prinfor.IsHaveSecondTpye == 2)
                        {
                            rbno.Checked = true;
                        }
                        txtRemarks.Text = prinfor.Remarks;
                        Image1.ImageUrl = prinfor.ProductTypePic.ToString();
                    }
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            using (BLLProductType bll = new BLLProductType())
            {
                ProductType obj = new ProductType();

                if (id > 0)
                {
                    obj = bll.GetSingle(id);
                    obj.ID = id;
                }
                obj.ProductTypeName = txtProductTypeName.Text.Trim().ToString();
                obj.AutoSort = Convert.ToInt32(txtAutoSort.Text) ;
                obj.Remarks = txtRemarks.Text.ToString();
                #region 上传产品图片(前台产品图片来源于此)
                try
                {
                    if (this.UploadImg.HasFile)
                    {
                        string extName = Path.GetExtension(UploadImg.FileName);
                        string virFileFullName;
                        string fileName;

                        WebCommon.GetUploadRandFileName(extName, out virFileFullName, out fileName);
                        UploadImg.SaveAs(StringPlus.MapPath(virFileFullName));

                        if (IsAllowedExtension(StringPlus.MapPath(virFileFullName)))
                        {
                            if (id > 0)
                            {//新增时无需删除
                                if (File.Exists(StringPlus.MapPath(bll.GetSingle(id).ProductTypePic)))
                                {
                                    File.Delete(StringPlus.MapPath(bll.GetSingle(id).ProductTypePic));
                                }
                            }
                            obj.ProductTypePic = virFileFullName;
                        }
                        else
                        {
                            if (File.Exists(StringPlus.MapPath(virFileFullName)))
                            {
                                File.Delete(StringPlus.MapPath(virFileFullName));
                            }
                            ShowMsg("请上传正确的图片(.jpg,.gif,.bmp,.png)");
                            return;
                        }
                    }
                    else
                    {
                        obj.ProductTypePic = Image1.ImageUrl.ToString();
                    }
                }
                catch (DevNetException ex)
                {
                    ExceptionManager.ShowErrorMsg(this, ex);
                    return;
                }
                #endregion
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

                if (rbhave.Checked == true)
                {
                    obj.IsHaveSecondTpye = 1;
                }
                else if (rbno.Checked == true)
                {
                    obj.IsHaveSecondTpye = 2;
                }
                else
                {
                    ShowMsg("请是否有二级目录！");
                    return;
                }

                bll.Save(obj);

                if (bll.IsFail)
                {
                    ExceptionManager.ShowErrorMsg(this, bll.DevNetException);
                }
                else
                {
                    JSMsg.ShowWinRedirect(this, "保存成功", "cpProductTypeList.aspx");
                }
            }
        }

    }
}