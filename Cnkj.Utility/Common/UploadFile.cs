using System;
using System.IO;
using System.Web.UI.WebControls;

namespace Common
{
    /// <summary>
    /// 文件上传类
    /// </summary>
    public class UploadFile
    {
        #region 上传文件的方法
        /// <summary>   
        /// 上传文件方法   
        /// </summary>   
        /// <param name="myFileUpload">上传控件ID</param>   
        /// <param name="allowExtensions">允许上传的扩展文件名类型,如：string[] allowExtensions = { ".doc", ".xls", ".ppt", ".jpg", ".gif" };</param>   
        /// <param name="maxLength">允许上传的最大大小，以M为单位</param>   
        /// <param name="savePath">保存文件的目录，注意是绝对路径,如：Server.MapPath("~/upload/");</param>   
        /// <param name="saveName">保存的文件名，如果是""则以原文件名保存</param>   
        public static void Upload(FileUpload myFileUpload, string[] allowExtensions, int maxLength, string savePath, string saveName)
        {
			if (!myFileUpload.HasFile)
				return;

            // 文件格式是否允许上传   
            bool fileAllow = false;

            //检查是否有文件案   
            //if (myFileUpload.HasFile)
            //{
                // 检查文件大小, ContentLength获取的是字节，转成M的时候要除以2次1024 
            if (myFileUpload.PostedFile != null)
            {
                if (myFileUpload.PostedFile.ContentLength / 1024 / 1024 >= maxLength)
                {
                    throw new Exception("只能上传小于" + maxLength + "M的文件！");
                }

                //取得上传文件之扩展文件名，并转换成小写字母   
                string fileExtension = System.IO.Path.GetExtension(myFileUpload.FileName).ToLower();
                //string tmp = "";   // 存储允许上传的文件后缀名   
                //检查扩展文件名是否符合限定类型   
                for (int i = 0; i < allowExtensions.Length; i++)
                {
                    //tmp += i == allowExtensions.Length - 1 ? allowExtensions[i] : allowExtensions[i] + ",";
                    if (fileExtension == allowExtensions[i])
                    {
                        fileAllow = true;
						break;
                    }
                }

                if (fileAllow)
                {
                    try
                    {
                        string path = savePath + (saveName == "" ? myFileUpload.FileName : saveName);
                        //存储文件到文件夹   
                        myFileUpload.SaveAs(path);
                    }
                    catch //(Exception ex)
                    {
                        throw new Exception("上传文件失败！");
                    }
                }
                else
                {

                    throw new Exception("文件格式不符");

                }
            }
            //}
            //else
            //{
            //    throw new Exception("请选择要上传的文件！");
            //}
        }


    	/// <summary>
    	/// 获取上传文件随机文件名，返回绝对路径地址
    	/// </summary>
    	/// <param name="saveVirtualDir"></param>
    	/// <param name="extName">扩展名【请包含 . 】</param>
    	/// <param name="virtualPathName">虚路径名(包括文件名称)【/upload/..../filename.ext】</param>
    	/// <param name="fileName">文件名带扩展名</param>
    	/// <returns></returns>
    	public static string GetUploadRandFileName(string saveVirtualDir,string extName, out string virtualPathName, out string fileName)
		{
			fileName = FileHelper.GetRandFileName() + extName;
			virtualPathName = saveVirtualDir + fileName;
			string dir = StringPlus.MapPath(virtualPathName);
			FileHelper.CreateDirectory(dir);
			return dir;
		}

