using DevNet.Common.Entity;

namespace Cnkj.Utility
{
    /// <summary>
    /// ����Զ��������ֶε�DevNet���߼��������չ�ӿ�
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TCondition"></typeparam>
    public interface IBLLExt<T, TCondition> : IBLLManager<T, TCondition> where T : class, IEntity
    {
    	/// <summary>
    	/// �������ݣ��ֶ�IDΪ�Զ������ͣ�ID>0��Update����Insert��
    	/// </summary>
    	/// <param name="objEntity"></param>
		
    	/// <param name="fieldsName"></param>
    	void Save(T objEntity,params string[] fieldsName);
    }
}