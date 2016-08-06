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
            this.Title = PageTitle + "-��̨��������";
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
        /// ��ȡ����ģ�����Ե�ͼ�ĳ��ȺͿ��
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
        /// ��ȡ�ϴ��ļ�����,��ͼƬ����return False
        /// �е�ʱ����Ҫ����ϴ��ļ�����ʵ���ͣ�����׼ȷ���ж��û��ϴ����ļ��Ƿ��������Ҫ���˵��ļ�����
        /// �������������Ƕ����� Path.GetExtension(file.FileName)
        /// ��ȡ�ļ�����չ����Ȼ������ж��ļ��Ƿ���������Ҫ���˵��ļ����������ַ���ֻ�ܵõ������ϵ���չ�������һЩ��������û������text���ļ�����Ϊ jpg
        /// ��ôPath.GetExtension(file.FileName) ��ȡ�����ļ����;��� jpg ������text
        /// ������ķ�����õ��ļ�����ʵ����
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
            /*�ļ���չ��˵��
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
             *10056       bt���� 
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
        /// ��ȡ��˾��Ϣ�������
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
        /// ��ȡ�����������
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
        /// ��ȡBanner�������
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
        /// ��ȡְλ�������
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
        /// ��ȡ�ɹ������������
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
        /// ��ȡ��Ʒ��������
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
        /// ��ȡ��ƷС������
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
        /// �ж��Ƿ��ж�������
        /// true ���� false ����
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
