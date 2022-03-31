using Microsoft.EntityFrameworkCore.Migrations;

namespace F1API.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Drivers",
                columns: new[] { "DriverId", "Age", "Name", "Team" },
                values: new object[,]
                {
                    { 1, 37, "Lewis Hamilton", "Mercedes" },
                    { 2, 24, "Max Verstappen", "Red Bull" },
                    { 3, 32, "Daniel Ricciardo", "McLaren" },
                    { 4, 27, "Carlos Sainz", "Ferrari" },
                    { 5, 34, "Aston Martin", "Astin Martin" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Drivers",
                keyColumn: "DriverId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Drivers",
                keyColumn: "DriverId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Drivers",
                keyColumn: "DriverId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Drivers",
                keyColumn: "DriverId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Drivers",
                keyColumn: "DriverId",
                keyValue: 5);
        }
    }
}
