using System.Collections.Generic;

namespace EntityFramework22Application.Model
{
    public partial class Employee
    {
        public Employee() => this.Customers = new HashSet<Customer>();

        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public EmployeeType EmployeeType { get; set; }

         public virtual ICollection<Customer> Customers { get; set; }
    }

    public enum EmployeeType
    {
        CEO,
        CTO,
        Sales,
        Marketing,
        Peon
    }
}
