using DataAccessLayer;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class ViewModification_BL
    {
        public List<ModificationViewModel> GetModificationList()
        {
            ViewModification_DAL modificationData = new ViewModification_DAL();
            return modificationData.GetAllModificationList();
        }
    }
}
