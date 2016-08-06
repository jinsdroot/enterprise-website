using System;
using System.Security.Cryptography;  
using System.Text;

namespace Common.DEncrypt
{
    /// <summary>
    /// Encrypt ��ժҪ˵����
    /// </summary>
    public static class DEncrypt
    {

        #region ʹ�� ȱʡ��Կ�ַ��� ����/����string

        /// <summary>
        /// ʹ��ȱʡ��Կ�ַ�������string
        /// </summary>
        /// <param name="original">����</param>
        /// <returns>����</returns>
        public static string Encrypt(string original)
        {
            return Encrypt(original,"SJFE");
        }
        /// <summary>
        /// ʹ��ȱʡ��Կ�ַ�������string
        /// </summary>
        /// <param name="original">����</param>
        /// <returns>����</returns>
        public static string Decrypt(string original)
        {
            return Decrypt(original, "SJFE", System.Text.Encoding.Default);
        }

        #endregion

        #region ʹ�� ������Կ�ַ��� ����/����string
        /// <summary>
        /// ʹ�ø�����Կ�ַ�������string
        /// </summary>
        /// <param name="original">ԭʼ����</param>
        /// <param name="key">��Կ</param>
        /// <returns>����</returns>
        public static string Encrypt(string original, string key)  
        {  
            byte[] buff = System.Text.Encoding.Default.GetBytes(original);  
            byte[] kb = System.Text.Encoding.Default.GetBytes(key);
            return Convert.ToBase64String(Encrypt(buff, kb));     
        }
        /// <summary>
        /// ʹ�ø�����Կ�ַ�������string
        /// </summary>
        /// <param name="original">����</param>
        /// <param name="key">��Կ</param>
        /// <returns>����</returns>
        public static string Decrypt(string original, string key)
        {
            return Decrypt(original,key,System.Text.Encoding.Default);
        }

        /// <summary>
        /// ʹ�ø�����Կ�ַ�������string,����ָ�����뷽ʽ����
        /// </summary>
        /// <param name="encrypted">����</param>
        /// <param name="key">��Կ</param>
        /// <param name="encoding">�ַ����뷽��</param>
        /// <returns>����</returns>
        public static string Decrypt(string encrypted, string key,Encoding encoding)  
        {       
            byte[] buff = Convert.FromBase64String(encrypted);  
            byte[] kb = System.Text.Encoding.Default.GetBytes(key);
            return encoding.GetString(Decrypt(buff,kb));      
        }  
        #endregion

        #region ʹ�� ȱʡ��Կ�ַ��� ����/����/byte[]
        /// <summary>
        /// ʹ��ȱʡ��Կ�ַ�������byte[]
        /// </summary>
        /// <param name="encrypted">����</param>
        /// <returns>����</returns>
        public static byte[] Decrypt(byte[] encrypted)  
        {
            byte[] key = System.Text.Encoding.Default.GetBytes("SJFE"); 
            return Decrypt(encrypted,key);     
        }
        /// <summary>
        /// ʹ��ȱʡ��Կ�ַ�������
        /// </summary>
        /// <param name="original">ԭʼ����</param>
        /// <returns>����</returns>
        public static byte[] Encrypt(byte[] original)  
        {
            byte[] key = System.Text.Encoding.Default.GetBytes("SJFE"); 
            return Encrypt(original,key);     
        }  
        #endregion

        #region  ʹ�� ������Կ ����/����/byte[]

        /// <summary>
        /// ʹ�ø�����Կ����
        /// </summary>
        /// <param name="original">����</param>
        /// <param name="key">��Կ</param>
        /// <returns>����</returns>
        public static byte[] Encrypt(byte[] original, byte[] key)  
        {  
            TripleDESCryptoServiceProvider des = new TripleDESCryptoServiceProvider();       
            des.Key =  MD5.GetMd5Hash(key);
            des.Mode = CipherMode.ECB;  
     
            return des.CreateEncryptor().TransformFinalBlock(original, 0, original.Length);     
        }  

        /// <summary>
        /// ʹ�ø�����Կ��������
        /// </summary>
        /// <param name="encrypted">����</param>
        /// <param name="key">��Կ</param>
        /// <returns>����</returns>
        public static byte[] Decrypt(byte[] encrypted, byte[] key)  
        {  
            TripleDESCryptoServiceProvider des = new TripleDESCryptoServiceProvider();
            des.Key = MD5.GetMd5Hash(key);  
            des.Mode = CipherMode.ECB;  

            return des.CreateDecryptor().TransformFinalBlock(encrypted, 0, encrypted.Length);
        }  
  
        #endregion

		

		
    }
}