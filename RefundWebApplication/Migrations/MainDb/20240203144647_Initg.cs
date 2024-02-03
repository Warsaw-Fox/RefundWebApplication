using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RefundWebApplication.Migrations.MainDb
{
    /// <inheritdoc />
    public partial class Initg : Migration
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
                    ProductModel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SerialNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PurchaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IssueDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IssueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FixDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Complaints", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Complaints",
                columns: new[] { "Id", "City", "Email", "FirstName", "FixDescription", "HouseNumber", "IssueDate", "IssueDescription", "LastName", "PostalCode", "ProductModel", "PurchaseDate", "SerialNumber", "Status", "Street" },
                values: new object[] { new Guid("50a40ca4-d1d6-42e4-ad48-18e1f8b8e015"), "Sample Town", "jane.smith@example.com", "Jane", "Product fix description goes here", "Suite 101", new DateTime(2024, 2, 3, 15, 46, 47, 317, DateTimeKind.Local).AddTicks(4340), "Product issue description goes here", "Smith", "54321", "LENOVO IdeaPad Slim 3 15IAH8", new DateTime(2023, 11, 3, 15, 46, 47, 317, DateTimeKind.Local).AddTicks(4295), "0987654321", "Nowy", "456 Oak St" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Complaints");
        }
    }
}
