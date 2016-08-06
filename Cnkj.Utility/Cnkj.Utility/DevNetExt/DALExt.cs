using DevNet.Common;
using DevNet.Common.Entity;

namespace Cnkj.Utility
{
    /// <summary>
    /// ����Զ��������ֶε�DevNet�����ݲ�����չ
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TCondition"></typeparam>
    public abstract class DALExt<T, TCondition> : DataManager<T, TCondition>, IDALExt<T, TCondition>
        where T : EntityBase, IEntity, new()
    {
        #region IDALExt<T,TCondition> ��Ա

        ///// <summary>
        ///// �������ݣ��ֶ�IDΪ�Զ������ͣ�ID>0��Update����Insert������д
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
        /// �������ݣ��ֶ�IDΪ�Զ������ͣ�ID>0��Update����Insert������д
        /// </summary>
        /// <param name="objEntity"></param>
        /// <param name="fieldsName">��Update�����Ǹ����ų����ֶ�</param>
        public bool Save(T objEntity, params string[] fieldsName)
        {
            if (objEntity.ID > 0)
            {

                return Update(objEntity, fieldsName);//�����߼��ķ��������ڲ����߼�����
            }
            else
            {
                return Insert(objEntity);
            }
        }
        ///// <summary>
        ///// .net3.5ע�͸÷���
        ///// </summary>
        ///// <returns></returns>
        //public override object Clone()
        //{
        //    return System.Activator.CreateInstance(this.GetType());
        //}

		
        #endregion
    }
}