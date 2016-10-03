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
    public class AddEmployee_BL
    {
        public bool AddAllDetails(NewEmployeeViewModel employee,int adminID)
        {
            EmployeeDetailsOfficial employeeOfficial = new EmployeeDetailsOfficial();
            EmployeeDetailsPersonal employeePersonal = new EmployeeDetailsPersonal();

            employeeOfficial.Name = employee.Name;
            employeeOfficial.Designation = employee.Designation;
            employeeOfficial.DepartmentCode = employee.Department;
            employeeOfficial.EmailID = employee.MailID;
            employeeOfficial.Password = employee.Password;
            employeeOfficial.Gender = employee.Gender;
            employeeOfficial.OfficeCode = employee.Office;
            employeeOfficial.IsAdmin = employee.IsAdmin == 1 ? true : false ;
            employeeOfficial.IsActive = true;

            employeePersonal.Salary = employee.Salary;
            employeePersonal.City = employee.City;
            employeePersonal.Country = employee.Country;
            employeePersonal.PhoneNumber = employee.PhoneNumber;

            AddEmployee_DAL employeeData = new AddEmployee_DAL();
            //employee.IsActive = 1;
            return employeeData.AddDetails(employeeOfficial,employeePersonal,adminID);
        }
        public bool CheckNameAvailability(string employee)
        {
            AddEmployee_DAL employeeData = new AddEmployee_DAL();
            return employeeData.CheckName(employee);
        }
        public bool CheckEmailAvailability(string email)
        {
            AddEmployee_DAL employeeData = new AddEmployee_DAL();
            return employeeData.CheckMail(email);
        }
    }
}
