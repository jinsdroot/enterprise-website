using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using Common;
using DevNet.Common.Logger;

namespace Cnkj.Utility
{
	/// <summary>
	/// Cnkj页面基类，提供一些页面常用方法[简化调用Common类库的方法]
	/// </summary>
	public class WebPageBase : Page
	{

		/// <summary>
		/// 页面Title
		/// </summary>
		protected static string PageTitle =Config.Settings.PageTitle;
		/// <summary>
		/// JQuery1.4.1的Script脚本
		/// </summary>
	    protected const string JQueryScript = "<script src=\"js/jquery-1.4.1.min.js\" type=\"text/javascript\"></script>";
		/// <summary>
		/// 验证图片中的session字符
		/// </summary>
		public string CheckCode
		{
			get { return Session["CheckCode"] == null ? "" : Session["CheckCode"].ToString(); }
			set { Session["CheckCode"] = value; }
		}

		protected override void OnInit(System.EventArgs e)
		{
			if (this.Page.Header != null)
				this.Page.Title = Config.Settings.PageTitle;
			base.OnInit(e);
		}
		/// <summary>
		/// 设置页面标题、搜索关键字、描述
		/// </summary>
		protected void SetHeaderInfo(HtmlHead header, string sKeywords, string sDescription)
		{
			try
			{
				if (header == null)
					return;
				//Page.Title = sTitle;
				HtmlMeta keywords = new HtmlMeta();
				keywords.Name = "keywords";
				keywords.Content = sKeywords;
				HtmlMeta description = new HtmlMeta();
				description.Name = "description";
				description.Content = sDescription;
				header.Controls.Add(keywords);
				header.Controls.Add(description);
			}
			catch
			{ }
		}

		/// <summary>
		/// 获取图片路径
		/// </summary>
		/// <param name="picPath"></param>
		/// <returns></returns>
		protected string GetPicPath(string picPath)
		{
			return WebCommon.GetPicPath(this, picPath);
		}

		/// <summary>
		/// 返回当前系统日期的标准格式 yyyy-MM-dd
		/// </summary>
		protected string GetShortDate(object obj)
		{
			return DateHelper.GetShortDate(obj);
		}

		/// <summary>
		/// 删除文件或目录
		/// </summary>
		/// <param name="filePath">文件或目录路径，可以为虚拟路径或绝对路径</param>
		/// <param name="isDir">是否目录</param>
		protected void DeletePath(string filePath,bool isDir)
		{
			try
			{
				FileHelper.DeletePath(filePath, isDir);
			}
			catch(Exception ex)
			{
				Log.Error(ex.Message);
			}
		}

		/// <summary>
		/// 显示提示信息
		/// </summary>
		/// <param name="msg"></param>
		protected void ShowMsg(string msg)
		{
			JSMsg.ShowRegisterMsg(this, msg);
		}

		/// <summary>
		/// 显示信息并跳转，msg为空则直接跳转
		/// </summary>
		/// <param name="msg"></param>
		/// <param name="url"></param>
		/// <param name="thisORTop"></param>
		protected void ShowMsgRedirct(string msg,string url,bool thisORTop)
		{
			if (thisORTop)
				JSMsg.ShowWinRedirect(this, msg, url);
			else
				JSMsg.ShowTopRedirect(this, msg, url);
		}
		/// <summary>
		/// 注册脚本块JS方法等，已加入ScriptTag
		/// </summary>
		/// <param name="scriptText"></param>
		protected void RegistScript(string scriptText)
		{
			JSMsg.RegisterJS(this, scriptText, true);
		}

		/// <summary>
		/// 返回删除html格式后的字符串
		/// </summary>
		/// <param name="htmlContent"></param>
		/// <returns></returns>
		protected string DelHTML(string htmlContent,int length)
		{
			return StringPlus.DelHTML(htmlContent,length);
		}

		/// <summary>
		/// 按字节长度剪切字符串
		/// </summary>
		/// <param name="str"></param>
		/// <param name="byteLength"></param>
		/// <param name="isDot">是否末尾加  ...</param>
		/// <returns></returns>
		protected string GetStrByByteLength(string str, int byteLength,bool isDot)
		{
			return StringPlus.GetStrByByteLength(str, byteLength, isDot);
		}

		/// <summary>
		/// 按字节长度剪切字符串
		/// </summary>
		/// <param name="str"></param>
		/// <param name="byteLength"></param>
		/// <returns></returns>
		protected string GetStrByByteLength(string str, int byteLength)
		{
			return StringPlus.GetStrByByteLength(str, byteLength, true);
		}

		/// <summary>
		///  取得HTML中所有图片的 URL
		/// </summary>
		/// <param name="sHtmlText"></param>
		/// <returns></returns>
		protected string[] GetHtmlImageUrlList(string sHtmlText)
		{
			return StringPlus.GetHtmlImageUrlList(sHtmlText);
		}

		/// <summary>
		/// 获取URL请求参数值
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="key"></param>
		/// <param name="defaultValue"></param>
		/// <param name="converter"></param>
		/// <returns></returns>
		protected T GetRequestQuery<T>(string key, T defaultValue, Converter<object, T> converter) where T : IConvertible
		{
			return URLHelper.GetRequestQuery(key, defaultValue, converter);
		} 

		/// <summary>
		/// 获取安全的转换值（错误或异常返回默认值）
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="inputValue"></param>
		/// <param name="defaultValue"></param>
		/// <param name="converter"></param>
		/// <returns></returns>
		protected T GetSaftyValue<T>(object inputValue,T defaultValue,Converter<object,T> converter) where T:IConvertible
		{
			return StringPlus.ConverTValue<T>(inputValue, defaultValue, converter);
		}


		/// <summary>
		/// 获取URL请求参数值
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="key"></param>
		/// <param name="defaultValue"></param>
		/// <returns></returns>
		protected T GetRequestQuery<T>(string key, T defaultValue) where T : IConvertible
		{
			return URLHelper.GetRequestQuery(key, defaultValue);
		}

		/// <summary>
		/// 获取安全的转换值（错误或异常返回默认值）
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="inputValue"></param>
		/// <param name="defaultValue"></param>
		/// <returns></returns>
		protected T GetSaftyValue<T>(object inputValue, T defaultValue) where T : IConvertible
		{
			return StringPlus.ConverTValue<T>(inputValue, defaultValue);
		}
	}
}