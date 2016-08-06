using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common;
using jsbestop.BLL;
using jsbestop.Entity;
using System.Text.RegularExpressions;
using jsbestop.Entity.Search;
using DevNet.Common;

namespace jsbestop.Web
{
    public partial class index : System.Web.UI.Page
    {

        public string phone;
        public string tel;
        public string address;
        public string fax;
        public string name;
        public string people;
        public string website;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                IsPhone();
                setInfo();
                MeunBindtype();
                ProBind();
                NewsBind();
                BannerBind();
                setContactsInfo();
                Bindanli();
                setnews();
                Bindshengchan();
                Bind();
                jishao();
                Bindqiye();
                bindInfo();
                Page.Title = ConfigHelper.GetAppString("Title") + "-网页首页";
            }
        }



        private void Bindanli()
        {
            SearchSuccessStories sss = new SearchSuccessStories();
            sss.IsEnglish = 1;

        
            sss.SSType = 14;
            Pagination pagination = new DevNet.Common.Pagination(0, 20, 0);
            using (BLLSuccessStories bll = new BLLSuccessStories())
            {
                List<SuccessStories> lists = bll.GetPageList(sss, pagination);
                chenggong.DataSource = lists;
                chenggong.DataBind();
               
            }

        }
        private void Bindshengchan()
        {
            SearchSuccessStories sss = new SearchSuccessStories();
            sss.IsEnglish = 1;


            sss.SSType = 15;
            Pagination pagination = new DevNet.Common.Pagination(0, 20, 0);
            using (BLLSuccessStories bll = new BLLSuccessStories())
            {
                List<SuccessStories> lists = bll.GetPageList(sss, pagination);
                shengchan.DataSource = lists;
                shengchan.DataBind();
                shengchan1.DataSource = lists;
                shengchan1.DataBind();

            }

        }
        private void jishao()
        {
            // 公司信息
            using (BLLCompanyInformationDetails bll = new BLLCompanyInformationDetails())
            {

                
                string[] fileds = new string[] { "CompanyInformationTypeID", "IsEnglish" };
                object[] values = new object[] { 5, 1 };

                // 公司简介
                CompanyInformationDetails cpinfor = bll.GetSingle(fileds, values);
                if (cpinfor != null)
                {
                    companyintroduce.Text = cpinfor.CompanyInformationDetail;
                }
                else
                {
                }

            }

        }

        private void Bindqiye()
        {
            SearchSuccessStories sss = new SearchSuccessStories();
            sss.IsEnglish = 1;
            sss.SSType = 16;
            Pagination pagination = new DevNet.Common.Pagination(0, 6, 0);
            using (BLLSuccessStories bll = new BLLSuccessStories())
            {
                List<SuccessStories> lists = bll.GetPageList(sss, pagination);
                //rptProducttype.DataSource = lists;
                //rptProducttype.DataBind();
                //pager.RecordCount = pagination.RecordCount;
            }

        }
        private void setContactsInfo()
        {
            using (BLLContact bll = new BLLContact())
            {
                Contact contact = bll.GetSingle(1);
                if (contact != null)
                {
                    address = contact.ConAddress;
                    tel = contact.ConTel;
                    ////lblTel1.Text = contact.ConTel;
                    name = contact.ConCompany;
                    //Lblcomname1.Text = contact.ConCompany;

                    phone = contact.ConPhone;
                    //lblEmail.Text = contact.ConEmail;
                    fax = contact.ConFax;
                    people = contact.ConName;
                    website = contact.ConWebsite;
                    //numbertongji = contact.BaiDuCount.ToString();
                }
            }
        }

        private void BannerBind()
        {
            SearchComBanner scb = new SearchComBanner();
            scb.ComBannerTypeID = 4;
            using (BLLComBanner bll = new BLLComBanner())
            {
                List<ComBanner> lists = bll.GetList(scb);
                rptBanner.DataSource = lists;
                rptBanner.DataBind();
            }
        }

        private void setnews()
        {
            SearchNewsDetail snt = new SearchNewsDetail();
            snt.IsEnglish = 1;

            Pagination pagination = new DevNet.Common.Pagination(1, 6, 0);
            using (BLLNewsDetail bll = new BLLNewsDetail())
            {
                List<NewsDetail> lists = bll.GetPageList(snt, pagination);

                rptNews.DataSource = lists;
                rptNews.DataBind();
            }
        }
        /// <summary>
        /// 按字节长度剪切字符串
        /// </summary>
        /// <param name="str"></param>
        /// <param name="byteLength"></param>
        /// <param name="isDot">是否末尾加  ...</param>
        /// <returns></returns>
        protected string GetStrByByteLength(string str, int byteLength, bool isDot)
        {
            return StringPlus.GetStrByByteLength(str, byteLength, isDot);
        }
        public string DelHTML(string Htmlstring, int length)//将HTML去除
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
        private void setInfo()
        {
            using (BLLContact bll = new BLLContact())
            {
                Contact contact = bll.GetSingle(1);
                if (contact != null)
                {
                    //lblAddress.Text = contact.ConAddress;
                    //lblTel.Text = contact.ConTel;
                    
                    //Lblcomname.Text = contact.ConCompany;
                    //Lblcomname1.Text = contact.ConCompany;
                    //lblPhone.Text = contact.ConPhone;
                    //lblEmail.Text = contact.ConEmail;
                    //lblFax.Text = contact.ConFax;
                    //lblWeb.Text = contact.ConWebsite;
                    //numbertongji = contact.BaiDuCount.ToString();
                }
            }
        }

        private void ProBind()
        {
            SearchProductDetail snt = new SearchProductDetail();
            snt.IsEnglish = 1;
            Pagination pagination = new DevNet.Common.Pagination(0, 9, 0);
            using (BLLProductDetail bll = new BLLProductDetail())
            {
                List<ProductDetail> lists = bll.GetPageList(snt, pagination);
                rptProduct.DataSource = lists;
                rptProduct.DataBind();
            }

        }

        private void MeunBindtype()
        {
            using (BLLProductType bll = new BLLProductType())
            {
                SearchProductType cond = new SearchProductType();
                cond.IsEnglish = 1;
                List<ProductType> lists = bll.GetList(cond);
                rptProType.DataSource = lists;
                rptProType.DataBind();
            }
        }
        private void NewsBind()
        {
            SearchNewsDetail snt = new SearchNewsDetail();
            using (BLLNewsDetail bll = new BLLNewsDetail())
            {
                snt.IsEnglish = 1;
                List<NewsDetail> nd = bll.GetTopList(snt);
                if (nd != null)
                {
                    if (nd.Count >= 1)
                    {
                    //    newsFirTitle.Text = GetStrByByteLength(nd[0].NewsTitle, 50, true);
                    //    newsFirText.Text = DelHTML(nd[0].NewsContent, 100);
                    //    newsFirTime1.Text = Convert.ToDateTime(nd[0].AddTime).ToString("yyy-MM");
                    //    newsFirTime2.Text = Convert.ToDateTime(nd[0].AddTime).ToString("dd");
                    //    Session["newsFirid"] = nd[0].ID;
                    //}
                    //if (nd.Count >= 2)
                    //{
                    //    newsSecTitle.Text = GetStrByByteLength(nd[1].NewsTitle, 50, true);
                    //    newsSecText.Text = DelHTML(nd[1].NewsContent, 100);
                    //    newsSecTime1.Text = Convert.ToDateTime(nd[1].AddTime).ToString("yyy-MM");
                    //    newsSecTime2.Text = Convert.ToDateTime(nd[1].AddTime).ToString("dd");
                    //    Session["newsSecid"] = nd[1].ID;
                    //}
                    //if (nd.Count >= 3)
                    //{
                    //    newsThrTitle.Text = GetStrByByteLength(nd[2].NewsTitle, 50, true);
                    //    newsThrText.Text = DelHTML(nd[2].NewsContent, 100);
                    //    newsThrTime1.Text = Convert.ToDateTime(nd[2].AddTime).ToString("yyy-MM");
                    //    newsThrTime2.Text = Convert.ToDateTime(nd[2].AddTime).ToString("dd");
                    //    Session["newsThrid"] = nd[2].ID;
                    }
                }
            }
        }

        /// <summary>
        /// 判断手机与pc
        /// </summary>
        public void IsPhone()
        {
            string str_u = Request.ServerVariables["HTTP_USER_AGENT"];
            Regex b = new Regex(@"android.+mobile|avantgo|bada\/|blackberry|blazer|compal|elaine|fennec|hiptop|iemobile|ip(hone|od)|iris|kindle|lge |maemo|midp|mmp|netfront|opera m(ob|in)i|palm( os)?|phone|p(ixi|re)\/|plucker|pocket|psp|symbian|treo|up\.(browser|link)|vodafone|wap|windows (ce|phone)|xda|xiino", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            Regex v = new Regex(@"1207|6310|6590|3gso|4thp|50[1-6]i|770s|802s|a wa|abac|ac(er|oo|s\-)|ai(ko|rn)|al(av|ca|co)|amoi|an(ex|ny|yw)|aptu|ar(ch|go)|as(te|us)|attw|au(di|\-m|r |s )|avan|be(ck|ll|nq)|bi(lb|rd)|bl(ac|az)|br(e|v)w|bumb|bw\-(n|u)|c55\/|capi|ccwa|cdm\-|cell|chtm|cldc|cmd\-|co(mp|nd)|craw|da(it|ll|ng)|dbte|dc\-s|devi|dica|dmob|do(c|p)o|ds(12|\-d)|el(49|ai)|em(l2|ul)|er(ic|k0)|esl8|ez([4-7]0|os|wa|ze)|fetc|fly(\-|_)|g1 u|g560|gene|gf\-5|g\-mo|go(\.w|od)|gr(ad|un)|haie|hcit|hd\-(m|p|t)|hei\-|hi(pt|ta)|hp( i|ip)|hs\-c|ht(c(\-| |_|a|g|p|s|t)|tp)|hu(aw|tc)|i\-(20|go|ma)|i230|iac( |\-|\/)|ibro|idea|ig01|ikom|im1k|inno|ipaq|iris|ja(t|v)a|jbro|jemu|jigs|kddi|keji|kgt( |\/)|klon|kpt |kwc\-|kyo(c|k)|le(no|xi)|lg( g|\/(k|l|u)|50|54|\-[a-w])|libw|lynx|m1\-w|m3ga|m50\/|ma(te|ui|xo)|mc(01|21|ca)|m\-cr|me(di|rc|ri)|mi(o8|oa|ts)|mmef|mo(01|02|bi|de|do|t(\-| |o|v)|zz)|mt(50|p1|v )|mwbp|mywa|n10[0-2]|n20[2-3]|n30(0|2)|n50(0|2|5)|n7(0(0|1)|10)|ne((c|m)\-|on|tf|wf|wg|wt)|nok(6|i)|nzph|o2im|op(ti|wv)|oran|owg1|p800|pan(a|d|t)|pdxg|pg(13|\-([1-8]|c))|phil|pire|pl(ay|uc)|pn\-2|po(ck|rt|se)|prox|psio|pt\-g|qa\-a|qc(07|12|21|32|60|\-[2-7]|i\-)|qtek|r380|r600|raks|rim9|ro(ve|zo)|s55\/|sa(ge|ma|mm|ms|ny|va)|sc(01|h\-|oo|p\-)|sdk\/|se(c(\-|0|1)|47|mc|nd|ri)|sgh\-|shar|sie(\-|m)|sk\-0|sl(45|id)|sm(al|ar|b3|it|t5)|so(ft|ny)|sp(01|h\-|v\-|v )|sy(01|mb)|t2(18|50)|t6(00|10|18)|ta(gt|lk)|tcl\-|tdg\-|tel(i|m)|tim\-|t\-mo|to(pl|sh)|ts(70|m\-|m3|m5)|tx\-9|up(\.b|g1|si)|utst|v400|v750|veri|vi(rg|te)|vk(40|5[0-3]|\-v)|vm40|voda|vulc|vx(52|53|60|61|70|80|81|83|85|98)|w3c(\-| )|webc|whit|wi(g |nc|nw)|wmlb|wonu|x700|yas\-|your|zeto|zte\-", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (!(b.IsMatch(str_u) || v.IsMatch(str_u.Substring(0, 4))))
            {
                //PC访问
                if (Request.Url.ToString().IndexOf("phone") > 0)
                {
                    Response.Redirect("/index.aspx", false);
                }
            }
            else
            {
                if (Request.Url.ToString().IndexOf("phone") > 0)
                {

                }
                else
                {
                    //手机访问   
                    Response.Redirect("/phone/index.aspx", false);
                }
            }
        }
        private void Bind()
        {
            //SearchSuccessStories sss = new SearchSuccessStories();
            //sss.IsEnglish = 1;
       

            //using (BLLSuccessStories bll = new BLLSuccessStories())
            //{
            //    List<SuccessStories> lists = bll.GetList(sss);
            //    rptProducttype.DataSource = lists;
            //    rptProducttype.DataBind();
        
            //}

        }

        private void bindInfo()
        {
            SearchSuccessStories spt = new  SearchSuccessStories();
            spt.IsEnglish = 1;
            using (BLLSuccessStories bll = new BLLSuccessStories())
            {
                List<SuccessStories> lists = bll.GetList(spt);

                if (lists != null)
                {
                    int x = 0;

                    for (int i = 0; i < (lists.Count) / 2; i++)
                    {
                    //    prlsdaafgad.InnerHtml += "<span class=\"workItem\">";
                    //    if (lists[x] != null)
                    //    {
                    //        prlsdaafgad.InnerHtml += "<a href=\"caseDetail.aspx?id=" + lists[x].ID + "\" ><img src=\"" + lists[x].SSPic + "\" alt=\"\" />" + "</a>";
                    //    }
                    //    x++;
                    //    if (lists[x] != null)
                    //    {
                    //        prlsdaafgad.InnerHtml += "<a href=\"caseDetail.aspx?id=" + lists[x].ID + "\" ><img src=\"" + lists[x].SSPic + "\" alt=\"\" />" + "</a>";
                    //    }
                    //    x++;
                    //    prlsdaafgad.InnerHtml += "</span>";
                    }

                }
                else
                {
                    //prlsdaafgad.InnerHtml += "暂无数据";
                }
            }
        }




    }
}