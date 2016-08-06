using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using jsbestop.Entity;
using jsbestop.BLL;
using Cnkj.Utility;
using Common;
using jsbestop.Entity.Search;
using System.Data;
using System.IO;
using DevNet.Common;
using System.Drawing;

namespace jsbestop.Web.Manager.ProductManager
{
    public partial class cpProductDetail : AdminPageBase
    {
        private int id = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            id = GetRequestQuery<int>("id", 0, Convert.ToInt32);
            if (!IsPostBack)
            {
                getProtypeList();
                bindinfo();
                imgHeight.Text = getXmlString("productConfig", "thumbHight");
                imgWidth.Text = getXmlString("productConfig", "thumbWidth");
                imgHeight.ReadOnly = true;
                imgWidth.ReadOnly = true;
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
                    ddlProType.DataSource = dt;
                    ddlProType.DataTextField = ProductType.ProductTypeName_FieldName;
                    ddlProType.DataValueField = ProductType.ID_FieldName;
                    ddlProType.DataBind();
                    ddlProType.Items.Insert(0, new ListItem("==请选择类型==", "0"));

                }
            }
        }

        protected void ProductType_Change(object sender, EventArgs e)
        {
            if (ddlProType.SelectedValue == "")
            {
                return;
            }
            if (IsHaveSecondType(Convert.ToInt32(ddlProType.SelectedValue)))
            {
                ddlProSecondType.Visible = true;
                SearchProductSecondType search = new SearchProductSecondType();
                search.ProductTypeID = Convert.ToInt32(ddlProType.SelectedValue);
                using (BLLProductSecondType bll = new BLLProductSecondType())
                {
                    DataTable dt = bll.GetTable(search);
                    if (dt != null)
                    {
                        ddlProSecondType.DataSource = dt;
                        ddlProSecondType.DataTextField = ProductSecondType.ProductSecondTypeName_FieldName;
                        ddlProSecondType.DataValueField = ProductSecondType.ID_FieldName;
                        ddlProSecondType.DataBind();
                        ddlProSecondType.Items.Insert(0, new ListItem("==请选择类型==", "0"));
                    }
                }
            }
        }

        private void bindinfo()
        {
            if (ddlProType.SelectedValue == "")
            {
                return;
            }
            if (IsHaveSecondType(Convert.ToInt32(ddlProType.SelectedValue)))
            {
                ddlProSecondType.Visible = true;
                SearchProductSecondType search = new SearchProductSecondType();
                search.ProductTypeID = Convert.ToInt32(ddlProType.SelectedValue);
                using (BLLProductSecondType bll = new BLLProductSecondType())
                {
                    DataTable dt = bll.GetTable(search);
                    if (dt != null)
                    {
                        ddlProSecondType.DataSource = dt;
                        ddlProSecondType.DataTextField = ProductSecondType.ProductSecondTypeName_FieldName;
                        ddlProSecondType.DataValueField = ProductSecondType.ID_FieldName;
                        ddlProSecondType.DataBind();
                        ddlProSecondType.Items.Insert(0, new ListItem("==请选择类型==", "0"));
                    }
                }
            }
            if (id > 0)
            {
                using (BLLProductDetail bll = new BLLProductDetail())
                {
                    ProductDetail obj = bll.GetSingle(id);
                    if (obj != null)
                    {
                        if (obj.IsEnglish == 1)
                        {
                            rbtnIsChinese.Checked = true;
                        }
                        else if (obj.IsEnglish == 2)
                        {
                            rbtnIsEnglish.Checked = true;
                        }
                        txtProName.Text = obj.ProductName;
                        //txtProEngName.Text = obj.ProductEngName;
                        ddlProType.SelectedValue = obj.ProTypeID.ToString();
                        if (IsHaveSecondType(obj.ProTypeID))
                        {
                            ddlProSecondType.SelectedValue = obj.ProSecondTypeID.ToString();
                            ddlProSecondType.Visible = true;
                        }
                        else
                        {
                            ddlProSecondType.Visible = false;
                        }
                        txtContent.Value = obj.ProductContent;
                        txtAutoSort.Text = obj.AutoSort.ToString();
                        txtRemarks.Text = obj.Remarks;
                        Image1.ImageUrl = obj.ProductPic.ToString();
                    }
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            using (BLLProductDetail bll = new BLLProductDetail())
            {
                string prourlname = "";
                ProductDetail obj = new ProductDetail();
                if (id > 0)
                {
                    obj = bll.GetSingle(id);
                    obj.ID = id;
                }
                else
                {
                    obj.IsFlag = 0;
                }
                obj.ProductName = txtProName.Text.ToString();
                //obj.ProductEngName = txtProEngName.Text.ToString();
                obj.ProTypeID = Convert.ToInt32(ddlProType.SelectedValue);
                if (ddlProType.SelectedValue == null || ddlProType.SelectedValue == "0")
                {
                    return;
                }
                if (IsHaveSecondType(Convert.ToInt32(ddlProType.SelectedValue)))
                {
                    obj.ProSecondTypeID = Convert.ToInt32(ddlProSecondType.SelectedValue);
                }
                obj.ProductContent = txtContent.Value;
                obj.AutoSort = Convert.ToInt32(txtAutoSort.Text.Trim().ToString() == "" ? "0" : txtAutoSort.Text.Trim().ToString());
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
                        #region Add Begin
                        int ind = fileName.IndexOf(".");
                        string ofileName = fileName.Substring(0, ind);
                        prourlname = extName;
                        #endregion
                        UploadImg.SaveAs(StringPlus.MapPath(virFileFullName));
                        #region Add Begin
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
                        #endregion
                        if (IsAllowedExtension(StringPlus.MapPath(virFileFullName)))
                        {
                            if (id > 0)
                            {//新增时无需删除
                                string filename = bll.GetSingle(id).ProductPic;
                                if (File.Exists(StringPlus.MapPath(bll.GetSingle(id).ProductPic)))
                                {
                                    File.Delete(StringPlus.MapPath(bll.GetSingle(id).ProductPic));
                                }
                                if (File.Exists(StringPlus.MapPath(bll.GetSingle(id).ProductPic)))
                                {
                                    File.Delete(StringPlus.MapPath(bll.GetSingle(id).ProductPic));
                                }
                            }
                            obj.ProductPic = virFileFullName;

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
                        obj.ProductPic = Image1.ImageUrl.ToString();
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
                bll.Save(obj);
                if (bll.IsFail)
                {
                    ExceptionManager.ShowErrorMsg(this, bll.DevNetException);
                }
                else
                {
                    JSMsg.ShowWinRedirect(this, "保存成功", "cpProductList.aspx");
                }


            }
        }
        /// asp.net上传图片并生成缩略图
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