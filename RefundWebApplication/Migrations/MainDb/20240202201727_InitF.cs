using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RefundWebApplication.Migrations.MainDb
{
    /// <inheritdoc />
    public partial class InitF : Migration
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
                columns: new[] { "Id", "City", "Email", "FirstName", "FixDescription", "HouseNumber", "IssueDate", "IssueDescription", "LastName", "Phone", "PostalCode", "PurchaseDate", "SerialNumber", "Status", "Street" },
                values: new object[] { new Guid("b8a6dd2e-454c-4908-8b4c-26110eee1047"), "Sample Town", "jane.smith@example.com", "Jane", "Product fix description goes here", "Suite 101", new DateTime(2024, 2, 2, 21, 17, 27, 314, DateTimeKind.Local).AddTicks(7488), "Product issue description goes here", "Smith", "555-987-6543", "54321", new DateTime(2023, 11, 2, 21, 17, 27, 314, DateTimeKind.Local).AddTicks(7437), "0987654321", "Nowy", "456 Oak St" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Complaints");
        }
    }
}
