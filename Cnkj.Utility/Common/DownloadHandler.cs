using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Web;
namespace Common
{
    public class DownloadHandler : IHttpHandler
    {
        public DownloadHandler()
        {

        }
        public bool IsReusable
        {
            get { return true; }
        }

        #region IHttpHandler 成员

        /// <summary>
        /// 处理请求的方法
        /// </summary>
        /// <param name="context">他提供对于为HTTP请求提供服务的内部服务器对象(如 Request Response Session Server和Server)</param>
        public void ProcessRequest(HttpContext context)
        {
            try
            {
                Uri referrerUri = context.Request.UrlReferrer;//获取下载之前访问的那个页面的Uri
                Uri currentUri = context.Request.Url;
                string requestFile =context.Request.PhysicalPath;
                if (referrerUri == null)//没有签到页面,直接访问下载页
                {
                    context.Response.Write("请不要盗链本站资源,请从首页访问。");//<a href='www.cjtax.cn'>首页</a>
                    return;
                }
                #region 判断前导页面是否是我们程序里面的页面(可以改变) 可以加session进行双重判断更为保险！
                string referrerPage = referrerUri.LocalPath.Substring(referrerUri.LocalPath.LastIndexOf('/') + 1);
                if (referrerPage == "NewsDetail.aspx" || referrerPage == "epDownList.aspx")//可以动态设置
                {
                    WriteFile(requestFile, context);
                }
                else
                {
                    context.Response.Write("请不要盗链本站资源,请从首页访问。");//<a href='www.cjtax.cn'>首页</a>
                    return;
                }
            }
            catch (System.Exception ex)
            {
                context.Response.Write("请不要盗链本站资源,请从首页访问。");//<a href='www.cjtax.cn'>首页</a>
                return;
            }
                #endregion
        }

        /// <summary>   
        /// 对字符串中的非 ASCII 字符进行编码   
        /// </summary>   
        /// <param name="s"></param>   
        /// <returns></returns>   
        public static string ToHexString(string s)
        {
            char[] chars = s.ToCharArray();
            StringBuilder builder = new StringBuilder();
            for (int index = 0; index < chars.Length; index++)
            {
                bool needToEncode = NeedToEncode(chars[index]);
                if (needToEncode)
                {
                    string encodedString = ToHexString(chars[index]);
                    builder.Append(encodedString);
                }
                else
                {
                    builder.Append(chars[index]);
                }
            }
            return builder.ToString();
        }   

        /// <summary>   
        /// 判断字符是否需要使用特殊的 ToHexString 的编码方式   
        /// </summary>   
        /// <param name="chr"></param>   
        /// <returns></returns>   
        private static bool NeedToEncode(char chr)   
        {   
            string reservedChars = "$-_.+!*'(),@=&";   
          
            if (chr > 127)   
               return true;   
            if (char.IsLetterOrDigit(chr) || reservedChars.IndexOf(chr) >= 0)   
               return false;   
          
            return true;   
        }   
          
        /// <summary>   
        /// 为非 ASCII 字符编码   
        /// </summary>   
        /// <param name="chr"></param>   
        /// <returns></returns>   
        private static string ToHexString(char chr)   
        {   
            UTF8Encoding utf8 = new UTF8Encoding();   
            byte[] encodedBytes = utf8.GetBytes(chr.ToString());   
            StringBuilder builder = new StringBuilder();   
            for (int index = 0; index < encodedBytes.Length; index++)   
           {   
               builder.AppendFormat("%{0}", Convert.ToString(encodedBytes[index], 16));   
           }   
          return builder.ToString();   
        }  
 

        /// <summary>
        /// 向客户端输出文件
        /// </summary>
        /// <param name="filePath">文件的完整物理路径</param>
        /// <param name="context">服务器响应的实例</param>
        protected void WriteFile(string filePath, HttpContext context)
        {
            try
            {
                string extension = Path.GetExtension(filePath).ToLower();
                string path = context.Request.PhysicalPath;
                context.Response.Clear();
                context.Response.ContentType = GetMimeType(extension);
                string fileName = Path.GetFileName(path);

                context.Response.AddHeader("Content-Disposition", "attachment;filename=" + ToHexString(fileName));
                context.Response.WriteFile(path);
            }
            catch (System.Exception ex)
            {
                context.Response.Write("请不要盗链本站资源,请从首页访问。");//<a href='www.cjtax.cn'>首页</a>
                return;
            }
        }

        public static string GetMimeType(string extension)
        {
            string mime = string.Empty;
            extension = extension.ToLower();
            switch (extension)
            {
                case ".doc":
                    mime = "application/msword";
                    break;
                case ".xls":
                    mime = "application/vnd.ms-excel";
                    break;
                case ".docx":
                    mime = "application/vnd.openxmlformats-officedocument.wordprocessingml.document ";
                    break;
                case ".xlsx":
                    mime = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet ";
                    break;
                case ".pdf":
                    mime = "application/pdf";
                    break;
                case ".pptx":
                    mime = "application/vnd.openxmlformats-officedocument.presentationml.presentation ";
                    break;
                case ".rar":
                    mime = "application/octet-stream ";
                    break;
                case ".ppt":
                    mime = "application/x-ppt";
                    break;
                default:
                    break;
            }
            return mime;
        }
        #endregion
    }
}
