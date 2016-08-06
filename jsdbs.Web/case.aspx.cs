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

namespace jsbestop.Web
{
    public partial class _case : PageBase
    {
        private int type;
        private int id;
        protected void Page_Load(object sender, EventArgs e)
        {
            id = GetRequestQuery<int>("id", 0, Convert.ToInt32);
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
        public string GetStrByByteLength(string str, int byteLength, bool isDot)
        {
            return StringPlus.GetStrByByteLength(str, byteLength, isDot);
        }
        private void Bind()
        {
            SearchSuccessStories sss = new SearchSuccessStories();
            sss.IsEnglish = 1;

            if (type == 15)
            {
                qianzhui.Text = "生产";
                houzhui.Text = "设备";
                yingwen.Text = "PRODUCT RUN  EQUIPMENT";


            }
            else if (type == 14)
            {
                qianzhui.Text = "成功";
                houzhui.Text = "案例";
                yingwen.Text = "SUCCESSFUL CASE";


            }
            else
            {
                type = 15;
                qianzhui.Text = "生产";
                houzhui.Text = "设备";
                yingwen.Text = "PRODUCT RUN  EQUIPMENT";
            }
            sss.SSType = type;
            Pagination pagination = new DevNet.Common.Pagination(pager.PageIndex, pager.PageSize, 0);
            using (BLLSuccessStories bll = new BLLSuccessStories())
            {
                List<SuccessStories> lists = bll.GetPageList(sss, pagination);
                rptProducttype.DataSource = lists;
                rptProducttype.DataBind();
                pager.RecordCount = pagination.RecordCount;
            }

        }

        
    }
}