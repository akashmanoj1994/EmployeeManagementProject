using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using System.Net.Mail;
using Utilities;
using System.Configuration;
namespace BusinessLogicLayer
{
    public class EmailQuiry_BL
    {
        public bool SendInquiry(EmailViewModel emailModel)
        {
            string from = System.Configuration.ConfigurationManager.AppSettings["InquiryMailID"];
            string to = from;
            string subject = "New Inquiry";
            string body= "Dear sir,<br/> You have a new inquiry from " + emailModel.Name + ".<br/>Type: " + emailModel.Type + "<br/>Email: " + emailModel.MailID + "<br/>Question: " +emailModel.Question+ "<br/>Thanks";
            string password= System.Configuration.ConfigurationManager.AppSettings["InquiryMailPassword"];
            return MailSender.SendMail(to, from, subject, body,password);
        }
    }
}
