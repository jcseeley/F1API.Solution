using Microsoft.EntityFrameworkCore.Migrations;

namespace F1API.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Drivers",
                keyColumn: "DriverId",
                keyValue: 5,
                column: "Name",
                value: "Sebastian Vettel");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Drivers",
                keyColumn: "DriverId",
                keyValue: 5,
                column: "Name",
                value: "Aston Martin");
        }
    }
}
