using DevNet.Common.Entity;

namespace Cnkj.Utility
{
    /// <summary>
    /// ����Զ��������ֶε�DevNet�����ݲ�����չ�ӿ�
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TCondition"></typeparam>
    public interface IDALExt<T, TCondition> : IDataManager<T, TCondition> where T : class, IEntity
    {
        /// <summary>
        /// �������ݣ��ֶ�IDΪ�Զ������ͣ�ID>0��Update����Insert��
        /// </summary>
        /// <param name="objEntity"></param>
        /// <param name="fieldsName"></param>
        /// <returns></returns>
        bool Save(T objEntity,params string[] fieldsName);
    }
}