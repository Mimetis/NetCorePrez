using EntityFramework22Application.Model;
using System;

namespace EntityFramework22Application
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var advCtx = new AdventureWorksContext())
            {
                advCtx.Database.EnsureDeleted();
                advCtx.Database.EnsureCreated();

                foreach (var e in advCtx.Employee)
                {
                    Console.WriteLine($"{e.FirstName} {e.LastName} ({e.EmployeeType})");
                }
            }

            Console.ReadLine();
        }
    }
}
