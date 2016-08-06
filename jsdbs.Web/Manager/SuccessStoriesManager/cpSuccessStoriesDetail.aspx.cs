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
using System.IO;
using System.Drawing;

namespace jsbestop.Web.Manager.SuccessStoriesManager
{
    public partial class cpSuccessStoriesDetail : AdminPageBase
    {
        private int id = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            id = GetRequestQuery<int>("id", 0, Convert.ToInt32);
            if (!IsPostBack)
            {
                imgHeight.Text = getXmlString("projectConfig", "thumbHight");
                imgWidth.Text = getXmlString("projectConfig", "thumbWidth");
                setInfo();
                getProtypeList();
            }
        }

        private void getProtypeList()
        {
            SearchSuccessStoriesType search = new SearchSuccessStoriesType();
            using (BLLSuccessStoriesType bll = new BLLSuccessStoriesType())
            {
                DataTable dt = bll.GetTable(search);//ScriptQuery.SortEnum.DESC
                if (dt != null)
                {
                    ddlSuccessStoriesType.DataSource = dt;
                    ddlSuccessStoriesType.DataTextField = SuccessStoriesType.SSTypeName_FieldName;
                    ddlSuccessStoriesType.DataValueField = SuccessStoriesType.ID_FieldName;
                    ddlSuccessStoriesType.DataBind();
                }
            }
        }

