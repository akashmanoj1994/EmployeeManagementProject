using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace log4netproject
{
    public interface ILogger
    {
        void LogError(string errormessage, Type caller);
    }
}
