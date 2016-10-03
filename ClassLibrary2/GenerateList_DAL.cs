using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Mvc;
using Utilities;
using ClassLibrary2;

namespace DataAccessLayer
{
    public static class GenerateList
    {
        public static List<SelectListItem> DesignationList()
        {
            using (var dbContext = new EmployeeManagementEntities())
            {
               var list = (from des in dbContext.a_Designation
                           select new SelectListItem()
                           {
                               Text = des.DesignationName,
                               Value = des.Code.ToString()
                           }).ToList();
                return list;
            }
        }
       
        public static List<SelectListItem> DepartmentList()
        {
            using (var dbContext = new EmployeeManagementEntities())
            {
                var list = (from dep in dbContext.a_DepartmentDetails
                            select new SelectListItem()
                            {
                                Text = dep.Name,
                                Value = dep.Code.ToString()
                            }).ToList();
                return list;
            }
        }
        public static List<SelectListItem> OfficeList()
        {
            using (var dbContext = new EmployeeManagementEntities())
            {
                var list = (from off in dbContext.a_OfficeDetails
                            select new SelectListItem()
                            {
                                Text = off.Name,
                                Value = off.Code.ToString()
                            }).ToList();
                return list;
            }
        }
        public static List<SelectListItem> CountryList()
        {
            using (var dbContext = new EmployeeManagementEntities())
            {
                var list = (from con in dbContext.a_Country
                            select new SelectListItem()
                            {
                                Text = con.Name,
                                Value = con.CountryCode.ToString()
                            }).ToList();
                return list;
            }
        }
    }
}
