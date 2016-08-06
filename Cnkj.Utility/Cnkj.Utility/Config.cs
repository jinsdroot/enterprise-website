using System;
using System.Web;
using System.Xml;
using Common;
using DevNet.Common.Logger;

namespace Cnkj.Utility
{
	/// <summary>
	/// ��վ���ò�������~/AppCode/SysConfig.config�ļ��л�ȡ���Ժ���ṩ������չ
	/// </summary>
	public class Config
	{
		private static Config _config;
		private static readonly object _LockObject = new object();

		#region===����====
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
		/// ��վ�����ϴ�����չ��
		/// </summary>
		public string[] AllowExt
		{
			get { return _allowExt; }
			set { _allowExt = value; }
		}

		/// <summary>
		/// ��վ���ʹؼ���
		/// </summary>
		public string WebKeyword
		{
			get { return _webkeyword; }
			set { _webkeyword = value; }
		}
		/// <summary>
		/// ��վ��������
		/// </summary>
		public string WebDescription
		{
			get { return _webdescription; }
			set { _webdescription = value; }
		}

		private string _webdescription;

		/// <summary>
		/// ��վ����
		/// </summary>
		public string WebICP
		{
			get { return _webICP; }
			set { _webICP = value; }
		}


		/// <summary>
		/// �����ļ��е����ͨ���ʼ���������
		/// </summary>
		public string Pass
		{
			get { return _Pass; }
			set { _Pass = value; }
		}

		/// <summary>
		/// �����ļ��е����δͨ���ʼ���������
		/// </summary>
		public string NotPass
		{
			get { return _NotPass; }
			set { _NotPass = value; }
		}
		/// <summary>
		/// �����ļ��е�ע���ʼ���������
		/// </summary>
		public string Register
		{
			get { return _register; }
			set { _register = value; }
		}

		/// <summary>
		/// �����ļ��е����������ʼ���������
		/// </summary>
		public string Forgetpwd
		{
			get { return _forgetpwd; }
			set { _forgetpwd = value; }
		}

		/// <summary>
		/// ���������
		/// </summary>
		public string EmailServer
		{
			get { return _EmailServer; }
			set { _EmailServer = value; }
		}

		/// <summary>
		/// Email��ַ
		/// </summary>
		public string EmailAddress
		{
			get { return _EmailAddress; }
			set { _EmailAddress = value; }
		}
		/// <summary>
		/// Email����
		/// </summary>
		public string EmailPassWord
		{
			get { return _EmailPassWord; }
			set { _EmailPassWord = value; }
		}
		/// <summary>
		/// ҳ��Title
		/// </summary>
		public string PageTitle
		{
			get { return _PageTitle; }
			set { _PageTitle = value; }
		}
	
		/// <summary>
		/// DAL���ݲ�����
		/// </summary>
		public string DalPath
		{
			get { return _DALPath; }
			set { _DALPath = value; }
		}
		/// <summary>
		/// Ĭ�����������
		/// </summary>
		public string DefaultPwd
		{
			get { return _DefaultPwd; }
			set { _DefaultPwd = value; }
		}
		/// <summary>
		/// Ĭ��ͼƬ
		/// </summary>
		public string DefaultPicPath
		{
			get { return _DefaultPicPath; }
			set { _DefaultPicPath = value; }
		}
		/// <summary>
		/// ��վ��������
		/// </summary>
		public string WebServerEmail
		{
			get { return _WebServerEmail; }
			set { _WebServerEmail = value; }
		}
		/// <summary>
		/// ��վ����绰
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
		/// ũ����ƷURL
		/// </summary>
		public string NFCPURL
		{
			get { return _NFCPURL; }
			set { _NFCPURL = value; }
		}
		/// <summary>
		/// �ִ�����ϵͳ
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
		/// �������ϵͳ
		/// </summary>
		public string TMSURL
		{
			get { return _TMSURL; }
			set { _TMSURL = value; }
		}

		#endregion

		#region Web.Config�����ļ���AppSettings
		string _upLoadFolder = string.Empty;

		/// <summary>
		/// �ϴ��ļ����ļ���"/Upload/"
		/// </summary>
		public string UploadFolder
		{
			get { return _upLoadFolder; }
			set { _upLoadFolder = value; }
		}

		private int _upLoadSize;

		/// <summary>
		/// ����ļ��ϴ���С
		/// </summary>
		public  int UpLoadSize
		{
			get { return _upLoadSize; }
			set { _upLoadSize = value; }
		}

		#endregion

		/// <summary>
		/// ��վ����
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
		/// ��ʼ�������������ļ�
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