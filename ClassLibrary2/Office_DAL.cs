using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;
using Models;
using ClassLibrary2;

namespace DataAccessLayer
{
    public class Office_DAL
    {
        public List<OfficeViewModel> GetOfficeList()
        {
            using (var dbContext = new EmployeeManagementEntities())
            {
                var officeDetails = (from of in dbContext.a_OfficeDetails
                                    select new OfficeViewModel()
                                    {
                                     Address=of.Address,
                                     Phone=of.PhoneNumber
                                    }).ToList();
                return officeDetails;
            }
        }
    }
}
