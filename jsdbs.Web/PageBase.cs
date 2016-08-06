using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using Cnkj.Utility;
using Common;
using jsbestop.Entity.Search;
using jsbestop.BLL;
using jsbestop.Entity;
using System.Text.RegularExpressions;

namespace jsbestop.Web
{
	public class PageBase:WebPageBase
	{		
		/// <summary>
		/// 设置编辑器的内容
		/// </summary>
		/// <param name="editerString"></param>
		protected void SetEditContent(string editerString)
		{
			//string tmp = StringPlus.JSStringFormat(editerString, true);
			JSMsg.RegisterJS(this, "setInfo('" +StringPlus.JSStringFormat(editerString,true) + "');", true);
		}

		/// <summary>
		/// 显示消息，设置编辑器内容
		/// </summary>
		/// <param name="msg"></param>
		/// <param name="editerString"></param>
		protected void ShowMsgSetContent(string msg,string editerString)
		{
			JSMsg.RegisterJS(this, "alert('" + msg + "');setInfo(\"" +StringPlus.JSStringFormat(editerString,true) + "\");", true);
		}
        public string phoneImgUrl(string ourl)
        {
            int ind = ourl.LastIndexOf('/');
            //int i = ourl.Length - ind - 1;
            return ourl.Substring(0, ind + 1) + "s_" + ourl.Substring(ind + 1, ourl.Length - ind - 1);
        }
        /// <summary>
        /// 获取指定字节长度的字符串，超过长度末尾加“...”
        /// </summary>
        /// <param name="inputStr"></param>
        /// <param name="byteLength"></param>
        /// <returns></returns>
        protected static string GetStrByLength(string inputStr, int byteLength)
        {
            return StringPlus.GetStrByByteLength(inputStr, byteLength, true);
        }
        /// <summary>
        /// 去样式截取字符串长度
        /// </summary>
        /// <param name="Htmlstring"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public string DelHTML(string Htmlstring, int length)//将HTML去除
        {
            #region
            //删除脚本
            Htmlstring = System.Text.RegularExpressions.Regex.Replace(Htmlstring, @"<script[^>]*?>.*?</script>", "", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            //删除HTML
            Regex regex = new Regex(@"\<[^img](.*?)\>", RegexOptions.IgnoreCase);
            Htmlstring = regex.Replace(Htmlstring, "");
            Htmlstring = System.Text.RegularExpressions.Regex.Replace(Htmlstring, @"<(.[^>]*)>", "", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            Htmlstring = System.Text.RegularExpressions.Regex.Replace(Htmlstring, @"([\r\n])[\s]+", "", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            Htmlstring = System.Text.RegularExpressions.Regex.Replace(Htmlstring, @"-->", "", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            Htmlstring = System.Text.RegularExpressions.Regex.Replace(Htmlstring, @"<!--.*", "", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            Htmlstring = System.Text.RegularExpressions.Regex.Replace(Htmlstring, @"<A>.*</A>", "");
            Htmlstring = System.Text.RegularExpressions.Regex.Replace(Htmlstring, @"<[a-zA-Z]*=\.[a-zA-Z]*\?[a-zA-Z]+=\d&\w=%[a-zA-Z]*|[A-Z0-9]", "");
            Htmlstring = System.Text.RegularExpressions.Regex.Replace(Htmlstring, @"&(quot|#34);", "\"", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            Htmlstring = System.Text.RegularExpressions.Regex.Replace(Htmlstring, @"&(amp|#38);", "&", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            Htmlstring = System.Text.RegularExpressions.Regex.Replace(Htmlstring, @"&(lt|#60);", "<", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            Htmlstring = System.Text.RegularExpressions.Regex.Replace(Htmlstring, @"&(gt|#62);", ">", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            Htmlstring = System.Text.RegularExpressions.Regex.Replace(Htmlstring, @"&(nbsp|#160);", " ", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            Htmlstring = System.Text.RegularExpressions.Regex.Replace(Htmlstring, @"&(iexcl|#161);", "\xa1", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            Htmlstring = System.Text.RegularExpressions.Regex.Replace(Htmlstring, @"&(cent|#162);", "\xa2", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            Htmlstring = System.Text.RegularExpressions.Regex.Replace(Htmlstring, @"&(pound|#163);", "\xa3", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            Htmlstring = System.Text.RegularExpressions.Regex.Replace(Htmlstring, @"&(copy|#169);", "\xa9", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            Htmlstring = System.Text.RegularExpressions.Regex.Replace(Htmlstring, @"&#(\d+);", "", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            Htmlstring.Replace("<", "");
            Htmlstring.Replace(">", "");
            Htmlstring.Replace("\r\n", "");
            //Htmlstring=HttpContext.Current.Server.HtmlEncode(Htmlstring).Trim();
            Htmlstring = GetStrByByteLength(Htmlstring, length, true);
            #endregion
            return Htmlstring;
        }
	}
}