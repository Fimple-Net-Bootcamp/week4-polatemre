using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace VirtualPetCareApi.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PetId",
                table: "Pets",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SocialInteraction",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    PetId = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SocialInteraction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SocialInteraction_Pets_PetId",
                        column: x => x.PetId,
                        principalTable: "Pets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "609665d7-c40b-45a4-ad60-dfb3c9464616", "AQAAAAIAAYagAAAAEE/ve8mVLZ+G+LVpNCtpgl+dkU/uleJvrPk93QSw9Me84dQADd1Qo6p+SaF4aTNwvg==", "2f0a7937-0e2e-4f99-bdc5-c3f8b8ae46ab" });

            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 1,
                column: "PetId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 2,
                column: "PetId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_Pets_PetId",
                table: "Pets",
                column: "PetId");

            migrationBuilder.CreateIndex(
                name: "IX_SocialInteraction_PetId",
                table: "SocialInteraction",
                column: "PetId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pets_Pets_PetId",
                table: "Pets",
                column: "PetId",
                principalTable: "Pets",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pets_Pets_PetId",
                table: "Pets");

            migrationBuilder.DropTable(
                name: "SocialInteraction");

            migrationBuilder.DropIndex(
                name: "IX_Pets_PetId",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "PetId",
                table: "Pets");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "10a56692-345d-414c-ae5a-93e3b869da29", "AQAAAAIAAYagAAAAENgplWIXOITQ9zpg+vDyg8xtKU7PUXohG3FXAbN9H/9zSAaujxFo0SrzSbIYKYsJ+A==", "62fc0697-701f-45a0-9f4d-778cb15b5275" });
        }
    }
}