        private void setInfo()
        {
            if (id > 0)
            {
                using (BLLSuccessStories bll = new BLLSuccessStories())
                {
                    SuccessStories cpinfor = bll.GetSingle(id);
                    if (cpinfor != null)
                    {
                        ddlSuccessStoriesType.SelectedValue = cpinfor.SSType.ToString();
                        txtNewsTitle.Text = cpinfor.SSName;
                        txtContent.Value = cpinfor.SSContent;
                        txtRemarks.Text = cpinfor.Remarks;
                        Image1.ImageUrl = cpinfor.SSPic.ToString();
                        txtAutoSort.Text = cpinfor.AutoSort.ToString();
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
            string prourlname = "";
            using (BLLSuccessStories bll = new BLLSuccessStories())
            {
                SuccessStories obj = new SuccessStories();
                if (id > 0)
                {
                    obj = bll.GetSingle(id);
                }
                obj.SSType = Convert.ToInt32(ddlSuccessStoriesType.SelectedValue);
                obj.SSName = txtNewsTitle.Text.ToString();
                obj.SSContent = txtContent.Value;
                obj.Remarks = txtRemarks.Text.ToString();
                obj.AutoSort = Convert.ToInt32(txtAutoSort.Text.Trim().ToString() == "" ? "0" : txtAutoSort.Text.Trim().ToString());
                obj.AddTime = Convert.ToDateTime(System.DateTime.Now.ToShortDateString());
                try
                {
                    if (this.UploadImg.HasFile)
                    {
                        string extName = Path.GetExtension(UploadImg.FileName);
                        string virFileFullName;
                        string fileName;
                        WebCommon.GetUploadRandFileName(extName, out virFileFullName, out fileName);
                        UploadImg.SaveAs(StringPlus.MapPath(virFileFullName));
                        int ind = fileName.IndexOf(".");
                        string ofileName = fileName.Substring(0, ind);
                        prourlname = extName;
                        UploadImg.SaveAs(StringPlus.MapPath(virFileFullName));
                        HttpFileCollection files = Request.Files;
                        string path = Server.MapPath("../../Upload");
                        HttpPostedFile file = files[0];
                        if (file != null && file.ContentLength > 0)
                        {
                            if (rbthasPhone.Checked == true)
                            {
                                //string filename = this.UpLoadImage(file, path + "/", Convert.ToInt32(ConfigHelper.GetAppString("CompressionWidth").Trim()), Convert.ToInt32(ConfigHelper.GetAppString("CompressionHeight").Trim()), ofileName);
                                string filename = this.UpLoadImage(file, path + "/", Convert.ToInt32(imgWidth.Text.ToString()), Convert.ToInt32(imgHeight.Text.ToString()), ofileName);
                            }
                        }
                        if (IsAllowedExtension(StringPlus.MapPath(virFileFullName)))
                        {
                            if (id > 0)
                            {//新增时无需删除
                                if (File.Exists(StringPlus.MapPath(bll.GetSingle(id).SSPic)))
                                {
                                    File.Delete(StringPlus.MapPath(bll.GetSingle(id).SSPic));
                                }
                            }
                            obj.SSPic = virFileFullName;
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
                        obj.SSPic = Image1.ImageUrl.ToString();
                    }
                }
                catch (DevNetException ex)
                {
                    ExceptionManager.ShowErrorMsg(this, ex);
                    return;
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
                    JSMsg.ShowWinRedirect(this, "保存成功", "cpSuccessStoriesList.aspx");
                }

            }
        }
        /// </summary>
        /// <param name="upImage">HtmlInputFile控件</param>
        /// <param name="sSavePath">保存的路径,些为相对服务器路径的下的文件夹</param>
        /// <param name="sThumbExtension">缩略图的thumb</param>
        /// <param name="intThumbWidth">生成缩略图的宽度</param>
        /// <param name="intThumbHeight">生成缩略图的高度</param>
        /// <returns>缩略图名称</returns>
        public string UpLoadImage(HttpPostedFile myFile, string sSavePath, int intThumbWidth, int intThumbHeight, string ofileName)
        {

            string sFilename = "";
            if (myFile != null && myFile.ContentLength > 0)
            {
                // HttpPostedFile myFile = upImage.PostedFile;
                int nFileLen = myFile.ContentLength;
                // if (nFileLen == 0)
                //    return "没有选择上传图片";            
                //获取upImage选择文件的扩展名
                string extendName = System.IO.Path.GetExtension(myFile.FileName).ToLower();
                //判断是否为图片格式
                if (extendName != ".jpg" && extendName != ".jpge" && extendName != ".gif" && extendName != ".bmp" && extendName != ".png")
                    return "false";

                byte[] myData = new Byte[nFileLen];
                myFile.InputStream.Read(myData, 0, nFileLen);
                //保存文件名

                sFilename = ofileName + extendName;// System.IO.Path.GetFileName(myFile.FileName);
                string datetime = DateTime.Now.ToString("yyyy-MM");
                if (!System.IO.Directory.Exists(sSavePath + datetime + "/"))
                {
                    System.IO.Directory.CreateDirectory(sSavePath + datetime + "/");
                }
                int file_append = 0;
                //检查当前文件夹下是否有同名图片,有则在文件名+1

                while (System.IO.File.Exists(sSavePath + datetime + "/" + sFilename))
                {
                    File.Delete(StringPlus.MapPath(sSavePath + datetime + "/" + sFilename));
                    //file_append++;
                    //sFilename = System.IO.Path.GetFileNameWithoutExtension(sFilename)
                    //    + file_append.ToString() + extendName;
                }
                System.IO.FileStream newFile
                    = new System.IO.FileStream((sSavePath + datetime + "/" + sFilename),
                    System.IO.FileMode.Create, System.IO.FileAccess.Write);
                newFile.Write(myData, 0, myData.Length);
                newFile.Close();
                //以上为上传原图
                try
                {
                    //原图加载
                    using (System.Drawing.Image sourceImage = System.Drawing.Image.FromFile(sSavePath + datetime + "/" + sFilename))
                    {
                        //原图宽度和高度
                        int width = sourceImage.Width;
                        int height = sourceImage.Height;
                        int smallWidth;
                        int smallHeight;
                        //获取第一张绘制图的大小,(比较 原图的宽/缩略图的宽  和 原图的高/缩略图的高)
                        if (((decimal)width) / height <= ((decimal)intThumbWidth) / intThumbHeight)
                        {
                            smallWidth = intThumbWidth;
                            smallHeight = intThumbWidth * height / width;
                        }
                        else
                        {
                            smallWidth = intThumbHeight * width / height;
                            smallHeight = intThumbHeight;
                        }
                        //判断缩略图在当前文件夹下是否同名称文件存在
                        file_append = 0;

                        // sThumbFile =myFile.FileName ;
                        sFilename = "s_" + sFilename;
                        if (!System.IO.Directory.Exists(sSavePath + datetime + "/"))
                        {
                            System.IO.Directory.CreateDirectory(sSavePath + datetime + "/");
                        }
                        while (System.IO.File.Exists(sSavePath + datetime + "/" + sFilename))
                        {
                            file_append++;
                            sFilename = System.IO.Path.GetFileNameWithoutExtension(sFilename) +
                                file_append.ToString() + extendName;
                        }
                        //缩略图保存的绝对路径
                        string smallImagePath = sSavePath + datetime + "/" + sFilename;
                        //新建一个图板,以最小等比例压缩大小绘制原图
                        using (System.Drawing.Image bitmap = new System.Drawing.Bitmap(smallWidth, smallHeight))
                        {
                            //绘制中间图
                            using (System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(bitmap))
                            {
                                //高清,平滑
                                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
                                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                                g.Clear(Color.Black);
                                g.DrawImage(
                                sourceImage,
                                new System.Drawing.Rectangle(0, 0, smallWidth, smallHeight),
                                new System.Drawing.Rectangle(0, 0, width, height),
                                System.Drawing.GraphicsUnit.Pixel
                                );
                            }
                            //新建一个图板,以缩略图大小绘制中间图
                            using (System.Drawing.Image bitmap1 = new System.Drawing.Bitmap(intThumbWidth, intThumbHeight))
                            {
                                //绘制缩略图  http://www.cnblogs.com/sosoft/ 

                                using (System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(bitmap1))
                                {
                                    //高清,平滑
                                    g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
                                    g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                                    g.Clear(Color.Black);
                                    int lwidth = (smallWidth - intThumbWidth) / 2;
                                    int bheight = (smallHeight - intThumbHeight) / 2;
                                    g.DrawImage(bitmap, new Rectangle(0, 0, intThumbWidth, intThumbHeight), lwidth, bheight, intThumbWidth, intThumbHeight, GraphicsUnit.Pixel);
                                    g.Dispose();
                                    bitmap1.Save(smallImagePath, System.Drawing.Imaging.ImageFormat.Jpeg);
                                }
                            }
                        }
                    }
                }
                catch
                {
                    //出错则删除
                    System.IO.File.Delete((sSavePath + sFilename));
                    return "false";
                }
                //返回缩略图名称
                return sFilename;
            }
            return "false";
        }
    }
}