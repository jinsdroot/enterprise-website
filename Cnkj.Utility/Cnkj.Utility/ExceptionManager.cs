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
		/// ���쳣���󣬲���ʧ��,��ˢ�����Ի���ϵ����Ա�� 
        /// </summary>
        public const string ErrorText = "�쳣���󣬲���ʧ��,��ˢ�����Ի���ϵ����Ա";

        /// <summary>
        /// �����쳣����ҳ����ʾ������Ϣ
        /// </summary>
        /// <param name="page"></param>
        /// <param name="ex"></param>
        public static void ShowErrorMsg(Page page, DevNetException ex)
        {
            JSMsg.ShowRegisterMsg(page, GetErrorMsg(ex));
        }

        /// <summary>
        /// �����쳣����ҳ����ʾ������Ϣ
        /// </summary>
        /// <param name="page"></param>
        /// <param name="ex"></param>
        public static void ShowErrorMsg(Page page, Exception ex)
        {
            WriteLog(ex.Message);
            JSMsg.ShowRegisterMsg(page, ErrorText);
        }

        /// <summary>
        /// ����DevNetException���󼶱𷵻ش�����Ϣ
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
        /// д������־
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