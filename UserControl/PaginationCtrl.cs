using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.Drawing;
using System.ComponentModel;
using System.Web;
using System.Text.RegularExpressions;

namespace Cnkj.UserControl
{
    [ToolboxData("<{0}:PaginationCtrl></{0}:PaginationCtrl>")]
    public class PaginationCtrl : WebControl, INamingContainer, IPostBackDataHandler, IPostBackEventHandler
    {
        public PaginationCtrl() { }

        #region override method
        protected override void LoadViewState(object savedState)
        {
            base.LoadViewState(savedState);
            m_nPageIndex = Convert.ToInt32(ViewState["pageindex"]);
            m_nRecordCount = Convert.ToInt32(ViewState["recordcount"]);
            m_nPageCount = Convert.ToInt32(ViewState["pagecount"]);
            m_nPageSize = Convert.ToInt32(ViewState["pagesize"]);
            m_NumberColor = (Color)ViewState["numbercolor"];
            m_bIsPostModel = Convert.ToBoolean(ViewState["ispostmodel"]);
            m_sTemplateUrl = (string)ViewState["templateurl"];
        	rightCount = Convert.ToInt32(ViewState["rightCount"]);
            m_nIsEnglish = Convert.ToBoolean(ViewState["IsEnglish"]);
        }

        protected override object SaveViewState()
        {
            ViewState["pageindex"] = m_nPageIndex;
            ViewState["recordcount"] = m_nRecordCount;
            ViewState["pagecount"] = m_nPageCount;
            ViewState["pagesize"] = m_nPageSize;
            ViewState["numbercolor"] = m_NumberColor;
            ViewState["ispostmodel"] = m_bIsPostModel;
            ViewState["templateurl"] = m_sTemplateUrl;
            ViewState["IsEnglish"] = m_nIsEnglish;
			ViewState["rightCount"] = rightCount;
            return base.SaveViewState();
        }

