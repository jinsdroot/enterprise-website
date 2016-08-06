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
namespace jsbestop.Web
{
    public partial class ProductListDetail : PageBase
    {
        private int id = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            id = GetRequestQuery<int>("id", 0, Convert.ToInt32);
            if (!IsPostBack)
            {
                ShowMenu();
       
                //Page.Title = "产品展示";
            }
        }
        private void ShowMenu()
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
                    lblTitle.Text = obj.ProductName;
                    lblContent.Text = obj.ProductContent;
                    picpro.ImageUrl = obj.ProductPic;
                }
            }
        }


    }
}