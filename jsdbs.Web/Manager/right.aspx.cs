using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using jsbestop.Entity;
using Cnkj.Utility;
using Common;

namespace jsbestop.Web.Manager
{
    public partial class right : AdminPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
			if(!IsPostBack)
			{
                AdminUser adminbestop = new AdminUser();
                adminbestop=(AdminUser)Session["admin"];
                if (adminbestop.Account == "jsbestop.admin.54" && adminbestop.PassWord == WebCommon.Md5Enctry("21876"))
                {
                    btnSubmit.Visible = true;
                    txtName.Visible = true;
                    setInfo();
                }
                else
                {
                    btnSubmit.Visible = false;
                    txtName.Visible = false;
                }
			}
        }
        private void setInfo()
        {
            txtName.Text = ConfigHelper.GetAppString("BestopLink").ToString().Trim();
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            SetValue("BestopLink", txtName.Text.ToString().Trim());
        }
        public static void SetValue(string AppKey, string AppValue)
        {
            HttpContext HttpCurrent = HttpContext.Current;
            if (HttpCurrent != null)
            {
                System.Xml.XmlDocument xDoc = new System.Xml.XmlDocument();
                xDoc.Load(HttpCurrent.Server.MapPath("~") + "Web.config");

                System.Xml.XmlNode xNode;
                System.Xml.XmlElement xElem1;
                System.Xml.XmlElement xElem2;
                xNode = xDoc.SelectSingleNode("//appSettings");

                xElem1 = (System.Xml.XmlElement)xNode.SelectSingleNode("//add[@key='" + AppKey + "']");
                if (xElem1 != null) xElem1.SetAttribute("value", AppValue);
                else
                {
                    xElem2 = xDoc.CreateElement("add");
                    xElem2.SetAttribute("key", AppKey);
                    xElem2.SetAttribute("value", AppValue);
                    xNode.AppendChild(xElem2);
                }
                xDoc.Save(HttpCurrent.Server.MapPath("~") + "Web.config");
            }
        }
    }
}
