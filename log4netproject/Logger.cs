using InterfaceProject;
using log4net;
using log4net.Appender;
using log4net.Config;
using log4net.Repository.Hierarchy;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
namespace log4netproject
{
    public class Logger : ILogger
    {
        private static ILog logger;
        static Logger()
        {
            //XmlConfigurator.Configure(new FileInfo(GetConfigPath()));
            //XmlConfigurator.Configure(new FileInfo(AppDomain.CurrentDomain.BaseDirectory + "Log4net.config"));
            XmlConfigurator.Configure(Assembly.GetExecutingAssembly().GetManifestResourceStream("log4netproject.App.config"));
            //XmlConfigurator.Configure();
            SetAdoNetAppenderConnectionStrings("Connection1");
        }
        private static void SetAdoNetAppenderConnectionStrings(string connectionStringKey)
        {
            var hier = (Hierarchy)LogManager.GetRepository();
            if (hier != null)
            {
                var appenders = hier.GetAppenders().OfType<AdoNetAppender>();
                foreach (var appender in appenders)
                {
                    appender.ConnectionString = ConfigurationManager.ConnectionStrings[connectionStringKey].ConnectionString;
                    appender.ActivateOptions();
                }
            }
        }
        private static string GetConfigPath()
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
