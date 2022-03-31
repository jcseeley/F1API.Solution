using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace F1API.Migrations
{
    public partial class InitialWithSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Drivers",
                columns: table => new
                {
                    DriverId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Team = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drivers", x => x.DriverId);
                });

            migrationBuilder.InsertData(
                table: "Drivers",
                columns: new[] { "DriverId", "Age", "Name", "Team" },
                values: new object[,]
                {
                    { 1, 37, "Lewis Hamilton", "Mercedes" },
                    { 2, 24, "Max Verstappen", "Red Bull" },
                    { 3, 32, "Daniel Ricciardo", "McLaren" },
                    { 4, 27, "Carlos Sainz", "Ferrari" },
                    { 5, 34, "Sebastian Vettel", "Astin Martin" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Drivers");
        }
    }
}
