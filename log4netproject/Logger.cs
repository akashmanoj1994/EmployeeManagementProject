using InterfaceProject;
using log4net;
using log4net.Config;
using System;
using System.Collections.Generic;
using System.IO;
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
            XmlConfigurator.Configure(new FileInfo(GetConfigPath()));
        }
        string GetConfigPath()
        {
            //try to do as relative path
            var webproject = AppDomain.CurrentDomain.BaseDirectory;
            var solutionpath = Directory.GetParent(webproject).Parent.FullName;
            var configpath = solutionpath + "\\log4netproject\\App.config";
            return configpath;
        }
        public void LogError(string errormessage, string caller,string callermethod)
        {
            //additional parameter logmethod
            LogicalThreadContext.Properties["logmethod"] = callermethod;
            logger = LogManager.GetLogger(caller);
            logger.Error(errormessage);
        }

    }
}
