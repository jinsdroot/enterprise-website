using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cnkj.Utility;
using jsbestop.BLL;
using jsbestop.Entity;
using Common;
using System.Data;
using jsbestop.Entity.Search;
using System.Data.OleDb;

namespace jsbestop.Web.Manager.MessageManager
{
    public partial class cpMessageDetail : AdminPageBase
    {
        private int id = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            id = GetRequestQuery<int>("id", 0, Convert.ToInt32);
            if (!IsPostBack)
            {
                setInfo();
            }
        }

        private void setInfo()
        {
            if (id > 0)
            {
                using (BLLMessages bll = new BLLMessages())
                {
                    Messages mesg = bll.GetSingle(id);
                    if (mesg != null)
                    {
                        lblMesDetail.Text = mesg.MesContent;
                        lblMesName.Text = mesg.MesName;
                        lblMesPhone.Text = mesg.MesTelphone;
                        lblMesTel.Text = mesg.MesQQ;
                        lblMesEmail.Text = mesg.MesEmail;
                        lblMesAdd.Text = mesg.MesAddress;
                        lblMesReTime.Text = mesg.MesCompany;
                        lblMessageDate.Text = mesg.MesDate.ToString();
                        txtMesReplayDetail.Text = mesg.ReplyContent.ToString();
                        if (mesg.IsReply == 1)
                        {
                            lblIsRead.Text = "是";
                        }
                        else
                        {
                            lblIsRead.Text = "否";
                        }
                    }
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            using (BLLMessages bll = new BLLMessages())
            {
                Messages mesg = bll.GetSingle(id);
                mesg.ID = id;
                mesg.MesContent = lblMesDetail.Text.Trim().ToString();
                mesg.MesName = lblMesName.Text.Trim().ToString();
                mesg.MesTelphone = lblMesPhone.Text.Trim().ToString();
                mesg.MesQQ = lblMesTel.Text.Trim().ToString();
                mesg.MesEmail = lblMesEmail.Text.Trim().ToString();
                mesg.MesAddress = lblMesAdd.Text.Trim().ToString();
                mesg.MesCompany = lblMesReTime.Text.Trim().ToString();
                mesg.MesDate = Convert.ToDateTime(lblMessageDate.Text.ToString());
                if (txtMesReplayDetail.Text.Trim().ToString() != "")
                {
                    mesg.IsReply = 1;
                }
                mesg.ReplyContent = txtMesReplayDetail.Text.ToString();
                AdminUser admin = Session["admin"] as AdminUser;

                mesg.ReplyName = admin.TrueName.ToString();
                mesg.RePlyDate = System.DateTime.Now;

                try
                {
                    bll.Save(mesg);
                }
                catch (Exception)
                {

                    throw;
                }

                if (bll.IsFail)
                {
                    ExceptionManager.ShowErrorMsg(this, bll.DevNetException);
                }
                else
                {
                    JSMsg.ShowWinRedirect(this, "保存成功", "cpMessageList.aspx");
                }
            }
        }
    }
}