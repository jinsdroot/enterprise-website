using System;
using System.Collections.Generic;
using System.Text;

namespace Cnkj.Utility
{
    public class SysDic
    {
        #region ===获取SysCode表中信息用===

        /// <summary>
        /// 苏网模块
        /// </summary>
        public const int swmk = 59;

        /// <summary>
        /// 公司介绍
        /// </summary>
        public const int gsjs = 60;

        /// <summary>
        /// 组织机构
        /// </summary>
        public const int zzjg = 61;

        /// <summary>
        /// 领导关怀
        /// </summary>
        public const int ldgh = 62;

        /// <summary>
        /// 公司资质
        /// </summary>
        public const int gszz = 63;

        /// <summary>
        /// 公司荣誉
        /// </summary>
        public const int gsry = 64;

        /// <summary>
        /// 企业文化
        /// </summary>
        public const int qywh = 65;

        /// <summary>
        /// 联系我们
        /// </summary>
        public const int lxwm = 66;

        /// <summary>
        /// 苏鑫装潢模块
        /// </summary>
        public const int sxzh = 67;

        /// <summary>
        /// 苏鑫企业介绍
        /// </summary>
        public const int sxqyjs = 68;

        /// <summary>
        /// 服务收费
        /// </summary>
        public const int fwsf = 69;

        /// <summary>
        /// 装潢联系我们
        /// </summary>
        public const int lxwmzh = 70;
        #endregion

        #region ===根据ID获取SysCode表名称===

        public static string GetSysCodeName(int id)
        {
            switch (id)
            {
                case SysDic.gsjs:
                    return "公司介绍";
                case SysDic.zzjg:
                    return "组织机构";
                case SysDic.ldgh:
                    return "领导关怀";
                case SysDic.gszz:
                    return "公司资质";
                case SysDic.gsry:
                    return "公司荣誉";
                case SysDic.qywh:
                    return "企业文化";
                case SysDic.lxwm:
                    return "联系我们";
                case SysDic.sxqyjs:
                    return "企业介绍";
                case SysDic.fwsf:
                    return "服务收费";
                case SysDic.lxwmzh:
                    return "联系我们";
                default:
                    return "未知";
            }
        }
        #endregion
    }
}
