using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
namespace Models
{
    public class EditEmployeeSelfViewModel
    {
        public int EmployeeID { get; set; }
        public string Name { get; set; }
        public string EmailID { get; set; }
        public string City { get; set; }
        public int Country { get; set; }
        public string Phone { get; set; }
        public List<SelectListItem> CountryList { get; set; }
    }
}
