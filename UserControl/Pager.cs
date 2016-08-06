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
    /// <summary>
    /// 分页控件
    /// </summary>
    [ToolboxData("<{0}:Pager runat=\"server\"></{0}:Pager>"), PersistChildren(false), ParseChildren(true)]
    public class Pager : WebControl, INamingContainer, IPostBackDataHandler, IPostBackEventHandler
    {
        /// <summary>
        /// 分页布局模式
        /// </summary>
        public enum Layout
        {
            /// <summary>
            /// Div布局模式
            /// </summary>
            DIVLayout,

            /// <summary>
            /// Table布局模式
            /// </summary>
            TableLayout
        }

        public Pager() { }

        #region override method
		
		protected override void OnInit(EventArgs e)
		{
			if (!m_bIsPostModel)
			{
				try
				{
					string pageIndex = HttpContext.Current.Request.QueryString[queryString] ?? string.Empty;
					Int32.TryParse(pageIndex, out m_nPageIndex);
					if (m_nPageIndex == 0)
						m_nPageIndex = 1;
				}
				catch
				{
					m_nPageIndex = 1;
				}
			}
			base.OnLoad(e);
		}
        protected override void LoadViewState(object savedState)
        {
            base.LoadViewState(savedState);
            if (m_bIsPostModel)
            {
                m_nPageIndex = Convert.ToInt32(ViewState["pageindex"]);
                m_nRecordCount = Convert.ToInt32(ViewState["recordcount"]);
                //m_nPageCount = Convert.ToInt32(ViewState["pagecount"]);
                m_nPageSize = Convert.ToInt32(ViewState["pagesize"]);
                m_NumberColor = ViewState["numbercolor"].ToString();
                m_bIsPostModel = Convert.ToBoolean(ViewState["ispostmodel"]);
                m_sTemplateUrl = (string)ViewState["templateurl"];
                rightCount = Convert.ToInt32(ViewState["rightCount"]);
                _isforePager = Convert.ToBoolean(ViewState["_isforePager"]);

                _showRecordCount = Convert.ToBoolean(ViewState["_showRecordCount"]);
                _beforeRecountCountText = ViewState["_beforeRecountCountText"].ToString();
                _afterRecountCountText = ViewState["_afterRecountCountText"].ToString();
                _firstPageText = ViewState["_firstPageText"].ToString();
                _prePageText = ViewState["_prePageText"].ToString();
                _nextPageText = ViewState["_nextPageText"].ToString();
                _lastPageText = ViewState["_lastPageText"].ToString();
                _showPageState = Convert.ToBoolean(ViewState["_showPageState"]);
                queryString = ViewState["queryString"].ToString();
            }
        }

        protected override object SaveViewState()
        {
            if (m_bIsPostModel)
            {
                ViewState["pageindex"] = m_nPageIndex;
                ViewState["recordcount"] = m_nRecordCount;
                //ViewState["pagecount"] = m_nPageCount;
                ViewState["pagesize"] = m_nPageSize;
                ViewState["numbercolor"] = m_NumberColor;
                ViewState["ispostmodel"] = m_bIsPostModel;
                ViewState["templateurl"] = m_sTemplateUrl;
                ViewState["rightCount"] = rightCount;
                ViewState["_isforePager"] = _isforePager;

                ViewState["_showRecordCount"] = _showRecordCount;
                ViewState["_beforeRecountCountText"] = _beforeRecountCountText;
                ViewState["_afterRecountCountText"] = _afterRecountCountText;
                ViewState["_firstPageText"] = _firstPageText;
                ViewState["_prePageText"] = _prePageText;
                ViewState["_nextPageText"] = _nextPageText;
                ViewState["_lastPageText"] = _lastPageText;
                ViewState["_showPageState"] = _showPageState;
                ViewState["queryString"] = queryString;
            }
            return base.SaveViewState();
        }


        protected override void Render(HtmlTextWriter writer)
        {
            try
            {
                if (!_isforePager)
                {
                    renderBackUI(writer);
                }
                else
                {
                    if (_layout == Layout.DIVLayout)
                    {
                        renderForeUI(writer);
                    }
                    else
                    {
                        renderForeTableUI(writer);
                    }
                }
            }
            catch
            { }
        }

        private void renderForeTableUI(HtmlTextWriter writer)
        {
            string url = string.Empty;
            ClientScriptManager cs = Page.ClientScript;

            StringBuilder sb = new StringBuilder();

            int begin, end;
            setbeginend(out begin, out end);

            sb.Append(" <div class=\"");
            sb.Append(CssClass == "" ? "tdsabrosus" : CssClass); //<!--只做了tdsabrosus和tdyahoo、tddigg-->
            sb.Append(
                "\"><table cellpadding=\"0\" cellspacing=\"3\" border=\"0\" width=\"100%\"><tr><td width=\"100%\" align=\"center\">");
            sb.Append("<table cellpadding=\"0\" cellspacing=\"3\" border=\"0\"> <tr>");

            if (_showRecordCount)
            {
                sb.Append("<td>");
                sb.Append(_beforeRecountCountText);
                sb.Append("<span style=\"color:");
                sb.Append(m_NumberColor);
                sb.Append(";\">");
                sb.Append(m_nRecordCount);
                sb.Append("</span>");
                sb.Append(_afterRecountCountText);
                sb.Append("&nbsp;&nbsp;");
                sb.Append("</td>");

            }
            if (m_bIsPostModel)
            {
                if (m_nPageIndex == 1)
                {
                    sb.Append("<td class=\"firstlastdisbale\">");
                    sb.Append(_firstPageText);
                    sb.Append("</td>");

                    sb.Append("<td class=\"firstlastdisbale\">");
                    sb.Append(_prePageText);
                    sb.Append("</td>");
                }
                else
                {
                    sb.Append(
                        "<td class=\"firstlast\" onmouseover=\"javascript:this.className='firstlasthover';\" onmouseout=\"javascript:this.className='firstlast';\" ");
                    sb.Append("onclick=\"javascript:");
                    sb.Append(cs.GetPostBackEventReference(this, "1"));
                    sb.Append("\">");
                    sb.Append(_firstPageText);
                    sb.Append("</td>");

                    sb.Append(
                        "<td class=\"firstlast\" onmouseover=\"javascript:this.className='firstlasthover';\" onmouseout=\"javascript:this.className='firstlast';\" ");
                    sb.Append("onclick=\"javascript:");
                    sb.Append(cs.GetPostBackEventReference(this, (m_nPageIndex - 1).ToString()));
                    sb.Append("\">");
                    sb.Append(_prePageText);
                    sb.Append("</td>");
                }
                for (int i = begin; i <= end; i++)
                {
                    if (i != m_nPageIndex)
                    {
                        sb.Append(
                            "<td class=\"tdcomm\" onmouseover=\"javascript:this.className='tdhover';\" onmouseout=\"javascript:this.className='tdcomm';\" ");
                        sb.Append("onclick=\"javascript:");
                        sb.Append(cs.GetPostBackEventReference(this, i.ToString()));
                        sb.Append("\">");
                        sb.Append(i);
                        sb.Append("</td>");
                    }
                    else
                    {
                        sb.Append("<td class=\"current\">");
                        sb.Append(i);
                        sb.Append("</td>");
                    }
                }
                if (m_nPageIndex < PageCount)
                {
                    sb.Append(
                        "<td class=\"firstlast\" onmouseover=\"javascript:this.className='firstlasthover';\" onmouseout=\"javascript:this.className='firstlast';\" ");
                    sb.Append("onclick=\"javascript:");
                    sb.Append(cs.GetPostBackEventReference(this, (m_nPageIndex + 1).ToString()));
                    sb.Append("\">");
                    sb.Append(_nextPageText);
                    sb.Append("</td>");

                    sb.Append(
                        "<td class=\"firstlast\" onmouseover=\"javascript:this.className='firstlasthover';\" onmouseout=\"javascript:this.className='firstlast';\" ");
                    sb.Append("onclick=\"javascript:");
                    sb.Append(cs.GetPostBackEventReference(this, PageCount.ToString()));
                    sb.Append("\">");
                    sb.Append(_lastPageText);
                    sb.Append("</td>");
                }
                else
                {
                    sb.Append("<td class=\"firstlastdisbale\">");
                    sb.Append(_nextPageText);
                    sb.Append("</td>");

                    sb.Append("<td class=\"firstlastdisbale\">");
                    sb.Append(_lastPageText);
                    sb.Append("</td>");
                }


            }
            else
            {
                if (string.IsNullOrEmpty(UrlPathText))
                {
                    url = HttpContext.Current.Request.Url.PathAndQuery;
                    Regex reg = new Regex(@"(\?|&){0,1}" + queryString + "=[^&]*", RegexOptions.IgnoreCase);
                    url = reg.Replace(url, string.Empty);
                    if (url.IndexOf("?") >= 0) url += "&" + queryString + "={0}";
                    else url += "?" + queryString + "={0}";
                }
                else url = UrlPathText;

                m_nPageIndex = PageIndex; //sjfe_add 10-29

                if (m_nPageIndex == 1)
                {
                    sb.Append("<td class=\"firstlastdisbale\">");
                    sb.Append(_firstPageText);
                    sb.Append("</td>");

                    sb.Append("<td class=\"firstlastdisbale\">");
                    sb.Append(_prePageText);
                    sb.Append("</td>");
                }
                else
                {
                    sb.Append(
                        "<td class=\"firstlast\" onmouseover=\"javascript:this.className='firstlasthover';\" onmouseout=\"javascript:this.className='firstlast';\" ");
                    sb.Append("onclick=\"javascript:window.location.href='");
                    sb.Append(String.Format(url, 1));
                    sb.Append("'\">");
                    sb.Append(_firstPageText);
                    sb.Append("</td>");

                    sb.Append(
                        "<td class=\"firstlast\" onmouseover=\"javascript:this.className='firstlasthover';\" onmouseout=\"javascript:this.className='firstlast';\" ");
                    sb.Append("onclick=\"javascript:window.location.href='");
                    sb.Append(String.Format(url, (m_nPageIndex - 1)));
                    sb.Append("'\">");
                    sb.Append(_prePageText);
                    sb.Append("</td>");
                }
                for (int i = begin; i <= end; i++)
                {
                    if (i != m_nPageIndex)
                    {
                        sb.Append(
                            "<td class=\"tdcomm\" onmouseover=\"javascript:this.className='tdhover';\" onmouseout=\"javascript:this.className='tdcomm';\" ");
                        sb.Append("onclick=\"javascript:window.location.href='");
                        sb.Append(String.Format(url, i));
                        sb.Append("'\">");
                        sb.Append(i);
                        sb.Append("</td>");
                    }
                    else
                    {
                        sb.Append("<td class=\"current\">");
                        sb.Append(i);
                        sb.Append("</td>");
                    }
                }
                if (m_nPageIndex < PageCount)
                {
                    sb.Append(
                        "<td class=\"firstlast\" onmouseover=\"javascript:this.className='firstlasthover';\" onmouseout=\"javascript:this.className='firstlast';\" ");
                    sb.Append("onclick=\"javascript:window.location.href='");
                    sb.Append(String.Format(url, (m_nPageIndex + 1)));
                    sb.Append("'\">");
                    sb.Append(_nextPageText);
                    sb.Append("</td>");

                    sb.Append(
                        "<td class=\"firstlast\" onmouseover=\"javascript:this.className='firstlasthover';\" onmouseout=\"javascript:this.className='firstlast';\" ");
                    sb.Append("onclick=\"javascript:window.location.href='");
                    sb.Append(String.Format(url, PageCount));
                    sb.Append("'\">");
                    sb.Append(_lastPageText);
                    sb.Append("</td>");
                }
                else
                {
                    sb.Append("<td class=\"firstlastdisbale\">");
                    sb.Append(_nextPageText);
                    sb.Append("</td>");

                    sb.Append("<td class=\"firstlastdisbale\">");
                    sb.Append(_lastPageText);
                    sb.Append("</td>");
                }
            }

            if (_showPageState)
            {
                sb.Append("<td>");
                sb.Append("&nbsp;&nbsp;");
                sb.Append("<span style=\"color:");
                sb.Append(m_NumberColor);
                sb.Append(";\">");
                sb.Append(m_nPageIndex);
                sb.Append("/");
                sb.Append(PageCount);
                sb.Append("</span>");
                sb.Append("</td>");
            }

            sb.Append("</tr></table></td></tr></table> </div>  ");

            writer.Write(sb.ToString());

        }


        private void renderForeUI(HtmlTextWriter writer)
        {
            string url = string.Empty;
            ClientScriptManager cs = Page.ClientScript;

            StringBuilder sb = new StringBuilder();

            int begin, end;
            setbeginend(out begin, out end);

            sb.Append(" <div class=\"");
            sb.Append(CssClass == "" ? "sabrosus" : CssClass);
            sb.Append("\"><div>");

            if (_showRecordCount)
            {
                sb.Append(_beforeRecountCountText);
                sb.Append("<span style=\"color:");
                sb.Append(m_NumberColor);
                sb.Append(";\">");
                sb.Append(m_nRecordCount);
                sb.Append("</span>");
                sb.Append(_afterRecountCountText);
                sb.Append("&nbsp;&nbsp;");

            }
            if (m_bIsPostModel)
            {
                if (m_nPageIndex == 1)
                {
                    sb.Append("<span class=\"disabled\">");
                    sb.Append(_firstPageText);
                    sb.Append("</span>");

                    sb.Append("<span class=\"disabled\">");
                    sb.Append(_prePageText);
                    sb.Append("</span>");
                }
                else
                {
                    sb.Append("<span class=\"pagination\">");
                    sb.Append("<a href=\"javascript:");
                    sb.Append(cs.GetPostBackEventReference(this, "1"));
                    sb.Append("\">");
                    sb.Append(_firstPageText);
                    sb.Append("</a></span>");

                    sb.Append("<span class=\"pagination\">");
                    sb.Append("<a href=\"javascript:");
                    sb.Append(cs.GetPostBackEventReference(this, (m_nPageIndex - 1).ToString()));
                    sb.Append("\">");
                    sb.Append(_prePageText);
                    sb.Append("</a></span>");
                }
                for (int i = begin; i <= end; i++)
                {
                    if (i != m_nPageIndex)
                    {
                        sb.Append("<span class=\"pagination\"><a href=\"javascript:");
                        sb.Append(cs.GetPostBackEventReference(this, i.ToString()));
                        sb.Append("\">");
                        sb.Append(i);
                        sb.Append("</a></span>");
                    }
                    else
                    {
                        sb.Append(" <span class=\"current\">");
                        sb.Append(i);
                        sb.Append("</span>");
                    }
                }
                if (m_nPageIndex < PageCount)
                {
                    sb.Append("<span class=\"pagination\">");
                    sb.Append("<a href=\"javascript:");
                    sb.Append(cs.GetPostBackEventReference(this, (m_nPageIndex + 1).ToString()));
                    sb.Append("\">");
                    sb.Append(_nextPageText);
                    sb.Append("</a></span>");

                    sb.Append("<span class=\"pagination\">");
                    sb.Append("<a href=\"javascript:");
                    sb.Append(cs.GetPostBackEventReference(this, PageCount.ToString()));
                    sb.Append("\">");
                    sb.Append(_lastPageText);
                    sb.Append("</a></span>");
                }
                else
                {
                    sb.Append("<span class=\"disabled\">");
                    sb.Append(_nextPageText);
                    sb.Append("</span>");

                    sb.Append("<span class=\"disabled\">");
                    sb.Append(_lastPageText);
                    sb.Append("</span>");
                }


            }
            else
            {
                if (string.IsNullOrEmpty(UrlPathText))
                {
                    url = HttpContext.Current.Request.Url.PathAndQuery;
                    Regex reg = new Regex(@"(\?|&){0,1}" + queryString + "=[^&]*", RegexOptions.IgnoreCase);
                    url = reg.Replace(url, string.Empty);
                    if (url.IndexOf("?") >= 0) url += "&" + queryString + "={0}";
                    else url += "?" + queryString + "={0}";
                }
                else url = UrlPathText;

                m_nPageIndex = PageIndex;//sjfe_add 10-29

                if (m_nPageIndex == 1)
                {
                    sb.Append("<span class=\"disabled\">");
                    sb.Append(_firstPageText);
                    sb.Append("</span>");

                    sb.Append("<span class=\"disabled\">");
                    sb.Append(_prePageText);
                    sb.Append("</span>");
                }
                else
                {
                    sb.Append("<span class=\"pagination\">");
                    sb.Append("<a href=\"");
                    sb.Append(String.Format(url, 1));
                    sb.Append("\">");
                    sb.Append(_firstPageText);
                    sb.Append("</a></span>");

                    sb.Append("<span class=\"pagination\">");
                    sb.Append("<a href=\"");
                    sb.Append(String.Format(url, (m_nPageIndex - 1)));
                    sb.Append("\">");
                    sb.Append(_prePageText);
                    sb.Append("</a></span>");
                }
                for (int i = begin; i <= end; i++)
                {
                    if (i != m_nPageIndex)
                    {
                        sb.Append("<span class=\"pagination\"><a href=\"");
                        sb.Append(String.Format(url, i));
                        sb.Append("\">");
                        sb.Append(i);
                        sb.Append("</a></span>");
                    }
                    else
                    {
                        sb.Append(" <span class=\"current\">");
                        sb.Append(i);
                        sb.Append("</span>");
                    }
                }
                if (m_nPageIndex < PageCount)
                {
                    sb.Append("<span class=\"pagination\">");
                    sb.Append("<a href=\"");
                    sb.Append(String.Format(url, (m_nPageIndex + 1)));
                    sb.Append("\">");
                    sb.Append(_nextPageText);
                    sb.Append("</a></span>");

                    sb.Append("<span class=\"pagination\">");
                    sb.Append("<a href=\"");
                    sb.Append(String.Format(url, PageCount));
                    sb.Append("\">");
                    sb.Append(_lastPageText);
                    sb.Append("</a></span>");
                }
                else
                {
                    sb.Append("<span class=\"disabled\">");
                    sb.Append(_nextPageText);
                    sb.Append("</span>");

                    sb.Append("<span class=\"disabled\">");
                    sb.Append(_lastPageText);
                    sb.Append("</span>");
                }
            }

            if (_showPageState)
            {
                sb.Append("&nbsp;&nbsp;");
                sb.Append("第<span style=\"font-weight: bold;color:");
                sb.Append(m_NumberColor);
                sb.Append(";\">");
                sb.Append(m_nPageIndex);
                sb.Append("</span>页/共<span style=\"font-weight: bold;color:");
                sb.Append(m_NumberColor);
                sb.Append(";\">");
                sb.Append(PageCount);
                sb.Append("</span>页");
            }

            sb.Append("  </div></div>");

            writer.Write(sb.ToString());
        }

        private void renderBackUI(HtmlTextWriter writer)
        {
            string url = string.Empty;
            ClientScriptManager cs = Page.ClientScript;
            int begin, end;
            setbeginend(out begin, out end);           

            //writer.Write("<div style=\"width:100%;height:25px; line-height:25px;\"><div style=\"float:left; padding-left:10px;\">");
            //writer.Write(string.Format("<span style=\"font-weight:normal \">" + _beforeRecountCountText + "</span><span style=\"color:" + m_NumberColor + "\">{0}</span><span style=\"font-weight:normal \">" + _afterRecountCountText + "，</span>&nbsp;" +
            //                           "<span style=\"font-weight:normal \">当前第</span><span style=\"color:" + m_NumberColor + "\">{1}</span><span style=\"font-weight:normal \">页，共<span style=\"color:" + m_NumberColor + ";\">{2}</span><span style=\"font-weight:normal \">页</span>&nbsp;&nbsp;", RecordCount, PageIndex, PageCount));
            //writer.Write("</div><div style=\"float:right; padding-right:5px; white-space:nowrap;\">");
            if (IsPostModel)
            {
                writer.Write("<a href=\"javascript:" + cs.GetPostBackEventReference(this, "1") + "\" class=\"\" style=\"color:Black;\">" + _firstPageText + "</a>&nbsp;");

                if (PageIndex > 1)
                {
                    writer.Write("<a href=\"javascript:" + cs.GetPostBackEventReference(this, Convert.ToString(PageIndex - 1)) + "\" style=\"color:Black;\" class=\"\">" + _prePageText + "</a>&nbsp;");
                }
                else
                {
                    writer.Write(_prePageText + "&nbsp;");
                }
                for (int i = begin; i < end + 1; i++)
                {
                    if (i != PageIndex)
                    {
                        writer.Write("<a href=\"javascript:" + cs.GetPostBackEventReference(this, i.ToString()) + "\" class=\"\">" + i + "</a>&nbsp;");
                    }
                    else
                    {
                        writer.Write(string.Format("<span style=\"color:" + m_NumberColor + "\">{0}</span>&nbsp;", i));
                    }
                }
                if (PageIndex < PageCount)
                {
                    writer.Write("&nbsp;<a href=\"javascript:" + cs.GetPostBackEventReference(this, Convert.ToString(PageIndex + 1)) + "\" style=\"color:Black;\" class=\"\">" + _nextPageText + "</a>&nbsp;");
                }
                else writer.Write(_nextPageText + "&nbsp;");
                writer.Write("<a href=\"javascript:" + cs.GetPostBackEventReference(this, PageCount.ToString()) +
                             "\" class=\"\" style=\"color:Black;\">" + _lastPageText + "</a>&nbsp;");
            }
            else
            {
                if (string.IsNullOrEmpty(UrlPathText))
                {
                    url = HttpContext.Current.Request.Url.PathAndQuery;
                    Regex reg = new Regex(@"(\?|&){0,1}" + queryString + "=[^&]*", RegexOptions.IgnoreCase);
                    url = reg.Replace(url, string.Empty);
                    if (url.IndexOf("?") >= 0) url += "&" + queryString + "={0}";
                    else url += "?" + queryString + "={0}";
                }
                else url = UrlPathText;

                m_nPageIndex = PageIndex; 

                writer.Write(string.Format("<a href=" + url + " class=\"\">" + _firstPageText + "</a>&nbsp;", 1));
                if (PageIndex > 1)
                {
                    writer.Write(string.Format("<a href=" + url + " class=\"\">" + _prePageText + "</a>&nbsp;", PageIndex - 1));
                }
                else writer.Write(_prePageText + "&nbsp;");
                for (int i = begin; i < end + 1; i++)
                {
                    if (i != m_nPageIndex)
                    {
                        writer.Write(string.Format("<a href=" + url + " class=\"\">{0}</a>&nbsp;", i));
                    }
                    else
                    {
                        writer.Write(string.Format("<span style=\"color:" + m_NumberColor + "\">{0}</span>&nbsp;", i));
                    }

                }
                if (m_nPageIndex < PageCount)
                {
                    writer.Write(string.Format("<a href=" + url + " class=\"\">" + _nextPageText + "</a>&nbsp;", PageIndex + 1));
                }
                else writer.Write(_nextPageText + "&nbsp");
                writer.Write(string.Format("&nbsp;<a href=" + url + " class=\"\">" + _lastPageText + "</a>", PageCount));
            }
            writer.Write("</div></div>");
        }

        private void setbeginend(out int begin, out int end)
        {
            if (PageIndex < (((rightCount + 1) / 2) + 1)) begin = 1;
            else
            {
                if (PageIndex + ((rightCount + 1) / 2) >= PageCount)
                {
                    if (PageCount < (rightCount + 1)) begin = 1;
                    else begin = PageCount - rightCount;
                }
                else
                    begin = PageIndex - (((rightCount + 1) / 2) - 1);
            }
            if (PageCount < (rightCount + 1)) end = PageCount;
            else end = begin + rightCount;
        }

        #endregion

        #region 属性
        private int m_nPageIndex = 1;
        private int m_nRecordCount = 0;
        private int m_nPageCount = 0;
        private int m_nPageSize = 15;
        private string m_NumberColor = "#ff0000";
        private bool m_bIsPostModel = true;
        private string m_sTemplateUrl = string.Empty;

        private int rightCount = 9;

        bool _isforePager = false;
        /// <summary>
        /// 是否是前台分页，默认false
        /// </summary>
        [Category("Data"), Description("是否是前台分页，默认false并使用post回发模式进行分页，如为true则使用get模式")]
        public bool IsForePager
        {
            get { return _isforePager; }
            set
            {
                m_bIsPostModel = !value;
                _isforePager = value;
                if (_isforePager)
                {
                    _beforeRecountCountText = "共";
                    _afterRecountCountText = "条";
                }
                else
                {
                    _beforeRecountCountText = "共有";
                    _afterRecountCountText = "条记录";
                }
            }
        }
        /// <summary>
        /// 显示的翻页的页码数目
        /// </summary>
        [Category("Data"), Description("显示的翻页的页码数目")]
        public int PagerNumberCount
        {
            get { return (rightCount + 1); }
            set { rightCount = (value - 1); }
        }

        /// <summary>
        /// 设置或获取页面总数、记录数、当前页码、页码状态显示的颜色
        /// </summary>
        [Category("Design"),
        Description("设置或获取页面总数、记录数、当前页码、页码状态显示的颜色")]
        public string NumberColor
        {
            get { return m_NumberColor; }
            set
            {
                m_NumberColor = value;
                if (String.IsNullOrEmpty(m_NumberColor))
                    m_NumberColor = "#ff0000";
            }
        }
        /// <summary>
        /// 设置或获取当前页码
        /// </summary>
        [Category("Data"),
        Description("设置或获取当前页码")]
        public int PageIndex
        {
            get
            {
                //if (m_bIsPostModel)
                //{
                    return m_nPageIndex;
                //}
				//try
				//{
				//    string pageIndex = HttpContext.Current.Request.QueryString[queryString] ?? string.Empty;
				//    Int32.TryParse(pageIndex, out m_nPageIndex);
				//    if (m_nPageIndex == 0)
				//        m_nPageIndex = 1;
				//    return m_nPageIndex;
				//}
				//catch
				//{
				//    return 1;
				//}
            }
            set
            {
                m_nPageIndex = value;
                if (m_nPageIndex <= 0)
                    m_nPageIndex = 1;
				//if (!m_bIsPostModel)
					//HttpContext.Current.Request.QueryString[queryString] = m_nPageIndex.ToString();
            }
        }
        /// <summary>
        /// 设置或获取记录总数
        /// </summary>
        [Category("Data"),
        Description("设置或获取记录总数")]
        public int RecordCount
        {
            get { return m_nRecordCount; }
            set { m_nRecordCount = value; }
        }
        /// <summary>
        /// 获取页面总数
        /// </summary>
        [Category("Data"),
        Description("获取页面总数")]
        public int PageCount
        {
            get
            {
                if (m_nPageCount == 0)
                {
                    m_nPageCount = (int)(m_nRecordCount / m_nPageSize);
                    if (m_nRecordCount % m_nPageSize != 0)
                        m_nPageCount++;
                }
                return m_nPageCount;
            }
        }
        /// <summary>
        /// 设置或获取页面分页大小,默认15
        /// </summary>
        [Category("Data"),
        Description("设置或获取页面分页大小,默认15")]
        public int PageSize
        {
            get { return m_nPageSize; }
            set { m_nPageSize = value; }
        }
        /// <summary>
        /// 设置或获取是否用post回发模式
        /// </summary>
        [Category("Action"),
        Description("设置或获取是否用post回发模式")]
        public bool IsPostModel
        {
            get { return m_bIsPostModel; }
            set { m_bIsPostModel = value; }
        }
        /// <summary>
        /// 设置或获取格式化路径,get模式时的url路径或urlwriter路径
        /// </summary>
        [Category("Data"),
        Description("设置或获取格式化路径,get模式时的url路径或urlwriter路径")]
        public string UrlPathText
        {
            get { return m_sTemplateUrl; }
            set { m_sTemplateUrl = value; }
        }
        #endregion

        #region
        bool _showRecordCount = false;
        private string _beforeRecountCountText = "共有";
        private string _afterRecountCountText = "条记录";
        private string _firstPageText = "首页";
        private string _prePageText = "上页";
        private string _nextPageText = "下页";
        private string _lastPageText = "尾页";
        bool _showPageState = false;
        Layout _layout = Layout.DIVLayout;

        private string queryString = "page";
        /// <summary>
        /// 传参模式的querystring字符串，默认”page“
        /// </summary>
        [Category("Data"), Description("传参模式的querystring字符串，默认”page“")]
        public string QueryString
        {
            get { return queryString; }
            set
            {
                queryString = value;

            }
        }
        /// <summary>
        /// 分页的布局模式
        /// </summary>
        [Category("Data"), Description("分页的布局样式，默认DIV布局，前台分页样式式有效")]
        public Layout PagerLayout
        {
            get { return _layout; }
            set { _layout = value; }
        }

        /// <summary>
        /// 记录总数后的字符串
        /// </summary>
        [Category("Data"), Description("记录总数后的字符串")]
        public string AfterRecountCountText
        {
            get { return _afterRecountCountText; }
            set { _afterRecountCountText = value; }
        }
        /// <summary>
        /// 是否显示记录总数，前台分页模式有效
        /// </summary>
        [Category("Data"), Description("是否显示记录总数，前台分页模式有效")]
        public bool ShowRecordCount
        {
            get { return _showRecordCount; }
            set { _showRecordCount = value; }
        }
        /// <summary>
        /// 记录总数前的字符串
        /// </summary>
        [Category("Data"), Description("记录总数前的字符串")]
        public string BeforeRecountCountText
        {
            get { return _beforeRecountCountText; }
            set { _beforeRecountCountText = value; }
        }
        /// <summary>
        /// 首页的字符串默认“首页”
        /// </summary>
        [Category("Data"), Description("首页的字符串默认“首页”")]
        public string FirstPageText
        {
            get { return _firstPageText; }
            set
            {
                _firstPageText = value;
                if (String.IsNullOrEmpty(_firstPageText))
                    _firstPageText = "首页";
            }
        }
        /// <summary>
        /// 上一页的字符串默认“上页”
        /// </summary>
        [Category("Data"), Description("上一页的字符串默认“上页”")]

        public string PrePageText
        {
            get { return _prePageText; }
            set
            {
                _prePageText = value;
                if (String.IsNullOrEmpty(_prePageText))
                    _prePageText = "上页";
            }
        }
        /// <summary>
        /// 下一页的字符串默认”下页“
        /// </summary>
        [Category("Data"), Description("下一页的字符串默认”下页“")]

        public string NextPageText
        {
            get { return _nextPageText; }
            set
            {
                _nextPageText = value;
                if (String.IsNullOrEmpty(_nextPageText))
                    _nextPageText = "下页";
            }
        }
        /// <summary>
        /// 尾页字符串默认”尾页“
        /// </summary>
        [Category("Data"), Description("尾页字符串默认”尾页“")]
        public string LastPageText
        {
            get { return _lastPageText; }
            set
            {
                _lastPageText = value;
                if (String.IsNullOrEmpty(_lastPageText))
                    _lastPageText = "尾页";
            }
        }
        /// <summary>
        /// 是否显示页码状态，譬如”1/20“，前台分页模式有效
        /// </summary>
        [Category("Data"), Description("是否显示页码状态，譬如”1/20“，前台分页模式有效")]

        public bool ShowPageState
        {
            get { return _showPageState; }
            set { _showPageState = value; }
        }

        #endregion

        #region====event====

        /// <summary>
        /// 委托跳转事件
        /// </summary>
        public event EventHandler PageJump;

        protected virtual void OnPageJump(EventArgs e)
        {
            try
            {
                if (PageJump != null)
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

        #endregion
    }
}
