using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Web;

namespace Common
{
    /// <summary>
    /// 文件操作类
    /// </summary>
    public static class FileHelper
    { 
        /// <summary>
        /// 获取全路径中的文件名，如存在用“_”+数字改名,返回绝对路径, 路径中的目录不存在自动创建目录
        /// </summary>
        /// <param name="fileFullName">文件全路径</param>
        /// <returns></returns>
        public static string ChangeFileName(string fileFullName)
        {
            string tmpName = StringPlus.MapPath(fileFullName);
            string filename = Path.GetFileNameWithoutExtension(tmpName);
            string ext = Path.GetExtension(tmpName);
            string path = tmpName.Substring(0, tmpName.LastIndexOf("\\"));
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            
            int i = Directory.GetFiles(path, filename + "*", System.IO.SearchOption.TopDirectoryOnly).Length;
            while (File.Exists(tmpName))
            {
                i++;
                tmpName = path + "\\" + filename + "_" + (i + 1).ToString() + ext;
            }
            return tmpName;
        }

        /// <summary>
        /// 根据时间+随机数重命名
        /// </summary>
        /// <returns></returns>
        public static string GetRandFileName()
        {
            Random rd = new Random();
            return DateTime.Now.ToString("yyyyMMddHHmmss") + rd.Next(1000).ToString();
        }


        /// <summary>
        /// 回发文件，参数为文件绝对全路径
        /// </summary>
        /// <param name="page"></param>
        /// <param name="fileFullName">文件绝对全路径</param>
        public static void WriteFile(System.Web.UI.Page page, string fileFullName)
        {
            page.Response.Clear();
            page.Response.ClearHeaders();
            page.Response.Buffer = false;

            // page.Response.Charset = "GB2312";
            //page.Response.ContentEncoding = System.Text.Encoding.UTF8;

            page.Response.ContentType = "application/octet-stream";// "application/ms-excel";
            page.Response.AppendHeader("Content-Disposition", "attachment;filename=" + System.Web.HttpUtility.UrlEncode(fileFullName, System.Text.Encoding.UTF8).Replace("+", "%20"));
            FileInfo info = new FileInfo(fileFullName);
            page.Response.AppendHeader("Content-Length", info.Length.ToString());  //显示文件长度 %20为空格

            page.Response.WriteFile(fileFullName);
            //try
            //{
                page.Response.Flush();
                HttpContext.Current.ApplicationInstance.CompleteRequest();
                //page.Response.End();
            //}
            //catch { }
        }


        /// <summary>
        /// 创建目录
        /// </summary>
        /// <param name="FileOrPath">文件或目录 文件请带上"."扩展名否则将视为目录创建</param>
        public static void CreateDirectory(string FileOrPath)
        {
            if (!string.IsNullOrEmpty(FileOrPath))
            {
                string path;
                if (FileOrPath.Contains("."))
                    path = Path.GetDirectoryName(FileOrPath);
                else
                    path = FileOrPath;

                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
            }
        }

    	/// <summary>
    	/// 删除文件或目录
    	/// </summary>
    	/// <param name="filePath">文件或目录，可以为虚拟路径或绝对路径</param>
    	/// <param name="isDir">是否目录</param>
    	public static void DeletePath(string filePath, bool isDir)
		{
            if (filePath == null)
                return;
			if(string.IsNullOrEmpty(filePath.Trim()))
			{
				return;
			}
			string file = StringPlus.MapPath(filePath);
			if (isDir)
			{
				if (Directory.Exists(file))
				{
					Directory.Delete(file, true);
					return;
				}
			}
			else
			{
				if (File.Exists(file))
				{
					File.Delete(file);
				}
			}
		}

    	/// <summary>
        /// 读取文件
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="encoding"></param>
        /// <param name="isCache"></param>
        /// <returns></returns>
        public static string ReadFile(string filename, Encoding encoding, bool isCache)
        {
            string body;
            if (isCache)
            {
                body =(string)WebCache.GetCache("filename");// (string)HttpContext.Current.WebCache[filename];// 
                if (body == null)
                {
                    body = ReadFile(filename, encoding, false);
                    WebCache.SetCache("filename", filename, DateTime.Now.AddMinutes(180), TimeSpan.Zero);
                    //HttpContext.Current.WebCache.Add(filename, body, new System.Web.Caching.CacheDependency(filename), DateTime.MaxValue, TimeSpan.Zero, System.Web.Caching.CacheItemPriority.High, null);
                }
            }
            else
            {
                using (StreamReader sr = new StreamReader(filename, encoding))
                {
                    body = sr.ReadToEnd();
                }
            }

            return body;
        }

        /// <summary>
        /// 备份文件
        /// </summary>
        /// <param name="sourceFileName">源文件名</param>
        /// <param name="destFileName">目标文件名</param>
        /// <param name="overwrite">当目标文件存在时是否覆盖</param>
        /// <returns>操作是否成功</returns>
        public static bool BackupFile(string sourceFileName, string destFileName, bool overwrite)
        {
            if (!System.IO.File.Exists(sourceFileName))
            {
                throw new FileNotFoundException(sourceFileName + "文件不存在！");
            }
            if (!overwrite && System.IO.File.Exists(destFileName))
            {
                return false;
            }
            try
            {
                System.IO.File.Copy(sourceFileName, destFileName, true);
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        /// <summary>
        /// 备份文件,当目标文件存在时覆盖
        /// </summary>
        /// <param name="sourceFileName">源文件名</param>
        /// <param name="destFileName">目标文件名</param>
        /// <returns>操作是否成功</returns>
        public static bool BackupFile(string sourceFileName, string destFileName)
        {
            return BackupFile(sourceFileName, destFileName, true);
        }


        /// <summary>
        /// 恢复文件
        /// </summary>
        /// <param name="backupFileName">备份文件名</param>
        /// <param name="targetFileName">要恢复的文件名</param>
        /// <param name="backupTargetFileName">要恢复文件再次备份的名称,如果为null,则不再备份恢复文件</param>
        /// <returns>操作是否成功</returns>
        public static bool RestoreFile(string backupFileName, string targetFileName, string backupTargetFileName)
        {
            try
            {
                if (!System.IO.File.Exists(backupFileName))
                {
                    throw new FileNotFoundException(backupFileName + "文件不存在！");
                }
                if (backupTargetFileName != null)
                {
                    if (!System.IO.File.Exists(targetFileName))
                    {
                        throw new FileNotFoundException(targetFileName + "文件不存在！无法备份此文件！");
                    }
                    else
                    {
                        System.IO.File.Copy(targetFileName, backupTargetFileName, true);
                    }
                }
                System.IO.File.Delete(targetFileName);
                System.IO.File.Copy(backupFileName, targetFileName);
            }
            catch (Exception e)
            {
                throw e;
            }
            return true;
        }

        public static bool RestoreFile(string backupFileName, string targetFileName)
        {
            return RestoreFile(backupFileName, targetFileName, null);
        }

        /// <summary>
        /// 获取文件夹占用空间大小
        /// </summary>
        /// <param name="Path"></param>
        /// <returns></returns>
        public static long GetDirecotrySize(string Path)
        {
            long result = 0;

            if (!Directory.Exists(Path))
                return result;

            DirectoryInfo info = new DirectoryInfo(Path);
            foreach (FileInfo fiInfo in info.GetFiles())
            {
                result += fiInfo.Length;
            }
            foreach (DirectoryInfo dirInfo in info.GetDirectories())
            {
                result += GetDirecotrySize(dirInfo.FullName);
            }

            return result;
        }
      
    }
}
