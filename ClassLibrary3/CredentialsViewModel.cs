using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class CredentialsViewModel
    {
        public int EmployeeID { get; set; }
        public string UserName { get; set; }

        //[Required(ErrorMessage = "Please enter the password")]
        [Required(ErrorMessageResourceName = "PasswordRequired", ErrorMessageResourceType = typeof(Resources.Validations))]
        public string Password { get; set; }
        public bool IsAlive { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsAuthentic { get; set; }

        //[Required(ErrorMessage = "Please enter an EmailID")]
        [Required(ErrorMessageResourceName = "EmailIdRequired", ErrorMessageResourceType = typeof(Resources.Validations))]
        public string Email { get; set; }
    }
}
