using System;
using System.Web;
using System.Xml;
using Common;
using DevNet.Common.Logger;

namespace Cnkj.Utility
{
	/// <summary>
	/// 网站配置参数，从~/AppCode/SysConfig.config文件中获取，以后可提供设置扩展
	/// </summary>
	public class Config
	{
		private static Config _config;
		private static readonly object _LockObject = new object();

		#region===属性====
		private string _EmailServer;
		private string _EmailAddress;
		private string _EmailPassWord;
		private string _PageTitle;
		private string _DALPath;
		private string _DefaultPwd;
		private string _DefaultPicPath;
		private string _WebServerEmail;
		private string _WebServerPhone;
		private string _forgetpwd;
		private string _register;
		private string _NotPass;
		private string _Pass;

		private string _BBSURL;
		private string _BBSDBType;
		private string _BBSConnStr;
		private string _NFCPURL;
		private string _WMSURL;
		private string _OAURL;
		private string _TMSURL;
		private string _webICP;
		private string _webkeyword;

		private string[] _allowExt;
		/// <summary>
		/// 网站允许上传的扩展名
		/// </summary>
		public string[] AllowExt
		{
			get { return _allowExt; }
			set { _allowExt = value; }
		}

		/// <summary>
		/// 网站访问关键词
		/// </summary>
		public string WebKeyword
		{
			get { return _webkeyword; }
			set { _webkeyword = value; }
		}
		/// <summary>
		/// 网站访问描述
		/// </summary>
		public string WebDescription
		{
			get { return _webdescription; }
			set { _webdescription = value; }
		}

		private string _webdescription;

		/// <summary>
		/// 网站备案
		/// </summary>
		public string WebICP
		{
			get { return _webICP; }
			set { _webICP = value; }
		}


		/// <summary>
		/// 配置文件中的审核通过邮件发送文字
		/// </summary>
		public string Pass
		{
			get { return _Pass; }
			set { _Pass = value; }
		}

		/// <summary>
		/// 配置文件中的审核未通过邮件发送文字
		/// </summary>
		public string NotPass
		{
			get { return _NotPass; }
			set { _NotPass = value; }
		}
		/// <summary>
		/// 配置文件中的注册邮件发送文字
		/// </summary>
		public string Register
		{
			get { return _register; }
			set { _register = value; }
		}

		/// <summary>
		/// 配置文件中的忘记密码邮件发送文字
		/// </summary>
		public string Forgetpwd
		{
			get { return _forgetpwd; }
			set { _forgetpwd = value; }
		}

		/// <summary>
		/// 邮箱服务器
		/// </summary>
		public string EmailServer
		{
			get { return _EmailServer; }
			set { _EmailServer = value; }
		}

		/// <summary>
		/// Email地址
		/// </summary>
		public string EmailAddress
		{
			get { return _EmailAddress; }
			set { _EmailAddress = value; }
		}
		/// <summary>
		/// Email密码
		/// </summary>
		public string EmailPassWord
		{
			get { return _EmailPassWord; }
			set { _EmailPassWord = value; }
		}
		/// <summary>
		/// 页面Title
		/// </summary>
		public string PageTitle
		{
			get { return _PageTitle; }
			set { _PageTitle = value; }
		}
	
		/// <summary>
		/// DAL数据层名称
		/// </summary>
		public string DalPath
		{
			get { return _DALPath; }
			set { _DALPath = value; }
		}
		/// <summary>
		/// 默认重设的密码
		/// </summary>
		public string DefaultPwd
		{
			get { return _DefaultPwd; }
			set { _DefaultPwd = value; }
		}
		/// <summary>
		/// 默认图片
		/// </summary>
		public string DefaultPicPath
		{
			get { return _DefaultPicPath; }
			set { _DefaultPicPath = value; }
		}
		/// <summary>
		/// 网站服务邮箱
		/// </summary>
		public string WebServerEmail
		{
			get { return _WebServerEmail; }
			set { _WebServerEmail = value; }
		}
		/// <summary>
		/// 网站服务电话
		/// </summary>
		public string WebServerPhone
		{
			get { return _WebServerPhone; }
			set { _WebServerPhone = value; }
		}

		/// <summary>
		/// BBSURL
		/// </summary>
		public string BBSURL
		{
			get { return _BBSURL; }
			set { _BBSURL = value; }
		}
		/// <summary>
		/// BBSDBType
		/// </summary>
		public string BBSDBType
		{
			get { return _BBSDBType; }
			set { _BBSDBType = value; }
		}

		/// <summary>
		/// BBSConnStr
		/// </summary>
		public string BBSConnStr
		{
			get { return _BBSConnStr; }
			set { _BBSConnStr = value; }
		}
		/// <summary>
		/// 农副产品URL
		/// </summary>
		public string NFCPURL
		{
			get { return _NFCPURL; }
			set { _NFCPURL = value; }
		}
		/// <summary>
		/// 仓储管理系统
		/// </summary>
		public string WMSURL
		{
			get { return _WMSURL; }
			set { _WMSURL = value; }
		}
		/// <summary>
		/// OAURL
		/// </summary>
		public string OAURL
		{
			get { return _OAURL; }
			set { _OAURL = value; }
		}
		/// <summary>
		/// 运输管理系统
		/// </summary>
		public string TMSURL
		{
			get { return _TMSURL; }
			set { _TMSURL = value; }
		}

