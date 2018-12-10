using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFramework22Application.Model
{
    public partial class Employee
    {
        public Employee()
        {
            Customer = new HashSet<Customer>();
        }

        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public ICollection<Customer> Customer { get; set; }
    }
}
