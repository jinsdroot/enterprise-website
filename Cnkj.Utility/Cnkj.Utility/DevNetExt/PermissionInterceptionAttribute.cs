using System;
using System.Security.Permissions;
using DevNet.Permission;

namespace Cnkj.Utility
{
    /// <summary>
    /// Ȩ����������
    /// </summary>
    [Serializable, AttributeUsage(AttributeTargets.Method | AttributeTargets.Class|AttributeTargets.Constructor, AllowMultiple = false, Inherited = false)]
    public class PermissionInterceptorAttribute : InterceptorAttribute
    {
        /// <summary>
        /// �������췽�������ڵ��û���Ĺ��췽��
        /// </summary>
        protected PermissionInterceptorAttribute(SecurityAction action)
            : base(action)
        { }

        /// <summary>
        /// ���췽��
        /// </summary>
        /// <param name="action">���ض�����Ŀǰֻ��<see cref="InterceptorAction.Demand"/></param>
        public PermissionInterceptorAttribute(InterceptorAction action)
            : this((SecurityAction)action)
        { }
        /// <summary>
        /// Ȩ�ޱ��
        /// </summary>
        public int PermissionID { get; set; }
        /// <summary>
        /// Ȩ������
        /// </summary>
        public string PermissionName { get; set;}
        /// <summary>
        /// ִ�����صķ���
        /// </summary>
        protected override void Demand()
        {
            //���ط���
            
        }

    
    }
}