using System;
using System.Collections.Generic;
 
using System.Text;
using System.Text.RegularExpressions;

namespace Common
{
    public class Validate
    {
		//电话^((0\d{2,3}))?(([-]?)\d{7,8})+([-](\d{1,7}))?$
		private static readonly Regex RegPhone = new Regex(@"^((0\d{2,3}))?(([-]?)\d{7,8})+([-](\d{1,7}))?$");
		private static readonly Regex RegNumber = new Regex("^[0-9]+$");
		private static readonly Regex RegNumberSign = new Regex("^[+-]?[0-9]+$");
		private static readonly Regex RegDecimal = new Regex("^[0-9]+[.]?[0-9]+$");
		private static readonly Regex RegDecimalSign = new Regex("^[+-]?[0-9]+[.]?[0-9]+$");
        //等价于^[+-]?\d+[.]?\d+$
		private static readonly Regex RegEmail = new Regex(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");
        //("^[\\w-]+@[\\w-]+\\.(com|net|org|edu|mil|tv|biz|info)$");//w 英文字母或数字的字符串，和 [a-zA-Z0-9] 语法一样 
		private static readonly Regex RegCHZN = new Regex("[\u4E00-\u9FA5]|[\uFE30-\uFFA0]");//("[\u4e00-\u9fa5]");

        /// <summary>
        /// 绝对地址
        /// </summary>
        private const string PhysicalPattern = @"^\s*[a-zA-Z]{1,10}:.*$";// @"^\s*[a-zA-Z]:.*$";

        private const string IPAddress =
            @"^(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])$";

        private const string MobilePattern = @"^(13[0-9]|15[0|1|2|3|5|6|7|8|9]|18[6|7|8|9])\d{8}$";
		//^(13[0-9]|15[^4]|18[6|8|9])\d{8}$


        #region 数字字符串检查
        /// <summary>
        /// 是否为电话号码或传真
        /// </summary>
        /// <param name="inputData"></param>
        /// <returns></returns>
        public static bool IsPhone(string inputData)
        {
            Match m = RegPhone.Match(inputData);
            return m.Success;
        }


        /// <summary>
        /// 是否为手机号码
        /// </summary>
        /// <param name="inputData"></param>
        /// <returns></returns>
        public static bool IsMobile(string inputData)
        {
            return Regex.IsMatch(inputData, MobilePattern);
        }
//        /// <summary>
//        /// 检查Request查询字符串的键值，是否是数字，最大长度限制
//        /// </summary>
//        /// <param name="req">Request</param>
//        /// <param name="inputKey">Request的键值</param>
//        /// <param name="maxLen">最大长度</param>
//        /// <returns>返回Request查询字符串</returns>
//        public static string FetchInputDigit(System.Web.HttpRequest req, string inputKey)
//        {
//            string retVal = string.Empty;
//            if (inputKey != null && inputKey != string.Empty)
//            {
//                retVal = req.QueryString[inputKey];
//                if (null == retVal)
//                    retVal = req.Form[inputKey];
//                if (null != retVal)
//                {
//                    retVal = StringPlus.ReplaceText(retVal);
//                    if (!IsNumber(retVal))
//                        retVal = string.Empty;
//                }
//            }
//            if (retVal == null)
//                retVal = string.Empty;
//            return retVal;
//        }
        /// <summary>
        /// 是否数字字符串
        /// </summary>
        /// <param name="inputData">输入字符串</param>
        /// <returns></returns>
        public static bool IsNumber(string inputData)
        {
            Match m = RegNumber.Match(inputData);
            return m.Success;
        }

        /// <summary>
        /// 是否数字字符串 可带正负号
        /// </summary>
        /// <param name="inputData">输入字符串</param>
        /// <returns></returns>
        public static bool IsNumberSign(string inputData)
        {
            Match m = RegNumberSign.Match(inputData);
            return m.Success;
        }
        /// <summary>
        /// 是否是浮点数
        /// </summary>
        /// <param name="inputData">输入字符串</param>
        /// <returns></returns>
        public static bool IsDecimal(string inputData)
        {
            Match m = RegDecimal.Match(inputData);
            return m.Success;
        }
        /// <summary>
        /// 是否是浮点数 可带正负号
        /// </summary>
        /// <param name="inputData">输入字符串</param>
        /// <returns></returns>
        public static bool IsDecimalSign(string inputData)
        {
            Match m = RegDecimalSign.Match(inputData);
            return m.Success;
        }

        /// <summary>
        /// 是否为IP地址
        /// </summary>
        /// <param name="inputData"></param>
        /// <returns></returns>
        public static bool IsIPAdress(string inputData)
        {
            return Regex.IsMatch(inputData, IPAddress);
        }

        #endregion

        #region 中文检测

        /// <summary>
        /// 检测是否有中文字符
        /// </summary>
        /// <param name="inputData"></param>
        /// <returns></returns>
        public static bool IsHasCHZN(string inputData)
        {
            Match m = RegCHZN.Match(inputData);
            return m.Success;
        }

        #endregion

        #region 邮件地址
        /// <summary>
        /// 是否电子邮箱
        /// </summary>
        /// <param name="inputData">输入字符串</param>
        /// <returns></returns>
        public static bool IsEmail(string inputData)
        {
            Match m = RegEmail.Match(inputData);
            return m.Success;
        }

        #endregion

        #region 日期格式判断
//        /// <summary>
//        /// 日期格式字符串判断
//        /// </summary>
//        /// <param name="str"></param>
//        /// <returns></returns>
//        public static bool IsDateTime(string str)
//        {
//            try
//            {
//                if (!string.IsNullOrEmpty(str))
//                {
//                    DateTime.Parse(str);
//                    return true;
//                }
//                else
//                {
//                    return false;
//                }
//            }
//            catch
//            {
//                return false;
//            }
//        }

        /// <summary>
        /// 判断是否为合法日期，必须大于1900年1月1日
        /// </summary>
        /// <param name="strDate">输入日期字符串</param>
        /// <returns>True/False</returns>
        public static bool IsDateTime(string strDate)
        {
            try
            {
                DateTime oDate = DateTime.Parse(strDate);
                if (oDate.CompareTo(DateTime.Parse("1900-1-1")) > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
        #endregion

        #region 其他


        /// <summary>
        /// 判断是否为相对地址（虚拟地址）
        /// </summary>
        public static bool IsRelativePath(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return false;
            }
            if (s.StartsWith("/") || s.StartsWith("?"))
            {
                return true;
            }
            if (Regex.IsMatch(s,PhysicalPattern ))
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// 判断是否为绝对地址（物理地址）
        /// </summary>
        public static bool IsPhysicalPath(string s)
        {
            return Regex.IsMatch(s, PhysicalPattern);
        }

        #endregion
    }
}