using DevNet.Common;
using DevNet.Common.Entity;

namespace Cnkj.Utility
{
    /// <summary>
    /// 针对自动增长型字段的DevNet的数据操作扩展
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TCondition"></typeparam>
    public abstract class DALExt<T, TCondition> : DataManager<T, TCondition>, IDALExt<T, TCondition>
        where T : EntityBase, IEntity, new()
    {
        #region IDALExt<T,TCondition> 成员

        ///// <summary>
        ///// 保存数据，字段ID为自动增长型，ID>0则Update否则Insert。可重写
        ///// </summary>
        ///// <param name="objEntity"></param>
        ///// <returns></returns>
        //public virtual bool Save(T objEntity)
        //{
        //    if (objEntity.ID > 0)
        //    {
        //        return Update(objEntity);
        //    }
        //    return Insert(objEntity);
        //}

        /// <summary>
        /// 保存数据，字段ID为自动增长型，ID>0则Update否则Insert。可重写
        /// </summary>
        /// <param name="objEntity"></param>
        /// <param name="fieldsName">在Update方法是更新排除的字段</param>
        public bool Save(T objEntity, params string[] fieldsName)
        {
            if (objEntity.ID > 0)
            {

                return Update(objEntity, fieldsName);//调用逻辑的方法，便于参与逻辑操作
            }
            else
            {
                return Insert(objEntity);
            }
        }
        ///// <summary>
        ///// .net3.5注释该方法
        ///// </summary>
        ///// <returns></returns>
        //public override object Clone()
        //{
        //    return System.Activator.CreateInstance(this.GetType());
        //}

		
        #endregion
    }
}