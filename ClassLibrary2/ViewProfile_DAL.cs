using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using System.Data.SqlClient;
using Utilities;
using ClassLibrary2;
using System.Data.Entity.SqlServer;

namespace DataAccessLayer
{
    public class ViewProfile_DAL
    {
        public ShowEmployeeViewModel GetProfileDetails(int userid)
        {
            using (var dbContext = new EmployeeManagementEntities())
            {
                
                var details = (from e in dbContext.EmployeeDetailsOfficials
                               join ds in dbContext.a_Designation on e.Designation equals ds.Code
                               join dp in dbContext.a_DepartmentDetails on e.DepartmentCode equals dp.Code
                               join of in dbContext.a_OfficeDetails on e.OfficeCode equals of.Code
                               join ep in dbContext.EmployeeDetailsPersonals on e.EmployeeID equals ep.EmployeeID
                               join cn in dbContext.a_Country on ep.Country equals cn.CountryCode
                               where e.EmployeeID==userid
                               select new ShowEmployeeViewModel()
                               {
                                   Name=e.Name,
                                   EmployeeID = e.EmployeeID,
                                   Designation=ds.DesignationName,
                                   Department=dp.Name,
                                   MailID=e.EmailID,
                                   Office=of.Name,
                                   City=ep.City,
                                   Country=cn.Name,
                                   PhoneNumber=ep.PhoneNumber
                               }).FirstOrDefault();
                return details;
                
            }

        }
        public List<ShowEmployeePrimaryViewModel> GetEmployeeListWithPrimaryDetails(string name,string loggedinusername)
        {
            using (var dbContext = new EmployeeManagementEntities())
            {
                var detailList = (from eo in dbContext.EmployeeDetailsOfficials
                                  join dp in dbContext.a_DepartmentDetails on eo.DepartmentCode equals dp.Code
                                  join of in dbContext.a_OfficeDetails on eo.OfficeCode equals of.Code
                                  where (eo.IsActive == true) && (eo.Name != loggedinusername) && (name==null ? true : eo.Name.StartsWith(name))
                                  orderby eo.Name
                                  select new ShowEmployeePrimaryViewModel()
                                  {
                                      EmployeeID=eo.EmployeeID,
                                      Name=eo.Name,
                                      Department=dp.Name,
                                      EmailID=eo.EmailID,
                                      Office=of.Name
                                  }).ToList();
                return detailList;
                
            }
            
        }
        public EditEmployeeByAdminViewModel GetEmployeeDetailsForEditing(int userid)
        {
            using (var dbContext = new EmployeeManagementEntities())
            {
                var record = (from eo in dbContext.EmployeeDetailsOfficials
                             join ep in dbContext.EmployeeDetailsPersonals on eo.EmployeeID equals ep.EmployeeID
                             where eo.EmployeeID == userid
                             select new EditEmployeeByAdminViewModel()
                             {
                                 EmployeeID=userid,
                                 Name=eo.Name,
                                 Designation=eo.Designation,
                                 Department=eo.DepartmentCode,
                                 Office=eo.OfficeCode,
                                 IsAdmin=eo.IsAdmin,
                                 Salary=ep.Salary
                             }).FirstOrDefault();
                return record;
            }
            
            
        }
        public EditEmployeeSelfViewModel GetEmployeeDetailsForEditingSelf(int userid)
        {
            using (var dbContext = new EmployeeManagementEntities())
            {
                var record = (from eo in dbContext.EmployeeDetailsOfficials
                              join ep in dbContext.EmployeeDetailsPersonals on eo.EmployeeID equals ep.EmployeeID
                              where eo.EmployeeID==userid
                              select new EditEmployeeSelfViewModel()
                              {
                                  EmployeeID=eo.EmployeeID,
                                  Name=eo.Name,
                                  EmailID=eo.EmailID,
                                  City=ep.City,
                                  Country=ep.Country.HasValue ? ep.Country.Value : 1,
                                  Phone=ep.PhoneNumber
                              }).FirstOrDefault();
                return record;
            }
        }
    }
}
