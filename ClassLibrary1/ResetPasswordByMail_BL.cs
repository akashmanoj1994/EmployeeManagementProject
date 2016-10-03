using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using ClassLibrary2;
using System.Web.Mvc;
using Utilities;
namespace BusinessLogicLayer
{
    public class ResetPasswordByMail_BL
    {
        public bool ValidateAndSend(string mailID)
        {
            Credentials_DAL credentialData = new Credentials_DAL();

            EmployeeDetailsOfficial actualCredential = credentialData.GetCredential(mailID);

            if(actualCredential.IsActive==true)
            {
                string to = actualCredential.EmailID;
                string from = System.Configuration.ConfigurationManager.AppSettings["InquiryMailID"];
                string subject = "Reset Password";
                string body= String.Format("Dear {0},<br/> To reset your password on 'Employee Management' please click the following link <br/><a href=\"{1} \" title=\"Reset password\">ResetPassword</a><br/>Thanks",actualCredential.Name, "http://localhost:49715/Home/ResetPassword?userID="+actualCredential.EmployeeID);
                string password = System.Configuration.ConfigurationManager.AppSettings["InquiryMailPassword"];
                return MailSender.SendMail(to, from, subject, body, password);
                
            }
            return false;
        }
    }
}
