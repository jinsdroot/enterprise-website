using System;
using System.Security.Permissions;
using DevNet.Permission;

namespace Cnkj.Utility
{
    /// <summary>
    /// 权限拦截属性
    /// </summary>
    [Serializable, AttributeUsage(AttributeTargets.Method | AttributeTargets.Class|AttributeTargets.Constructor, AllowMultiple = false, Inherited = false)]
    public class PermissionInterceptorAttribute : InterceptorAttribute
    {
        /// <summary>
        /// 保护构造方法，用于调用基类的构造方法
        /// </summary>
        protected PermissionInterceptorAttribute(SecurityAction action)
            : base(action)
        { }

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="action">拦截动作，目前只有<see cref="InterceptorAction.Demand"/></param>
        public PermissionInterceptorAttribute(InterceptorAction action)
            : this((SecurityAction)action)
        { }
        /// <summary>
        /// 权限编号
        /// </summary>
        public int PermissionID { get; set; }
        /// <summary>
        /// 权限名称
        /// </summary>
        public string PermissionName { get; set;}
        /// <summary>
        /// 执行拦截的方法
        /// </summary>
        protected override void Demand()
        {
            //拦截方法
            
        }

    
    }
}