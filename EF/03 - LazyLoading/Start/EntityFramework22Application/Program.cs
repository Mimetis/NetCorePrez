using EntityFramework22Application.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace EntityFramework22Application
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            using (var advCtx = new AdventureWorksContext())
            {
                advCtx.Database.EnsureDeleted();
                advCtx.Database.EnsureCreated();

                foreach (var e in advCtx.Employees)
                {
                    Console.WriteLine($"{e.FirstName} {e.LastName} ({e.EmployeeType})");

                    if (!e.Customers.Any())
                    {
                        Console.WriteLine("- No customers loaded, yet.");
                        continue;
                    }

                    foreach (var c in e.Customers)
                    {
                        Console.WriteLine($"- {c.FirstName} {c.LastName} from {c.CompanyName}");
                    }

                }
            }

            Console.ReadLine();
        }
    }
}
