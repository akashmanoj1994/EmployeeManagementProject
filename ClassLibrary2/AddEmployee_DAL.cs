using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using System.Data.SqlClient;
using Utilities;
using System.Data;
using ClassLibrary2;
namespace DataAccessLayer
{
    public class AddEmployee_DAL
    {
        public bool AddDetails(EmployeeDetailsOfficial employeeOfficial,EmployeeDetailsPersonal employeePersonal, int adminID)
        {
            
            using (var dbContext = new EmployeeManagementEntities())
            {
                var transaction = dbContext.Database.BeginTransaction();

                try
                {
                    int employeeID =(int) dbContext.AddNewEmployeeDetail(employeeOfficial.Name, employeeOfficial.Designation, employeeOfficial.DepartmentCode, employeeOfficial.EmailID,
                                             employeeOfficial.Password, employeeOfficial.Gender, employeeOfficial.OfficeCode, employeeOfficial.IsAdmin, employeeOfficial.IsActive,
                                             employeePersonal.City, employeePersonal.Country, employeePersonal.PhoneNumber, employeePersonal.Salary).Single();
                    dbContext.SaveChanges();
                    //save to modficationinfo
                    dbContext.AddModificationInfo(employeeID, adminID, LogAction.ADDED, DateTime.Now);
                    dbContext.SaveChanges();

                    transaction.Commit();
                    return true;
                }
                catch
                {
                    transaction.Rollback();
                }
                return false;
            }
            
        }
        public bool CheckName(string name)
        {
            int count;
            using (var dbContext = new EmployeeManagementEntities())
            {
                count = (int)dbContext.NameAvailability(name).Single();
            }
            if (count != 0)
                return true;
            return false;
        }

        public bool CheckMail(string mail)
        {
            int count;
            using (var dbContext = new EmployeeManagementEntities())
            {
                count = (int)dbContext.EmailAvailability(mail).Single();
            }
            if (count != 0)
                return true;
            return false;
        }

    }
}
