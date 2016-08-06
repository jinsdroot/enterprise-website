using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Net.Mail;

namespace Common
{
    /// <summary>
    /// SendMail 的摘要说明
    /// </summary>
    public static class SendMail
    {
      
        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <param name="smtpServer">smtp配置服务器</param>
        /// <param name="port">端口，默认请使用25</param>
        /// <param name="fromEmail">From Emal</param>
        /// <param name="fromEmailPassword">From PassWord</param>
        /// <param name="toEmail">To Emal</param>
        /// <param name="strSubject">主题</param>
        /// <param name="strBody">正文，内容</param>
        /// <param name="attachFiles" >附件全路径列表[绝对路径]，可以为null</param>
        public static void SendSMTPEMail(string smtpServer,int port, string fromEmail, string fromEmailPassword, string[]  toEmail, string strSubject, string strBody,params string[] attachFiles)
        {
            if (toEmail.Length == 0)
                throw new ArgumentException("目标Email不能为空", "toEmail");
            System.Net.Mail.SmtpClient client = new SmtpClient(smtpServer);
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential(fromEmail, fromEmailPassword);
            client.DeliveryMethod = SmtpDeliveryMethod.Network;

            System.Net.Mail.MailMessage message = new System.Net.Mail.MailMessage();
                //strFrom, strto, strSubject, strBody);
            message.From = new MailAddress(fromEmail);

            for (int i = 0; i < toEmail.Length; i++)
                message.To.Add(toEmail[i]);

            message.Subject = strSubject;
            message.Body = strBody;

            //  邮件附件
            if (attachFiles != null && attachFiles.Length > 0)
            {
                foreach (string file in attachFiles)
                {
                    System.Net.Mail.Attachment attachment = new System.Net.Mail.Attachment(file);
                    message.Attachments.Add(attachment);
                }
            }
            message.BodyEncoding = System.Text.Encoding.UTF8;
            message.IsBodyHtml = true;
			
            client.Port = port;
            client.Send(message);
        }

        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <param name="smtpServer">smtp配置服务器</param>
        /// <param name="fromEmail">From Email</param>
        /// <param name="fromEmailPassWord">FromEmail PassWord</param>
        /// <param name="toEmail">To Email</param>
        /// <param name="strSubject">邮件标题</param>
        /// <param name="strBody">内容</param>
        public static void SendSMTPEMail(string smtpServer, string fromEmail, string fromEmailPassWord, string toEmail, string strSubject, string strBody)
        {
            System.Net.Mail.SmtpClient client = new SmtpClient(smtpServer);
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential(fromEmail, fromEmailPassWord);
            client.DeliveryMethod = SmtpDeliveryMethod.Network;

            System.Net.Mail.MailMessage message = new System.Net.Mail.MailMessage(fromEmail, toEmail, strSubject, strBody);
            message.BodyEncoding = System.Text.Encoding.UTF8;
            message.IsBodyHtml = true;
            client.Send(message);
        }

		/// <summary>
		/// 发送邮件
		/// </summary>
		/// <param name="smtpServer">smtp配置服务器</param>
		/// <param name="fromEmail">From Email</param>
		/// <param name="fromEmailPassWord">FromEmail PassWord</param>
		/// <param name="toEmail">To Email</param>
		/// <param name="CcEmail">抄送Email</param>
		/// <param name="strSubject">邮件标题</param>
		/// <param name="strBody">内容</param>
		public static void SendSMTPEMail(string smtpServer, string fromEmail, string fromEmailPassWord, string toEmail, string[] CcEmail, string strSubject, string strBody)
		{
			System.Net.Mail.SmtpClient client = new SmtpClient(smtpServer);
			client.UseDefaultCredentials = false;
			client.Credentials = new System.Net.NetworkCredential(fromEmail, fromEmailPassWord);
			client.DeliveryMethod = SmtpDeliveryMethod.Network;

			System.Net.Mail.MailMessage message = new System.Net.Mail.MailMessage(fromEmail, toEmail, strSubject, strBody);
			if (CcEmail != null && CcEmail.Length > 0)
			{
				foreach (string cc in CcEmail)
					message.CC.Add(cc);
			}
			message.BodyEncoding = System.Text.Encoding.UTF8;
			message.IsBodyHtml = true;
			client.Send(message);
		}

    }
}