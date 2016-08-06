using System;
using System.Text.RegularExpressions;
using System.Collections;

namespace Common
{
    /// <summary>
    /// 文章内分页
    /// </summary>
    public class ContentAutoPage
    {
        public ContentAutoPage()
        {

        }
        /// <summary>
        /// 文章内容自动分页
        /// </summary>
        /// <remarks >
		/// int m_page = GetQueryStringValue("page", 1, Convert.ToInt32);
		/// txtContent.Text = ContentAutoPage.ContentPagination(NewsContent, 800, "id=" + m_Id, "", 0, "", m_page);
        /// </remarks>
        /// <param name="content"></param>
        /// <param name="ContentpageSize"></param>
        /// <param name="preFix"></param>
        /// <param name="sufFix"></param>
        /// <param name="IsURLRewrite"></param>
        /// <param name="fileExt"></param>
        /// <param name="CurrentPage"></param>
        /// <returns></returns>
        public static string ContentPagination(string content, int ContentpageSize, string preFix, string sufFix, int IsURLRewrite, string fileExt, int CurrentPage)
        {

            string ArticleContent = content;           
            int Paginate = 0;
            string m_strFileUrl, m_strFileExt;
            if (CurrentPage < 1) { CurrentPage = 1; }
            if (content.IndexOf("[split_page]") == -1 && content.Length < ContentpageSize)
            {
                ArticleContent = content;
            }
            else
            {            
                if (content.IndexOf("[split_page]") != -1)
                {
                    string[] arrContent = content.Split(new string[1] { "[split_page]" }, StringSplitOptions.None);
                    Paginate = arrContent.Length;
                    if (CurrentPage > Paginate) { CurrentPage = Paginate; }
                    ArticleContent = "<div>" + arrContent[CurrentPage - 1] + "</div><p align=\"center\"><b>";
                }
                else
                {
                    int num = RemoveHtml(ArticleContent).Length;                    
                    if (num % ContentpageSize == 0)
                        Paginate = num / ContentpageSize;
                    else Paginate = num / ContentpageSize + 1;
                    if (CurrentPage > Paginate) { CurrentPage = Paginate; }
                    ArrayList arrContent = new ArrayList(); 
                    for (int i = 0; i < Paginate; i++)
                    {
                        arrContent.Add(SubString(ContentpageSize, ref ArticleContent));                                               
                    }                               
                    ArticleContent = "<div>" + arrContent[CurrentPage - 1] + "</div><p align=\"center\"><b>";
                }
                if (IsURLRewrite == 1)
                {
                    string tmpA, tmpB;
                    tmpA = preFix.Replace('&', '-');
                    tmpB = sufFix.Replace('&', '-');
                    m_strFileUrl = tmpA + "-" + tmpB;
                    m_strFileExt = fileExt;
                }
                else
                {
                    m_strFileExt = "";
                    if (preFix != "")
                    {
                        m_strFileUrl = "?" + preFix + "&Page=";
                    }
                    else
                    {
                        m_strFileUrl = "?Page=";
                    }
                }
                if (CurrentPage > 1)
                {
                    if (IsURLRewrite == 1 && (CurrentPage - 1) == 1)
                    {
                        ArticleContent += "<a href=\"" + m_strFileUrl + (CurrentPage - 1).ToString() + sufFix + m_strFileExt + "\">上一页</a>  ";
                    }
                    else
                    {
                        ArticleContent += "<a href=\"" + m_strFileUrl + (CurrentPage - 1).ToString() + sufFix + m_strFileExt + "\">上一页</a>  ";
                    }
                }
                for (int i = 1; i <= Paginate; i++)
                {
                    if (i == CurrentPage)
                    {
                        ArticleContent += "<span style=\"color:red;\">[" + i.ToString() + "]</span> ";
                    }
                    else
                    {
                        if (IsURLRewrite == 1 && i == 1)
                        {
                            ArticleContent += "<a href=\"" + m_strFileUrl + i.ToString() + sufFix + m_strFileExt + "\">[" + i.ToString() + "]</a> ";
                        }
                        else if (IsURLRewrite == 1 && i != 1)
                        {
                            ArticleContent += "<a href=\"" + m_strFileUrl + i.ToString() + sufFix + m_strFileExt + "\">[" + i.ToString() + "]</a> ";
                        }
                        else
                        {
                            ArticleContent += "<a href=\"" + m_strFileUrl + i.ToString() + sufFix + m_strFileExt + "\">[" + i.ToString() + "]</a> ";
                        }
                    }
                }
                if (CurrentPage < Paginate)
                {
                    if (IsURLRewrite == 1)
                    {
                        ArticleContent += " <a href=\"" + m_strFileUrl + (CurrentPage + 1).ToString() + sufFix + m_strFileExt + "\">下一页</a>";
                    }
                    else
                    {
                        ArticleContent += " <a href=\"" + m_strFileUrl + (CurrentPage + 1).ToString() + sufFix + m_strFileExt + "\">下一页</a>";
                    }
                }
                ArticleContent += "</b></p>";
            }
            return ArticleContent;                                
        }


   
        private static bool IsBegin(char cr)
        {
            return cr.Equals('<');
        }

       
        private static bool IsEnd(char cr)
        {
            return cr.Equals('>');
        }

      
        private static string SubString(int index, ref string str)
        {
            ArrayList arrlistB = new ArrayList();
            ArrayList arrlistE = new ArrayList();
            string strTag = "";
            char strend = '0';
            bool isBg = false;
            bool IsSuEndTag = false;

            index = Gindex(str, index);
            string substr = CutString(str, 0, index); 
            string substr1 = CutString(str, index, str.Length - substr.Length);
            int iof = substr.LastIndexOf("<"), iof1 = 0;


            if (iof > 0) iof1 = CutString(substr, iof, substr.Length - iof).IndexOf(">"); 
            if (iof1 < 0) 
            {
                index = index + substr1.IndexOf(">") + 1;
                substr = CutString(str, 0, index);
                substr1 = CutString(str, index, str.Length - substr.Length);
            }

            int indexendtb = substr.LastIndexOf("</tr>");
            if (indexendtb >= 0)
            {
                substr = CutString(str, 0, indexendtb);
                substr1 = CutString(str, indexendtb, str.Length - indexendtb);
            }

            int intsubstr = substr.LastIndexOf("/>") + 1;
            int intsubstr1 = substr1.IndexOf("</");
            if (intsubstr >= 0 && intsubstr1 >= 0) 
            {
                string substr2 = CutString(substr, intsubstr, substr.Length - intsubstr) + CutString(substr1, 0, intsubstr1);
                if (substr2.IndexOf('>') == -1 && substr2.IndexOf('<') == -1) // 
                {
                    substr += CutString(substr1, 0, intsubstr1);
                    substr2 = CutString(substr1, intsubstr1, substr1.Length - intsubstr1);
                    int sub2idf = substr2.IndexOf('>');
                    substr += CutString(substr2, 0, sub2idf);
                    substr1 = CutString(substr2, sub2idf, substr2.Length - sub2idf);
                }
            }



            foreach (char cr in substr)
            {
                if (IsBegin(cr)) isBg = true;
                if (isBg) strTag += cr;

                if (isBg && cr.Equals('/') && strend.Equals('<')) IsSuEndTag = true;

                if (IsEnd(cr))
                {
                    if (strend.Equals('/')) 
                    {
                        isBg = false;
                        IsSuEndTag = false;
                        strTag = "";
                    }

                    if (isBg)
                    {
                        if (!CutString(strTag.ToLower(), 0, 3).Equals("<br"))
                        {
                            if (IsSuEndTag)
                                arrlistE.Add(strTag); 
                            else
                                arrlistB.Add(strTag); 
                        }
                        IsSuEndTag = false;
                        strTag = "";
                        isBg = false;
                    }
                }
                strend = cr;
            }

      
            for (int b = 0; b < arrlistB.Count; b++)
            {
                for (int e = 0; e < arrlistE.Count; e++)
                {
                    string strb = arrlistB[b].ToString().ToLower();
                    int num = strb.IndexOf(' ');
                    if (num > 0) strb = CutString(strb, 0, num) + ">";
                    if (strb.ToLower().Replace("<", "</").Equals(arrlistE[e].ToString().ToLower()))
                    {
                        arrlistB.RemoveAt(b);
                        arrlistE.RemoveAt(e);
                        b = -1;
                        break;
                    }
                }
            }

            
            for (int i = arrlistB.Count; i > 0; i--)
            {
                string stral = arrlistB[i - 1].ToString();
                substr += (stral.IndexOf(" ") == -1 ? stral.Replace("<", "</") : CutString(stral, 0, stral.IndexOf(" ")).Replace("<", "</") + ">");
            }
            
            string strtag = "";
            for (int i = 0; i < arrlistB.Count; i++) strtag += arrlistB[i].ToString();

            str = strtag + substr1; 
            return substr;  
        } 
        
