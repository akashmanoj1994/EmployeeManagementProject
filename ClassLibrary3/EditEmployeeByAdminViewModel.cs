using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
namespace Models
{
    public class EditEmployeeByAdminViewModel
    {
        public int EmployeeID { get; set; }
        public string Name { get; set; }
        public int Designation { get; set; }
        public int Department { get; set; }
        public int Office { get; set; }
        public bool IsAdmin { get; set; }
        public int Salary { get; set; }
        public List<SelectListItem> DesignationList { get; set; }
        public List<SelectListItem> DepartmentList { get; set; }
        public List<SelectListItem> OfficeList { get; set; }
    }
}
