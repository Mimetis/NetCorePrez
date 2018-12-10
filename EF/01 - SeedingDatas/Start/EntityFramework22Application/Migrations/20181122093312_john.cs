using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityFramework22Application.Migrations
{
    public partial class john : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "EmployeeId",
                keyValue: 1,
                column: "FirstName",
                value: "John");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "EmployeeId",
                keyValue: 1,
                column: "FirstName",
                value: "Orlando");
        }
    }
}
