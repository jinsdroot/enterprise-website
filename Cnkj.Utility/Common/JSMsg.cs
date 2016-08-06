using System;
using System.Text;
using System.Web;
using System.Web.UI;

namespace Common
{
	/// <summary>
	/// JavaScript类
	/// </summary>
	public class JSMsg
	{		
		private  JSMsg()
		{
           
		}

        /// <summary>
        /// 函数名:ShowModalDialogJavascript    
        /// 功能描述:返回打开模式窗口的脚本    
        /// </summary>
        /// <param name="webFormUrl"></param>
        /// <returns></returns>
        public static string ShowModalDialogJavascript(string webFormUrl)
        {
            string js = @"<script language=javascript>
                            var iWidth = 0 ;
                            var iHeight = 0 ;
                            iWidth=window.screen.availWidth-10;
                            iHeight=window.screen.availHeight-50;
                            var szFeatures = 'dialogWidth:'+iWidth+';dialogHeight:'+iHeight+';dialogLeft:0px;dialogTop:0px;center:yes;help:no;resizable:yes;status:no;scroll:yes';
                            showModalDialog('" + webFormUrl + "','',szFeatures);</script>";
            return js;
        }

        public static string ShowModalDialogJavascript(string webFormUrl, string features)
        {
            string js = @"<script language=javascript>                            
                            showModalDialog('" + webFormUrl + "','','" + features + "');</script>";
            return js;
        }

        /// <summary>
        /// 函数名:ShowModalDialogWindow    
        /// 功能描述:打开模式窗口    
        /// </summary>
        /// <param name="webFormUrl"></param>
        /// <returns></returns>
        public static void ShowModalDialogWindow(string webFormUrl)
        {
            string js = ShowModalDialogJavascript(webFormUrl);
            HttpContext.Current.Response.Write(js);
        }

        public static void ShowModalDialogWindow(string webFormUrl, string features)
        {
            string js = ShowModalDialogJavascript(webFormUrl, features);
            HttpContext.Current.Response.Write(js);
        }
        public static void ShowModalDialogWindow(string webFormUrl, int width, int height, int top, int left)
        {
            string features = "dialogWidth:" + width.ToString() + "px"
                + ";dialogHeight:" + height.ToString() + "px"
                + ";dialogLeft:" + left.ToString() + "px"
                + ";dialogTop:" + top.ToString() + "px"
                + ";center:yes;help=no;resizable:no;status:no;scroll=no";
            ShowModalDialogWindow(webFormUrl, features);
        }



        /// <summary>
        /// 刷新父窗口
        /// </summary>
        public static void RefreshParent()
        {
            string js = @"<Script language='JavaScript'>
                    parent.location.reload();
                  </Script>";
            HttpContext.Current.Response.Write(js);
        }


        /// <summary>
        /// 刷新打开窗口
        /// </summary>
        public static void RefreshOpener()
        {
            string js = @"<Script language='JavaScript'>
                    opener.location.reload();
                  </Script>";
            HttpContext.Current.Response.Write(js);
        }

        /// <summary>
        /// 打开窗口
        /// </summary>
        /// <param name="url"></param>
        public static void OpenWebForm(string url)
        {
            string js = @"<Script language='JavaScript'>
            //window.open('" + url + @"');
            window.open('" + url + @"','','height=0,width=0,top=0,left=0,location=no,menubar=no,resizable=yes,scrollbars=yes,status=yes,titlebar=no,toolbar=no,directories=no');
            </Script>";

            HttpContext.Current.Response.Write(js);
        }
        public static void OpenWebForm(string url, string name, string future)
        {
            string js = @"<Script language='JavaScript'>
                     window.open('" + url + @"','" + name + @"','" + future + @"')
                  </Script>";
            HttpContext.Current.Response.Write(js);
        }
        public static void OpenWebForm(string url, string formName)
        {
            string js = @"<Script language='JavaScript'>
            
            window.open('" + url + @"','" + formName + @"','height=0,width=0,top=0,left=0,location=no,menubar=no,resizable=yes,scrollbars=yes,status=yes,titlebar=no,toolbar=no,directories=no');
            </Script>";

            HttpContext.Current.Response.Write(js);
        }//window.open('" + url + @"','" + formName + @"');

        public static string OpenWebFormJS(string url, string title, int width, int height)
        {
            return "javascript:window.open('" + url + "','" + title + "','width=" + width + ",height=" + height + ",center=yes,toolbar=no, status=no, menubar=no, resizable=yes, scrollbars=yes');";//<script type=\"text/javascript\"></script>
        }

