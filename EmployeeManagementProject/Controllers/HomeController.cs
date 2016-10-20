using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLogicLayer;
using Models;
using System.Net.Mail;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using InterfaceProject;

namespace EmployeeManagementProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger logger;
        public HomeController(ILogger logger)
        {
            this.logger = logger;
        }
        /// <summary>
        /// Shows home page of website
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Shows department names and small description about the department taken from DB
        /// </summary>
        /// <returns></returns>
        public ActionResult About()
        {
            try
            {
                throw new NullReferenceException();
            }
            catch(Exception ex)
            {
                string classname = this.GetType().FullName;
                string methodname = nameof(About);
                logger.LogError("" + ex, classname, methodname);
            }
            List<DepartmentViewModel> departmentList;
            Department_BL departmentLogic = new Department_BL();
            departmentList = departmentLogic.GetDepartmentLists();
            return View(departmentList);
        }

        /// <summary>
        /// Shows contact informaion from DB. Shows form for inquiry.
        /// </summary>
        /// <returns></returns>
        public ActionResult Contact()
        {
            EmailViewModel emailModel = new EmailViewModel();
            try
            {
                throw new InvalidOperationException();
            }
            catch (Exception ex)
            {
                string classname = this.GetType().FullName;

                //string methodname = ex.TargetSite.Name;
                //string classname = ex.TargetSite.ReflectedType.Name;
                //string methodname = new StackTrace(ex).GetFrame(0).GetMethod().Name;
                string methodname = nameof(Contact);

                logger.LogError("" + ex,classname,methodname);
            }
            emailModel.TypeDropDown.Add(new SelectListItem
                {
                    Text = "Business",
                    Value = "Business"
                });
            emailModel.TypeDropDown.Add(new SelectListItem
                {
                    Text = "Career",
                    Value = "Career",
                    Selected = true
                });
            emailModel.TypeDropDown.Add(new SelectListItem
                {
                    Text = "Other",
                    Value = "Other"
                });
            
            List<OfficeViewModel> officeList;
            Office_BL officeLogic = new Office_BL();
            officeList = officeLogic.GetOfficeLists();

            ContactUsViewModel emailAndOffice = new ContactUsViewModel();
            emailAndOffice.OfficeCombo = officeList;
            emailAndOffice.EmailCombo = emailModel;
            return View(emailAndOffice);
        }

        /// <summary>
        /// Post method for Email Inquiry form.
        /// Emails the inquiry.
        /// </summary>
        /// <param name="emailAndOffice"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult PostInquiry(ContactUsViewModel emailAndOffice)
        {
            EmailViewModel email = emailAndOffice.EmailCombo;
            if (email.MailID == null || email.Name == null || email.Question == null)
                TempData["message"] = "Please fill all details";
            else
            {
                EmailQuiry_BL inquiry = new EmailQuiry_BL();
                if (inquiry.SendInquiry(email) == true)
                    TempData["message"] = "Succesfully posted";
                else
                    TempData["message"] = "Error in  posting";                   
            }
            return RedirectToAction("Contact", "Home");
        }

        /// <summary>
        /// Shows login form and forgot password link
        /// </summary>
        /// <returns></returns>
        public ActionResult Login()
        {     
            CredentialsViewModel loginCredential = new CredentialsViewModel();
            return View(loginCredential);
        }

        /// <summary>
        /// Post method for login form.
        /// It authenticates user, save session information and redirect to admin/employee controller.
        /// </summary>
        /// <param name="loginCredential"></param>
        /// <returns></returns>
        [HttpPost]
        public async System.Threading.Tasks.Task<ActionResult> AuthenticateLogin(CredentialsViewModel loginCredential)
        {
            if (ModelState.IsValid)
            {
                Authenticate_BL authenticationLogic = new Authenticate_BL();
                authenticationLogic.Validate(loginCredential);
                if (loginCredential.IsAuthentic == true)
                {
                    System.Web.HttpContext.Current.Session["sessionname"] = loginCredential.UserName;
                    System.Web.HttpContext.Current.Session["sessionid"] = loginCredential.EmployeeID;
                    System.Web.HttpContext.Current.Session["isadmin"] = loginCredential.IsAdmin;
                    if (loginCredential.IsAdmin == true)
                    {
                        return RedirectToAction("Index", "Admin");
                    }
                    else
                    {
                        return RedirectToAction("Index", "Employee");
                    }
                }
                else
                {
                    TempData["loginmessage"] = "Please enter a valid UserID and Password";
                    return RedirectToAction("Login", "Home");
                }
            }
            else
                return View("Login", loginCredential);

        }

        /// <summary>
        /// Shows form that reads email to which reset password link is to be send.
        /// </summary>
        /// <returns></returns>
        public ActionResult ForgotPassword()
        {
            return View();
        }

        /// <summary>
        /// Post method that reads email address, validate it and send reset password link to mail.
        /// </summary>
        /// <param name="emailID"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult ForgotPasswordPost(string emailID)
        {
            if(emailID!=null)
            {
                ResetPasswordByMail_BL validateAndSendLogic = new ResetPasswordByMail_BL();
                if (validateAndSendLogic.ValidateAndSend(emailID) == true)
                    TempData["resetmessage"] = "Please check your mail for resetting password";
                else
                    TempData["resetmessage"] = "Not a registered mailID";
            }
            else
            {
                TempData["resetmessage"] = "Please enter emailID";
            }
            return RedirectToAction("ForgotPassword", "Home");
        }

        /// <summary>
        /// Accessed through email link for reset password send to user.
        /// Saves session information.
        /// Shows reset password form.
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        //[HandleError(View = "CustomError")]
        public ActionResult ResetPassword(int userID)
        {
            System.Web.HttpContext.Current.Session["sessionid"] = userID;
            ResetPasswordViewModel model = new ResetPasswordViewModel();
            return View(model);
        }

        public ActionResult CheckError()
        {
            Response.StatusCode = 404;
            Response.TrySkipIisCustomErrors = true;
            return View();
        }
        /// <summary>
        /// Post method that reads reset password form.
        /// Resets the password.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult ResetPasswordPost(ResetPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                model.UserID = (int)System.Web.HttpContext.Current.Session["sessionid"];
                ResetPassword_BL resetLogic = new ResetPassword_BL();

                if (resetLogic.SetNewPassword(model) == true)
                {
                    TempData["errormessage"] = "Successfull please login";
                }
                return RedirectToAction("ResetPassword", "Home", new { userID = model.UserID });
            }
            else
                return View("ResetPassword", model);
        }

        /// <summary>
        /// Shows session timeout page
        /// </summary>
        /// <returns></returns>
        public ActionResult SessionTimedOut()
        {      
            return View();
        }
        

        /// <summary>
        /// Remaining functions are used for implementing sample features.
        /// </summary>
        /// <returns></returns>

        public ActionResult TestSpinner()
        {
            GenerateDropDownList_BL layer = new GenerateDropDownList_BL();
            ViewData["dropdown"] = layer.DepartmentDropDown();
            return View();
        }

        public ActionResult TestTabs()
        {
            return View();
        }
        public ActionResult GetEmployeeList([DataSourceRequest]DataSourceRequest request)
        {
            ViewProfile_BL profileLogic = new ViewProfile_BL();
            List<ShowEmployeePrimaryViewModel> employeeList = profileLogic.GetEmployeeListWithPrimaryDetail("", "");
            return Json(employeeList.ToDataSourceResult(request));
        }

        public ActionResult GetOfficeList(int EmployeeID,[DataSourceRequest]DataSourceRequest request)
        {
            ViewProfile_BL profileLogic = new ViewProfile_BL();
            ShowEmployeeViewModel model = profileLogic.GetProfile(EmployeeID);
            List<ShowEmployeeViewModel> list = new List<ShowEmployeeViewModel>();
            list.Add(model);
            return Json(list.ToDataSourceResult(request));
        }
        public ActionResult ShowFlow()
        {
            return PartialView("~/Views/Home/partial/flow1.cshtml");
        }

        public ActionResult TestEditor()
        {
            NewEmployeeViewModel testmodel = new NewEmployeeViewModel();
            return View(testmodel);
        }

        public ActionResult TestDisplay()
        {
            ViewProfile_BL bl = new ViewProfile_BL();
            ShowEmployeeViewModel model = bl.GetProfile(10);
            return View();
        }
    }
}