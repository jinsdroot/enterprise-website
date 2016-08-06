using System;
using System.Web.UI;
using Common;
using DevNet.Common;
using DevNet.Common.Logger;

namespace Cnkj.Utility
{
    public class ExceptionManager
    {
        /// <summary>
		/// ”异常错误，操作失败,请刷新重试或联系管理员“ 
        /// </summary>
        public const string ErrorText = "异常错误，操作失败,请刷新重试或联系管理员";

        /// <summary>
        /// 处理异常并向页面显示错误信息
        /// </summary>
        /// <param name="page"></param>
        /// <param name="ex"></param>
        public static void ShowErrorMsg(Page page, DevNetException ex)
        {
            JSMsg.ShowRegisterMsg(page, GetErrorMsg(ex));
        }

        /// <summary>
        /// 处理异常并向页面显示错误信息
        /// </summary>
        /// <param name="page"></param>
        /// <param name="ex"></param>
        public static void ShowErrorMsg(Page page, Exception ex)
        {
            WriteLog(ex.Message);
            JSMsg.ShowRegisterMsg(page, ErrorText);
        }

        /// <summary>
        /// 根据DevNetException错误级别返回错误信息
        /// </summary>
        /// <param name="ex"></param>
        /// <returns></returns>
        public static string GetErrorMsg(DevNetException ex)
        {
            //WriteLog(ex.Message);
            switch ((DevNetExceptionEnum) ex.ErrorCode)
            {
                case DevNetExceptionEnum.CustomException:
                    return ex.Message;
                default:
                    return ErrorText;
            }
        }

        /// <summary>
        /// 写错误日志
        /// </summary>
        /// <param name="msg"></param>
        public static void WriteLog(string msg)
        {
            try
            {
                Log.Error(msg);
            }
            catch
            {}
        }
    }
}