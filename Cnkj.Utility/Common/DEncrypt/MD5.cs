using System;
using System.Collections.Generic;
 
using System.Text;
using System.Web.Security;
using System.Security.Cryptography;

namespace Common.DEncrypt
{
    /// <summary>
    /// MD5加密
    /// </summary>
    public class MD5
    {

        /// <summary>
        /// MD5加密
        /// </summary>
        /// <param name="original">数据源</param>
        /// <returns>摘要</returns>
        public static byte[] GetMd5Hash(byte[] original)
        {
            MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
            byte[] keyhash = hashmd5.ComputeHash(original);
            hashmd5 = null;
            return keyhash;
        }

        /// <summary>
        /// MD5加密
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static string GetMd5(byte[] bytes)
        {
            return Encoding.Default.GetString(GetMd5Hash(bytes));
        }

        /// <summary>
        /// 获取指定开始与结束长度之间的MD5Hash
        /// </summary>
        /// <param name="input"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public static string GetMd5Hash(string input,int startIndex,int endIndex)
        {
            return GetMd5Hash(input).Substring(startIndex, endIndex);
        }

        /// <summary>
        /// MD5加密
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string GetMd5Hash(string input)
        {
            System.Security.Cryptography.MD5 md5Hasher = System.Security.Cryptography.MD5.Create();
            byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(input));
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }


        /// <summary>
        /// MD5加密
        /// </summary>
        /// <param name="Text">使用Web加密方式</param>
        /// <returns>MD5值</returns>
        public static string GetMd5(string Text)
        {
            return FormsAuthentication.HashPasswordForStoringInConfigFile(Text, "MD5");
        }
    }
}