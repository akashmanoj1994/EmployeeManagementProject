using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ModificationViewModel
    {
        public int LogNumber { get; set; }
        public string AdminName { get; set; }
        public int AdminID { get; set; }
        public string Action { get; set; }
        public string EmployeeName { get; set; }
        public int EmployeeID { get; set; }

        public DateTime Time { get; set; }

    }
}
