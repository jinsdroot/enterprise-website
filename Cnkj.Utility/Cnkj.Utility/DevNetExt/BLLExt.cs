using DevNet.Common.Entity;

namespace Cnkj.Utility
{
    /// <summary>
    /// ����Զ��������ֶε�DevNet���߼��������չ
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TCondition"></typeparam>
    public abstract class BLLExt<T, TCondition> : BLLManager<T, TCondition>, IBLLExt<T, TCondition>
        where T : EntityBase, IEntity, new()
    {
        #region IBLLExt<T,TCondition> ��Ա
		///// <summary>
		///// �������ݣ��ֶ�IDΪ�Զ������ͣ�ID>0��Update����Insert������д
		///// </summary>
		///// <param name="objEntity"></param>
		//public virtual void Save(T objEntity)
		//{
		//    if (objEntity.ID > 0)
		//    {
		//        Update(objEntity);//�����߼��ķ��������ڲ����߼�����
		//    }
		//    else
		//    {
		//        Insert(objEntity);
		//    }
		//}

    	/// <summary>
    	/// �������ݣ��ֶ�IDΪ�Զ������ͣ�ID>0��Update����Insert������д
    	/// </summary>
    	/// <param name="objEntity"></param>
    	/// <param name="fieldsName">��Update�����Ǹ����ų����ֶ�</param>
    	public virtual void Save(T objEntity,params string[] fieldsName)
		{
			if (objEntity.ID > 0)
			{
				Update(objEntity, fieldsName);//�����߼��ķ��������ڲ����߼�����
			}
			else
			{                
                Insert(objEntity);
			}
		}
        #endregion
    }
}