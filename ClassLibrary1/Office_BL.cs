using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using Models;

namespace BusinessLogicLayer
{
    public class Office_BL
    {
        public List<OfficeViewModel> GetOfficeLists()
        {
            Office_DAL officeData = new Office_DAL();
            return officeData.GetOfficeList();
        }
    }
}
