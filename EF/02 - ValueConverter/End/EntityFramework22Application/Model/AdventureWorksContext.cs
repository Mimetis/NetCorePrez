using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;

namespace EntityFramework22Application.Model
{
    public partial class AdventureWorksContext : DbContext
    {
        public AdventureWorksContext(DbContextOptions<AdventureWorksContext> options)
            : base(options)
        {
        }

        public AdventureWorksContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Demo.ValueConverter;Trusted_Connection=True;ConnectRetryCount=0");

        public virtual DbSet<Address> Address { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>(entity =>
            {
                entity.HasIndex(e => e.StateProvince);

                entity.HasIndex(e => new { e.City, e.StateProvince, e.PostalCode, e.CountryRegion });

                entity.Property(e => e.AddressLine1)
                    .IsRequired();

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.CountryRegion)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PostalCode)
                    .IsRequired()
                    .IsUnicode()
                    .HasMaxLength(15);

                entity.Property(e => e.StateProvince)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.CompanyName).HasMaxLength(128);

                entity.Property(e => e.EmailAddress).HasMaxLength(50);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.MiddleName).HasMaxLength(50);

                entity.Property(e => e.PasswordHash)
                .IsRequired()
                .HasMaxLength(128)
                .IsUnicode(false);

                entity.Property(e => e.PasswordSalt)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Phone).HasMaxLength(25);

                entity.Property(e => e.SalesPerson).HasMaxLength(256);

                entity.Property(e => e.Suffix).HasMaxLength(10);

                entity.Property(e => e.Title).HasMaxLength(8);

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Customer)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);


                //entity.Property(e => e.EmployeeType)
                //    .HasConversion(et => et.ToString(),
                //                    str => Enum.Parse<EmployeeType>(str));

                entity.Property(e => e.EmployeeType)
                    .HasConversion(new EnumToStringConverter<EmployeeType>());
            });

            this.OnSeeding(modelBuilder);
        }

        protected void OnSeeding(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>().HasData(
                new Address { AddressId = 1, AddressLine1 = "8713 Yosemite Ct.", City = "Bothell", StateProvince = "Washington", CountryRegion = "United States", PostalCode = "98011" },
                new Address { AddressId = 2, AddressLine1 = "1318 Lasalle Street", City = "Bothell", StateProvince = "Washington", CountryRegion = "United States", PostalCode = "98011" },
                new Address { AddressId = 3, AddressLine1 = "9178 Jumping St.", City = "Dallas", StateProvince = "Texas", CountryRegion = "United States", PostalCode = "75201" },
                new Address { AddressId = 4, AddressLine1 = "9228 Via Del Sol", City = "Phoenix", StateProvince = "Arizona", CountryRegion = "United States", PostalCode = "85004" },
                new Address { AddressId = 5, AddressLine1 = "26910 Indela Road", City = "Montreal", StateProvince = "Quebec", CountryRegion = "Canada", PostalCode = "H1Y 2H5" },
                new Address { AddressId = 6, AddressLine1 = "2681 Eagle Peak", City = "Bellevue", StateProvince = "Washington", CountryRegion = "United States", PostalCode = "98004" },
                new Address { AddressId = 7, AddressLine1 = "7943 Walnut Ave", City = "Renton", StateProvince = "Washington", CountryRegion = "United States", PostalCode = "98055" },
                new Address { AddressId = 8, AddressLine1 = "6388 Lake City Way", City = "Burnaby", StateProvince = "British Columbia", CountryRegion = "Canada", PostalCode = "V5A 3A6" },
                new Address { AddressId = 9, AddressLine1 = "52560 Free Street", City = "Toronto", StateProvince = "Ontario", CountryRegion = "Canada", PostalCode = "M4B 1V7" },
                new Address { AddressId = 10, AddressLine1 = "22580 Free Street", City = "Toronto", StateProvince = "Ontario", CountryRegion = "Canada", PostalCode = "M4B 1V7" },
                new Address { AddressId = 11, AddressLine1 = "2575 Bloor Street East", City = "Toronto", StateProvince = "Ontario", CountryRegion = "Canada", PostalCode = "M4B 1V6" },
                new Address { AddressId = 12, AddressLine1 = "Station E", City = "Chalk Riber", StateProvince = "Ontario", CountryRegion = "Canada", PostalCode = "K0J 1J0" },
                new Address { AddressId = 13, AddressLine1 = "575 Rue St Amable", City = "Quebec", StateProvince = "Quebec", CountryRegion = "Canada", PostalCode = "G1R" },
                new Address { AddressId = 14, AddressLine1 = "2512-4th Ave Sw", City = "Calgary", StateProvince = "Alberta", CountryRegion = "Canada", PostalCode = "T2P 2G8" },
                new Address { AddressId = 15, AddressLine1 = "55 Lakeshore Blvd East", City = "Toronto", StateProvince = "Ontario", CountryRegion = "Canada", PostalCode = "M4B 1V6" },
                new Address { AddressId = 16, AddressLine1 = "6333 Cote Vertu", City = "Montreal", StateProvince = "Quebec", CountryRegion = "Canada", PostalCode = "H1Y 2H5" },
                new Address { AddressId = 17, AddressLine1 = "3255 Front Street West", City = "Toronto", StateProvince = "Ontario", CountryRegion = "Canada", PostalCode = "H1Y 2H5" },
                new Address { AddressId = 18, AddressLine1 = "2550 Signet Drive", City = "Weston", StateProvince = "Ontario", CountryRegion = "Canada", PostalCode = "H1Y 2H7" },
                new Address { AddressId = 19, AddressLine1 = "6777 Kingsway", City = "Burnaby", StateProvince = "British Columbia", CountryRegion = "Canada", PostalCode = "H1Y 2H8" },
                new Address { AddressId = 20, AddressLine1 = "5250-505 Burning St", City = "Vancouver", StateProvince = "British Columbia", CountryRegion = "Canada", PostalCode = "H1Y 2H9" },
                new Address { AddressId = 21, AddressLine1 = "600 Slater Street", City = "Ottawa", StateProvince = "Ontario", CountryRegion = "Canada", PostalCode = "M9V 4W3" }
            );

            modelBuilder.Entity<Employee>().HasData(
                new Employee { EmployeeId = 1, FirstName = "Paul", LastName = "Orson", EmployeeType = EmployeeType.CEO },
                new Employee { EmployeeId = 2, FirstName = "David", LastName = "Kandle", EmployeeType = EmployeeType.Sales },
                new Employee { EmployeeId = 3, FirstName = "Jillian", LastName = "Jon", EmployeeType = EmployeeType.Peon }
            );


            modelBuilder.Entity<Customer>().HasData(
                new Customer { CustomerId = 1000, EmployeeId = 1, NameStyle = false, Title = "Mr.", FirstName = "John", MiddleName = "N.", LastName = "Gee", CompanyName = "A Bike Store", SalesPerson = @"adventure-works\pamela0", EmailAddress = "orlando0@adventure-works.com", Phone = "245-555-0173", PasswordHash = "L/Rlwxzp4w7RWmEgXX+/A7cXaePEPcp+KwQhl2fJL7w=", PasswordSalt = "1KjXYs4=" },
                new Customer { CustomerId = 1001, EmployeeId = 1, NameStyle = false, Title = "Mr.", FirstName = "Keith", MiddleName = "N.", LastName = "Harris", CompanyName = "Progressive Sports", SalesPerson = @"adventure-works\david8", EmailAddress = "keith0@adventure-works.com", Phone = "170-555-0127", PasswordHash = "YPdtRdvqeAhj6wyxEsFdshBDNXxkCXn+CRgbvJItknw=", PasswordSalt = "fs1ZGhY=" },
                new Customer { CustomerId = 1002, EmployeeId = 2, NameStyle = false, Title = "Ms.", FirstName = "Donna", MiddleName = "F.", LastName = "Carreras", CompanyName = "Advanced Bike Components", SalesPerson = @"adventure-works\jillian0", EmailAddress = "donna0@adventure-works.com", Phone = "279-555-0130", PasswordHash = "LNoK27abGQo48gGue3EBV/UrlYSToV0/s87dCRV7uJk=", PasswordSalt = "YTNH5Rw=" },
                new Customer { CustomerId = 1003, EmployeeId = 3, NameStyle = false, Title = "Ms.", FirstName = "Janet", MiddleName = "M.", LastName = "Gates", CompanyName = "Modular Cycle Systems", SalesPerson = @"adventure-works\jillian0", EmailAddress = "janet1@adventure-works.com", Phone = "710-555-0173", PasswordHash = "ElzTpSNbUW1Ut+L5cWlfR7MF6nBZia8WpmGaQPjLOJA=", PasswordSalt = "nm7D5e4=" }
            );



        }

    }


}