        protected override void Render(HtmlTextWriter writer)
        {
            string url = string.Empty;
            ClientScriptManager cs = Page.ClientScript;
            int begin, end;
            if (PageIndex < 6) begin = 1;
            else
            {
                if (PageIndex + 5 >= PageCount)
                {
                    if (PageCount < 10) begin = 1;
                    else begin = PageCount - 9;
                }
                else
                    begin = PageIndex - 4;
            }
            if (PageCount < 10) end = PageCount;
            else end = begin + rightCount;
            string beginRecord = (PageSize * PageIndex - PageSize + 1).ToString();
            string endRecord = (PageSize * PageIndex).ToString();
            if (PageIndex == PageCount) endRecord = RecordCount.ToString();
            if (IsSpecial)
            {
                writer.Write("<div class=\"page\"><div class=\"row\"><ul class=\"page\">");
                if (IsPostModel)
                {
                    if (PageIndex > 1)
                    {
                        writer.Write("<li><a href=\"javascript:" + cs.GetPostBackEventReference(this, Convert.ToString(PageIndex - 1)) + "\"><</a></li>");
                    }
                    else
                    {
                        writer.Write("<li><a><</a></li>");
                    }
                    for (int i = begin; i < end + 1; i++)
                    {
                        if (i != PageIndex)
                        {
                            writer.Write("<li><a href=\"javascript:" + cs.GetPostBackEventReference(this, i.ToString()) + "\" >" + i + "</a></li>");
                        }
                        else
                        {

                            writer.Write("<li class=\"select\"><a href=\"javascript:" + cs.GetPostBackEventReference(this, i.ToString()) + "\" >" + i + "</a></li>");
                        }
                    }
                    if (PageIndex < PageCount)
                    {
                        writer.Write("<li><a href=\"javascript:" + cs.GetPostBackEventReference(this, Convert.ToString(PageIndex + 1)) + "\">></a></li>");
                    }
                    else
                    {
                        writer.Write("<li><a>></a></li>");
                    }

                }

                writer.Write("</ul></div></div>");
            }
            else
            {
                if (IsEnglish)
                {
                    writer.Write("<div style=\"width:100%;height:25px; line-height:25px;\"><div style=\"float:left; padding-left:10px;\">");
                    writer.Write(string.Format("<span style=\"font-weight:normal \">Total</span><span style=\"color:" + m_NumberColor.Name + "\">{0}</span><span style=\"font-weight:normal \">Records，</span>&nbsp;" +
                        "<span style=\"font-weight:normal \">Current Page</span><span style=\"color:" + m_NumberColor.Name + "\">{1}</span><span style=\"font-weight:normal \">，Total Page<span style=\"color:" + m_NumberColor.Name + ";\">{2}</span><span style=\"font-weight:normal \"></span>&nbsp;&nbsp;", RecordCount, PageIndex, PageCount));
                    writer.Write("</div><div style=\"float:right; padding-right:5px; white-space:nowrap;\">");
                }
                else
                {
                    writer.Write("<div style=\"width:100%;height:25px; line-height:25px;\"><div style=\"float:left; padding-left:10px;\">");
                    writer.Write(string.Format("<span style=\"font-weight:normal \">共有</span><span style=\"color:" + m_NumberColor.Name + "\">{0}</span><span style=\"font-weight:normal \">条记录，</span>&nbsp;" +
                        "<span style=\"font-weight:normal \">当前第</span><span style=\"color:" + m_NumberColor.Name + "\">{1}</span><span style=\"font-weight:normal \">页，共<span style=\"color:" + m_NumberColor.Name + ";\">{2}</span><span style=\"font-weight:normal \">页</span>&nbsp;&nbsp;", RecordCount, PageIndex, PageCount));
                    writer.Write("</div><div style=\"float:right; padding-right:5px; white-space:nowrap;\">");
                }
                if (IsEnglish)
                {
                    if (IsPostModel)
                    {
                        writer.Write("<a href=\"javascript:" + cs.GetPostBackEventReference(this, "1") + "\" class=\"pager\">Home</a>&nbsp;");

                        if (PageIndex > 1)
                        {
                            writer.Write("<a href=\"javascript:" + cs.GetPostBackEventReference(this, Convert.ToString(PageIndex - 1)) + "\" class=\"pager\">Last Page</a>&nbsp;");
                        }
                        else
                        {
                            writer.Write("Last Page&nbsp;");
                        }
                        for (int i = begin; i < end + 1; i++)
                        {
                            if (i != PageIndex)
                            {
                                writer.Write("<a href=\"javascript:" + cs.GetPostBackEventReference(this, i.ToString()) + "\" class=\"pager\">" + i + "</a>&nbsp;");
                            }
                            else
                            {
                                writer.Write(string.Format("<span style=\"color:" + m_NumberColor.Name + "\">{0}</span>&nbsp;", i));
                            }
                        }
                        if (PageIndex < PageCount)
                        {
                            writer.Write("&nbsp;<a href=\"javascript:" + cs.GetPostBackEventReference(this, Convert.ToString(PageIndex + 1)) + "\" class=\"pager\">Next Page</a>&nbsp;");
                        }
                        else writer.Write("Next Page&nbsp;");
                        writer.Write("<a href=\"javascript:" + cs.GetPostBackEventReference(this, PageCount.ToString()) + "\" class=\"pager\">End</a>&nbsp;");
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(TemplateUrl))
                        {
                            url = HttpContext.Current.Request.Url.PathAndQuery;
                            Regex reg = new Regex(@"(\?|&){0,1}Page=[^&]*", RegexOptions.IgnoreCase);
                            url = reg.Replace(url, string.Empty);
                            if (url.IndexOf("?") >= 0) url += "&Page={0}";
                            else url += "?Page={0}";
                        }
                        else url = TemplateUrl;
                        writer.Write(string.Format("<a href=" + url + " class=\"pager\">Home</a>&nbsp;", 1));
                        if (PageIndex > 1)
                        {
                            writer.Write(string.Format("<a href=" + url + " class=\"pager\">Last Pgae</a>&nbsp;", PageIndex - 1));
                        }
                        else writer.Write("Last Pgae&nbsp;");
                        for (int i = begin; i < end + 1; i++)
                        {
                            if (i != PageIndex)
                            {
                                writer.Write(string.Format("<a href=" + url + " class=\"pager\">{0}</a>&nbsp;", i));
                            }
                            else
                            {
                                writer.Write(string.Format("<span style=\"color:" + m_NumberColor.Name + "\">{0}</span>&nbsp;", i));
                            }

                        }
                        if (PageIndex < PageCount)
                        {
                            writer.Write(string.Format("<a href=" + url + " class=\"pager\">Next Page</a>&nbsp;", PageIndex + 1));
                        }
                        else writer.Write("Next Page&nbsp");
                        writer.Write(string.Format("&nbsp;<a href=" + url + " class=\"pager\">End</a>", PageCount));
                    }
                }
                else
                {
                    if (IsPostModel)
                    {
                        writer.Write("<a href=\"javascript:" + cs.GetPostBackEventReference(this, "1") + "\" class=\"pager\">首页</a>&nbsp;");

                        if (PageIndex > 1)
                        {
                            writer.Write("<a href=\"javascript:" + cs.GetPostBackEventReference(this, Convert.ToString(PageIndex - 1)) + "\" class=\"pager\">上一页</a>&nbsp;");
                        }
                        else
                        {
                            writer.Write("上一页&nbsp;");
                        }
                        for (int i = begin; i < end + 1; i++)
                        {
                            if (i != PageIndex)
                            {
                                writer.Write("<a href=\"javascript:" + cs.GetPostBackEventReference(this, i.ToString()) + "\" class=\"pager\">" + i + "</a>&nbsp;");
                            }
                            else
                            {
                                writer.Write(string.Format("<span style=\"color:" + m_NumberColor.Name + "\">{0}</span>&nbsp;", i));
                            }
                        }
                        if (PageIndex < PageCount)
                        {
                            writer.Write("&nbsp;<a href=\"javascript:" + cs.GetPostBackEventReference(this, Convert.ToString(PageIndex + 1)) + "\" class=\"pager\">下一页</a>&nbsp;");
                        }
                        else writer.Write("下一页&nbsp;");
                        writer.Write("<a href=\"javascript:" + cs.GetPostBackEventReference(this, PageCount.ToString()) + "\" class=\"pager\">尾页</a>&nbsp;");
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(TemplateUrl))
                        {
                            url = HttpContext.Current.Request.Url.PathAndQuery;
                            Regex reg = new Regex(@"(\?|&){0,1}Page=[^&]*", RegexOptions.IgnoreCase);
                            url = reg.Replace(url, string.Empty);
                            if (url.IndexOf("?") >= 0) url += "&Page={0}";
                            else url += "?Page={0}";
                        }
                        else url = TemplateUrl;
                        writer.Write(string.Format("<a href=" + url + " class=\"pager\">首页</a>&nbsp;", 1));
                        if (PageIndex > 1)
                        {
                            writer.Write(string.Format("<a href=" + url + " class=\"pager\">上一页</a>&nbsp;", PageIndex - 1));
                        }
                        else writer.Write("上一页&nbsp;");
                        for (int i = begin; i < end + 1; i++)
                        {
                            if (i != PageIndex)
                            {
                                writer.Write(string.Format("<a href=" + url + " class=\"pager\">{0}</a>&nbsp;", i));
                            }
                            else
                            {
                                writer.Write(string.Format("<span style=\"color:" + m_NumberColor.Name + "\">{0}</span>&nbsp;", i));
                            }

                        }
                        if (PageIndex < PageCount)
                        {
                            writer.Write(string.Format("<a href=" + url + " class=\"pager\">下一页</a>&nbsp;", PageIndex + 1));
                        }
                        else writer.Write("下一页&nbsp");
                        writer.Write(string.Format("&nbsp;<a href=" + url + " class=\"pager\">尾页</a>", PageCount));
                    }
                }


