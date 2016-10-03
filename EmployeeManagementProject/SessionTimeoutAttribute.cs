﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeManagementProject
{
    public class SessionTimeoutAttribute: ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (System.Web.HttpContext.Current.Session["sessionid"] == null)
            {
                filterContext.Result = new RedirectResult("~/Home/SessionTimedOut");
                return;
            }
            base.OnActionExecuting(filterContext);
        }
    }
}