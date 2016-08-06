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

namespace jsbestop.Web.Manager.DownLoadManager
{
    public partial class cpDownLoadDetail : AdminPageBase
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
                using (BLLDownLoad bll = new BLLDownLoad())
                {
                    DownLoad dwinfor = bll.GetSingle(id);
                    if (dwinfor != null)
                    {
                        if (dwinfor.IsEnglish == 1)
                        {
                            rbtnIsChinese.Checked = true;
                        }
                        else if (dwinfor.IsEnglish == 2)
                        {
                            rbtnIsEnglish.Checked = true;
                        }
                        txtDLName.Text = dwinfor.DLName;
                        txtRemarks.Text = dwinfor.Remarks;
                        lblDLAddress.Text = dwinfor.DLAddress;
                    }
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            using (BLLDownLoad bll = new BLLDownLoad())
            {
                DownLoad obj = new DownLoad();

                if (id > 0)
                {
                    obj = bll.GetSingle(id);
                    obj.ID = id;
                }
                obj.DLName = txtDLName.Text.Trim().ToString();
                obj.DLAddTime = Convert.ToDateTime(DateTime.Now.ToShortDateString()) ;
                obj.Remarks = txtRemarks.Text.ToString();
                if (Session["admin"] != null)
                {
                    AdminUser adminuser = GetAdminUser();
                    if (adminuser != null)
                        obj.DLAddName = adminuser.TrueName.ToString();
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


                #region 上传产品图片(前台产品图片来源于此)
                try
                {
                    if (this.UploadDLAddress.HasFile)
                    {
                        string extName = Path.GetExtension(UploadDLAddress.FileName);
                        string virFileFullName;
                        string fileName;
                        WebCommon.GetUploadRandFileName(extName, out virFileFullName, out fileName);
                        if (UploadDLAddress.PostedFile.ContentLength < 5000000)//文件小于5M
                        {
                            UploadDLAddress.SaveAs(StringPlus.MapPath(virFileFullName));
                        }
                        else
                        {
                            ShowMsg("文件大小不能超过5M！");
                            return;
                        }
                        if (IsAllowedExtension(StringPlus.MapPath(virFileFullName)))
                        {
                            if (id > 0)
                            {//新增时无需删除
                                if (File.Exists(StringPlus.MapPath(bll.GetSingle(id).DLAddress)))
                                {
                                    File.Delete(StringPlus.MapPath(bll.GetSingle(id).DLAddress));
                                }
                            }
                            obj.DLAddress = virFileFullName;
                        }
                        else
                        {
                            if (File.Exists(StringPlus.MapPath(virFileFullName)))
                            {
                                File.Delete(StringPlus.MapPath(virFileFullName));
                            }
                            ShowMsg("此文件类型不可以上传");
                            return;
                        }
                    }
                    else
                    {
                        obj.DLAddress = lblDLAddress.Text;
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
                    JSMsg.ShowWinRedirect(this, "保存成功", "cpDownLoadList.aspx");
                }
            }
        }


        /// <summary>
        /// 获取上传文件类型,非图片类型return False
        /// 有的时候需要检测上传文件的真实类型，才能准确的判断用户上传的文件是否真的是需要过滤的文件类型
        /// 大多数情况下我们都是用 Path.GetExtension(file.FileName)
        /// 获取文件的扩展名，然后进行判断文件是否是我们需要过滤的文件，但是这种方法只能得到表面上的扩展名，如果一些恶作剧的用户故意把text的文件更改为 jpg
        /// 那么Path.GetExtension(file.FileName) 获取到的文件类型就是 jpg 而不是text
        /// 用上面的方法会得到文件的真实类型
        /// </summary>
        /// <param name="hifile"></param>
        /// <returns></returns>
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
            String[] fileType = { "255216", "7173", "6677", "13780", "239187", "208207", "6063", "6033", "4742", "8075", "8297","115115","100100"};
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