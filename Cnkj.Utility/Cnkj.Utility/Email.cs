using System;
using System.Net;
using System.Web;
using System.Xml;
using Common;
using DevNet.Common.Logger;

namespace Cnkj.Utility
{
	/// <summary>
	/// 发送邮件处理类
	/// </summary>
	public class Email
	{
		//static readonly string EmailServer = ConfigHelper.GetAppString("emailserver");
		//static readonly string EmailAddress = ConfigHelper.GetAppString("emailaddress");
		//static readonly string PassWord = ConfigHelper.GetAppString("password");

		
		/// <summary>
		/// 发送默认密码
		/// </summary>
		/// <param name="toEmail"></param>
		/// <param name="userName"></param>
		/// <returns></returns>
		public static bool SendDefaultPwd(string toEmail,string userName)
		{
			try
			{
				string subject = Config.Settings.PageTitle;
				//XmlDocument doc = new XmlDocument();

				//doc.Load(HttpContext.Current.Server.MapPath(WebCommon.ConfigPath));

				//string body = XMLHelper.GetSingleNodeValue(doc,"sysconfig/email/forgetpwd", false);

				//该格式与xml配置文件内保存一致
				string body = string.Format(Config.Settings.Forgetpwd, userName, Config.Settings.DefaultPwd, URLHelper.WebURLRoot, subject);

				SendMail.SendSMTPEMail(Config.Settings.EmailServer, Config.Settings.EmailAddress, Config.Settings.EmailPassWord, toEmail, subject, body);
			}
			catch (Exception ex)
			{
				Log.Error("发送邮件失败\n" + ex.Message);
				return false;
			}
			return true;
		}
	}
}