using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common;
using jsbestop.Entity.Search;
using DevNet.Common;
using jsbestop.BLL;
using jsbestop.Entity;

namespace jsbestop.Web.Phone
{
    public partial class _case : PageBase
    {
        private int type;
        public string Title;
        protected void Page_Load(object sender, EventArgs e)
        {
            type = GetRequestQuery<int>("type", 0, Convert.ToInt32);
            pager.PageJump += new EventHandler(pager_PageJump);
            if (!Page.IsPostBack)
            {
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
        private void Bind()
        {
            SearchSuccessStories sss = new SearchSuccessStories();
            sss.IsEnglish = 1;
            if (type == 14) 
            {
                Title = "成功案例";
                sss.SSType = type;
            }
            else
            {
                Title = "生产设备";
                sss.SSType = type;
            }
            Pagination pagination = new DevNet.Common.Pagination(pager.PageIndex, pager.PageSize, 0);
            using (BLLSuccessStories bll = new BLLSuccessStories())
            {
                List<SuccessStories> lists = bll.GetPageList(sss, pagination);
                rptProducttype.DataSource = lists;
                rptProducttype.DataBind();
                pager.RecordCount = pagination.RecordCount;
            }

            //using (BLLCompanyInformationType bll = new BLLCompanyInformationType())
            //{

            //    CompanyInformationType contype = bll.GetSingle(14);
            //    if (contype != null)
            //    {
            //        Title = contype.CompanyInformationName;
            //    }

            //}

        }
    }
}