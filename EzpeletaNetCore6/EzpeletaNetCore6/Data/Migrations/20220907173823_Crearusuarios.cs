using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EzpeletaNetCore6.Data.Migrations
{
    public partial class Crearusuarios : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "70f988bd-fd20-491d-bbec-df9219deaa65", "fa3745da-d06c-4feb-9d3e-a80165935954", "Superusuario", "SUPERUSUARIO" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f901dc87-2ee6-4596-be5d-5a17d6e6906e", "7a862642-e72f-4760-a134-8955f24c8bad", "Administrador", "ADMINISTRADOR" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "c1331a0c-a551-4c2e-bb35-6e4e0cd03c3e", 0, "89cce728-8c41-4373-bebc-cfebd2210aa8", "ApplicationUser", "superusuario@appezpeleta.com", false, false, null, "SUPERUSUARIO@APPEZPELETA.COM", "SUPERUSUARIO@APPEZPELETA.COM", "AQAAAAEAACcQAAAAELHUWOtjfZLXaNvJKCRso2klXspstljS+tU0G/VZB7TOiLsHEjHrG6RLH1cqH4f+GQ==", null, false, "c8c8018f-5bc9-4e90-a909-575f56c1f04d", false, "superusuario@appezpeleta.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "70f988bd-fd20-491d-bbec-df9219deaa65", "c1331a0c-a551-4c2e-bb35-6e4e0cd03c3e" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f901dc87-2ee6-4596-be5d-5a17d6e6906e");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "70f988bd-fd20-491d-bbec-df9219deaa65", "c1331a0c-a551-4c2e-bb35-6e4e0cd03c3e" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "70f988bd-fd20-491d-bbec-df9219deaa65");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c1331a0c-a551-4c2e-bb35-6e4e0cd03c3e");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");
        }
    }
}
