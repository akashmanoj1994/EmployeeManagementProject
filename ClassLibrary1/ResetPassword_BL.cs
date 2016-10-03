using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using Models;
namespace BusinessLogicLayer
{
    public class ResetPassword_BL
    {
        public bool SetNewPassword(ResetPasswordViewModel newCredential)
        {
            ResetPassword_DAL loginData = new ResetPassword_DAL();
            return loginData.SetNewPasswordDB(newCredential);
        }
    }
}
