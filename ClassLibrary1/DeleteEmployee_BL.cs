using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using Models;
namespace BusinessLogicLayer
{
    public class DeleteEmployee_BL
    {
        public bool DeleteEmployee(int userID,int adminID)
        {
            DeleteEmployee_DAL deleteData = new DeleteEmployee_DAL();
            return deleteData.DeleteEmployeeDetails(userID,adminID);
        }
    }
}
