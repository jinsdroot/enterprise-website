using DevNet.Common.Entity;

namespace Cnkj.Utility
{
    /// <summary>
    /// 针对自动增长型字段的DevNet的逻辑层操作扩展接口
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TCondition"></typeparam>
    public interface IBLLExt<T, TCondition> : IBLLManager<T, TCondition> where T : class, IEntity
    {
    	/// <summary>
    	/// 保存数据，字段ID为自动增长型，ID>0则Update否则Insert。
    	/// </summary>
    	/// <param name="objEntity"></param>
		
    	/// <param name="fieldsName"></param>
    	void Save(T objEntity,params string[] fieldsName);
    }
}