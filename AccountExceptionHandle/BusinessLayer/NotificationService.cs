using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using AccountExceptionHandle.Exceptions;
using System.Threading.Tasks;

namespace AccountExceptionHandle.BusinessLayer
{
    public class NotificationService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Mailid"></param>
        /// <param name="msg"></param>
        /// <param name="subject"></param>
        /// <returns></returns>
        /// <exception cref="UnableToSendMailException"/>
        public bool SendMail(string Mailid,string msg,string subject)
        {
            SmtpClient smtpClient = new SmtpClient();
            MailMessage mailMessage = new MailMessage("manager@abcbank.com", Mailid);
            mailMessage.Body = msg;
            mailMessage.Subject = subject;

            smtpClient.Port = 1231;
            smtpClient.Host = "abcbank.smtp";
            try
            {
                smtpClient.Send(mailMessage);
            }
            catch (SmtpException ex)
            {
                UnableToSendMailException exp = new UnableToSendMailException("Mail server is down",ex);
                throw exp;
            }
            return true;
        }
    }
}
