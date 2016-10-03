using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using System.Data.SqlClient;
using Utilities;
using ClassLibrary2;

namespace DataAccessLayer
{
    public class Credentials_DAL
    {
        public EmployeeDetailsOfficial GetCredential(string email)
        {
            EmployeeDetailsOfficial record;
            using (var dbContext = new EmployeeManagementEntities())
            {
                if(dbContext.EmployeeDetailsOfficials.Any(m=>m.EmailID==email))
                {
                    record = dbContext.EmployeeDetailsOfficials.FirstOrDefault(m => m.EmailID == email);
                }
                else
                {
                    record = new EmployeeDetailsOfficial();
                    record.IsActive = false;
                }
            }
            return record;
        }

    }
}
