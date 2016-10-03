using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
namespace Models
{
    public class NewEmployeeViewModel
    {
        public int EmployeeID { get; set; }

        [Required(ErrorMessage ="Please enter the name")]
        public string Name { get; set; }

        public int Designation { get; set; }

        public int Department { get; set; }

        [RegularExpression("([a-zA-Z0-9_.&]+)@([a-zA-Z0-9]+).com",ErrorMessage ="Please enter valid Email ID")]
        [Required(ErrorMessage = "Please enter the EmailID ")]
        public string MailID { get; set; }

        [Required(ErrorMessage = "Please give a temporary password")]
        public string Password{ get; set; }

        [Required(ErrorMessage = "Please select the gender")]
        public string Gender { get; set; }

        public int Office { get; set; }

        public int IsAdmin { get; set; }

        public int Salary { get; set; }

        [Required(ErrorMessage = "Please enter the city")]
        public string City { get; set; }

        public int Country { get; set; }

        [Required(ErrorMessage = "Please add contact phone number")]
        public string PhoneNumber { get; set; }
        public int IsActive { get; set; }

        public List<SelectListItem> DesignationList { get; set; }
        public List<SelectListItem> DepartmentList { get; set; }
        public List<SelectListItem> OfficeList { get; set; }
        public List<SelectListItem> CountryList { get; set; }
    }
}
