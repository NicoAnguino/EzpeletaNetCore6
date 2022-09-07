using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EzpeletaNetCore6.Data.Migrations
{
    public partial class ImagenProducto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "Img",
                table: "Rubros");

            migrationBuilder.DropColumn(
                name: "TipoImg",
                table: "Rubros");

            migrationBuilder.AddColumn<byte[]>(
                name: "Img",
                table: "Articulos",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TipoImg",
                table: "Articulos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "608675fe-9bec-4099-adae-f74db559e9bd", "ab43fd81-68cd-4a28-bf4c-bc07ab6c3f09", "Superusuario", "SUPERUSUARIO" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d81b3448-1cfd-4b69-ba88-85c6a0857b98", "78e42367-90c8-4992-821f-ce6acdbb3649", "Administrador", "ADMINISTRADOR" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "dadcde81-c171-4da6-bf0b-15c0afef99c9", 0, "a0aea7c3-76db-40e8-96b2-3b397a7af2c9", "ApplicationUser", "superusuario@appezpeleta.com", false, false, null, "SUPERUSUARIO@APPEZPELETA.COM", "SUPERUSUARIO@APPEZPELETA.COM", "AQAAAAEAACcQAAAAEJn5OJwerwsco4/oitl/blKVeSF68Bvp889gv6w1vtkPg0Jt0WPFr/Z7pYfG6UphNQ==", null, false, "df61166a-a575-44bc-8a53-18a1fb5b41e9", false, "superusuario@appezpeleta.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "608675fe-9bec-4099-adae-f74db559e9bd", "dadcde81-c171-4da6-bf0b-15c0afef99c9" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d81b3448-1cfd-4b69-ba88-85c6a0857b98");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "608675fe-9bec-4099-adae-f74db559e9bd", "dadcde81-c171-4da6-bf0b-15c0afef99c9" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "608675fe-9bec-4099-adae-f74db559e9bd");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dadcde81-c171-4da6-bf0b-15c0afef99c9");

            migrationBuilder.DropColumn(
                name: "Img",
                table: "Articulos");

            migrationBuilder.DropColumn(
                name: "TipoImg",
                table: "Articulos");

            migrationBuilder.AddColumn<byte[]>(
                name: "Img",
                table: "Rubros",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TipoImg",
                table: "Rubros",
                type: "nvarchar(max)",
                nullable: true);

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
    }
}
