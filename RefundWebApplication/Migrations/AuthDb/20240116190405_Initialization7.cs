using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RefundWebApplication.Migrations.AuthDb
{
    /// <inheritdoc />
    public partial class Initialization7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "37cc67e1-41ca-461c-bf34-2b5e62dbae32",
                columns: new[] { "Name", "NormalizedName" },
                values: new object[] { "Admin", "Admin" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a0cab2c3-6558-4a1c-be81-dfb39180da3d",
                columns: new[] { "Name", "NormalizedName" },
                values: new object[] { "User", "User" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "472ba632-6133-44a1-b158-6c10bd7d850d",
                columns: new[] { "ConcurrencyStamp", "Email", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "0760e081-824f-46e7-888b-b187bf2ee390", "superadmin@dupex.com", "SUPERADMIN@DUPEX.COM", "SUPERADMIN@DUPEX.COM", "AQAAAAIAAYagAAAAEFdtZLnMrxnw2ThtkxdFz6h+bkeoqmTVciUgj9+PNbeoTrx4a10f8TN/M7Ypo44eYA==", "64533bf5-1328-43af-a7a4-7126686dadfa", "superadmin@dupex.com" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "37cc67e1-41ca-461c-bf34-2b5e62dbae32",
                columns: new[] { "Name", "NormalizedName" },
                values: new object[] { "Majster", "Majster" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a0cab2c3-6558-4a1c-be81-dfb39180da3d",
                columns: new[] { "Name", "NormalizedName" },
                values: new object[] { "Serwisant", "Serwisant" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "472ba632-6133-44a1-b158-6c10bd7d850d",
                columns: new[] { "ConcurrencyStamp", "Email", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "e1acdddc-d75d-4889-86f8-72d93a7f1c5a", "superadmin@bloggie.com", "SUPERADMIN@BLOGGIE.COM", "SUPERADMIN@BLOGGIE.COM", "AQAAAAIAAYagAAAAELlDe3tD720ixO2Z7FByFZSIjr/bVd971WhDvmeJkgZOZ9AIkB7tM1VKFshHTFWdyg==", "fcf68e95-0099-4494-ad65-addf782769dc", "superadmin@bloggie.com" });
        }
    }
}
