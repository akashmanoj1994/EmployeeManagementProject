using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using DataAccessLayer;
using Utilities;
namespace BusinessLogicLayer
{
    public class ViewProfile_BL
    {
        public ShowEmployeeViewModel GetProfile(int userID)
        {
            ViewProfile_DAL profileData = new ViewProfile_DAL();
            return profileData.GetProfileDetails(userID);
        }
        public List<ShowEmployeePrimaryViewModel> GetEmployeeListWithPrimaryDetail(string name,string loggedInUserName)
        {
            ViewProfile_DAL profileData = new ViewProfile_DAL();
            return profileData.GetEmployeeListWithPrimaryDetails(name, loggedInUserName);
        }
        public EditEmployeeByAdminViewModel GetDetailsForEditing(int userID)
        {
            ViewProfile_DAL employeeData = new ViewProfile_DAL();
            return employeeData.GetEmployeeDetailsForEditing(userID);
        }
        public EditEmployeeSelfViewModel GetDetailsForEditingSelf(int userID)
        {
            ViewProfile_DAL employeeData = new ViewProfile_DAL();
            return employeeData.GetEmployeeDetailsForEditingSelf(userID);
        }
    }
}
