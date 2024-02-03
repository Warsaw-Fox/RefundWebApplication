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
            migrationBuilder.DeleteData(
                table: "Complaints",
                keyColumn: "Id",
                keyValue: new Guid("50a40ca4-d1d6-42e4-ad48-18e1f8b8e015"));

            migrationBuilder.InsertData(
                table: "Complaints",
                columns: new[] { "Id", "City", "Email", "FirstName", "FixDescription", "HouseNumber", "IssueDate", "IssueDescription", "LastName", "PostalCode", "ProductModel", "PurchaseDate", "SerialNumber", "Status", "Street" },
                values: new object[] { new Guid("24bb8fd6-9bfe-42d5-b91a-f7b350df6ca1"), "Sample Town", "jane.smith@example.com", "Jane", "Product fix description goes here", "Suite 101", new DateTime(2024, 2, 3, 20, 50, 42, 224, DateTimeKind.Local).AddTicks(134), "Product issue description goes here", "Smith", "54321", "LENOVO IdeaPad Slim 3 15IAH8", new DateTime(2023, 11, 3, 20, 50, 42, 224, DateTimeKind.Local).AddTicks(69), "0987654321", "Nowy", "456 Oak St" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Complaints",
                keyColumn: "Id",
                keyValue: new Guid("24bb8fd6-9bfe-42d5-b91a-f7b350df6ca1"));

            migrationBuilder.InsertData(
                table: "Complaints",
                columns: new[] { "Id", "City", "Email", "FirstName", "FixDescription", "HouseNumber", "IssueDate", "IssueDescription", "LastName", "PostalCode", "ProductModel", "PurchaseDate", "SerialNumber", "Status", "Street" },
                values: new object[] { new Guid("50a40ca4-d1d6-42e4-ad48-18e1f8b8e015"), "Sample Town", "jane.smith@example.com", "Jane", "Product fix description goes here", "Suite 101", new DateTime(2024, 2, 3, 15, 46, 47, 317, DateTimeKind.Local).AddTicks(4340), "Product issue description goes here", "Smith", "54321", "LENOVO IdeaPad Slim 3 15IAH8", new DateTime(2023, 11, 3, 15, 46, 47, 317, DateTimeKind.Local).AddTicks(4295), "0987654321", "Nowy", "456 Oak St" });
        }
    }
}