        /// </summary>
        /// <param name="url">WEB窗口</param>
        /// <param name="isFullScreen">是否全屏幕</param>
        public static void OpenWebForm(string url, bool isFullScreen)
        {
            string js = @"<Script language='JavaScript'>";
            if (isFullScreen)
            {
                js += "var iWidth = 0;";
                js += "var iHeight = 0;";
                js += "iWidth=window.screen.availWidth-10;";
                js += "iHeight=window.screen.availHeight-50;";
                js += "var szFeatures ='width=' + iWidth + ',height=' + iHeight + ',top=0,left=0,location=no,menubar=no,resizable=yes,scrollbars=yes,status=yes,titlebar=no,toolbar=no,directories=no';";
                js += "window.open('" + url + @"','',szFeatures);";
            }
            else
            {
                js += "window.open('" + url + @"','','height=0,width=0,top=0,left=0,location=no,menubar=no,resizable=yes,scrollbars=yes,status=yes,titlebar=no,toolbar=no,directories=no');";
            }
            js += "</Script>";
            HttpContext.Current.Response.Write(js);
        }

        /// <summary>
        /// 函数名：CloseAllForm
        /// 功能描述：关闭链接到此网页的所有父窗体，并只展现“url”页面
        /// </summary>
        /// <param name="url"></param>
        public static void CloseAllForm(string url)
        {
            string js = @"<Script language='JavaScript'> 
                                 if (typeof(window.opener) != 'undefined' && window.opener != null)
                                 {
                                     window.opener.location = '" + url + @"';
                                     window.close();
                                 }
                                 else if (self != top) 
                                 {
                                     top.location = '" + url + @"';
                                 }

                         </Script>";
            HttpContext.Current.Response.Write(js);
        }


        /// <summary>
        /// 打开新窗口
        /// </summary>
        /// <param name="page"></param>
        /// <param name="url"></param>
        public static void OpenWindow(System.Web.UI.Page page , string url)
        {
            string script = "<script>window.open(\"" + url + "\");</script>";
            page.Response.Write(script);
        }

		/// <summary>
        /// 显示消息提示对话框，页面加载结束前
		/// </summary>
		/// <param name="page">当前页面指针，一般为this</param>
		/// <param name="msg">提示信息</param>
        public static void ShowRegisterMsg(System.Web.UI.Page page, string msg)
		{
            string script="<script language='javascript' >alert('" + StringPlus.JSStringFormat(msg,false) + "');</script>";
            RegisterJS(page, script,false);
            //page.ClientScript.RegisterStartupScript(page.GetType(), "message", ");
		}

