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
                foreach(var c in advCtx.Customer)
                {
                    Console.WriteLine($"{c.FirstName} {c.LastName} ({c.CompanyName})");
                }
            }

            Console.ReadLine();
        }
    }
}
