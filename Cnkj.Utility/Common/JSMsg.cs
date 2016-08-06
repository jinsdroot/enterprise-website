using System;
using System.Text;
using System.Web;
using System.Web.UI;

namespace Common
{
	/// <summary>
	/// JavaScript��
	/// </summary>
	public class JSMsg
	{		
		private  JSMsg()
		{
           
		}

        /// <summary>
        /// ������:ShowModalDialogJavascript    
        /// ��������:���ش�ģʽ���ڵĽű�    
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
        /// ������:ShowModalDialogWindow    
        /// ��������:��ģʽ����    
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
        /// ˢ�¸�����
        /// </summary>
        public static void RefreshParent()
        {
            string js = @"<Script language='JavaScript'>
                    parent.location.reload();
                  </Script>";
            HttpContext.Current.Response.Write(js);
        }


        /// <summary>
        /// ˢ�´򿪴���
        /// </summary>
        public static void RefreshOpener()
        {
            string js = @"<Script language='JavaScript'>
                    opener.location.reload();
                  </Script>";
            HttpContext.Current.Response.Write(js);
        }

        /// <summary>
        /// �򿪴���
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
        /// <param name="url">WEB����</param>
        /// <param name="isFullScreen">�Ƿ�ȫ��Ļ</param>
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
        /// ��������CloseAllForm
        /// �����������ر����ӵ�����ҳ�����и����壬��ֻչ�֡�url��ҳ��
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
        /// ���´���
        /// </summary>
        /// <param name="page"></param>
        /// <param name="url"></param>
        public static void OpenWindow(System.Web.UI.Page page , string url)
        {
            string script = "<script>window.open(\"" + url + "\");</script>";
            page.Response.Write(script);
        }

		/// <summary>
        /// ��ʾ��Ϣ��ʾ�Ի���ҳ����ؽ���ǰ
		/// </summary>
		/// <param name="page">��ǰҳ��ָ�룬һ��Ϊthis</param>
		/// <param name="msg">��ʾ��Ϣ</param>
        public static void ShowRegisterMsg(System.Web.UI.Page page, string msg)
		{
            string script="<script language='javascript' >alert('" + StringPlus.JSStringFormat(msg,false) + "');</script>";
            RegisterJS(page, script,false);
            //page.ClientScript.RegisterStartupScript(page.GetType(), "message", ");
		}

        /// <summary>
        /// ҳ����ؽ���ǰ
        /// </summary>
        /// <param name="page"></param>
        /// <param name="scriptText"></param>
        /// <param name="addScriptTag"></param>
        public static void RegisterJS(System.Web.UI.Page page, string scriptText,bool addScriptTag)
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), "regmsg", scriptText,addScriptTag);
        }
        /// <summary>
        /// ҳ����ؿ�ʼ��
        /// </summary>
        /// <param name="page"></param>
        /// <param name="scriptText">δ����Script��ǩ</param>
        public static void ResponseWriteJS(System.Web.UI.Page page, string scriptText)
        {
            ResponseWriteJS(page, scriptText,false);
        }

	    /// <summary>
	    /// ҳ����ؿ�ʼ��
	    /// </summary>
	    /// <param name="page"></param>
	    /// <param name="scriptText"></param>
	    /// <param name="addScriptTag">�Ƿ����Script��ǩ</param>
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
        /// ��ʾ��Ϣ��ʾ�Ի���ҳ����ؿ�ʼ��
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
        /// �ؼ���� ��Ϣȷ����ʾ��
		/// </summary>
		/// <param name="Control"></param>
		/// <param name="msg"></param>
		public static void ShowConfirm(System.Web.UI.WebControls.WebControl Control, string msg)
		{

			//Control.Attributes.Add("onclick", "return confirm('" + StringPlus.JSStringFormat(msg,false) + "');");
			AddJSAttrib(Control, "onclick", "return confirm('" + StringPlus.JSStringFormat(msg, false) + "');");
		}

		/// <summary>
		/// ���ؼ����js����ֵControl.Attributes.Add("onclick", "return confirm('" + StringPlus.JSStringFormat(msg,false) + "');");
		/// </summary>
		/// <param name="control"></param>
		/// <param name="attName"></param>
		/// <param name="scriptText"></param>
		public static void AddJSAttrib(System.Web.UI.WebControls.WebControl control,string attName,string scriptText)
		{
			control.Attributes.Add(attName, scriptText);
		}

		/// <summary>
        /// ��ʾ��Ϣ��ʾ�Ի��򣬲�����ҳ����תwindows.location��ת��msgΪ��ֱ����ת
		/// </summary>
		/// <param name="page">��ǰҳ��ָ�룬һ��Ϊthis</param>
		/// <param name="msg">��ʾ��Ϣ</param>
		/// <param name="url">��ת��Ŀ��URL</param>
        public static void ShowWinRedirect(System.Web.UI.Page page, string msg, string url)
        {
            ResponseWriteJS(page, RedirectWinJS(msg, url));
            //page.ClientScript.RegisterStartupScript(page.GetType(), "message", Builder.ToString());
        }

        /// <summary>
        /// ����window.location.href=''�ű�,msg��Ϊ�գ�����ʾ��Ϣ����ת
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
        /// ����top.location.href=''�ű�,msg��Ϊ�գ�����ʾ��Ϣ����ת
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
        /// ��ʾ��Ϣ��ʾ�Ի��򣬲�����ҳ����תtop��ת,msgΪ��ֱ����ת
        /// </summary>
        /// <param name="page">��ǰҳ��ָ�룬һ��Ϊthis</param>
        /// <param name="msg">��ʾ��Ϣ</param>
        /// <param name="url">��ת��Ŀ��URL</param>
        public static void ShowTopRedirect(System.Web.UI.Page page, string msg, string url)
        {
            ResponseWriteJS(page, RedirectTopJS(msg, url));

            //page.ClientScript.RegisterStartupScript(page.GetType(), "message", Builder.ToString());
        }




        /// <summary>
        /// ָ���Ŀ��ҳ��ת��
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
        /// WebControl��UpdatePanel����ִ��js�ű�
        /// </summary>
        /// <param name="webControl"></param>
        /// <param name="scriptText"></param>
        /// <param name="isAddScriptTag">�Ƿ����ScriptTag</param>
        public static void RegisterAjaxJS(System.Web.UI.WebControls.WebControl webControl, string scriptText,bool isAddScriptTag)
        {
           ScriptManager.RegisterStartupScript(webControl, webControl.GetType(), "msg", scriptText, isAddScriptTag);
        }

        /// <summary>
        /// WebControl��UpdatePanel������ʾһ��Ϣ
        /// </summary>
        /// <param name="webControl"></param>
        /// <param name="msg"></param>
        public static void ShowAjaxMsg(System.Web.UI.WebControls.WebControl webControl, string msg)
        {
            RegisterAjaxJS(webControl, "alert(\"" + StringPlus.JSStringFormat(msg, false) + "\");", true);
        }

	    /// <summary>
	    /// ע��ScriptManager�ű�
	    /// </summary>
	    /// <param name="page"></param>
	    /// <param name="scriptText"></param>
	    /// <param name="isAddScriptTag">�Ƿ����ScriptTag</param>
	    public static void RegisterAjaxJS(Page page, string scriptText,bool isAddScriptTag)
	    {
	        ScriptManager.RegisterStartupScript(page, page.GetType(), "msg", scriptText, isAddScriptTag);
	    }

        /// <summary>
        /// �ص���ʷҳ��
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
        /// �رյ�ǰ����
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
