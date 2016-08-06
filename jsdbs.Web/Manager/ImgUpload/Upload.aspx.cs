using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Drawing;
using jsbestop.BLL;
using jsbestop.Entity;
using Cnkj.Utility;
using Common;

public partial class Upload : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
	{
        //接受产品ID
        int id = 0;
        Int32.TryParse(HttpContext.Current.Request.QueryString["id"], out id); //  .ToInt32(HttpContext.Current.Request.QueryString["id"]);
        if (!Page.IsPostBack)
        {
            if (id != 0)
            {
                HttpFileCollection files = Request.Files;

                if (files.Count == 0)
                {
                    Response.Write("未检测到客户端提交的文件信息！");
                    Response.End();
                }

                // 服务器端存储文件的文件夹（磁盘路径）
                string path = Server.MapPath("../../Upload");
                // 只取第 1 个文件，因为客户端的flash会循环提交
                HttpPostedFile file = files[0];

                if (file != null && file.ContentLength > 0)
                {
                    // flash 会自动发送文件名到 Request.Form["fileName"] ，当然了你可以使用Guid给命名文件命名，防止覆盖掉重名文件
                    //file.SaveAs(savePath);
                    //上传缩略图
                    //
                    string filename = this.UpLoadImage(file, path + "/", 118, 118);
                    if (filename != "false")
                    {
                        //数据入库
                        ImgIN("../../Upload/", filename, id);

                    }
                    //////////////////////////////////////////////////////////////////////
                    // 在这里你可以做关于数据库的其他操作，例如将文件信息保存到数据库
                    //////////////////////////////////////////////////////////////////////
                }
            }
        }
    }
    /// <summary>
    ///  图片路径保存
    /// </summary>
    /// <param name="imgpath">图片路径</param>这个方法没有问题
    /// <param name="id"></param>
    public void ImgIN(string imgbasepath, string filename, int id)
    {

        using (BLLProductPicture bll = new BLLProductPicture())
        {
            ProductPicture obj = new ProductPicture();

            obj.ProDetailID=id;
            obj.ProPicAddress = imgbasepath + DateTime.Now.ToString("yyyy-MM-dd") + "/" + filename;
            obj.ProPicSmallAddress=imgbasepath + "thumb/"+DateTime.Now.ToString("yyyy-MM-dd") + "/"+ filename; //缩略图路径
            obj.Remarks = "备注";
            bll.Save(obj);

            if (bll.IsFail)
            {
                ExceptionManager.ShowErrorMsg(this, bll.DevNetException);
            }
            else
            {
              //  JSMsg.ShowWinRedirect(this, "保存成功", "cpNewsList.aspx");
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
        public string UpLoadImage(HttpPostedFile myFile, string sSavePath,  int intThumbWidth, int intThumbHeight)
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

                 sFilename = DateTime.Now.ToString("yyyyMMddHHmmssffff")+extendName;// System.IO.Path.GetFileName(myFile.FileName);
                 
                 string datetime = DateTime.Now.ToString("yyyy-MM-dd");
                 if (!System.IO.Directory.Exists(sSavePath + datetime+"/"))
                 {
                     System.IO.Directory.CreateDirectory(sSavePath + datetime + "/");
                 }

                 int file_append = 0;
                 //检查当前文件夹下是否有同名图片,有则在文件名+1
                 while (System.IO.File.Exists(sSavePath + datetime + "/" + sFilename))
                 {
                     file_append++;
                     sFilename = System.IO.Path.GetFileNameWithoutExtension(sFilename)
                         + file_append.ToString() + extendName;
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

                         if (!System.IO.Directory.Exists(sSavePath + "thumb/" + datetime + "/"))
                         {
                             System.IO.Directory.CreateDirectory(sSavePath + "thumb/" + datetime + "/");
                         }
                         while (System.IO.File.Exists(sSavePath + "thumb/" + datetime + "/" + sFilename))
                         {
                             file_append++;
                             sFilename = System.IO.Path.GetFileNameWithoutExtension(sFilename) +
                                 file_append.ToString() + extendName;
                         }
                         //缩略图保存的绝对路径
                         string smallImagePath = sSavePath + "thumb/" + datetime + "/" + sFilename;
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