		#endregion

		#region Web.Config配置文件的AppSettings
		string _upLoadFolder = string.Empty;

		/// <summary>
		/// 上传文件的文件夹"/Upload/"
		/// </summary>
		public string UploadFolder
		{
			get { return _upLoadFolder; }
			set { _upLoadFolder = value; }
		}

		private int _upLoadSize;

		/// <summary>
		/// 最大文件上传大小
		/// </summary>
		public  int UpLoadSize
		{
			get { return _upLoadSize; }
			set { _upLoadSize = value; }
		}

		#endregion

		/// <summary>
		/// 网站配置
		/// </summary>
		public static Config Settings
		{
			get
			{
				lock (_LockObject)
				{
					if (null == _config)
					{
						_config = new Config();
						_config.iniSett();
					}
				}
				
				return _config;
			}
		}

		/// <summary>
		/// 初始化或重置配置文件
		/// </summary>
		public static void Initialize()
		{
			lock (_LockObject)
			{
				if (null == _config)
				{
					_config = new Config();
				}
				_config.iniSett();
			}
		}

		private void iniSett()
		{
			try
			{
				_upLoadFolder = ConfigHelper.GetAppString("UploadFolder");
				_upLoadSize = ConfigHelper.GetAppInt("UpLoadSize");
				string _configPath = ConfigHelper.GetAppString("configpath");

				if (_upLoadFolder.StartsWith("~"))
				{
					_upLoadFolder = _upLoadFolder.Substring(1);
				}

				if (!_upLoadFolder.EndsWith("/"))
					_upLoadFolder += "/";

				XmlDocument doc = new XmlDocument();

				doc.Load(HttpContext.Current.Server.MapPath(_configPath));

				_BBSURL = XMLHelper.GetSingleNodeValue(doc, "sysconfig/BBSURL");
				_BBSDBType = XMLHelper.GetSingleNodeValue(doc, "sysconfig/BBSDBType");
				_BBSConnStr = XMLHelper.GetSingleNodeValue(doc, "sysconfig/BBSConnStr");
				_NFCPURL = XMLHelper.GetSingleNodeValue(doc, "sysconfig/NFCPURL");
				_WMSURL = XMLHelper.GetSingleNodeValue(doc, "sysconfig/WMSURL");
				_OAURL = XMLHelper.GetSingleNodeValue(doc, "sysconfig/OAURL");
				_TMSURL = XMLHelper.GetSingleNodeValue(doc, "sysconfig/TMSURL");


				_forgetpwd = XMLHelper.GetSingleNodeValue(doc, "sysconfig/email/forgetpwd", false);
				_register =  XMLHelper.GetSingleNodeValue(doc, "sysconfig/email/register", false);
				_NotPass = XMLHelper.GetSingleNodeValue(doc, "sysconfig/email/NotPass", false);
				_Pass = XMLHelper.GetSingleNodeValue(doc, "sysconfig/email/Pass", false);


				_EmailServer = XMLHelper.GetSingleNodeValue(doc, "sysconfig/emailserver");
				_EmailAddress = XMLHelper.GetSingleNodeValue(doc, "sysconfig/emailaddress");
				_EmailPassWord = XMLHelper.GetSingleNodeValue(doc, "sysconfig/emailpassword");

				_PageTitle = XMLHelper.GetSingleNodeValue(doc, "sysconfig/PageTitle");

				_DALPath = XMLHelper.GetSingleNodeValue(doc, "sysconfig/DALPath");
				_DefaultPwd = XMLHelper.GetSingleNodeValue(doc, "sysconfig/defaultpwd");
				_DefaultPicPath = XMLHelper.GetSingleNodeValue(doc, "sysconfig/defaultpic");
				string allext = XMLHelper.GetSingleNodeValue(doc, "sysconfig/AllowExt");
				_allowExt = allext.Split(new char[] {','}, StringSplitOptions.RemoveEmptyEntries);

				_WebServerEmail = XMLHelper.GetSingleNodeValue(doc, "sysconfig/webemail");

				_WebServerPhone = XMLHelper.GetSingleNodeValue(doc, "sysconfig/webphone");

				_webICP = XMLHelper.GetSingleNodeValue(doc, "sysconfig/webICP");
				_webkeyword = XMLHelper.GetSingleNodeValue(doc, "sysconfig/webkeyword");
				_webdescription = XMLHelper.GetSingleNodeValue(doc, "sysconfig/webdescription");
			}
			catch(Exception ex)
			{
				Log.Error(ex.Message, ex);
			}
		}
	}
}