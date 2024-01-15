using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RefundWebApplication.Migrations
{
    /// <inheritdoc />
    public partial class Seed2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CustomerModel",
                keyColumn: "Id",
                keyValue: new Guid("329ec81f-bcb4-42f2-8bec-3ecf91979001"));

            migrationBuilder.DeleteData(
                table: "ProductModel",
                keyColumn: "Id",
                keyValue: new Guid("437675f9-d001-47d4-9f49-ca0e7c4ffb2e"));

            migrationBuilder.AddColumn<Guid>(
                name: "ComplaintModelId",
                table: "ProductModel",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ComplaintModelId",
                table: "CustomerModel",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ComplaintModel",
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
                    table.PrimaryKey("PK_ComplaintModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AttachmentModel",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ComplaintId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UploadDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ComplaintModelId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttachmentModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AttachmentModel_ComplaintModel_ComplaintModelId",
                        column: x => x.ComplaintModelId,
                        principalTable: "ComplaintModel",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ComplaintHistoryModel",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ComplaintId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ActionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Action = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Details = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ComplaintModelId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComplaintHistoryModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ComplaintHistoryModel_ComplaintModel_ComplaintModelId",
                        column: x => x.ComplaintModelId,
                        principalTable: "ComplaintModel",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EmailLogsModel",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ComplaintId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RecipientEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailSubject = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailBody = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ComplaintModelId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailLogsModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmailLogsModel_ComplaintModel_ComplaintModelId",
                        column: x => x.ComplaintModelId,
                        principalTable: "ComplaintModel",
                        principalColumn: "Id");
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_ProductModel_ComplaintModelId",
                table: "ProductModel",
                column: "ComplaintModelId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerModel_ComplaintModelId",
                table: "CustomerModel",
                column: "ComplaintModelId");

            migrationBuilder.CreateIndex(
                name: "IX_AttachmentModel_ComplaintModelId",
                table: "AttachmentModel",
                column: "ComplaintModelId");

            migrationBuilder.CreateIndex(
                name: "IX_ComplaintHistoryModel_ComplaintModelId",
                table: "ComplaintHistoryModel",
                column: "ComplaintModelId");

            migrationBuilder.CreateIndex(
                name: "IX_EmailLogsModel_ComplaintModelId",
                table: "EmailLogsModel",
                column: "ComplaintModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerModel_ComplaintModel_ComplaintModelId",
                table: "CustomerModel",
                column: "ComplaintModelId",
                principalTable: "ComplaintModel",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductModel_ComplaintModel_ComplaintModelId",
                table: "ProductModel",
                column: "ComplaintModelId",
                principalTable: "ComplaintModel",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerModel_ComplaintModel_ComplaintModelId",
                table: "CustomerModel");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductModel_ComplaintModel_ComplaintModelId",
                table: "ProductModel");

            migrationBuilder.DropTable(
                name: "AttachmentModel");

            migrationBuilder.DropTable(
                name: "ComplaintHistoryModel");

            migrationBuilder.DropTable(
                name: "EmailLogsModel");

            migrationBuilder.DropTable(
                name: "ComplaintModel");

            migrationBuilder.DropIndex(
                name: "IX_ProductModel_ComplaintModelId",
                table: "ProductModel");

            migrationBuilder.DropIndex(
                name: "IX_CustomerModel_ComplaintModelId",
                table: "CustomerModel");

            migrationBuilder.DeleteData(
                table: "CustomerModel",
                keyColumn: "Id",
                keyValue: new Guid("72d4869c-5304-450e-be87-c806162ffca0"));

            migrationBuilder.DeleteData(
                table: "ProductModel",
                keyColumn: "Id",
                keyValue: new Guid("4f0c8b2f-59a8-4358-9076-b4f252cab91d"));

            migrationBuilder.DropColumn(
                name: "ComplaintModelId",
                table: "ProductModel");

            migrationBuilder.DropColumn(
                name: "ComplaintModelId",
                table: "CustomerModel");

            migrationBuilder.InsertData(
                table: "CustomerModel",
                columns: new[] { "Id", "City", "Email", "FirstName", "HouseNumber", "LastName", "Phone", "PostalCode", "Street" },
                values: new object[] { new Guid("329ec81f-bcb4-42f2-8bec-3ecf91979001"), "Example City", "john.doe@example.com", "John", "Apt 4B", "Doe", "555-555-5555", "12345", "123 Main Street" });

            migrationBuilder.InsertData(
                table: "ProductModel",
                columns: new[] { "Id", "Name", "PurchaseDate", "SerialNumber", "WarrantyEndDate" },
                values: new object[] { new Guid("437675f9-d001-47d4-9f49-ca0e7c4ffb2e"), "Example Product", new DateTime(2022, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "1234567890", new DateTime(2023, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }
    }
}
