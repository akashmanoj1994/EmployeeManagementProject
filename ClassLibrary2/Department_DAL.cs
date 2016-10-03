using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;
using Models;
using ClassLibrary2;
namespace DataAccessLayer
{
    public class Department_DAL
    {

        public List<DepartmentViewModel> GetDepartmentList()
        {
            
            using (var dbContext = new EmployeeManagementEntities())
            {
                var departmentList = (from dp in dbContext.a_DepartmentDetails
                                     select new DepartmentViewModel()
                                     {
                                             Name = dp.Name,
                                             Description=dp.Description,
                                     }).ToList();

                return departmentList;
            }
            
        }
    }
}
