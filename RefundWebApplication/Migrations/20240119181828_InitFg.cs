using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RefundWebApplication.Migrations
{
    /// <inheritdoc />
    public partial class InitFg : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Complaints",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HouseNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SerialNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PurchaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IssueDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Complaints", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Complaints",
                columns: new[] { "Id", "City", "Email", "FirstName", "HouseNumber", "IssueDescription", "LastName", "Phone", "PostalCode", "PurchaseDate", "SerialNumber", "Street" },
                values: new object[] { new Guid("6ab35a2f-556f-4659-aeb1-fcd055b44c18"), "Sample Town", "jane.smith@example.com", "Jane", "Suite 101", "Product issue description goes here", "Smith", "555-987-6543", "54321", new DateTime(2023, 10, 19, 19, 18, 28, 536, DateTimeKind.Local).AddTicks(7662), "0987654321", "456 Oak St" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Complaints");
        }
    }
}
