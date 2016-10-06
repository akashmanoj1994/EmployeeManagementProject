using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementProject.Interfaces
{
    public interface ILogger
    {
        void LogError(string errormessage,Type caller);
    }
}
