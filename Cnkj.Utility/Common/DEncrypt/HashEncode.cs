using System;
using System.Text;
using System.Security.Cryptography;

namespace Common.DEncrypt
{
    /// <summary>
    /// �õ������ȫ�루��ϣ���ܣ���
    /// </summary>
    public static class HashEncode
    {
    
        /// <summary>
        /// �õ������ϣ�����ַ���
        /// </summary>
        /// <returns></returns>
        public static string GetSecurity()
        {			
           return HashEncoding(GetRandomValue());		
        }
        /// <summary>
        /// �õ�һ�������ֵ
        /// </summary>
        /// <returns></returns>
        public static string GetRandomValue()
        {			
            Random Seed = new Random();
            return  Seed.Next(1, int.MaxValue).ToString();
        }
        /// <summary>
        /// ��ϣ����һ���ַ���
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