                writer.Write("</div></div>");
            }
        }




        #endregion

        #region 属性
        private int m_nPageIndex = 1;
        private int m_nRecordCount = 0;
        private int m_nPageCount = 0;
        private int m_nPageSize = 20;
        private Color m_NumberColor = Color.Red;
        private bool m_bIsPostModel = true;
        private string m_sTemplateUrl = string.Empty;
        private bool m_nIsEnglish = false;

        private bool m_isSpecial = false;

    	private int rightCount = 10;
		/// <summary>
		/// 右边显示的翻页数目
		/// </summary>
    	public int RightCount
    	{
			get { return rightCount; }
			set { rightCount = (value-1); }
    	}

        [Category("Design"),
       Description("设置或获取页面总数、记录数、页码的显示的颜色")]
        public Color NumberColor
        {
            get { return m_NumberColor; }
            set { m_NumberColor = value; }
        }

        [Category("Data"),
        Description("设置或获取当前页码")]
        public int PageIndex
        {
            get { return m_nPageIndex; }
            set { m_nPageIndex = value; }
        }

        [Category("Data"),
        Description("设置或获取记录总数")]
        public int RecordCount
        {
            get { return m_nRecordCount; }
            set { m_nRecordCount = value; }
        }

        [Category("Data"),
        Description("设置或获取页面总数")]
        public int PageCount
        {
            get { return m_nPageCount; }
            set { m_nPageCount = value; }
        }

        [Category("Data"),
        Description("设置或获取页面分页大小")]
        public int PageSize
        {
            get { return m_nPageSize; }
            set { m_nPageSize = value; }
        }

        [Category("Action"),
        Description("设置是否英文")]
        public bool IsEnglish
        {
            get { return m_nIsEnglish; }
            set { m_nIsEnglish = value; }
        }

        [Category("Action"),
       Description("设置是否是特殊样式")]
        public bool IsSpecial
        {
            get { return m_isSpecial; }
            set { m_isSpecial = value; }
        }

        [Category("Action"),
        Description("设置或获取是否用post模式")]
        public bool IsPostModel
        {
            get { return m_bIsPostModel; }
            set { m_bIsPostModel = value; }
        }

        [Category("Data"),
        Description("设置或获取格式化路径")]
        public string TemplateUrl
        {
            get { return m_sTemplateUrl; }
            set { m_sTemplateUrl = value; }
        }
        #endregion

        /// <summary>
        /// 委托跳转事件
        /// </summary>
        public event EventHandler PageJump;

        protected void OnPageJump(EventArgs e)
        {
            try
            {
                PageJump(this, e);
            }
            catch { }
        }

        #region IPostBackDataHandler 成员

        public bool LoadPostData(string postDataKey, System.Collections.Specialized.NameValueCollection postCollection)
        {
            return false;
        }

        public void RaisePostDataChangedEvent()
        {
            // IPostBackDataHandler 协定的一部分。如果曾经从 LoadPostData 方法返回真
            // （表示需要引发更改通知），则被调用。由于
            // 始终返回假，则此方法只是一个空操作。
        }

        #endregion

        #region IPostBackEventHandler 成员

        public void RaisePostBackEvent(string eventArgument)
        {
            PageIndex = Convert.ToInt32(eventArgument);
            OnPageJump(EventArgs.Empty);
        }

        #endregion
    }
}
