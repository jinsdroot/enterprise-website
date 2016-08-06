using System;
using System.Text;
using System.Security.Cryptography;

namespace Common.DEncrypt
{
    /// <summary>
    /// 得到随机安全码（哈希加密）。
    /// </summary>
    public static class HashEncode
    {
    
        /// <summary>
        /// 得到随机哈希加密字符串
        /// </summary>
        /// <returns></returns>
        public static string GetSecurity()
        {			
           return HashEncoding(GetRandomValue());		
        }
        /// <summary>
        /// 得到一个随机数值
        /// </summary>
        /// <returns></returns>
        public static string GetRandomValue()
        {			
            Random Seed = new Random();
            return  Seed.Next(1, int.MaxValue).ToString();
        }
        /// <summary>
        /// 哈希加密一个字符串
        /// </summary>
        /// <param name="Security"></param>
        /// <returns></returns>
        public static string HashEncoding(string Security)
        {						
            byte[] Value;
            UnicodeEncoding Code = new UnicodeEncoding();
            byte[] Message = Code.GetBytes(Security);
            SHA512Managed Arithmetic = new SHA512Managed();
            Value = Arithmetic.ComputeHash(Message);
            Security = "";
            foreach(byte o in Value)
            {
                Security += (int) o + "O";
            }
            return Security;
        }
    }
}