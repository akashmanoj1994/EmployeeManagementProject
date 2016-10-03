using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using DataAccessLayer;
using ClassLibrary2;
namespace BusinessLogicLayer
{
    public class EditEmployee_BL
    {
        public bool EditByAdmin(EditEmployeeByAdminViewModel model,int adminID)
        {
            EmployeeDetailsOfficial employeeOfficial = new EmployeeDetailsOfficial();
            employeeOfficial.EmployeeID = model.EmployeeID;
            employeeOfficial.Name = model.Name;
            employeeOfficial.Designation = model.Designation;
            employeeOfficial.DepartmentCode = model.Department;
            employeeOfficial.OfficeCode = model.Office;
            employeeOfficial.IsAdmin = model.IsAdmin;

            EmployeeDetailsPersonal employeePersonal = new EmployeeDetailsPersonal();
            employeePersonal.Salary = model.Salary;

            EditEmployee_DAL editData = new EditEmployee_DAL();
            return editData.EditDetailsByAdmin(employeeOfficial,employeePersonal,adminID);
        }
        public bool EditSelf(EditEmployeeSelfViewModel model)
        {
            EmployeeDetailsOfficial employeeOfficial = new EmployeeDetailsOfficial();
            employeeOfficial.EmployeeID = model.EmployeeID;
            employeeOfficial.Name = model.Name;

            EmployeeDetailsPersonal employeePersonal = new EmployeeDetailsPersonal();
            employeePersonal.City = model.City;
            employeePersonal.Country = model.Country;
            employeePersonal.PhoneNumber = model.Phone;

            EditEmployee_DAL editData = new EditEmployee_DAL();
            return editData.EditDetailsSelf(employeeOfficial,employeePersonal);
        }
    }
}
