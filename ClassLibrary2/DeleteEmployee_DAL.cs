using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;
using ClassLibrary2;
namespace DataAccessLayer
{
    public class DeleteEmployee_DAL
    {
        public bool DeleteEmployeeDetails(int userID,int adminID)
        {
            using (var dbContext = new EmployeeManagementEntities())
            {
                EmployeeDetailsOfficial record = dbContext.EmployeeDetailsOfficials.First(m => m.EmployeeID == userID);
                if (record.IsAdmin == false)
                {
                    record.IsActive = false;
                    if (dbContext.SaveChanges() != 0)
                    {
                        dbContext.AddModificationInfo(userID, adminID, LogAction.DELETED, DateTime.Now);
                        dbContext.SaveChanges();
                        return true;
                    }
                }
                return false;
            }
        }
    }
}