    	/// <summary>
    	/// 上传文件或图片,返回保存后的文件虚路径名(包括文件名称)【/upload/..../filename.ext】，统一保存到UpLoad文件夹下
    	/// </summary>
    	/// <param name="fileUp">FileUplad控件，保存的文件名称使用随机文件名</param>
		/// <param name="saveVirtualDir">保存的虚拟目录”/upload/”</param>
		/// <param name="allowExtensions">允许上传的文件扩展名，带".",null则不检查扩展名，如：string[] allowExtensions = { ".doc", ".xls", ".ppt", ".jpg", ".gif" };</param>   
		/// <param name="maxLength">允许上传的最大大小，以M为单位，0则不检查大小</param>   
    	/// <param name="oldVirtualFileUp">原有文件虚拟路径</param>
    	/// <param name="isDelOldFile">是否删除原有文件</param>
    	/// <returns></returns>
    	public static string UpLoadFile(FileUpload fileUp, string saveVirtualDir, string[] allowExtensions, int maxLength, string oldVirtualFileUp, bool isDelOldFile)
    	{
			if (fileUp.HasFile)
			{
				checkAllowUpLoad(fileUp,allowExtensions, maxLength);

				string virtualPathName, fileName;
				string fileFullPath = GetUploadRandFileName(saveVirtualDir,Path.GetExtension(fileUp.FileName), out virtualPathName, out fileName);
				fileUp.SaveAs(fileFullPath);
				if (isDelOldFile)
				{
					try
					{
						FileHelper.DeletePath(oldVirtualFileUp, false);
						//						if (!string.IsNullOrEmpty(oldFileUp))
						//					;		File.Delete(StringPlus.MapPath(oldFileUp));
					}
					catch
					{ }
				}
				return virtualPathName;
			}
			return oldVirtualFileUp;
		}

    	/// <summary>
    	/// 上传文件或图片,返回保存后的文件虚路径名(包括文件名称)【/upload/..../filename.ext】，统一保存到UpLoad文件夹下
    	/// </summary>
    	/// <param name="fileUp">FileUplad控件</param>
		/// <param name="saveVirtualDir">保存的虚拟目录”/upload/”</param>
		/// <param name="allowExtensions">允许上传的文件扩展名，带".",null则不检查扩展名，如：string[] allowExtensions = { ".doc", ".xls", ".ppt", ".jpg", ".gif" };</param>   
		/// <param name="maxLength">允许上传的最大大小，以M为单位，0则不检查大小</param>   

		/// <param name="oldVirtualFileUp">原有文件虚拟路径</param>
    	/// <param name="isDelOldFile">是否删除原有文件</param>
    	/// <param name="isRandFileName">是否使用随机文件名,如不是随机文件名，将保存原有文件名_?.ext格式</param>
    	/// <returns></returns>
		public static string UpLoadFile(FileUpload fileUp, string saveVirtualDir, string[] allowExtensions, int maxLength, string oldVirtualFileUp, bool isDelOldFile, bool isRandFileName)
		{
			if (isRandFileName)
			{
				return UpLoadFile(fileUp, saveVirtualDir,allowExtensions,maxLength, oldVirtualFileUp, isDelOldFile);
			}
			if (fileUp.HasFile)
			{
				checkAllowUpLoad(fileUp, allowExtensions, maxLength);

				
				string virtualPathName = saveVirtualDir + fileUp.FileName;
				string fileFullPathName = FileHelper.ChangeFileName(virtualPathName);
				virtualPathName = saveVirtualDir + Path.GetFileName(fileFullPathName);
				fileUp.SaveAs(fileFullPathName);
				if (isDelOldFile)
				{
					try
					{
						FileHelper.DeletePath(oldVirtualFileUp, false);
						//						if (!string.IsNullOrEmpty(oldFileUp))
						//							File.Delete(StringPlus.MapPath(oldFileUp));
					}
					catch
					{ }
				}
				return virtualPathName;
			}
			return oldVirtualFileUp;
		}



		private static void checkAllowUpLoad(FileUpload fileUp, string[] allowExtensions, int maxLength)
		{
			if (fileUp.HasFile == false || fileUp.PostedFile == null)
				return;
			if (allowExtensions == null || allowExtensions.Length == 0)
				return;
			if (maxLength == 0)
				return;

			if (fileUp.PostedFile.ContentLength / 1024 / 1024 >= maxLength)
			{
				throw new Exception("只能上传小于" + maxLength + "M的文件！");
			}

			string fileExtension = Path.GetExtension(fileUp.FileName);

			if (string.IsNullOrEmpty(fileExtension))
				throw new Exception("不允许上传该文件类型");

			bool fileAllow = false;
			foreach (string ext in allowExtensions)
			{
				if (fileExtension.Equals(ext, StringComparison.OrdinalIgnoreCase))
				{
					fileAllow = true;
					break;
				}
			}
			if (!fileAllow)
				throw new Exception("不允许上传该文件类型");
		}

        #endregion  

    }
}
