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
    public class EditEmployee_DAL
    {
        public bool EditDetailsByAdmin(EmployeeDetailsOfficial officialModel,EmployeeDetailsPersonal personalModel,int adminID)
        {
            
            using (var dbContext = new EmployeeManagementEntities())
            {
                var transaction = dbContext.Database.BeginTransaction();
                try
                {
                    EmployeeDetailsOfficial record = dbContext.EmployeeDetailsOfficials.First(m => m.EmployeeID == officialModel.EmployeeID);
                    record.Designation = officialModel.Designation;
                    record.DepartmentCode = officialModel.DepartmentCode;
                    record.OfficeCode = officialModel.OfficeCode;
                    record.IsAdmin = officialModel.IsAdmin;

                    EmployeeDetailsPersonal record2 = dbContext.EmployeeDetailsPersonals.First(m => m.EmployeeID == officialModel.EmployeeID);
                    record2.Salary = personalModel.Salary;

                    dbContext.AddModificationInfo(officialModel.EmployeeID, adminID, LogAction.UPDATED, DateTime.Now);
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
        public bool EditDetailsSelf(EmployeeDetailsOfficial officialModel,EmployeeDetailsPersonal personalModel)
        {
            using (var dbContext = new EmployeeManagementEntities())
            {
                var transaction = dbContext.Database.BeginTransaction();
                try
                {
                    EmployeeDetailsOfficial record = dbContext.EmployeeDetailsOfficials.First(m => m.EmployeeID == officialModel.EmployeeID);
                    record.Name = officialModel.Name;

                    EmployeeDetailsPersonal record2 = dbContext.EmployeeDetailsPersonals.First(m => m.EmployeeID == officialModel.EmployeeID);
                    record2.City = personalModel.City;
                    record2.Country = personalModel.Country;
                    record2.PhoneNumber = personalModel.PhoneNumber;

                    dbContext.SaveChanges();

                    transaction.Commit();
                    return true;
                }
                catch
                {
                    transaction.Rollback();
                }
            }

            return false;
        }
    }
}
