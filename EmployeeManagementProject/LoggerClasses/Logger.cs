using EmployeeManagementProject.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using log4net;

namespace EmployeeManagementProject.LoggerClasses
{
    public class Logger:ILogger
    {
        private static ILog logger;
        public void LogError(string errormessage,string caller,string callermethod)
        {
            logger = LogManager.GetLogger(caller);
            logger.Error(errormessage);
        }

        
    }
}