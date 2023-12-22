using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VirtualPetCareApi.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "EmailConfirmed", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumberConfirmed", "SecurityStamp" },
                values: new object[] { "10a56692-345d-414c-ae5a-93e3b869da29", true, "XXXX@EXAMPLE.COM", "OWNER", "AQAAAAIAAYagAAAAENgplWIXOITQ9zpg+vDyg8xtKU7PUXohG3FXAbN9H/9zSAaujxFo0SrzSbIYKYsJ+A==", true, "62fc0697-701f-45a0-9f4d-778cb15b5275" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "EmailConfirmed", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumberConfirmed", "SecurityStamp" },
                values: new object[] { "cd8e27c7-cfcd-4612-8df4-bdd0e523e20c", false, null, null, "AQAAAAIAAYagAAAAENNhTCgSGRqK7JdazQUcPEpq/wVjPzyhwfBkgOnZGIq7gEvp4wW2BpME7lkaGhKq9w==", false, null });
        }
    }
}
