using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;
using Utilities;
using BusinessLogicLayer;
using log4net;
using log4net.Config;

namespace EmployeeManagementProject.Controllers
{
   [SessionTimeout]
    public class AdminController : BaseController
    {
        private static readonly ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        protected override void OnException(ExceptionContext filterContext)
        {
            Exception ex = filterContext.Exception;
            filterContext.ExceptionHandled = true;

            filterContext.Result = new ViewResult
            {
                ViewName = "~/Views/Shared/CheckError.cshtml"
            };

        }

        /// <summary>
        /// Shows home page for admin.
        /// Shows welcome note.
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {      
            ViewData["welcomenote"] ="Welcome, "+ System.Web.HttpContext.Current.Session["sessionname"];
            return View();

        }

        /// <summary>
        /// Get profile details from DB and shows it.
        /// </summary>
        /// <returns></returns>
        public ActionResult MyProfile()
        {
            ShowEmployeeViewModel profileModel = base.MyProfiles();
            return View(profileModel);

        }

        /// <summary>
        /// Shows profile of employee with employeeID=userID
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public ActionResult ViewEmployee(int userID)
        {

            ViewProfile_BL profileLogic = new ViewProfile_BL();
            ShowEmployeeViewModel profileModel = profileLogic.GetProfile(userID);
            return View(profileModel);

        }

        /// <summary>
        /// Shows profile in form (editable).
        /// </summary>
        /// <returns></returns>
        public ActionResult EditMyProfile()
        {
            EditEmployeeSelfViewModel model = base.EditMyProfiles();
            return View(model);

        }

        /// <summary>
        /// Post method that saves edited profile details to DB.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult PostEditMyProfile(EditEmployeeSelfViewModel model)
        {
            base.PostEditMyProfiles(model);
            return RedirectToAction("EditMyProfile", "Admin");
        }

        /// <summary>
        /// Shows form for adding new employee.
        /// </summary>
        /// <returns></returns>
        public ActionResult AddEmployee()
        {

            NewEmployeeViewModel employeeModel = new NewEmployeeViewModel();
            GenerateDropDownList_BL dropDownListLogic = new GenerateDropDownList_BL();
            employeeModel.DesignationList = dropDownListLogic.DesignationDropDown();
            employeeModel.DepartmentList = dropDownListLogic.DepartmentDropDown();
            employeeModel.OfficeList = dropDownListLogic.OfficeDropDown();
            employeeModel.CountryList = dropDownListLogic.CountryDropDown();
            TempData["mymodel"] = employeeModel;
            TempData.Keep();
            return View(employeeModel);

        }

        /// <summary>
        /// Post method that save new employee details in DB.
        /// It checks name and email availability.
        /// </summary>
        /// <param name="employeeModel"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AddEmployee(NewEmployeeViewModel employeeModel)
        {
            NewEmployeeViewModel newmodel = (NewEmployeeViewModel)TempData["mymodel"];
            TempData.Keep();
            int adminID=(int)System.Web.HttpContext.Current.Session["sessionid"];
            AddEmployee_BL employeeLogic = new AddEmployee_BL();
            if (ModelState.IsValid)
            {
                if (employeeLogic.CheckNameAvailability(employeeModel.Name) == true)
                    TempData["addedmessage"] = "Name not available, use another";
                else if (employeeLogic.CheckEmailAvailability(employeeModel.MailID) == true)
                    TempData["addedmessage"] = "EmailAddress not available, use another";
                else
                {
                    if (employeeLogic.AddAllDetails(employeeModel, adminID) == true)
                        TempData["addedmessage"] = "Successfully Added";
                    else
                        TempData["addedmessage"] = "Error in adding";
                }
            }
            else
                return View("AddEmployee",newmodel);
            return RedirectToAction("AddEmployee", "Admin");
        }

        /// <summary>
        /// Shows list of primary details of all  employee.
        /// </summary>
        /// <returns></returns>
        public ActionResult EmployeeList()
        {

            List<ShowEmployeePrimaryViewModel> employeeList = base.EmployeeLists();
            return View(employeeList);

        }

