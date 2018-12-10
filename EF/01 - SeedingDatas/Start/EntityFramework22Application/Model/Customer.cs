using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFramework22Application.Model
{
    public partial class Customer
    {
        public Customer()
        {
        }

        public int CustomerId { get; set; }
        public int EmployeeId { get; set; }
        public bool NameStyle { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Suffix { get; set; }
        public string CompanyName { get; set; }
        public string SalesPerson { get; set; }
        public string EmailAddress { get; set; }
        public string Phone { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }

        public ICollection<Address> Addresses { get; set; }
        public Employee Employee { get; set; }
    }
}
