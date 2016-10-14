using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceProject
{
    public interface ILogger
    {
        void LogError(string errormessage, string caller,string callermethod);
    }
}
