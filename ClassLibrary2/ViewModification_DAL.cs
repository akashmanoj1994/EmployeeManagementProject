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
    public class ViewModification_DAL
    {
        public List<ModificationViewModel> GetAllModificationList()
        {
            using (var dbContext = new EmployeeManagementEntities())
            {
                var recordList = (from m in dbContext.ModificationInfoes
                                 join ad in dbContext.EmployeeDetailsOfficials on m.AdminID equals ad.EmployeeID
                                 join em in dbContext.EmployeeDetailsOfficials on m.EmployeeID equals em.EmployeeID
                                 select new ModificationViewModel()
                                 {
                                     LogNumber=m.LogNumber,
                                     AdminName=ad.Name,
                                     AdminID=ad.EmployeeID,
                                     Action=m.Action,
                                     EmployeeName=em.Name,
                                     EmployeeID=em.EmployeeID,
                                     Time=(DateTime)m.ActionDate
                                 }).ToList();
                return recordList;
            }
        }
    }
}
