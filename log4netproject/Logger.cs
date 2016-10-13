using InterfaceProject;
using log4net;
using log4net.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace log4netproject
{
    public class Logger : ILogger
    {
        private static ILog logger;
        public Logger()
        {
            XmlConfigurator.Configure(/*new System.IO.FileInfo("C:\\Users\\Akash Manoj\\Documents\\Visual Studio 2015\\Projects\\EmployeeManagementProject\\log4netproject\\App.config")*/);
        }
        public void LogError(string errormessage, string caller,string callermethod)
        {
            LogicalThreadContext.Properties["logmethod"] = callermethod;
            logger = LogManager.GetLogger(caller);
            logger.Error(errormessage);
        }

    }
}
