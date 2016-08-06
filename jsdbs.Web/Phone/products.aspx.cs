using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using jsbestop.Entity.Search;
using jsbestop.BLL;
using jsbestop.Entity;
using System.Text.RegularExpressions;
using DevNet.Common;
using Common;

namespace jsbestop.Web.Phone
{
    public partial class products : PageBase
    {
        private int type;
        public string Title;
        protected void Page_Load(object sender, EventArgs e)
        {
            pager.PageJump += new EventHandler(pager_PageJump);
            type = GetRequestQuery<int>("type", 0, Convert.ToInt32);
            if (!Page.IsPostBack)
            {
                MeunBind();
                Bind();

            }
        }

        void pager_PageJump(object sender, EventArgs e)
        {
            Bind();
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
        private void MeunBind()
        {
            using (BLLProductType bll = new BLLProductType())
            {
                SearchProductType cond = new SearchProductType();
                cond.IsEnglish = 1;
                List<ProductType> lists = bll.GetList(cond);
                //rptProType.DataSource = lists;
                //rptProType.DataBind();
            }
        }

        private void Bind()
        {
            SearchProductDetail snt = new SearchProductDetail();
            snt.IsEnglish = 1;
            if (type == 0)
            { }
            else
            {
                snt.ProTypeID = type;
            }
            Pagination pagination = new DevNet.Common.Pagination(pager.PageIndex, pager.PageSize, 0);
            using (BLLProductDetail bll = new BLLProductDetail())
            {
                List<ProductDetail> lists = bll.GetPageList(snt, pagination);
                rptProduct.DataSource = lists;
                rptProduct.DataBind();
                pager.RecordCount = pagination.RecordCount;

            }
            using (BLLCompanyInformationType bll = new BLLCompanyInformationType())
            {
                string[] fileds = new string[] { "CompanyInformationTypeID", "IsEnglish" };
                object[] values = new object[] { type, 1 };
                CompanyInformationType contype = bll.GetSingle(type);
                if (contype != null)
                {
                    Title = contype.CompanyInformationName;
                }

            }
        }
    }
}