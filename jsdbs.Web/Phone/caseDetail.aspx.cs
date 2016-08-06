using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common;
using jsbestop.BLL;
using jsbestop.Entity;

namespace jsbestop.Web.Phone
{
    public partial class caseDetail : PageBase
    {
        private int id = 0;
        private int type;
        public string Title;
        protected void Page_Load(object sender, EventArgs e)
        {
            id = GetRequestQuery<int>("id", 0, Convert.ToInt32);
            type = GetRequestQuery<int>("type", 0, Convert.ToInt32);
            if (!IsPostBack)
            {
                ShowMenu();
            }
        }
        private void ShowMenu()
        {

            if (type == 14)
            {
                Title = "成功案例";

            }
            else
            {
                Title = "生产设备";

            }
            int IsEnglish = Session["isEnglish"] == null ? 1 : Convert.ToInt32(Session["isEnglish"]);
            string[] fileds = new string[] { "id", "IsEnglish" };
            object[] values = new object[] { id, IsEnglish };
            using (BLLSuccessStories BLL = new BLLSuccessStories())
            {
                SuccessStories obj = new SuccessStories();
                obj = BLL.GetSingle(fileds, values);
                if (obj != null)
                {
                    lblTitle.Text = GetStrByLength(obj.SSName, 30);
                    lblContent.Text = obj.SSContent;
                    image.Src = obj.SSPic;
                }
            }
            using (BLLCompanyInformationType bll = new BLLCompanyInformationType())
            {

                CompanyInformationType contype = bll.GetSingle(type);
                if (contype != null)
                {
                    Title = contype.CompanyInformationName;
                }

            }

        }
    }
}