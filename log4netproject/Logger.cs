using InterfaceProject;
using log4net;
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
        public void LogError(string errormessage, string caller,string callermethod)
        {
            logger = LogManager.GetLogger(caller);
            logger.Error(errormessage);
        }

    }
}
