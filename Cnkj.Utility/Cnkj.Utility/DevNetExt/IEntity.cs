namespace Cnkj.Utility
{
    /// <summary>
    /// 自动增长型实体接口
    /// </summary>
    public interface IEntity
    {
        /// <summary>
        ///  自动增长型字段名称，数据表请使用大写的ID
        /// </summary>
        int ID { get; set; }
    }
}