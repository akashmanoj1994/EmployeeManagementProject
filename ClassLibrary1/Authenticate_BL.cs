using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using DataAccessLayer;
using ClassLibrary2;
namespace BusinessLogicLayer
{
    public class Authenticate_BL
    {
        public void Validate(CredentialsViewModel enteredCredential)
        {
            Credentials_DAL credentialData = new Credentials_DAL();

            EmployeeDetailsOfficial actualCredential = credentialData.GetCredential(enteredCredential.Email);

            if (actualCredential.IsActive == true)
            {
                if (actualCredential.Password == enteredCredential.Password)
                {
                    enteredCredential.IsAuthentic = true;
                    enteredCredential.IsAdmin = actualCredential.IsAdmin;
                    enteredCredential.EmployeeID = actualCredential.EmployeeID;
                    enteredCredential.UserName = actualCredential.Name;
                }
                else
                {
                    enteredCredential.IsAuthentic = false;
                }
            }
            else
            enteredCredential.IsAuthentic = false;   

        }
        
    }
}
