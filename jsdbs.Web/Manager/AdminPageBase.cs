using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using Common;
using jsbestop.Entity;
using jsbestop.BLL;
using jsbestop.Entity.Search;
using System.Data;
using System.Xml;
using System.Web;

namespace jsbestop.Web.Manager
{
    public class AdminPageBase : PageBase
    {
        protected override void OnInit(EventArgs e)
        {
            if (Session["admin"] == null)
            {
                RedirectLogin();
            }
            this.Title = PageTitle + "-后台管理中心";
            base.OnInit(e);
        }

        private void RedirectLogin()
        {
            Response.Write("<script type='text/javascript'>top.location.href='" + ResolveClientUrl("~/Manager/login.aspx") + "';</script>");
            Response.End();
        }

        protected AdminUser GetAdminUser()
        {
            AdminUser admin = Session["admin"] as AdminUser;
            if (admin == null)
            {
                RedirectLogin();
            }
            return admin;
        }
        /// <summary>
        /// 获取各个模块缩略的图的长度和宽度
        /// </summary>
        /// <param name="xmlNode"></param>
        /// <param name="TagName"></param>
        /// <returns></returns>
        protected string getXmlString(string xmlNode, string TagName)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(HttpContext.Current.Server.MapPath("/thumbConfig.xml"));
            XmlElement rootElem = doc.DocumentElement;
            XmlNodeList personNodes = rootElem.GetElementsByTagName(xmlNode);
            foreach (XmlNode node in personNodes)
            {
                XmlNodeList subNodes = ((XmlElement)node).GetElementsByTagName(TagName);  //
                if (subNodes.Count == 1)
                {
                    string  Config = subNodes[0].InnerText;
                    return  Config;
                }
            }
            return "";
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
        protected bool IsAllowedExtension(string imgPath)
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
        protected  static string phoneImgUrl(string ourl)
        {
            int ind = ourl.LastIndexOf('/');
            //int i = ourl.Length - ind - 1;
            return ourl.Substring(0, ind + 1) + "s_" + ourl.Substring(ind + 1, ourl.Length - ind - 1);
        }
        /// <summary>
        /// 获取公司信息类别名称
        /// </summary>
        protected string GetProInforTypeName(int proinfotype)
        {
            using (BLLCompanyInformationType bll = new BLLCompanyInformationType())
            {
                CompanyInformationType obj = new CompanyInformationType();
                if (proinfotype > 0)
                {
                    obj = bll.GetSingle(proinfotype);
                    if (obj != null)
                    {
                        return obj.CompanyInformationName.ToString();
                    }
                }
                return "";
            }
        }
        /// <summary>
        /// 获取新闻类别名称
        /// </summary>
        protected string GetNewsTypeName(int proinfotype)
        {
            using (BLLNewsType bll = new BLLNewsType())
            {
                NewsType obj = new NewsType();
                if (proinfotype > 0)
                {
                    obj = bll.GetSingle(proinfotype);
                    if (obj != null)
                    {
                        return obj.NewsTypeName.ToString();
                    }
                }
                return "";
            }
        }
        /// <summary>
        /// 获取Banner类别名称
        /// </summary>
        protected string GetBannerTypeName(int proinfotype)
        {
            using (BLLComBannerType bll = new BLLComBannerType())
            {
                ComBannerType obj = new ComBannerType();
                if (proinfotype > 0)
                {
                    obj = bll.GetSingle(proinfotype);
                    if (obj != null)
                    {
                        return obj.ComBannerTypeName.ToString();
                    }
                }
                return "";
            }
        }
        /// <summary>
        /// 获取职位类别名称
        /// </summary>
        protected string GetJobTypeName(int proinfotype)
        {
            using (BLLJobType bll = new BLLJobType())
            {
                JobType obj = new JobType();
                if (proinfotype > 0)
                {
                    obj = bll.GetSingle(proinfotype);
                    if (obj != null)
                    {
                        return obj.JobTypeName.ToString();
                    }
                }
                return "";
            }
        }

        /// <summary>
        /// 获取成功案例类别名称
        /// </summary>
        protected string GetSuccessStoriesTypeName(int proinfotype)
        {
            using (BLLSuccessStoriesType bll = new BLLSuccessStoriesType())
            {
                SuccessStoriesType obj = new SuccessStoriesType();
                if (proinfotype > 0)
                {
                    obj = bll.GetSingle(proinfotype);
                    if (obj != null)
                    {
                        return obj.SSTypeName.ToString();
                    }
                }
                return "";
            }
        }
        /// <summary>
        /// 获取产品大类名称
        /// </summary>
        protected string GetProductTypeName(int proinfotype)
        {
            using (BLLProductType bll = new BLLProductType())
            {
                ProductType obj = new ProductType();
                if (proinfotype > 0)
                {
                    obj = bll.GetSingle(proinfotype);
                    if (obj != null)
                    {
                        return obj.ProductTypeName.ToString();
                    }
                }
                return "";
            }
        }
        /// <summary>
        /// 获取产品小类名称
        /// </summary>
        protected string GetProductSecondTypeName(int proinfotype)
        {
            using (BLLProductSecondType bll = new BLLProductSecondType())
            {
                ProductSecondType obj = new ProductSecondType();
                if (proinfotype > 0)
                {
                    obj = bll.GetSingle(proinfotype);
                    if (obj != null)
                    {
                        return obj.ProductSecondTypeName.ToString();
                    }
                }
                return "";
            }
        }
        /// <summary>
        /// 判断是否有二级分类
        /// true 是有 false 是无
        /// </summary>
        protected bool IsHaveSecondType(int protype)
        {
            using (BLLProductType bll = new BLLProductType())
            {
                ProductType obj = new ProductType();
                obj = bll.GetSingle(protype);
                if (obj != null)
                {
                    if (obj.IsHaveSecondTpye == 1)
                    {
                        return true;
                    }
                }
            }
            using (BLLProductSecondType bll = new BLLProductSecondType())
            {
                SearchProductSecondType con = new SearchProductSecondType();
                con.ProductTypeID = protype;
                List<ProductSecondType> lists = bll.GetList(con);
                if (lists.Count > 0)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