        /// <summary>
        /// 页面加载结束前
        /// </summary>
        /// <param name="page"></param>
        /// <param name="scriptText"></param>
        /// <param name="addScriptTag"></param>
        public static void RegisterJS(System.Web.UI.Page page, string scriptText,bool addScriptTag)
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), "regmsg", scriptText,addScriptTag);
        }
        /// <summary>
        /// 页面加载开始后
        /// </summary>
        /// <param name="page"></param>
        /// <param name="scriptText">未加入Script标签</param>
        public static void ResponseWriteJS(System.Web.UI.Page page, string scriptText)
        {
            ResponseWriteJS(page, scriptText,false);
        }

	    /// <summary>
	    /// 页面加载开始后
	    /// </summary>
	    /// <param name="page"></param>
	    /// <param name="scriptText"></param>
	    /// <param name="addScriptTag">是否加入Script标签</param>
	    public static void ResponseWriteJS(System.Web.UI.Page page, string scriptText,bool addScriptTag)
	    {
	        string msg = "";
            if (addScriptTag)
                msg = "<script type='text/javascript'>" + scriptText + "</script>";
            else
                msg = scriptText;
            page.Response.Write(msg);
        }

        /// <summary>
        /// 显示消息提示对话框，页面加载开始后
        /// </summary>
        /// <param name="page"></param>
        /// <param name="msg"></param>
        public static void ShowMsg(System.Web.UI.Page page, string msg)
        {
            string script = "<script type='text/javascript' language='javascript'>alert('" + StringPlus.JSStringFormat(msg,false) + "');</script>";
            //page.Response.Write();
            ResponseWriteJS(page, script);
        }
		/// <summary>
        /// 控件点击 消息确认提示框
		/// </summary>
		/// <param name="Control"></param>
		/// <param name="msg"></param>
		public static void ShowConfirm(System.Web.UI.WebControls.WebControl Control, string msg)
		{

			//Control.Attributes.Add("onclick", "return confirm('" + StringPlus.JSStringFormat(msg,false) + "');");
			AddJSAttrib(Control, "onclick", "return confirm('" + StringPlus.JSStringFormat(msg, false) + "');");
		}

		/// <summary>
		/// 给控件添加js属性值Control.Attributes.Add("onclick", "return confirm('" + StringPlus.JSStringFormat(msg,false) + "');");
		/// </summary>
		/// <param name="control"></param>
		/// <param name="attName"></param>
		/// <param name="scriptText"></param>
		public static void AddJSAttrib(System.Web.UI.WebControls.WebControl control,string attName,string scriptText)
		{
			control.Attributes.Add(attName, scriptText);
		}

		/// <summary>
        /// 显示消息提示对话框，并进行页面跳转windows.location跳转，msg为空直接挑转
		/// </summary>
		/// <param name="page">当前页面指针，一般为this</param>
		/// <param name="msg">提示信息</param>
		/// <param name="url">跳转的目标URL</param>
        public static void ShowWinRedirect(System.Web.UI.Page page, string msg, string url)
        {
            ResponseWriteJS(page, RedirectWinJS(msg, url));
            //page.ClientScript.RegisterStartupScript(page.GetType(), "message", Builder.ToString());
        }

        /// <summary>
        /// 返回window.location.href=''脚本,msg不为空，则显示信息后跳转
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="url"></param>
        /// <returns></returns>
        public static string RedirectWinJS(string msg, string url)
        {
            StringBuilder Builder = new StringBuilder();
            Builder.Append("<script language='javascript' >");

            if (!string.IsNullOrEmpty(msg))
            {
                string tmp = StringPlus.JSStringFormat(msg.Trim(),false);
                Builder.AppendFormat("alert('{0}');", tmp);
            }
            Builder.AppendFormat("window.location.href='{0}';", url);
            Builder.Append("</script>");
            return Builder.ToString();
        }

        /// <summary>
        /// 返回top.location.href=''脚本,msg不为空，则显示信息后跳转
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="url"></param>
        /// <returns></returns>
        public static string RedirectTopJS(string msg, string url)
        {
            StringBuilder Builder = new StringBuilder();
            Builder.Append("<script language='javascript' >");

            if (!string.IsNullOrEmpty(msg))
            {
                string tmp = StringPlus.JSStringFormat(msg.Trim(),false);
                Builder.AppendFormat("alert('{0}');", tmp);
            }
            Builder.AppendFormat("top.location.href='{0}';", url);
            Builder.Append("</script>");
            return Builder.ToString();
        }

        /// <summary>
        /// 显示消息提示对话框，并进行页面跳转top跳转,msg为空直接挑转
        /// </summary>
        /// <param name="page">当前页面指针，一般为this</param>
        /// <param name="msg">提示信息</param>
        /// <param name="url">跳转的目标URL</param>
        public static void ShowTopRedirect(System.Web.UI.Page page, string msg, string url)
        {
            ResponseWriteJS(page, RedirectTopJS(msg, url));

            //page.ClientScript.RegisterStartupScript(page.GetType(), "message", Builder.ToString());
        }




        /// <summary>
        /// 指定的框架页面转换
        /// </summary>
        /// <param name="FrameName"></param>
        /// <param name="url"></param>
        public static void Redirects(string FrameName, string url)
        {
            string js = @"<Script language='JavaScript'>
                    @obj.location.replace(""{0}"");
                  </Script>";
            js = js.Replace("@obj", FrameName);
            js = string.Format(js, url);
            System.Web.HttpContext.Current.Response.Write(js);
        }


        /// <summary>
        /// WebControl（UpdatePanel）中执行js脚本
        /// </summary>
        /// <param name="webControl"></param>
        /// <param name="scriptText"></param>
        /// <param name="isAddScriptTag">是否添加ScriptTag</param>
        public static void RegisterAjaxJS(System.Web.UI.WebControls.WebControl webControl, string scriptText,bool isAddScriptTag)
        {
           ScriptManager.RegisterStartupScript(webControl, webControl.GetType(), "msg", scriptText, isAddScriptTag);
        }

        /// <summary>
        /// WebControl（UpdatePanel）中显示一消息
        /// </summary>
        /// <param name="webControl"></param>
        /// <param name="msg"></param>
        public static void ShowAjaxMsg(System.Web.UI.WebControls.WebControl webControl, string msg)
        {
            RegisterAjaxJS(webControl, "alert(\"" + StringPlus.JSStringFormat(msg, false) + "\");", true);
        }

	    /// <summary>
	    /// 注册ScriptManager脚本
	    /// </summary>
	    /// <param name="page"></param>
	    /// <param name="scriptText"></param>
	    /// <param name="isAddScriptTag">是否添加ScriptTag</param>
	    public static void RegisterAjaxJS(Page page, string scriptText,bool isAddScriptTag)
	    {
	        ScriptManager.RegisterStartupScript(page, page.GetType(), "msg", scriptText, isAddScriptTag);
	    }

        /// <summary>
        /// 回到历史页面
        /// </summary>
        /// <param name="value">-1/1</param>
        public static void GoHistory(int value)
        {
            string js = @"<Script language='JavaScript'>
                    history.go({0});  
                  </Script>";
            System.Web.HttpContext.Current.Response.Write(string.Format(js, value));
        }

        /// <summary>
        /// 关闭当前窗口
        /// </summary>
        public static void CloseWindow()
        {
            string js = @"<Script language='JavaScript'>
                    window.close();  
                  </Script>";
            System.Web.HttpContext.Current.Response.Write(js);
            System.Web.HttpContext.Current.Response.End();
        }
	}
}
