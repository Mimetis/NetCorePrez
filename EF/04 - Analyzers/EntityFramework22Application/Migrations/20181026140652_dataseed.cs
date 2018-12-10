using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityFramework22Application.Migrations
{
    public partial class dataseed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    LastName = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.EmployeeId);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    CustomerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EmployeeId = table.Column<int>(nullable: false),
                    NameStyle = table.Column<bool>(nullable: false),
                    Title = table.Column<string>(maxLength: 8, nullable: true),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    MiddleName = table.Column<string>(maxLength: 50, nullable: true),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    Suffix = table.Column<string>(maxLength: 10, nullable: true),
                    CompanyName = table.Column<string>(maxLength: 128, nullable: true),
                    SalesPerson = table.Column<string>(maxLength: 256, nullable: true),
                    EmailAddress = table.Column<string>(maxLength: 50, nullable: true),
                    Phone = table.Column<string>(maxLength: 25, nullable: true),
                    PasswordHash = table.Column<string>(unicode: false, maxLength: 128, nullable: false),
                    PasswordSalt = table.Column<string>(unicode: false, maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.CustomerId);
                    table.ForeignKey(
                        name: "FK_Customer_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    AddressId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AddressLine1 = table.Column<string>(nullable: false),
                    AddressLine2 = table.Column<string>(nullable: true),
                    City = table.Column<string>(maxLength: 30, nullable: false),
                    StateProvince = table.Column<string>(maxLength: 50, nullable: false),
                    CountryRegion = table.Column<string>(maxLength: 50, nullable: false),
                    PostalCode = table.Column<string>(maxLength: 15, nullable: false),
                    CustomerId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.AddressId);
                    table.ForeignKey(
                        name: "FK_Address_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Address",
                columns: new[] { "AddressId", "AddressLine1", "AddressLine2", "City", "CountryRegion", "CustomerId", "PostalCode", "StateProvince" },
                values: new object[,]
                {
                    { 1, "8713 Yosemite Ct.", null, "Bothell", "United States", null, "98011", "Washington" },
                    { 21, "600 Slater Street", null, "Ottawa", "Canada", null, "M9V 4W3", "Ontario" },
                    { 20, "5250-505 Burning St", null, "Vancouver", "Canada", null, "H1Y 2H9", "British Columbia" },
                    { 19, "6777 Kingsway", null, "Burnaby", "Canada", null, "H1Y 2H8", "British Columbia" },
                    { 18, "2550 Signet Drive", null, "Weston", "Canada", null, "H1Y 2H7", "Ontario" },
                    { 17, "3255 Front Street West", null, "Toronto", "Canada", null, "H1Y 2H5", "Ontario" },
                    { 16, "6333 Cote Vertu", null, "Montreal", "Canada", null, "H1Y 2H5", "Quebec" },
                    { 15, "55 Lakeshore Blvd East", null, "Toronto", "Canada", null, "M4B 1V6", "Ontario" },
                    { 14, "2512-4th Ave Sw", null, "Calgary", "Canada", null, "T2P 2G8", "Alberta" },
                    { 13, "575 Rue St Amable", null, "Quebec", "Canada", null, "G1R", "Quebec" },
                    { 12, "Station E", null, "Chalk Riber", "Canada", null, "K0J 1J0", "Ontario" },
                    { 10, "22580 Free Street", null, "Toronto", "Canada", null, "M4B 1V7", "Ontario" },
                    { 9, "52560 Free Street", null, "Toronto", "Canada", null, "M4B 1V7", "Ontario" },
                    { 8, "6388 Lake City Way", null, "Burnaby", "Canada", null, "V5A 3A6", "British Columbia" },
                    { 7, "7943 Walnut Ave", null, "Renton", "United States", null, "98055", "Washington" },
                    { 6, "2681 Eagle Peak", null, "Bellevue", "United States", null, "98004", "Washington" },
                    { 5, "26910 Indela Road", null, "Montreal", "Canada", null, "H1Y 2H5", "Quebec" },
                    { 4, "9228 Via Del Sol", null, "Phoenix", "United States", null, "85004", "Arizona" },
                    { 3, "9178 Jumping St.", null, "Dallas", "United States", null, "75201", "Texas" },
                    { 2, "1318 Lasalle Street", null, "Bothell", "United States", null, "98011", "Washington" },
                    { 11, "2575 Bloor Street East", null, "Toronto", "Canada", null, "M4B 1V6", "Ontario" }
                });

            migrationBuilder.InsertData(
                table: "Employee",
                columns: new[] { "EmployeeId", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 2, "David", "Kandle" },
                    { 1, "Paul", "Orson" },
                    { 3, "Jillian", "Jon" }
                });

            migrationBuilder.InsertData(
                table: "Customer",
                columns: new[] { "CustomerId", "CompanyName", "EmailAddress", "EmployeeId", "FirstName", "LastName", "MiddleName", "NameStyle", "PasswordHash", "PasswordSalt", "Phone", "SalesPerson", "Suffix", "Title" },
                values: new object[,]
                {
                    { 1000, "A Bike Store", "orlando0@adventure-works.com", 1, "Orlando", "Gee", "N.", false, "L/Rlwxzp4w7RWmEgXX+/A7cXaePEPcp+KwQhl2fJL7w=", "1KjXYs4=", "245-555-0173", "adventure-works\\pamela0", null, "Mr." },
                    { 1001, "Progressive Sports", "keith0@adventure-works.com", 1, "Keith", "Harris", "N.", false, "YPdtRdvqeAhj6wyxEsFdshBDNXxkCXn+CRgbvJItknw=", "fs1ZGhY=", "170-555-0127", "adventure-works\\david8", null, "Mr." },
                    { 1002, "Advanced Bike Components", "donna0@adventure-works.com", 2, "Donna", "Carreras", "F.", false, "LNoK27abGQo48gGue3EBV/UrlYSToV0/s87dCRV7uJk=", "YTNH5Rw=", "279-555-0130", "adventure-works\\jillian0", null, "Ms." },
                    { 1003, "Modular Cycle Systems", "janet1@adventure-works.com", 3, "Janet", "Gates", "M.", false, "ElzTpSNbUW1Ut+L5cWlfR7MF6nBZia8WpmGaQPjLOJA=", "nm7D5e4=", "710-555-0173", "adventure-works\\jillian0", null, "Ms." }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Address_CustomerId",
                table: "Address",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Address_StateProvince",
                table: "Address",
                column: "StateProvince");

            migrationBuilder.CreateIndex(
                name: "IX_Address_City_StateProvince_PostalCode_CountryRegion",
                table: "Address",
                columns: new[] { "City", "StateProvince", "PostalCode", "CountryRegion" });

            migrationBuilder.CreateIndex(
                name: "IX_Customer_EmployeeId",
                table: "Customer",
                column: "EmployeeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "Employee");
        }
    }
}
