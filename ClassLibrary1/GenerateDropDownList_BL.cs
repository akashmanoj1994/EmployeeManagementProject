using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using DataAccessLayer;
namespace BusinessLogicLayer
{
    public class GenerateDropDownList_BL
    {
        public List<SelectListItem> DesignationDropDown()
        {
            return GenerateList.DesignationList();
        }
        public List<SelectListItem> DepartmentDropDown()
        {
            return GenerateList.DepartmentList();
        }
        public List<SelectListItem> OfficeDropDown()
        {
            return GenerateList.OfficeList();
        }
        public List<SelectListItem> CountryDropDown()
        {
            return GenerateList.CountryList();
        }
    }
}
