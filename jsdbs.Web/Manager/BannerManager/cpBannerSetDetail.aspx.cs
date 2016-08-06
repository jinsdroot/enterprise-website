using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using jsbestop.BLL;
using jsbestop.Entity;
using System.IO;
using Cnkj.Utility;
using Common;
using DevNet.Common;
using jsbestop.Entity.Search;
using System.Data;
namespace jsbestop.Web.Manager.BannerManager
{
    public partial class cpBannerSetDetail : AdminPageBase
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
            SearchComBannerType search = new SearchComBannerType();
            using (BLLComBannerType bll = new BLLComBannerType())
            {
                DataTable dt = bll.GetTable(search);//ScriptQuery.SortEnum.DESC
                if (dt != null)
                {
                    ddlNewsType.DataSource = dt;
                    ddlNewsType.DataTextField = ComBannerType.ComBannerTypeName_FieldName;
                    ddlNewsType.DataValueField = ComBannerType.ID_FieldName;
                    ddlNewsType.DataBind();
                }
            }
        }
        private void setInfo()
        {
            if (id > 0)
            {
                using (BLLComBanner bll = new BLLComBanner())
                {
                    ComBanner dwinfor = bll.GetSingle(id);
                    if (dwinfor != null)
                    {
                        ddlNewsType.SelectedValue = dwinfor.ComBannerTypeID.ToString();
                        txtDLName.Text = dwinfor.BannerTitle;
                        txtLink.Text = dwinfor.BannerLink;
                        Image1.ImageUrl = dwinfor.BannerPic;
                    }
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            using (BLLComBanner bll = new BLLComBanner())
            {
                ComBanner obj = new ComBanner();

                if (id > 0)
                {
                    obj = bll.GetSingle(id);
                    obj.ID = id;
                }
                obj.ComBannerTypeID = Convert.ToInt32(ddlNewsType.SelectedValue);
                obj.BannerTitle = txtDLName.Text.Trim().ToString();
                obj.BannerLink = txtLink.Text.Trim().ToString();
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
                                if (File.Exists(StringPlus.MapPath(bll.GetSingle(id).BannerPic)))
                                {
                                    File.Delete(StringPlus.MapPath(bll.GetSingle(id).BannerPic));
                                }
                            }
                            obj.BannerPic = virFileFullName;
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
                        obj.BannerPic = Image1.ImageUrl.ToString();
                    }
                }
                catch (DevNetException ex)
                {
                    ExceptionManager.ShowErrorMsg(this, ex);
                    return;
                }
                #endregion

                bll.Save(obj);

                if (bll.IsFail)
                {
                    ExceptionManager.ShowErrorMsg(this, bll.DevNetException);
                }
                else
                {
                    JSMsg.ShowWinRedirect(this, "保存成功", "cpBannerSet.aspx");
                }
            }
        }

        private bool IsAllowedExtension(string imgPath)
        {
            bool ret = false;

            //System.IO.FileStream fs = new System.IO.FileStream(hifile.FileName, System.IO.FileMode.Open, System.IO.FileAccess.Read);
            System.IO.FileStream fs = new System.IO.FileStream(imgPath, System.IO.FileMode.Open, System.IO.FileAccess.Read);
            System.IO.BinaryReader r = new System.IO.BinaryReader(fs);
            string fileclass = "";
            byte buffer;
            try
            {
                buffer = r.ReadByte();
                fileclass = buffer.ToString();
                buffer = r.ReadByte();
                fileclass += buffer.ToString();
            }
            catch
            {
                return false;
            }
            r.Close();
            fs.Close();
            /*文件扩展名说明
             *7173        gif 
             *255216      jpg
             *13780       png
             *6677        bmp
             *239187      txt,aspx,asp,sql
             *208207      xls.doc.ppt
             *6063        xml
             *6033        htm,html
             *4742        js
             *8075        xlsx,zip,pptx,mmap,zip
             *8297        rar   
             *01          accdb,mdb
             *7790        exe,dll           
             *5666        psd 
             *255254      rdp 
             *10056       bt种子 
             *64101       bat 
             */


            String[] fileType = { "255216", "7173", "6677", "13780" };

            for (int i = 0; i < fileType.Length; i++)
            {
                if (fileclass == fileType[i])
                {
                    ret = true;
                    break;
                }
            }
            return ret;
        }
        
    }
}