        /// <summary>
        /// Post method that reads name to search so that employees with similar names can be displayed as list.
        /// </summary>
        /// <param name="searchName"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult SearchEmployee(string searchName)
        {
            TempData["SearchName"] = searchName;
            return RedirectToAction("EmployeeList", "Admin");
        }

        /// <summary>
        /// Shows reset password form.
        /// </summary>
        /// <returns></returns>
        public ActionResult ResetPassword()
        {

            ResetPasswordViewModel resetModel = new ResetPasswordViewModel();
            return View(resetModel);

        }

        /// <summary>
        /// Post method that reads reset password form and resets password.
        /// </summary>
        /// <param name="resetModel"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult PostNewPassword(ResetPasswordViewModel resetModel)
        {
            if (ModelState.IsValid)
            {
                base.PostNewPasswords(resetModel);
                return RedirectToAction("ResetPassword", "Admin");
            }
            else
                return View("ResetPassword", resetModel);

        }

        /// <summary>
        /// Shows log infomation (added/updated/deleted).
        /// </summary>
        /// <returns></returns>
        public ActionResult ModificationList()
        {

            ViewModification_BL modificationLogic = new ViewModification_BL();
            List<ModificationViewModel> modificationList = modificationLogic.GetModificationList();
            return View(modificationList);

        }

        /// <summary>
        /// Set to inactive, the employee with employeeID=userID
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public ActionResult DeleteEmployee(int userID)
        {

            int adminID = (int)System.Web.HttpContext.Current.Session["sessionid"];
            DeleteEmployee_BL deleteLogic = new DeleteEmployee_BL();
            if(deleteLogic.DeleteEmployee(userID,adminID)==true)
            {
                TempData["deletemessage"] = "Successfully deleted";
                //return RedirectToAction("EmployeeList", "Admin");
                return this.Json(true, JsonRequestBehavior.AllowGet);
            }
            else
            {
                TempData["deletemessage"] = "Can't be deleted";
                //return RedirectToAction("EmployeeList", "Admin");
                return this.Json(true, JsonRequestBehavior.AllowGet);
            }

        }

        /// <summary>
        /// Reads detail of employee with emloyeeID=userID from DB.
        /// Bind drop down list.
        /// Shows detail in form(editable).
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public ActionResult EditEmployee(int userID)
        {

            ViewProfile_BL employeeLogic = new ViewProfile_BL();
            GenerateDropDownList_BL dropLogic = new GenerateDropDownList_BL();
            EditEmployeeByAdminViewModel model = employeeLogic.GetDetailsForEditing(userID);
            model.DesignationList = dropLogic.DesignationDropDown();
            model.DepartmentList = dropLogic.DepartmentDropDown();
            model.OfficeList = dropLogic.OfficeDropDown();
            foreach (var item in  model.DesignationList)
            {
                if (item.Value == model.Designation.ToString())
                {
                    item.Selected = true;
                    break;
                }
            }
            foreach (var item in model.DepartmentList)
            {
                if (item.Value == model.Department.ToString())
                {
                    item.Selected = true;
                    break;
                }
            }
            foreach (var item in model.OfficeList)
            {
                if (item.Value == model.Office.ToString())
                {
                    item.Selected = true;
                    break;
                }
            }
            TempData["id"] = model.EmployeeID;
            return View(model);

        }

        /// <summary>
        /// Post method that saves edited employee details to DB.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult PostEditEmployee(EditEmployeeByAdminViewModel model)
        {
            int adminID = (int)System.Web.HttpContext.Current.Session["sessionid"];

            model.EmployeeID =(int)TempData["id"];
            EditEmployee_BL editLogic = new EditEmployee_BL();
            if(editLogic.EditByAdmin(model,adminID)==true)
            {
                TempData["editedmessage"] = "Saved changes";
            }
            else
            {
                TempData["editedmessage"] = "Error in saving";
            }
            
            return RedirectToAction("EditEmployee", "Admin",new { userID = model.EmployeeID });
        }


        public ActionResult GetTime()
        {
            return Content(DateTime.Now.ToString());
        }
    }
}