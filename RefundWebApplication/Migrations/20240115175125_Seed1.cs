using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RefundWebApplication.Migrations
{
    /// <inheritdoc />
    public partial class Seed1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Complaints_ComplaintModelId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Complaints_ComplaintModelId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "Attachments");

            migrationBuilder.DropTable(
                name: "ComplaintHistories");

            migrationBuilder.DropTable(
                name: "EmailLogs");

            migrationBuilder.DropTable(
                name: "Complaints");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_ComplaintModelId",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Customers",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_ComplaintModelId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "ComplaintModelId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ComplaintModelId",
                table: "Customers");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "ProductModel");

            migrationBuilder.RenameTable(
                name: "Customers",
                newName: "CustomerModel");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductModel",
                table: "ProductModel",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CustomerModel",
                table: "CustomerModel",
                column: "Id");

            migrationBuilder.InsertData(
                table: "CustomerModel",
                columns: new[] { "Id", "City", "Email", "FirstName", "HouseNumber", "LastName", "Phone", "PostalCode", "Street" },
                values: new object[] { new Guid("329ec81f-bcb4-42f2-8bec-3ecf91979001"), "Example City", "john.doe@example.com", "John", "Apt 4B", "Doe", "555-555-5555", "12345", "123 Main Street" });

            migrationBuilder.InsertData(
                table: "ProductModel",
                columns: new[] { "Id", "Name", "PurchaseDate", "SerialNumber", "WarrantyEndDate" },
                values: new object[] { new Guid("437675f9-d001-47d4-9f49-ca0e7c4ffb2e"), "Example Product", new DateTime(2022, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "1234567890", new DateTime(2023, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductModel",
                table: "ProductModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CustomerModel",
                table: "CustomerModel");

            migrationBuilder.DeleteData(
                table: "CustomerModel",
                keyColumn: "Id",
                keyValue: new Guid("329ec81f-bcb4-42f2-8bec-3ecf91979001"));

            migrationBuilder.DeleteData(
                table: "ProductModel",
                keyColumn: "Id",
                keyValue: new Guid("437675f9-d001-47d4-9f49-ca0e7c4ffb2e"));

            migrationBuilder.RenameTable(
                name: "ProductModel",
                newName: "Products");

            migrationBuilder.RenameTable(
                name: "CustomerModel",
                newName: "Customers");

            migrationBuilder.AddColumn<Guid>(
                name: "ComplaintModelId",
                table: "Products",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ComplaintModelId",
                table: "Customers",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customers",
                table: "Customers",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Complaints",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HouseNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IssueDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PurchaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SerialNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Complaints", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Attachments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ComplaintId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ComplaintModelId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UploadDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attachments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Attachments_Complaints_ComplaintModelId",
                        column: x => x.ComplaintModelId,
                        principalTable: "Complaints",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ComplaintHistories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Action = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ActionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ComplaintId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ComplaintModelId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Details = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComplaintHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ComplaintHistories_Complaints_ComplaintModelId",
                        column: x => x.ComplaintModelId,
                        principalTable: "Complaints",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EmailLogs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ComplaintId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ComplaintModelId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    EmailBody = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailSubject = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RecipientEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SentDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmailLogs_Complaints_ComplaintModelId",
                        column: x => x.ComplaintModelId,
                        principalTable: "Complaints",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_ComplaintModelId",
                table: "Products",
                column: "ComplaintModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_ComplaintModelId",
                table: "Customers",
                column: "ComplaintModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Attachments_ComplaintModelId",
                table: "Attachments",
                column: "ComplaintModelId");

            migrationBuilder.CreateIndex(
                name: "IX_ComplaintHistories_ComplaintModelId",
                table: "ComplaintHistories",
                column: "ComplaintModelId");

            migrationBuilder.CreateIndex(
                name: "IX_EmailLogs_ComplaintModelId",
                table: "EmailLogs",
                column: "ComplaintModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Complaints_ComplaintModelId",
                table: "Customers",
                column: "ComplaintModelId",
                principalTable: "Complaints",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Complaints_ComplaintModelId",
                table: "Products",
                column: "ComplaintModelId",
                principalTable: "Complaints",
                principalColumn: "Id");
        }
    }
}
