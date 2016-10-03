using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Utilities;
using System.Data.SqlClient;
using ClassLibrary2;
namespace DataAccessLayer
{
    public class ResetPassword_DAL
    {
        public bool SetNewPasswordDB(ResetPasswordViewModel newcredential)
        {
            int count = 0;
            using (var dbContext = new EmployeeManagementEntities())
            {
                EmployeeDetailsOfficial record = dbContext.EmployeeDetailsOfficials.First(m => m.EmployeeID == newcredential.UserID);
                record.Password = newcredential.Password1;
                count = dbContext.SaveChanges();
            }
            if (count != 0)
                return true;
            else
                return false;
        }
    }
}
