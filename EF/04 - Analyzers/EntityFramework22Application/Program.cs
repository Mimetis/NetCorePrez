using EntityFramework22Application.Model;
using Microsoft.EntityFrameworkCore;
using System;

namespace EntityFramework22Application
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var advCtx = new AdventureWorksContext())
            {
                var str = $"Select * from Customer Where CustomerId = {args[0]}";
                // FormattableString : Composite format string

                var customers = advCtx.Customer
                    .FromSql(str);

                foreach (var c in customers)
                {
                    Console.WriteLine();
                    Console.WriteLine($"{c.FirstName} {c.LastName} ({c.CompanyName})");
                }
            }

            Console.ReadLine();
        }
    }
}
