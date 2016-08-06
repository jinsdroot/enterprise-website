using System;
using System.Configuration;

namespace Common
{
	/// <summary>
	/// Config�����ࡾ�ṩ��ȡApp���ú�Connection����ֵ�ķ�����
	/// </summary>
	public static class ConfigHelper
	{
		/// <summary>
		/// �õ�AppSettings�е������ַ�����Ϣ
		/// </summary>
		/// <param name="key"></param>
		/// <returns></returns>
		public static string GetAppString(string key)
		{
            string CacheKey = "AppSettings-" + key;
            object objModel = WebCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = ConfigurationManager.AppSettings[key]; 
                    if (objModel != null)
                    {                        
                        WebCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(180), TimeSpan.Zero);
                    }
                }
                catch
                { }
            }
            return objModel==null?"":objModel.ToString();
		}

        /// <summary>
        /// ��ȡConnectStrings�е������ַ�����Ϣ
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetConnectString(string key)
        {
            string CacheKey = "ConnectionStrings-" + key;
            object objModel = WebCache.GetCache(CacheKey);
            if (objModel == null)
            { 
                try
                {
                    objModel = ConfigurationManager.ConnectionStrings[key].ConnectionString;
                    if (objModel != null)
                    {
                        WebCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(180), TimeSpan.Zero);
                    }
                }
                catch
                { }
            }
            return objModel == null ? "" : objModel.ToString();
        }

		/// <summary>
		/// �õ�AppSettings�е�����Bool��Ϣ
		/// </summary>
		/// <param name="key"></param>
		/// <returns></returns>
		public static bool GetAppBool(string key)
		{
			bool result = false;
			string cfgVal = GetAppString(key);
			if(!string.IsNullOrEmpty(cfgVal))
			{
				try
				{
					result = bool.Parse(cfgVal);
				}
				catch//(FormatException)
				{
					// Ignore format exceptions.
				}
			}
			return result;
		}
		/// <summary>
		/// �õ�AppSettings�е�����Decimal��Ϣ
		/// </summary>
		/// <param name="key"></param>
		/// <returns></returns>
		public static decimal GetAppDecimal(string key)
		{
			decimal result = 0;
			string cfgVal = GetAppString(key);
			if(!string.IsNullOrEmpty(cfgVal))
			{
				try
				{
					result = decimal.Parse(cfgVal);
				}
				catch(FormatException)
				{
					// Ignore format exceptions.
				}
			}

			return result;
		}
		/// <summary>
		/// �õ�AppSettings�е�����int��Ϣ
		/// </summary>
		/// <param name="key"></param>
		/// <returns></returns>
		public static int GetAppInt(string key)
		{
			int result = 0;
			string cfgVal = GetAppString(key);
			if(!string.IsNullOrEmpty(cfgVal))
			{
				try
				{
					result = int.Parse(cfgVal);
				}
				catch(FormatException)
				{
					// Ignore format exceptions.
				}
			}

			return result;
		}
	}
}
