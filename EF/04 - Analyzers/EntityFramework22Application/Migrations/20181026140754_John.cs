using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityFramework22Application.Migrations
{
    public partial class John : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "CustomerId",
                keyValue: 1000,
                column: "FirstName",
                value: "John");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "CustomerId",
                keyValue: 1000,
                column: "FirstName",
                value: "Orlando");
        }
    }
}
