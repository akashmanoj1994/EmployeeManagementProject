using BusinessLogicLayer;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Utilities;

namespace EmployeeManagementProject.Controllers
{
    [SessionTimeout]
    public class BaseController : Controller
    {
        // GET: Base

        public ShowEmployeeViewModel MyProfiles()
        {

            int sessionID = (int)System.Web.HttpContext.Current.Session["sessionid"];
            ViewProfile_BL profileLogic = new ViewProfile_BL();
            ShowEmployeeViewModel profileModel = profileLogic.GetProfile(sessionID);
            return profileModel;

        }

        public EditEmployeeSelfViewModel EditMyProfiles()
        {

            int sessionID = (int)System.Web.HttpContext.Current.Session["sessionid"];
            ViewProfile_BL profileLogic = new ViewProfile_BL();
            EditEmployeeSelfViewModel model = profileLogic.GetDetailsForEditingSelf(sessionID);

            GenerateDropDownList_BL dropLogic = new GenerateDropDownList_BL();
            model.CountryList = dropLogic.CountryDropDown();
            foreach (var item in model.CountryList)
            {
                if (item.Value == model.Country.ToString())
                {
                    item.Selected = true;
                    break;
                }
            }
            return model;

        }

        public void PostEditMyProfiles(EditEmployeeSelfViewModel model)
        {
            model.EmployeeID = (int)System.Web.HttpContext.Current.Session["sessionid"];
            AddEmployee_BL employeeLogic = new AddEmployee_BL();
            if (model.City == null || model.Name == null || model.Phone == null)
                TempData["editedmessage"] = "Please fill all fields";
            else if ((string)System.Web.HttpContext.Current.Session["sessionname"] != model.Name && employeeLogic.CheckNameAvailability(model.Name) == true)
                TempData["editedmessage"] = "Name not available, use another";
            else
            {
                EditEmployee_BL editLogic = new EditEmployee_BL();
                if (editLogic.EditSelf(model) == true)
                {
                    System.Web.HttpContext.Current.Session["sessionname"] = model.Name;
                    TempData["editedmessage"] = "Saved changes";
                }
                else
                    TempData["editedmessage"] = "Error in saving";
            }
            return;

        }



        public void PostNewPasswords(ResetPasswordViewModel resetModel)
        {
            resetModel.UserID = (int)System.Web.HttpContext.Current.Session["sessionid"];
            ResetPassword_BL resetLogic = new ResetPassword_BL();
            if (resetLogic.SetNewPassword(resetModel) == true)
                TempData["resetmessage"] = "successfully reseted";
            else
                TempData["resetmessage"] = "error in reseting";
            return;
        }

        public List<ShowEmployeePrimaryViewModel> EmployeeLists()
        {

            string loggedInUserName = (string)System.Web.HttpContext.Current.Session["sessionname"];
            ViewProfile_BL profileLogic = new ViewProfile_BL();
            List<ShowEmployeePrimaryViewModel> employeeList = profileLogic.GetEmployeeListWithPrimaryDetail((string)TempData["SearchName"], loggedInUserName);
            return employeeList;

        }
    }
}