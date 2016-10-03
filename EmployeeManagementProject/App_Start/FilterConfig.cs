﻿using System.Web;
using System.Web.Mvc;

namespace EmployeeManagementProject
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            //filters.Add(new HandleErrorAttribute());

            filters.Add(new HandleErrorAttribute { ExceptionType=typeof(System.ArgumentException), View="CustomError"});
        }
    }
}
