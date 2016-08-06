using System;
using System.Configuration;
using Common;
using DevNet.Cache;
using DevNet.Common.Entity;
using DevNet.Common.Logger;

namespace Cnkj.Utility
{
    /// <summary>
    /// ���ݲ�������Ĺ����� ������DAL���������ַ��������Դ�Сд��
    /// </summary>
    public class DALFactory
    {
    	
        /// <summary>
        /// ��ȡ���ݲ�������������DAL���������ַ��������Դ�Сд��
        /// </summary>
        /// <typeparam name="TDAL">DAL��ӿڻ��࣬������IDataManager�ӿ�</typeparam>
        /// <typeparam name="T">ʵ������</typeparam>
        /// <typeparam name="TCondition">��ѯ�������޲�ѯ������object�����</typeparam>
        /// <param name="className">DAL������</param>
        /// <returns></returns>
        public static TDAL GetDALObj<TDAL, T, TCondition>(string className)
            where T : class
            where TDAL : IDataManager<T, TCondition>
        {
            try
            {
                object obj = DataCache.GetCacheObj(className);
                if (obj == null)
                {
					obj = System.Reflection.Assembly.Load(Config.Settings.DalPath).CreateInstance(Config.Settings.DalPath + "." + className, true);
                    if (obj == null)
                    {
                        Log.Warning(String.Format("����DAL�����ʧ�ܣ���ȷ�������ļ�����ȷ����DAL�������ƻ�ȷ���Ƿ���� {0} �ľ��������", className));
                        return default(TDAL);
                    }

                    DataCache.SetCacheObj(className, obj);
                }
                return (TDAL) ((TDAL) obj).Clone();
            }
            catch (Exception ex)
            {
                Log.Error(String.Format("����DAL�����ʧ�ܣ���ȷ�������ļ�����ȷ����DAL�������ƻ�ȷ���Ƿ���� {0} �ľ�������ಢ�Ҹò������Ƿ�������IDataManager��", className), ex);
                return default(TDAL);
            }
        }
    }
}