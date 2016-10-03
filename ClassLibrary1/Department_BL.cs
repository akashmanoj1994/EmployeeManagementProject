using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using Models;
namespace BusinessLogicLayer
{
    public class Department_BL
    {
        public List<DepartmentViewModel> GetDepartmentLists()
        {
            Department_DAL departmentData = new Department_DAL();
            return departmentData.GetDepartmentList();
        }
       
    }
}
