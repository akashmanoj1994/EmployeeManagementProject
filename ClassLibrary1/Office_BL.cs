using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using Models;
//using log4net;
namespace BusinessLogicLayer
{
    public class Office_BL
    {
        //private static readonly ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public List<OfficeViewModel> GetOfficeLists()
        {
            Office_DAL officeData = new Office_DAL();
            //try
            //{
            //    throw new ArgumentException();
            //}
            //catch (Exception ex)
            //{
            //    logger.Error(ex);
            //}
            return officeData.GetOfficeList();
        }
    }
}
