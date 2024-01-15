using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RefundWebApplication.Migrations
{
    /// <inheritdoc />
    public partial class Seed3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ComplaintModel",
                keyColumn: "Id",
                keyValue: new Guid("f117825f-f03c-413f-a51a-efcc90f0af4f"));

            migrationBuilder.DeleteData(
                table: "CustomerModel",
                keyColumn: "Id",
                keyValue: new Guid("72d4869c-5304-450e-be87-c806162ffca0"));

            migrationBuilder.DeleteData(
                table: "ProductModel",
                keyColumn: "Id",
                keyValue: new Guid("4f0c8b2f-59a8-4358-9076-b4f252cab91d"));

            migrationBuilder.InsertData(
                table: "AttachmentModel",
                columns: new[] { "Id", "ComplaintId", "ComplaintModelId", "FileName", "FilePath", "FileType", "UploadDate" },
                values: new object[] { new Guid("e5af7eda-8add-4e4d-ae31-3e3de4ddceb2"), new Guid("f117825f-f03c-413f-a51a-efcc90f0af4f"), null, "example.jpg", "/uploads/example.jpg", "image", new DateTime(2023, 12, 15, 19, 14, 26, 964, DateTimeKind.Local).AddTicks(4343) });

            migrationBuilder.InsertData(
                table: "ComplaintHistoryModel",
                columns: new[] { "Id", "Action", "ActionDate", "ComplaintId", "ComplaintModelId", "Details", "Status" },
                values: new object[] { new Guid("bb7af25d-812c-4765-ae1a-4ac55844c4fa"), "Change status", new DateTime(2023, 12, 15, 19, 14, 26, 964, DateTimeKind.Local).AddTicks(4321), new Guid("f117825f-f03c-413f-a51a-efcc90f0af4f"), null, "Complaint has been resolved.", "Resolved" });

            migrationBuilder.InsertData(
                table: "ComplaintModel",
                columns: new[] { "Id", "City", "Email", "FirstName", "HouseNumber", "IssueDescription", "LastName", "Phone", "PostalCode", "PurchaseDate", "SerialNumber", "Street" },
                values: new object[] { new Guid("7ca8bce3-b34e-4058-9365-99f56e8446ce"), "Sample Town", "jane.smith@example.com", "Jane", "Suite 101", "Product issue description goes here", "Smith", "555-987-6543", "54321", new DateTime(2023, 10, 15, 19, 14, 26, 964, DateTimeKind.Local).AddTicks(4181), "0987654321", "456 Oak St" });

            migrationBuilder.InsertData(
                table: "CustomerModel",
                columns: new[] { "Id", "City", "ComplaintModelId", "Email", "FirstName", "HouseNumber", "LastName", "Phone", "PostalCode", "Street" },
                values: new object[] { new Guid("4a71d37e-2bfd-4704-ba18-3655dc64cd44"), "Example City", null, "john.doe@example.com", "John", "Apt 4B", "Doe", "555-555-5555", "12345", "123 Main Street" });

            migrationBuilder.InsertData(
                table: "EmailLogsModel",
                columns: new[] { "Id", "ComplaintId", "ComplaintModelId", "EmailBody", "EmailSubject", "RecipientEmail", "SentDate" },
                values: new object[] { new Guid("90f0ee09-4285-4fed-b419-8c72da3c16a2"), new Guid("f117825f-f03c-413f-a51a-efcc90f0af4f"), null, "This is a sample email body.", "Sample Email", "recipient@example.com", new DateTime(2023, 12, 15, 19, 14, 26, 964, DateTimeKind.Local).AddTicks(4358) });

            migrationBuilder.InsertData(
                table: "ProductModel",
                columns: new[] { "Id", "ComplaintModelId", "Name", "PurchaseDate", "SerialNumber", "WarrantyEndDate" },
                values: new object[] { new Guid("48f53204-9140-4740-ba43-2c455934221c"), null, "Example Product", new DateTime(2023, 10, 15, 19, 14, 26, 958, DateTimeKind.Local).AddTicks(8236), "1234567890", new DateTime(2023, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AttachmentModel",
                keyColumn: "Id",
                keyValue: new Guid("e5af7eda-8add-4e4d-ae31-3e3de4ddceb2"));

            migrationBuilder.DeleteData(
                table: "ComplaintHistoryModel",
                keyColumn: "Id",
                keyValue: new Guid("bb7af25d-812c-4765-ae1a-4ac55844c4fa"));

            migrationBuilder.DeleteData(
                table: "ComplaintModel",
                keyColumn: "Id",
                keyValue: new Guid("7ca8bce3-b34e-4058-9365-99f56e8446ce"));

            migrationBuilder.DeleteData(
                table: "CustomerModel",
                keyColumn: "Id",
                keyValue: new Guid("4a71d37e-2bfd-4704-ba18-3655dc64cd44"));

            migrationBuilder.DeleteData(
                table: "EmailLogsModel",
                keyColumn: "Id",
                keyValue: new Guid("90f0ee09-4285-4fed-b419-8c72da3c16a2"));

            migrationBuilder.DeleteData(
                table: "ProductModel",
                keyColumn: "Id",
                keyValue: new Guid("48f53204-9140-4740-ba43-2c455934221c"));

            migrationBuilder.InsertData(
                table: "ComplaintModel",
                columns: new[] { "Id", "City", "Email", "FirstName", "HouseNumber", "IssueDescription", "LastName", "Phone", "PostalCode", "PurchaseDate", "SerialNumber", "Street" },
                values: new object[] { new Guid("f117825f-f03c-413f-a51a-efcc90f0af4f"), "Sample Town", "jane.smith@example.com", "Jane", "Suite 101", "Product issue description goes here", "Smith", "555-987-6543", "54321", new DateTime(2023, 10, 15, 19, 1, 23, 287, DateTimeKind.Local).AddTicks(2546), "0987654321", "456 Oak St" });

            migrationBuilder.InsertData(
                table: "CustomerModel",
                columns: new[] { "Id", "City", "ComplaintModelId", "Email", "FirstName", "HouseNumber", "LastName", "Phone", "PostalCode", "Street" },
                values: new object[] { new Guid("72d4869c-5304-450e-be87-c806162ffca0"), "Example City", null, "john.doe@example.com", "John", "Apt 4B", "Doe", "555-555-5555", "12345", "123 Main Street" });

            migrationBuilder.InsertData(
                table: "ProductModel",
                columns: new[] { "Id", "ComplaintModelId", "Name", "PurchaseDate", "SerialNumber", "WarrantyEndDate" },
                values: new object[] { new Guid("4f0c8b2f-59a8-4358-9076-b4f252cab91d"), null, "Example Product", new DateTime(2023, 10, 15, 19, 1, 23, 281, DateTimeKind.Local).AddTicks(8961), "1234567890", new DateTime(2023, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }
    }
}