        private static int Gindex(string str, int index)
        {
            bool isBg = false;
            bool isSuEndTag = false;
            bool isNbsp = false, isRnbsp = false; ;
            string strnbsp = "";
            int i = 0, c = 0;
            foreach (char cr in str)
            {
                if (!isBg && IsBegin(cr)) { isBg = true; isSuEndTag = false; }
                if (isBg && IsEnd(cr)) { isBg = false; isSuEndTag = true; }

                if (isSuEndTag && !isBg) 
                {
                    if (cr.Equals('&')) isNbsp = true;
                    if (isNbsp)
                    {
                        strnbsp += cr.ToString();
                        if (strnbsp.Length > " ".Length) { isNbsp = false; strnbsp = ""; }
                        if (cr.Equals(';')) isNbsp = false;
                    }
                    if (!isNbsp && !"".Equals(strnbsp)) isRnbsp = strnbsp.ToLower().Equals(" ");
                }

                if ((isSuEndTag || (!isBg && !isSuEndTag)) && !cr.Equals('\n') && !cr.Equals('\r') && !cr.Equals(' ')) { c++; }

                if (isRnbsp) { c = c - 6; isRnbsp = false; strnbsp = ""; }

                i++;

                if (c == index) return i;
            }
            return i;
        } 


     
        public static string RemoveHtml(string content)
        {
            content = Regex.Replace(content, @"<[^>]*>", string.Empty, RegexOptions.IgnoreCase);
            return Regex.Replace(content, " ", string.Empty, RegexOptions.IgnoreCase);
        } 


      
        public static string CutString(string str, int startIndex, int length)
        {
            if (startIndex >= 0)
            {
                if (length < 0)
                {
                    length = length * -1;
                    if (startIndex - length < 0)
                    {
                        length = startIndex;
                        startIndex = 0;
                    }
                    else
                    {
                        startIndex = startIndex - length;
                    }
                }

                if (startIndex > str.Length) return "";

            }
            else
            {
                if (length < 0)
                {
                    return "";
                }
                else
                {
                    if (length + startIndex > 0)
                    {
                        length = length + startIndex;
                        startIndex = 0;
                    }
                    else
                    {
                        return "";
                    }
                }
            }

            if (str.Length - startIndex < length) length = str.Length - startIndex;

            try
            {
                return str.Substring(startIndex, length);
            }
            catch
            {
                return str;
            }
        } 

    }
}
