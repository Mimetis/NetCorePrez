using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Extensions.Logging;

namespace EntityFramework22Application.Model
{
    public partial class AdventureWorksContext : DbContext
    {
        private static readonly ILoggerFactory loggerFactory = new LoggerFactory()
            .AddConsole((s, l) => l == LogLevel.Debug && s.EndsWith("Command"));


        public AdventureWorksContext(DbContextOptions<AdventureWorksContext> options)
            : base(options)
        {
        }

        public AdventureWorksContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseCosmos(
                    "https://exp18.documents.azure.com:443/",
                    "1bcnV5gmMboSWRoYp3jsTIJGmsCkWmBrzyuVks9Szi6ZDSED3rgoRcDyXtU3hGKnmNXVVTk2sRnU3yLXZj9DHA==",
                    "EFCoreDemo")
                .EnableSensitiveDataLogging()
                .UseLoggerFactory(loggerFactory);
        }
        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>(entity =>
            {
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
                    .WithMany(p => p.Customers)
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

            });

        }

 
    }


}
