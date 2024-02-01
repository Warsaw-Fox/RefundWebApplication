using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RefundWebApplication.Migrations
{
    /// <inheritdoc />
    public partial class InitD : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Complaints",
                keyColumn: "Id",
                keyValue: new Guid("89e520be-5eca-40fc-b298-b314c83b919f"));

            migrationBuilder.InsertData(
                table: "Complaints",
                columns: new[] { "Id", "City", "Email", "FirstName", "FixDescription", "HouseNumber", "IssueDate", "IssueDescription", "LastName", "Phone", "PostalCode", "PurchaseDate", "SerialNumber", "Status", "Street" },
                values: new object[] { new Guid("7f6397f0-3bf2-4bd3-993e-7d170e5cbdfa"), "Sample Town", "jane.smith@example.com", "Jane", "Product fix description goes here", "Suite 101", new DateTime(2024, 2, 1, 20, 49, 56, 482, DateTimeKind.Local).AddTicks(7761), "Product issue description goes here", "Smith", "555-987-6543", "54321", new DateTime(2023, 11, 1, 20, 49, 56, 482, DateTimeKind.Local).AddTicks(7721), "0987654321", "Nowy", "456 Oak St" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Complaints",
                keyColumn: "Id",
                keyValue: new Guid("7f6397f0-3bf2-4bd3-993e-7d170e5cbdfa"));

            migrationBuilder.InsertData(
                table: "Complaints",
                columns: new[] { "Id", "City", "Email", "FirstName", "FixDescription", "HouseNumber", "IssueDate", "IssueDescription", "LastName", "Phone", "PostalCode", "PurchaseDate", "SerialNumber", "Status", "Street" },
                values: new object[] { new Guid("89e520be-5eca-40fc-b298-b314c83b919f"), "Sample Town", "jane.smith@example.com", "Jane", "Product fix description goes here", "Suite 101", new DateTime(2024, 2, 1, 20, 30, 35, 697, DateTimeKind.Local).AddTicks(7017), "Product issue description goes here", "Smith", "555-987-6543", "54321", new DateTime(2023, 11, 1, 20, 30, 35, 697, DateTimeKind.Local).AddTicks(6966), "0987654321", "Nowy", "456 Oak St" });
        }
    }
}
