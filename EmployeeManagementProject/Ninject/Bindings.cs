using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject.Modules;
using Ninject;
using EmployeeManagementProject.Interfaces;
using EmployeeManagementProject.LoggerClasses;

namespace EmployeeManagementProject.Ninject
{
    public class Bindings : NinjectModule
    {
        public override void Load()
        {
            Bind<ILogger>().To<Logger>();
        }
    }
}