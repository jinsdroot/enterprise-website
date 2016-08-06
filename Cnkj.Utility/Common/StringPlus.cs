using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using System.IO;

namespace Common
{
    /// <summary>
    /// 包含字符串的一些操作
    /// </summary>
    public static class StringPlus
    {
        /// <summary>
        /// 字母（大小写）
        /// </summary>
        public const string LetterConst =
            "a,A,b,B,c,C,d,D,e,E,f,F,g,G,h,H,i,I,j,J,k,K,l,L,m,M,n,N,o,O,p,P,q,Q,r,R,s,S,t,T,u,U,v,V,w,W,x,X,y,Y,z,Z";
        /// <summary>
        /// 数字
        /// </summary>
        public const string NumberConst = "1,2,3,4,5,6,7,8,9,0";

        /// <summary>
        /// 格式化为JS可解释的字符串' 替换为空 未去除“”“双引号
        /// </summary>
        /// <param name="str"></param>
        /// <param name="cutRN">是否去除\r\n</param>
        /// <returns></returns>
        public static string JSStringFormat(string str, bool cutRN)
        {
        	return cutRN
        	       	? str.Replace("\r", "").Replace("\n", "").Replace("\r\n", "").Replace("'", "")
        	       	: str.Replace("'", "");
        }
		
        /// <summary>
        /// 获取字符串
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="encode"></param>
        /// <returns></returns>
        public static string GetStrByByte(byte[] bytes, Encoding encode)
        {
            return encode.GetString(bytes);
        }
        /// <summary>
        /// 获取字符串
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static string GetStrByByte(byte[] bytes)
        {
            return Encoding.Default.GetString(bytes);
        }

        /// <summary>
        /// 获取byte[]
        /// </summary>
        /// <param name="str"></param>
        /// <param name="encode"></param>
        /// <returns></returns>
        public static byte[] GetByteByStr(string str, Encoding encode)
        {
            return encode.GetBytes(str);
        }
        /// <summary>
        /// 获取byte[]
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static byte[] GetByteByStr(string str)
        {
            return Encoding.Default.GetBytes(str);
        }
        /// <summary>
        /// 获取字符串中字节数长度
        /// </summary>
        /// <param name="strText"></param>
        /// <param name="encode"></param>
        /// <returns></returns>
        public static int GetStrByteLength(string strText, Encoding encode)
        {
            return encode.GetByteCount(strText);
        }

        public static int GetStrByteLength(string strText)
        {
            return Encoding.Default.GetByteCount(strText);
        }

