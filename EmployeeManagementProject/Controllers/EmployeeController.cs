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
    public class EmployeeController : BaseController
    {
        // GET: Employee
        public ActionResult Index()
        {

                ViewData["welcomenote"] = "Welcome, " + System.Web.HttpContext.Current.Session["sessionname"];
                return View();

        }
        public ActionResult MyProfile()
        {

                ShowEmployeeViewModel profileModel = base.MyProfiles();
                return View(profileModel);

        }
        public ActionResult EmployeeList()
        {
                List<ShowEmployeePrimaryViewModel> employeeList = base.EmployeeLists();
                return View(employeeList);

        }
        [HttpPost]
        public ActionResult SearchEmployee(string searchName)
        {
                TempData["SearchName"] = searchName;
                return RedirectToAction("EmployeeList", "Employee");
        }
        
        public ActionResult ResetPassword()
        {

                ResetPasswordViewModel resetModel = new ResetPasswordViewModel();
                return View(resetModel);

        }
        [HttpPost]
        public ActionResult PostNewPassword(ResetPasswordViewModel resetModel)
        {
            if (ModelState.IsValid)
            {
                base.PostNewPasswords(resetModel);
                return RedirectToAction("ResetPassword", "Employee");
            }
            else
                return View("ResetPassword", resetModel);
        }
        public ActionResult EditMyProfile()
        {

                EditEmployeeSelfViewModel model = base.EditMyProfiles();
                return View(model);

        }
        [HttpPost]
        public ActionResult PostEditMyProfile(EditEmployeeSelfViewModel model)
        {
                base.PostEditMyProfiles(model);
                return RedirectToAction("EditMyProfile", "Employee");
        }

    }
}