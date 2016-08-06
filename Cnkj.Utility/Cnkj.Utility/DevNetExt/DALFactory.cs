using System;
using System.Configuration;
using Common;
using DevNet.Cache;
using DevNet.Common.Entity;
using DevNet.Common.Logger;

namespace Cnkj.Utility
{
    /// <summary>
    /// 数据操作对象的工厂， 依赖于DAL层类名的字符串（忽略大小写）
    /// </summary>
    public class DALFactory
    {
    	
        /// <summary>
        /// 获取数据操作对象，依赖于DAL层类名的字符串（忽略大小写）
        /// </summary>
        /// <typeparam name="TDAL">DAL层接口或类，派生自IDataManager接口</typeparam>
        /// <typeparam name="T">实体类型</typeparam>
        /// <typeparam name="TCondition">查询条件【无查询条件用object替代】</typeparam>
        /// <param name="className">DAL层类名</param>
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
                        Log.Warning(String.Format("创建DAL层对象失败，请确认配置文件中正确设置DAL程序集名称或确认是否存在 {0} 的具体操作类", className));
                        return default(TDAL);
                    }

                    DataCache.SetCacheObj(className, obj);
                }
                return (TDAL) ((TDAL) obj).Clone();
            }
            catch (Exception ex)
            {
                Log.Error(String.Format("创建DAL层对象失败，请确认配置文件中正确设置DAL程序集名称或确认是否存在 {0} 的具体操作类并且该操作类是否派生自IDataManager。", className), ex);
                return default(TDAL);
            }
        }
    }
}