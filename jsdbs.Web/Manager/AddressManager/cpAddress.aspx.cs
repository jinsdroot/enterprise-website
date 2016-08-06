using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using jsbestop.BLL;
using jsbestop.Entity;
using Common;
using Cnkj.Utility;

namespace jsbestop.Web.Manager.AddressManager
{
    public partial class cpAddress : AdminPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                setInfo();
            }
        }

        private void setInfo()
        {
            using (BLLContact bll = new BLLContact())
            {
                Contact obj = new Contact();
                if (this.rbtnIsChinese.Checked == true)
                {
                    obj = bll.GetSingle(1);
                }
                else if (this.rbtnIsEnglish.Checked == true)
                {
                    obj = bll.GetSingle(2);
                }
                txtConCompany.Text = obj.ConCompany;
                txtConAddress.Text = obj.ConAddress;
                txtConPhone.Text = obj.ConPhone;
                txtConTel.Text = obj.ConTel;
                txtConFax.Text = obj.ConFax;
                txtConEmail.Text = obj.ConEmail;
                txtConWebsite.Text = obj.ConWebsite;
                txtConName.Text = obj.ConName;
                txtHotPhone.Text = obj.HotPhone;
                txtBaiDuCount.Text = obj.BaiDuCount;
                txtRemarks.Text = obj.Remarks;
                phoneTxtTel.Text = obj.PhoneTel;
                phoneTxtSms.Text = obj.PhoneSms;
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            using (BLLContact bll = new BLLContact())
            {
                Contact obj = new Contact();
                if (this.rbtnIsChinese.Checked == true)
                {
                    obj = bll.GetSingle(1);
                }
                else if (this.rbtnIsEnglish.Checked == true)
                {
                    obj = bll.GetSingle(2);
                }
                obj.ConCompany = txtConCompany.Text.ToString();
                obj.ConAddress = txtConAddress.Text.ToString();
                obj.ConPhone = txtConPhone.Text.ToString();
                obj.ConTel = txtConTel.Text.ToString();
                obj.ConFax = txtConFax.Text.ToString();
                obj.ConEmail = txtConEmail.Text.ToString();
                obj.ConWebsite = txtConWebsite.Text.ToString();
                obj.ConName = txtConName.Text.ToString();
                obj.HotPhone = txtHotPhone.Text.ToString();
                obj.BaiDuCount = txtBaiDuCount.Text.ToString();
                obj.Remarks = txtRemarks.Text.ToString();
                obj.PhoneTel = phoneTxtTel.Text.ToString();
                obj.PhoneSms = phoneTxtSms.Text.ToString();
                bll.Save(obj);

                if (bll.IsFail)
                {
                    ExceptionManager.ShowErrorMsg(this, bll.DevNetException);
                }
                else
                {
                    JSMsg.ShowMsg(this, "保存成功");
                }
            }
        }

        protected void rbtnIsChinese_CheckedChanged(object sender, EventArgs e)
        {
            setInfo();
        }
    }
}