using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace Models
{
    public class ResetPasswordViewModel
    {
        public int UserID{ get; set; }

        [Required(ErrorMessage ="Please enter the password")]
        public string Password1 { get; set; }

        [Compare("Password1",ErrorMessage ="Password does not match please confirm")]
        [Required(ErrorMessage = "Confirm password is required")]
        public string Password2 { get; set; }
    }
}
