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
    /// �����ַ�����һЩ����
    /// </summary>
    public static class StringPlus
    {
        /// <summary>
        /// ��ĸ����Сд��
        /// </summary>
        public const string LetterConst =
            "a,A,b,B,c,C,d,D,e,E,f,F,g,G,h,H,i,I,j,J,k,K,l,L,m,M,n,N,o,O,p,P,q,Q,r,R,s,S,t,T,u,U,v,V,w,W,x,X,y,Y,z,Z";
        /// <summary>
        /// ����
        /// </summary>
        public const string NumberConst = "1,2,3,4,5,6,7,8,9,0";

        /// <summary>
        /// ��ʽ��ΪJS�ɽ��͵��ַ���' �滻Ϊ�� δȥ��������˫����
        /// </summary>
        /// <param name="str"></param>
        /// <param name="cutRN">�Ƿ�ȥ��\r\n</param>
        /// <returns></returns>
        public static string JSStringFormat(string str, bool cutRN)
        {
        	return cutRN
        	       	? str.Replace("\r", "").Replace("\n", "").Replace("\r\n", "").Replace("'", "")
        	       	: str.Replace("'", "");
        }
		
        /// <summary>
        /// ��ȡ�ַ���
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="encode"></param>
        /// <returns></returns>
        public static string GetStrByByte(byte[] bytes, Encoding encode)
        {
            return encode.GetString(bytes);
        }
        /// <summary>
        /// ��ȡ�ַ���
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static string GetStrByByte(byte[] bytes)
        {
            return Encoding.Default.GetString(bytes);
        }

        /// <summary>
        /// ��ȡbyte[]
        /// </summary>
        /// <param name="str"></param>
        /// <param name="encode"></param>
        /// <returns></returns>
        public static byte[] GetByteByStr(string str, Encoding encode)
        {
            return encode.GetBytes(str);
        }
        /// <summary>
        /// ��ȡbyte[]
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static byte[] GetByteByStr(string str)
        {
            return Encoding.Default.GetBytes(str);
        }
        /// <summary>
        /// ��ȡ�ַ������ֽ�������
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
        /// �ö��ŷָ�������
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


        #region ɾ�����һ���ַ�֮����ַ�

        /// <summary>
        /// ɾ������β��һ������
        /// </summary>
        public static string DelLastComma(string str)
        {
            return DelLastChar(str, ",");
        }

        /// <summary>
        /// ɾ������β��ָ���ַ�����ַ�
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
        /// תȫ�ǵĺ���(SBC case)
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string ToSBC(string input)
        {
            //���תȫ�ǣ�
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
        ///  ת��ǵĺ���(SBC case)
        /// </summary>
        /// <param name="input">����</param>
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


        #region ���ַ���ת��Ϊ����ʽ

        /// <summary>
        /// ���ַ���ĩβ���Զ��ָ��������֣���ԭ���к�׺�������ּ�1
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
        /// ����ַ�����󳤶ȣ�����ָ�����ȵĴ�
        /// </summary>
        /// <param name="sqlInput">�����ַ���</param>
        /// <param name="maxLength">��󳤶�</param>
        /// <returns></returns>			
        public static string GetStrByLength(string sqlInput, int maxLength)
        {
            if (!string.IsNullOrEmpty(sqlInput))
            {
                sqlInput = sqlInput.Trim();
                if (sqlInput.Length > maxLength) //����󳤶Ƚ�ȡ�ַ���
                    sqlInput = sqlInput.Substring(0, maxLength);
            }
            return sqlInput;
        }

        /// <summary>
        /// �����ֽ���󳤶ȣ������ַ��� 
        /// </summary>
        /// <param name="strText"></param>
        /// <param name="maxLength">�ֽڳ���</param>
        /// <param name="fillDot">�Ƿ���...��䳬�����ȵ�ĩβ</param>
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
        /// �ַ�������
        /// </summary>
        /// <param name="inputData"></param>
        /// <returns></returns>
        public static string HtmlEncode(string inputData)
        {
            return HttpUtility.HtmlEncode(inputData);
        }
        /// <summary>
        /// ����Label��ʾEncode���ַ���
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
        /// ����Ƿ���SqlΣ���ַ�
        /// </summary>
        /// <param name="str">Ҫ�ж��ַ���</param>
        /// <returns>�жϽ��</returns>
        public static bool IsSafeSqlString(string str)
        {
            return !Regex.IsMatch(str, @"[-|;|,|\/|\(|\)|\[|\]|\}|\{|%|@|\*|!|\']");
        }


        //�ַ�������
        /// <summary>
        /// �滻һЩ�ַ� "," > ,',\r,\n,\r\n
        /// </summary>
        /// <param name="inputString"></param>
        /// <returns></returns>
        public static string ReplaceText(string inputString)
        {
            StringBuilder retVal = new StringBuilder();

            if (!string.IsNullOrEmpty(inputString))
            {
                inputString = inputString.Trim();

                //�滻Σ���ַ�
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
                retVal.Replace("'", " ");// �滻������
            	retVal.Replace("\r", "").Replace("\n", "").Replace("\r\n", "");
            }
            return retVal.ToString();

        }
        /// <summary>
        /// ת���� HTML code
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
        ///����html�� ��ͨ�ı�
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
        /// ȥ��sqlΣ���ַ� "[-|;|,|\/|\(|\)|\[|\]|\}|\{|%|@|\*|!|\']");
        /// </summary>
        /// <param name="sqlText"></param>
        /// <returns></returns>
        public static string SqlTextClear(string sqlText)
        {
            if (String.IsNullOrEmpty(sqlText))
                return sqlText;

            //@"[-|;|,|\/|\(|\)|\[|\]|\}|\{|%|@|\*|!|\']");
            sqlText = sqlText.Replace(",", "");//ȥ��,
            //sqlText = sqlText.Replace("<", "");//ȥ��<
            //sqlText = sqlText.Replace(">", "");//ȥ��>
            //sqlText = sqlText.Replace("--", "");//ȥ��--
            sqlText = sqlText.Replace("'", "''");//�滻��''
            sqlText = sqlText.Replace("\"", "");//ȥ��"
            sqlText = sqlText.Replace("=", "");//ȥ��=
            sqlText = sqlText.Replace("%", "");//ȥ��%
            sqlText = sqlText.Replace(" ", "");//ȥ���ո�Replace("(", "").Replace(")", "").Replace("[", "").Replace("]", "").Replace("{", "").Replace("}", "").Replace("@", "")
            sqlText = sqlText.Replace(";", "").Replace("/", "").Replace("*", "").Replace("!", "");
            return sqlText;
        }


        #region �Ƿ����ض��ַ����
        /// <summary>
        /// �Ƿ��ǵ����ַ�
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
        /// �Ƿ����ָ���ַ�
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
        /// ����Ե�ַת��Ϊ���Ե�ַ
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
        /// �ַ������Ӳ�����
        /// </summary>
        /// <param name="value">Ҫ���ӵ��ַ���</param>
        /// <param name="speater">�����еķָ��ַ� ����Ϊstring.empty</param>
        /// <returns>���Ӻ���ַ���</returns>
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
        /// ��ȡ��ʵIP��ַ
        /// </summary>
        public static string GetIPAddress()
        {

            string userIP = null;
            // HttpRequest Request = HttpContext.Current.Request;
            HttpRequest Request = HttpContext.Current.Request; // ForumContext.Current.Context.Request;
            // ���ʹ�ô�����ȡ��ʵIP
            if (Request.ServerVariables["HTTP_X_FORWARDED_FOR"] != "")
                userIP = Request.ServerVariables["REMOTE_ADDR"];
            else
                userIP = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (string.IsNullOrEmpty(userIP))
                userIP = Request.UserHostAddress;
            return userIP;
        }
        /// <summary>
        /// ת��ֵ��������쳣����Ĭ��ֵ��
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="needConvertValue"></param>
        /// <param name="defaultValue">������쳣���ص�Ĭ��ֵ</param>
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
		/// ת��ֵ��������쳣����Ĭ��ֵ��
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="needConvertValue"></param>
		/// <param name="defaultValue">������쳣���ص�Ĭ��ֵ</param>
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
        /// ȥ��Html�еĸ�ʽ����������
        /// </summary>
        /// <param name="Htmlstring"></param>
        /// <returns></returns>
        public static string DelHTML(string Htmlstring, int length)//��HTMLȥ��
        {
            #region
            //ɾ���ű�
            Htmlstring = System.Text.RegularExpressions.Regex.Replace(Htmlstring, @"<script[^>]*?>.*?</script>", "", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            //ɾ��HTML
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
		/// Img������
		/// </summary>
    	public  const string ImgReg =
    		@"<img\b[^<>]*?\bsrc[\s\t\r\n]*=[\s\t\r\n]*[""']?[\s\t\r\n]*(?<imgUrl>[^\s\t\r\n""'<>]*)[^<>]*?/?[\s\t\r\n]*>";

		/// <summary>
		///  ȡ��HTML������ͼƬ�� URL
		/// </summary>
		/// <param name="sHtmlText"></param>
		/// <returns></returns>
		public static string[] GetHtmlImageUrlList(string sHtmlText)
		{
			// ����������ʽ����ƥ�� img ��ǩ
			Regex regImg = new Regex(ImgReg, RegexOptions.IgnoreCase);

			// ����ƥ����ַ���
			MatchCollection matches = regImg.Matches(sHtmlText);

			int i = 0;
			string[] sUrlList = new string[matches.Count];

			// ȡ��ƥ�����б�
			foreach (Match match in matches)
				sUrlList[i++] = match.Groups["imgUrl"].Value;

			return sUrlList;
		}

        /// <summary>
        /// ȥ��Html�е�imgͼƬ
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
