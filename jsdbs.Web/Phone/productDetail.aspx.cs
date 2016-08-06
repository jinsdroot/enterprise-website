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
    public partial class productDetail : PageBase
    {
        private int id = 0;
        private int type;
        protected void Page_Load(object sender, EventArgs e)
        {
            id = GetRequestQuery<int>("id", 0, Convert.ToInt32);
            type = GetRequestQuery<int>("type", 0, Convert.ToInt32);
            if (!IsPostBack)
            {
                MeunBind();
                ShowPro();
            }
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
        private void ShowPro()
        {
            int IsEnglish = Session["isEnglish"] == null ? 1 : Convert.ToInt32(Session["isEnglish"]);
            string[] fileds = new string[] { "id", "IsEnglish" };
            object[] values = new object[] { id, IsEnglish };
            using (BLLProductDetail BLL = new BLLProductDetail())
            {
                ProductDetail obj = new ProductDetail();
                obj = BLL.GetSingle(fileds, values);
                if (obj != null)
                {
                    lblTitle.Text = GetStrByByteLength(obj.ProductName, 30, true);
                    lblContent.Text = obj.ProductContent;
                    image.Src = phoneImgUrl(Convert.ToString(obj.ProductPic));
                    //lblTime.Text = string.Format("{0:D}", obj.AddTime);
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