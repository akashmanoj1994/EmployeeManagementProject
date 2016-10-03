using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DataAccessLayer.Tests
{
    [TestClass()]
    public class AddEmployee_DALTests
    {
        [TestMethod()]
        public void CheckMailTest()
        {
            string mail = "ali1234@gmail.com";
            bool actual = true;

            AddEmployee_DAL obj = new AddEmployee_DAL();
            bool result = obj.CheckMail(mail);

            Assert.AreEqual(actual, result, "Successfull");
        }

        [TestMethod()]
        public void CheckNameTest()
        {
            string name = "Ali";
            bool actual = true;

            AddEmployee_DAL obj = new AddEmployee_DAL();
            bool result = obj.CheckName(name);

            Assert.AreEqual(actual, result, "Successfull");
        }
    }
}