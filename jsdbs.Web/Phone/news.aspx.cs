using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using jsbestop.Entity.Search;
using jsbestop.BLL;
using jsbestop.Entity;
using System.Text.RegularExpressions;
using DevNet.Common;
using Common;

namespace jsbestop.Web.Phone
{
    public partial class news : PageBase
    {
        private int type;
        protected void Page_Load(object sender, EventArgs e)
        {
            pager.PageJump += new EventHandler(pager_PageJump);
            type = GetRequestQuery<int>("type", 0, Convert.ToInt32);
            if (!Page.IsPostBack)
            {
                setnews();
                //Page.Title = "新闻中心";
            }
        }
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
        void pager_PageJump(object sender, EventArgs e)
        {
            setnews();
        }
        /// <summary>
        /// 加载新闻
        /// </summary>
        private void setnews()
        {
            SearchNewsDetail snt = new SearchNewsDetail();
            snt.IsEnglish = 1;
            if (type == 0)
            { }
            else
            {
                snt.NewsTypeID = type;
            }
            Pagination pagination = new DevNet.Common.Pagination(pager.PageIndex, pager.PageSize, 0);
            using (BLLNewsDetail bll = new BLLNewsDetail())
            {
                List<NewsDetail> lists = bll.GetPageList(snt, pagination);
                pager.RecordCount = pagination.RecordCount;
                rptNews.DataSource = lists;
                rptNews.DataBind();
            }
        }
        /// <summary>
        /// 按字节长度剪切字符串
        /// </summary>
        /// <param name="str"></param>
        /// <param name="byteLength"></param>
        /// <param name="isDot">是否末尾加  ...</param>
        /// <returns></returns>
        protected string GetStrByByteLength(string str, int byteLength, bool isDot)
        {
            return StringPlus.GetStrByByteLength(str, byteLength, isDot);
        }
    }
}