        public static List<string> GetArrayByStr(string str, string speater, bool toLower)
        {
            List<string> list = new List<string>();
            string[] ss = str.Split(new string[] { speater }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string s in ss)
            {
                if (!string.IsNullOrEmpty(s) && s != speater)
                {
                    string strVal = s;
                    if (toLower)
                    {
                        strVal = s.ToLower();
                    }
                    list.Add(strVal);
                }
            }
            return list;
        }
        /// <summary>
        /// 用逗号分隔成数组
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string[] GetArrayByStr(string str)
        {
            return str.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
        }
        public static string GetStrByArray(List<string> list, string speater)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < list.Count; i++)
            {
                if (i == list.Count - 1)
                {
                    sb.Append(list[i]);
                }
                else
                {
                    sb.Append(list[i]);
                    sb.Append(speater);
                }
            }
            return sb.ToString();
        }


        #region 删除最后一个字符之后的字符

        /// <summary>
        /// 删除最后结尾的一个逗号
        /// </summary>
        public static string DelLastComma(string str)
        {
            return DelLastChar(str, ",");
        }

        /// <summary>
        /// 删除最后结尾的指定字符后的字符
        /// </summary>
        public static string DelLastChar(string str, string strchar)
        {
            str = str.Trim();
            int index = str.LastIndexOf(strchar);
            if (index == 0)
                return string.Empty;
            if (index > 0 && str.EndsWith(strchar))
                return str.Substring(0, index);
            return str;
        }

        #endregion

        /// <summary>
        /// 转全角的函数(SBC case)
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string ToSBC(string input)
        {
            //半角转全角：
            char[] c = input.ToCharArray();
            for (int i = 0; i < c.Length; i++)
            {
                if (c[i] == 32)
                {
                    c[i] = (char)12288;
                    continue;
                }
                if (c[i] < 127)
                    c[i] = (char)(c[i] + 65248);
            }
            return new string(c);
        }

        /// <summary>
        ///  转半角的函数(SBC case)
        /// </summary>
        /// <param name="input">输入</param>
        /// <returns></returns>
        public static string ToDBC(string input)
        {
            char[] c = input.ToCharArray();
            for (int i = 0; i < c.Length; i++)
            {
                if (c[i] == 12288)
                {
                    c[i] = (char)32;
                    continue;
                }
                if (c[i] > 65280 && c[i] < 65375)
                    c[i] = (char)(c[i] - 65248);
            }
            return new string(c);
        }


        #region 将字符串转换为新样式

        /// <summary>
        /// 给字符串末尾加自定分隔符和数字，如原已有后缀，则数字加1
        /// </summary>
        /// <param name="str"></param>
        /// <param name="speater"></param>
        /// <returns></returns>
        public static string GetNewStr(string str, string speater)
        {
            if (!string.IsNullOrEmpty(str))
            {
                string tmpStr = str.Trim();
                int index = tmpStr.LastIndexOf(speater);
                if (index >= 0)
                {
                    str = tmpStr.Substring(0, index);
                    index++;
                    if (index >= tmpStr.Length)
                        index = 1;
                    else
                    {
                        int tmpNum;
                        if (Int32.TryParse(tmpStr.Substring(index), out tmpNum))
                            index = ++tmpNum;
                    }
                }
                else
                    index = 1;
                str = str + speater + index;

            }
            return str;
        }

        #endregion



        /// <summary>
        /// 检查字符串最大长度，返回指定长度的串
        /// </summary>
        /// <param name="sqlInput">输入字符串</param>
        /// <param name="maxLength">最大长度</param>
        /// <returns></returns>			
        public static string GetStrByLength(string sqlInput, int maxLength)
        {
            if (!string.IsNullOrEmpty(sqlInput))
            {
                sqlInput = sqlInput.Trim();
                if (sqlInput.Length > maxLength) //按最大长度截取字符串
                    sqlInput = sqlInput.Substring(0, maxLength);
            }
            return sqlInput;
        }

        /// <summary>
        /// 根据字节最大长度，返回字符串 
        /// </summary>
        /// <param name="strText"></param>
        /// <param name="maxLength">字节长度</param>
        /// <param name="fillDot">是否用...填充超过长度的末尾</param>
        /// <returns></returns>
        public static string GetStrByByteLength(string strText, int maxLength, bool fillDot)
        {
            if (!string.IsNullOrEmpty(strText))
            {
                strText = strText.Trim();
                int i = 0;
                foreach (char c in strText)
                {
                    int j = Encoding.Default.GetByteCount(c.ToString());
                    if (j > 1)
                        maxLength -= (j - 1);

                    i++;
                    if (i >= maxLength)
                        break;
                }
                if (i < strText.Length)
                {
					if (fillDot)
						strText = strText.Substring(0, i) + "...";
					else
						strText = strText.Substring(0, i);
                }
            }
            return strText;
        }
        /// <summary>
        /// 字符串编码
        /// </summary>
        /// <param name="inputData"></param>
        /// <returns></returns>
        public static string HtmlEncode(string inputData)
        {
            return HttpUtility.HtmlEncode(inputData);
        }
        /// <summary>
        /// 设置Label显示Encode的字符串
        /// </summary>
        /// <param name="lbl"></param>
        /// <param name="txtInput"></param>
        public static void SetLabel(Label lbl, string txtInput)
        {
            lbl.Text = HtmlEncode(txtInput);
        }
        public static void SetLabel(Label lbl, object inputObj)
        {
            SetLabel(lbl, inputObj.ToString());
        }

        ///<summary>
        /// 检测是否有Sql危险字符
        /// </summary>
        /// <param name="str">要判断字符串</param>
        /// <returns>判断结果</returns>
        public static bool IsSafeSqlString(string str)
        {
            return !Regex.IsMatch(str, @"[-|;|,|\/|\(|\)|\[|\]|\}|\{|%|@|\*|!|\']");
        }


        //字符串清理
        /// <summary>
        /// 替换一些字符 "," > ,',\r,\n,\r\n
        /// </summary>
        /// <param name="inputString"></param>
        /// <returns></returns>
        public static string ReplaceText(string inputString)
        {
            StringBuilder retVal = new StringBuilder();

            if (!string.IsNullOrEmpty(inputString))
            {
                inputString = inputString.Trim();

                //替换危险字符
                for (int i = 0; i < inputString.Length; i++)
                {
                    switch (inputString[i])
                    {
                        case '"':
                            retVal.Append("&quot;");
                            break;
                        case '<':
                            retVal.Append("&lt;");
                            break;
                        case '>':
                            retVal.Append("&gt;");
                            break;
                        default:
                            retVal.Append(inputString[i]);
                            break;
                    }
                }
                retVal.Replace("'", " ");// 替换单引号
            	retVal.Replace("\r", "").Replace("\n", "").Replace("\r\n", "");
            }
            return retVal.ToString();

        }
        /// <summary>
        /// 转换成 HTML code
        /// </summary>
        /// <param name="str">string</param>
        /// <returns>string</returns>
        public static string Encode(string str)
        {
            str = str.Replace("&", "&amp;");
            str = str.Replace("'", "''");
            str = str.Replace("\"", "&quot;");
            str = str.Replace(" ", "&nbsp;");
            str = str.Replace("<", "&lt;");
            str = str.Replace(">", "&gt;");
            str = str.Replace("\n", "<br>");
            str = str.Replace("\r", "");
            return str;
        }
        /// <summary>
        ///解析html成 普通文本
        /// </summary>
        /// <param name="str">string</param>
        /// <returns>string</returns>
        public static string Decode(string str)
        {
            str = str.Replace("<br>", "\n");
            str = str.Replace("&gt;", ">");
            str = str.Replace("&lt;", "<");
            str = str.Replace("&nbsp;", " ");
            str = str.Replace("&quot;", "\"");
            return str;
        }

        /// <summary>
        /// 去除sql危险字符 "[-|;|,|\/|\(|\)|\[|\]|\}|\{|%|@|\*|!|\']");
        /// </summary>
        /// <param name="sqlText"></param>
        /// <returns></returns>
        public static string SqlTextClear(string sqlText)
        {
            if (String.IsNullOrEmpty(sqlText))
                return sqlText;

            //@"[-|;|,|\/|\(|\)|\[|\]|\}|\{|%|@|\*|!|\']");
            sqlText = sqlText.Replace(",", "");//去除,
            //sqlText = sqlText.Replace("<", "");//去除<
            //sqlText = sqlText.Replace(">", "");//去除>
            //sqlText = sqlText.Replace("--", "");//去除--
            sqlText = sqlText.Replace("'", "''");//替换成''
            sqlText = sqlText.Replace("\"", "");//去除"
            sqlText = sqlText.Replace("=", "");//去除=
            sqlText = sqlText.Replace("%", "");//去除%
            sqlText = sqlText.Replace(" ", "");//去除空格Replace("(", "").Replace(")", "").Replace("[", "").Replace("]", "").Replace("{", "").Replace("}", "").Replace("@", "")
            sqlText = sqlText.Replace(";", "").Replace("/", "").Replace("*", "").Replace("!", "");
            return sqlText;
        }


        #region 是否由特定字符组成
        /// <summary>
        /// 是否是单个字符
        /// </summary>
        /// <param name="strInput"></param>
        /// <returns></returns>
        public static bool IsContainSameChar(string strInput)
        {
            string charInput = string.Empty;
            if (!string.IsNullOrEmpty(strInput))
            {
                charInput = strInput.Substring(0, 1);
            }
            return IsContainSameChar(strInput, charInput);
        }

        /// <summary>
        /// 是否包含指定字符
        /// </summary>
        /// <param name="strInput"></param>
        /// <param name="charInput"></param>
        /// <returns></returns>
        public static bool IsContainSameChar(string strInput, string charInput)
        {
            if (string.IsNullOrEmpty(charInput))
            {
                return false;
            }
            Regex RegNumber = new Regex(string.Format("^([{0}])+$", charInput));
            //Regex RegNumber = new Regex(string.Format("^([{0}]{{1}})+$", charInput,lenInput));
            Match m = RegNumber.Match(strInput);
            return m.Success;
        }
        #endregion

        /// <summary>
        /// 将相对地址转化为绝对地址
        /// </summary>
        public static string MapPath(string path)
        {
            if (Validate.IsPhysicalPath(path))
            {
                return path;
            }
            if (null != HttpContext.Current)
            {   
              
                return HttpContext.Current.Server.MapPath(path);
            }
            if (MapPath(".").Length > 0)
            {
                return JoinString(MapPath(".") + "/" + path);
            }
            if (System.IO.Path.IsPathRooted(path))
                return path;
            return System.IO.Path.GetTempPath() + path;
        }


        /// <summary>
        /// 字符串连接操作。
        /// </summary>
        /// <param name="value">要连接的字符串</param>
        /// <param name="speater">连接中的分割字符 可以为string.empty</param>
        /// <returns>连接后的字符串</returns>
        public static string JoinString(string speater, params string[] value)
        {
            if (null == value)
            {
                return null;
            }
            if (0 == value.Length)
            {
                return string.Empty;
            }
            return string.Join(speater, value);
        }

        /// <summary>
        /// 获取真实IP地址
        /// </summary>
        public static string GetIPAddress()
        {

            string userIP = null;
            // HttpRequest Request = HttpContext.Current.Request;
            HttpRequest Request = HttpContext.Current.Request; // ForumContext.Current.Context.Request;
            // 如果使用代理，获取真实IP
            if (Request.ServerVariables["HTTP_X_FORWARDED_FOR"] != "")
                userIP = Request.ServerVariables["REMOTE_ADDR"];
            else
                userIP = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (string.IsNullOrEmpty(userIP))
                userIP = Request.UserHostAddress;
            return userIP;
        }
        /// <summary>
        /// 转换值（错误或异常返回默认值）
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="needConvertValue"></param>
        /// <param name="defaultValue">错误或异常返回的默认值</param>
        /// <param name="converter"></param>
        /// <returns></returns>
        public static T ConverTValue<T>(object needConvertValue, T defaultValue, Converter<object, T> converter) where T : IConvertible
        {
            if (needConvertValue == null)
                return defaultValue;
			if(string.IsNullOrEmpty(needConvertValue.ToString()))
				return defaultValue;
            try
            {
                return converter.Invoke(needConvertValue);
            }
            catch
            {
                return defaultValue;
            }
        }
		/// <summary>
		/// 转换值（错误或异常返回默认值）
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="needConvertValue"></param>
		/// <param name="defaultValue">错误或异常返回的默认值</param>
		/// <returns></returns>
		public static T ConverTValue<T>(object needConvertValue, T defaultValue) where T : IConvertible
    {
    	if(needConvertValue==null)
    	{
			return defaultValue;
    	}
		if (string.IsNullOrEmpty(needConvertValue.ToString()))
			return defaultValue;
		try
		{
			return (T) Convert.ChangeType(needConvertValue, typeof (T));
		}
		catch
		{
			return defaultValue;
		}
    }

        /// <summary>
        /// 去除Html中的格式，保留文字
        /// </summary>
        /// <param name="Htmlstring"></param>
        /// <returns></returns>
        public static string DelHTML(string Htmlstring, int length)//将HTML去除
        {
            #region
            //删除脚本
            Htmlstring = System.Text.RegularExpressions.Regex.Replace(Htmlstring, @"<script[^>]*?>.*?</script>", "", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            //删除HTML
            Regex regex = new Regex(@"\<[^img](.*?)\>", RegexOptions.IgnoreCase);
            Htmlstring = regex.Replace(Htmlstring, "");
            Htmlstring = System.Text.RegularExpressions.Regex.Replace(Htmlstring, @"<(.[^>]*)>", "", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            Htmlstring = System.Text.RegularExpressions.Regex.Replace(Htmlstring, @"([\r\n])[\s]+", "", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            Htmlstring = System.Text.RegularExpressions.Regex.Replace(Htmlstring, @"-->", "", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            Htmlstring = System.Text.RegularExpressions.Regex.Replace(Htmlstring, @"<!--.*", "", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            Htmlstring = System.Text.RegularExpressions.Regex.Replace(Htmlstring, @"<A>.*</A>", "");
            Htmlstring = System.Text.RegularExpressions.Regex.Replace(Htmlstring, @"<[a-zA-Z]*=\.[a-zA-Z]*\?[a-zA-Z]+=\d&\w=%[a-zA-Z]*|[A-Z0-9]", "");
            Htmlstring = System.Text.RegularExpressions.Regex.Replace(Htmlstring, @"&(quot|#34);", "\"", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            Htmlstring = System.Text.RegularExpressions.Regex.Replace(Htmlstring, @"&(amp|#38);", "&", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            Htmlstring = System.Text.RegularExpressions.Regex.Replace(Htmlstring, @"&(lt|#60);", "<", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            Htmlstring = System.Text.RegularExpressions.Regex.Replace(Htmlstring, @"&(gt|#62);", ">", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            Htmlstring = System.Text.RegularExpressions.Regex.Replace(Htmlstring, @"&(nbsp|#160);", " ", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            Htmlstring = System.Text.RegularExpressions.Regex.Replace(Htmlstring, @"&(iexcl|#161);", "\xa1", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            Htmlstring = System.Text.RegularExpressions.Regex.Replace(Htmlstring, @"&(cent|#162);", "\xa2", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            Htmlstring = System.Text.RegularExpressions.Regex.Replace(Htmlstring, @"&(pound|#163);", "\xa3", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            Htmlstring = System.Text.RegularExpressions.Regex.Replace(Htmlstring, @"&(copy|#169);", "\xa9", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            Htmlstring = System.Text.RegularExpressions.Regex.Replace(Htmlstring, @"&#(\d+);", "", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            Htmlstring.Replace("<", "");
            Htmlstring.Replace(">", "");
            Htmlstring.Replace("\r\n", "");
            //Htmlstring=HttpContext.Current.Server.HtmlEncode(Htmlstring).Trim();
            Htmlstring = GetStrByByteLength(Htmlstring, length, true);
            #endregion
            return Htmlstring;
        }
		/// <summary>
		/// Img正则表达
		/// </summary>
    	public  const string ImgReg =
    		@"<img\b[^<>]*?\bsrc[\s\t\r\n]*=[\s\t\r\n]*[""']?[\s\t\r\n]*(?<imgUrl>[^\s\t\r\n""'<>]*)[^<>]*?/?[\s\t\r\n]*>";

		/// <summary>
		///  取得HTML中所有图片的 URL
		/// </summary>
		/// <param name="sHtmlText"></param>
		/// <returns></returns>
		public static string[] GetHtmlImageUrlList(string sHtmlText)
		{
			// 定义正则表达式用来匹配 img 标签
			Regex regImg = new Regex(ImgReg, RegexOptions.IgnoreCase);

			// 搜索匹配的字符串
			MatchCollection matches = regImg.Matches(sHtmlText);

			int i = 0;
			string[] sUrlList = new string[matches.Count];

			// 取得匹配项列表
			foreach (Match match in matches)
				sUrlList[i++] = match.Groups["imgUrl"].Value;

			return sUrlList;
		}

        /// <summary>
        /// 去除Html中的img图片
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string GetHtmlReplceImg(string str)
        {
            string[] pic = GetHtmlImageUrlList(str);
            if (pic.Length > 0)
            {
                for (int i = 0; i < pic.Length; i++)
                {
                    str.Replace(pic[i],"");
                }
            }

            return str;
        }
    }
}
