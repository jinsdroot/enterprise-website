using System;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common;
using Common.DEncrypt;
using DevNet.Common.Logger;

namespace Cnkj.Utility
{
	/// <summary>
	/// Cnkj Web共用类，提供一些项目常用方法，页面及用户控件都可以使用
	/// </summary>
    public class WebCommon
	{
//        #region===常量设置====
//        /// <summary>
//        /// 页面PageTitle
//        /// </summary>
////		public static  string PageTitle = ConfigHelper.GetAppString("PageTitle");
////
//        /// <summary>
//        /// 上传文件的文件夹"/Upload/"
//        /// </summary>
////		public static  string UploadFolder = ConfigHelper.GetAppString("UploadFolder");
////
//        /// <summary>
//        /// DAL数据层名称
//        /// </summary>
////		public static  string DALPath = ConfigHelper.GetAppString("WEBDAL");
////
//        /// <summary>
//        /// 最大文件上传大小
//        /// </summary>
////		public static  int UpLoadSize = ConfigHelper.GetAppInt("UpFileSize");
////
//        /// <summary>
//        /// 默认重设的密码
//        /// </summary>
////		public static  string DefaultPwd = ConfigHelper.GetAppString("defaultpwd");
////
//        /// <summary>
//        /// 默认图片路径
//        /// </summary>
////		public static  string DefaultPicPath = ConfigHelper.GetAppString("defaultpic");
//        /// <summary>
//        /// 系统配置文件路径~/appcode/SysConfig.config
//        /// </summary>
////		public static  string ConfigPath = ConfigHelper.GetAppString("configpath");
//        /// <summary>
//        /// 网站服务邮箱
//        /// </summary>
////		public static  string WebServerEmail = ConfigHelper.GetAppString("webemail");
////
//        /// <summary>
//        /// 网站服务电话
//        /// </summary>
////		public static  string WebServerPhone = ConfigHelper.GetAppString("webphone");

//        #endregion

//		static WebCommon()
//		{
//			if (UploadFolder.StartsWith("~"))
//			{
//				UploadFolder = UploadFolder.Substring(1);
//			}
//		}

		/// <summary>
        /// md5加密取8--24位
        /// </summary>
        /// <param name="pwdStr"></param>
        /// <returns></returns>
        public static string Md5Enctry(string pwdStr)
        {
            return MD5.GetMd5Hash(pwdStr, 8, 16);
        } 
		/// <summary>
		/// 获取文件上传的虚拟目录 /upload/2010-10/
		/// </summary>
		/// <returns></returns>
		public static string GetVirtualDir()
		{
			return Config.Settings.UploadFolder + DateTime.Now.ToString("yyyy-MM") + "/";//每一月一个文件夹吧！
		}

        /// <summary>
        /// 获取上传文件随机文件名，返回绝对路径地址
        /// </summary>
        /// <param name="extName">扩展名【请包含 . 】</param>
        /// <param name="virtualPathName">虚路径名(包括文件名称)【/upload/..../filename.ext】</param>
        /// <param name="fileName">文件名带扩展名</param>
        /// <returns></returns>
        public static string GetUploadRandFileName(string extName, out string virtualPathName, out string fileName)
        {
        	return UploadFile.GetUploadRandFileName(GetVirtualDir(), extName, out virtualPathName, out fileName);
        }

		/// <summary>
		/// 上传文件或图片,返回保存后的文件虚路径名(包括文件名称)【/upload/..../filename.ext】，统一保存到UpLoad文件夹下
		/// </summary>
		/// <param name="fileUp">FileUplad控件</param>
		/// <param name="oldFileUp">原有文件虚拟路径</param>
		/// <param name="isDelOldFile">是否删除原有文件</param>
		/// <returns></returns>
		public static string UpLoadFile(FileUpload fileUp, string oldFileUp, bool isDelOldFile)
		{
			return UploadFile.UpLoadFile(fileUp, GetVirtualDir(),null,Config.Settings.UpLoadSize, oldFileUp, isDelOldFile);
		}

		/// <summary>
		/// 上传文件或图片,返回保存后的文件虚路径名(包括文件名称)【/upload/..../filename.ext】，统一保存到UpLoad文件夹下
		/// </summary>
		/// <param name="fileUp">FileUplad控件</param>
		/// <param name="oldFileUp">原有文件虚拟路径</param>
		/// <param name="isDelOldFile">是否删除原有文件</param>
		/// <param name="isRandFileName">是否使用随机文件名,如不是随机文件名，将保存原有文件名_?.ext格式</param>
		/// <returns></returns>
		public static string UpLoadFile(FileUpload fileUp, string oldFileUp, bool isDelOldFile,bool isRandFileName)
		{
			return UploadFile.UpLoadFile(fileUp, GetVirtualDir(),null,Config.Settings.UpLoadSize, oldFileUp, isDelOldFile, isRandFileName);
		}

		/// <summary>
		/// 返回当前系统日期的标准格式 yyyy-MM-dd
		/// </summary>
		public static string GetShortDate(object obj)
		{
			return DateHelper.GetShortDate(obj);
		}

		/// <summary>
        /// 获取图片地址
        /// </summary>
        /// <param name="page"></param>
        /// <param name="sPic"></param>
        /// <returns></returns>
		public static string GetPicPath(Page page, string sPic)
		{
			if (string.IsNullOrEmpty(sPic))
			{
				if (string.IsNullOrEmpty(Config.Settings.DefaultPicPath))
					return "";
				return page.ResolveClientUrl(Config.Settings.DefaultPicPath);
			}
			if (sPic.StartsWith("http://"))
			{
				return sPic;
			}
			string stemp = sPic.StartsWith(Config.Settings.UploadFolder, StringComparison.OrdinalIgnoreCase)
			               	? sPic
			               	: Config.Settings.UploadFolder + sPic;
			try
			{
				if (!File.Exists(StringPlus.MapPath(stemp)))
				{
					if (string.IsNullOrEmpty(Config.Settings.DefaultPicPath))
						return "";
					return page.ResolveClientUrl(Config.Settings.DefaultPicPath);
				}
			}
			catch
			{
				if (string.IsNullOrEmpty(Config.Settings.DefaultPicPath))
					return "";
				return page.ResolveClientUrl(Config.Settings.DefaultPicPath);
			}

			return page.ResolveClientUrl(stemp);
		}
	}
}