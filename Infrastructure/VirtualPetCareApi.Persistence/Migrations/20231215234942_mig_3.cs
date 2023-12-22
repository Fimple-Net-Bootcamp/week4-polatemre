using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace VirtualPetCareApi.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NameSurname", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RefreshToken", "RefreshTokenEndDate", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "b74ddd14-6340-4840-95c2-db12554843e5", 0, "c10706e1-fd78-4d15-b654-6c3bf7e7d7e2", "admin@gmail.com", false, false, null, "Admin", null, null, null, "1234567890", false, null, null, null, false, "Admin" });

            migrationBuilder.InsertData(
                table: "Foods",
                columns: new[] { "Id", "CreatedDate", "Name", "UpdatedDate", "Value" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 12, 15, 23, 49, 41, 984, DateTimeKind.Utc).AddTicks(7885), "Kedi Maması", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 25 },
                    { 2, new DateTime(2023, 12, 15, 23, 49, 41, 984, DateTimeKind.Utc).AddTicks(7892), "Et", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 50 }
                });

            migrationBuilder.InsertData(
                table: "Healths",
                columns: new[] { "Id", "CreatedDate", "Description", "UpdatedDate", "Value" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 12, 15, 23, 49, 41, 984, DateTimeKind.Utc).AddTicks(8777), "Sağlıklı", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 100 },
                    { 2, new DateTime(2023, 12, 15, 23, 49, 41, 984, DateTimeKind.Utc).AddTicks(8782), "Orta", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 50 }
                });

            migrationBuilder.InsertData(
                table: "Pets",
                columns: new[] { "Id", "CreatedDate", "Description", "HealthId", "Name", "Status", "UpdatedDate", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 12, 15, 23, 49, 41, 984, DateTimeKind.Utc).AddTicks(8890), "Sevimli", 1, "Kedi", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "b74ddd14-6340-4840-95c2-db12554843e5" },
                    { 2, new DateTime(2023, 12, 15, 23, 49, 41, 984, DateTimeKind.Utc).AddTicks(8895), "", 1, "Köpek", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "b74ddd14-6340-4840-95c2-db12554843e5" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "CreatedDate", "Name", "PetId", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 12, 15, 23, 49, 41, 984, DateTimeKind.Utc).AddTicks(8972), "Yürüyebilir", 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2023, 12, 15, 23, 49, 41, 984, DateTimeKind.Utc).AddTicks(8975), "Oyun Oynayabilir", 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(2023, 12, 15, 23, 49, 41, 984, DateTimeKind.Utc).AddTicks(8977), "Eğitilebilir", 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Healths",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5");

            migrationBuilder.DeleteData(
                table: "Healths",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
