using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
namespace BusinessLogicLayer.Tests
{
    [TestClass()]
    public class ResetPassword_BLTests
    {
        [TestMethod()]
        public void MatchPasswordTest()
        {


            ResetPasswordViewModel mdl = new ResetPasswordViewModel();
            mdl.UserID = 1;
            mdl.Password1= "haithere";
            mdl.Password2= "haitHereTHere";
            

            ResetPassword_BL obj = new ResetPassword_BL();
        
        }
    }
}