using DevNet.Common.Entity;

namespace Cnkj.Utility
{
    /// <summary>
    /// 针对自动增长型字段的DevNet的逻辑层操作扩展
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TCondition"></typeparam>
    public abstract class BLLExt<T, TCondition> : BLLManager<T, TCondition>, IBLLExt<T, TCondition>
        where T : EntityBase, IEntity, new()
    {
        #region IBLLExt<T,TCondition> 成员
		///// <summary>
		///// 保存数据，字段ID为自动增长型，ID>0则Update否则Insert。可重写
		///// </summary>
		///// <param name="objEntity"></param>
		//public virtual void Save(T objEntity)
		//{
		//    if (objEntity.ID > 0)
		//    {
		//        Update(objEntity);//调用逻辑的方法，便于参与逻辑操作
		//    }
		//    else
		//    {
		//        Insert(objEntity);
		//    }
		//}

    	/// <summary>
    	/// 保存数据，字段ID为自动增长型，ID>0则Update否则Insert。可重写
    	/// </summary>
    	/// <param name="objEntity"></param>
    	/// <param name="fieldsName">在Update方法是更新排除的字段</param>
    	public virtual void Save(T objEntity,params string[] fieldsName)
		{
			if (objEntity.ID > 0)
			{
				Update(objEntity, fieldsName);//调用逻辑的方法，便于参与逻辑操作
			}
			else
			{                
                Insert(objEntity);
			}
		}
        #endregion
    }
}