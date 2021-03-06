﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ClassLibrary2
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class EmployeeManagementEntities : DbContext
    {
        public EmployeeManagementEntities()
            : base("name=EmployeeManagementEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<a_Country> a_Country { get; set; }
        public virtual DbSet<a_DepartmentDetails> a_DepartmentDetails { get; set; }
        public virtual DbSet<a_Designation> a_Designation { get; set; }
        public virtual DbSet<a_OfficeDetails> a_OfficeDetails { get; set; }
        public virtual DbSet<EmployeeDetailsOfficial> EmployeeDetailsOfficials { get; set; }
        public virtual DbSet<EmployeeDetailsPersonal> EmployeeDetailsPersonals { get; set; }
        public virtual DbSet<ModificationInfo> ModificationInfoes { get; set; }
        public virtual DbSet<RandomKey> RandomKeys { get; set; }
        public virtual DbSet<LogInfo> LogInfoes { get; set; }
    
        public virtual int AddModificationInfo(Nullable<int> empID, Nullable<int> adminID, string action, Nullable<System.DateTime> actionDate)
        {
            var empIDParameter = empID.HasValue ?
                new ObjectParameter("EmpID", empID) :
                new ObjectParameter("EmpID", typeof(int));
    
            var adminIDParameter = adminID.HasValue ?
                new ObjectParameter("AdminID", adminID) :
                new ObjectParameter("AdminID", typeof(int));
    
            var actionParameter = action != null ?
                new ObjectParameter("Action", action) :
                new ObjectParameter("Action", typeof(string));
    
            var actionDateParameter = actionDate.HasValue ?
                new ObjectParameter("ActionDate", actionDate) :
                new ObjectParameter("ActionDate", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("AddModificationInfo", empIDParameter, adminIDParameter, actionParameter, actionDateParameter);
        }
    
        public virtual int AddNewEmployee(string name, Nullable<int> designation, Nullable<int> department, string email, string password, string gender, Nullable<int> office, Nullable<bool> admin, Nullable<bool> active, string city, Nullable<int> country, string phone, Nullable<int> salary)
        {
            var nameParameter = name != null ?
                new ObjectParameter("Name", name) :
                new ObjectParameter("Name", typeof(string));
    
            var designationParameter = designation.HasValue ?
                new ObjectParameter("Designation", designation) :
                new ObjectParameter("Designation", typeof(int));
    
            var departmentParameter = department.HasValue ?
                new ObjectParameter("Department", department) :
                new ObjectParameter("Department", typeof(int));
    
            var emailParameter = email != null ?
                new ObjectParameter("Email", email) :
                new ObjectParameter("Email", typeof(string));
    
            var passwordParameter = password != null ?
                new ObjectParameter("Password", password) :
                new ObjectParameter("Password", typeof(string));
    
            var genderParameter = gender != null ?
                new ObjectParameter("Gender", gender) :
                new ObjectParameter("Gender", typeof(string));
    
            var officeParameter = office.HasValue ?
                new ObjectParameter("Office", office) :
                new ObjectParameter("Office", typeof(int));
    
            var adminParameter = admin.HasValue ?
                new ObjectParameter("Admin", admin) :
                new ObjectParameter("Admin", typeof(bool));
    
            var activeParameter = active.HasValue ?
                new ObjectParameter("Active", active) :
                new ObjectParameter("Active", typeof(bool));
    
            var cityParameter = city != null ?
                new ObjectParameter("City", city) :
                new ObjectParameter("City", typeof(string));
    
            var countryParameter = country.HasValue ?
                new ObjectParameter("Country", country) :
                new ObjectParameter("Country", typeof(int));
    
            var phoneParameter = phone != null ?
                new ObjectParameter("Phone", phone) :
                new ObjectParameter("Phone", typeof(string));
    
            var salaryParameter = salary.HasValue ?
                new ObjectParameter("Salary", salary) :
                new ObjectParameter("Salary", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("AddNewEmployee", nameParameter, designationParameter, departmentParameter, emailParameter, passwordParameter, genderParameter, officeParameter, adminParameter, activeParameter, cityParameter, countryParameter, phoneParameter, salaryParameter);
        }
    
        public virtual int DeleteEmployee(Nullable<int> empID)
        {
            var empIDParameter = empID.HasValue ?
                new ObjectParameter("EmpID", empID) :
                new ObjectParameter("EmpID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("DeleteEmployee", empIDParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> EmailAvailability(string mailid)
        {
            var mailidParameter = mailid != null ?
                new ObjectParameter("mailid", mailid) :
                new ObjectParameter("mailid", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("EmailAvailability", mailidParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> NameAvailability(string name)
        {
            var nameParameter = name != null ?
                new ObjectParameter("Name", name) :
                new ObjectParameter("Name", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("NameAvailability", nameParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> AddNewEmployeeDetail(string name, Nullable<int> designation, Nullable<int> department, string email, string password, string gender, Nullable<int> office, Nullable<bool> admin, Nullable<bool> active, string city, Nullable<int> country, string phone, Nullable<int> salary)
        {
            var nameParameter = name != null ?
                new ObjectParameter("Name", name) :
                new ObjectParameter("Name", typeof(string));
    
            var designationParameter = designation.HasValue ?
                new ObjectParameter("Designation", designation) :
                new ObjectParameter("Designation", typeof(int));
    
            var departmentParameter = department.HasValue ?
                new ObjectParameter("Department", department) :
                new ObjectParameter("Department", typeof(int));
    
            var emailParameter = email != null ?
                new ObjectParameter("Email", email) :
                new ObjectParameter("Email", typeof(string));
    
            var passwordParameter = password != null ?
                new ObjectParameter("Password", password) :
                new ObjectParameter("Password", typeof(string));
    
            var genderParameter = gender != null ?
                new ObjectParameter("Gender", gender) :
                new ObjectParameter("Gender", typeof(string));
    
            var officeParameter = office.HasValue ?
                new ObjectParameter("Office", office) :
                new ObjectParameter("Office", typeof(int));
    
            var adminParameter = admin.HasValue ?
                new ObjectParameter("Admin", admin) :
                new ObjectParameter("Admin", typeof(bool));
    
            var activeParameter = active.HasValue ?
                new ObjectParameter("Active", active) :
                new ObjectParameter("Active", typeof(bool));
    
            var cityParameter = city != null ?
                new ObjectParameter("City", city) :
                new ObjectParameter("City", typeof(string));
    
            var countryParameter = country.HasValue ?
                new ObjectParameter("Country", country) :
                new ObjectParameter("Country", typeof(int));
    
            var phoneParameter = phone != null ?
                new ObjectParameter("Phone", phone) :
                new ObjectParameter("Phone", typeof(string));
    
            var salaryParameter = salary.HasValue ?
                new ObjectParameter("Salary", salary) :
                new ObjectParameter("Salary", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("AddNewEmployeeDetail", nameParameter, designationParameter, departmentParameter, emailParameter, passwordParameter, genderParameter, officeParameter, adminParameter, activeParameter, cityParameter, countryParameter, phoneParameter, salaryParameter);
        }
    }
}
