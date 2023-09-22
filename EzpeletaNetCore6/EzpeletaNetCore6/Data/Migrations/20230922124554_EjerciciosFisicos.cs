using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EzpeletaNetCore6.Data.Migrations
{
    public partial class EjerciciosFisicos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "TiposEjerciciosFisicos",
                columns: table => new
                {
                    TipoEjercicioFisicoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Eliminado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposEjerciciosFisicos", x => x.TipoEjercicioFisicoID);
                });

            migrationBuilder.CreateTable(
                name: "EjerciciosFisicos",
                columns: table => new
                {
                    EjercicioFisicoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoEjercicioFisicoID = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CantidadMinutos = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EjerciciosFisicos", x => x.EjercicioFisicoID);
                    table.ForeignKey(
                        name: "FK_EjerciciosFisicos_TiposEjerciciosFisicos_TipoEjercicioFisicoID",
                        column: x => x.TipoEjercicioFisicoID,
                        principalTable: "TiposEjerciciosFisicos",
                        principalColumn: "TipoEjercicioFisicoID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "539ba79c-f9e1-4815-b28b-8b5893eb26e9", "0d199fe2-68c9-4945-83a4-3be28d1878e0", "Superusuario", "SUPERUSUARIO" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "cccfa6e7-c83c-4e2b-9df9-619d31e948c2", "a77bbae7-d493-483a-a857-e326efaa95b3", "Administrador", "ADMINISTRADOR" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "95578f65-8ca3-4e70-94c8-2b1fd2a1f637", 0, "129a711e-f5d0-4704-93c3-a0590a01266a", "ApplicationUser", "superusuario@appezpeleta.com", false, false, null, "SUPERUSUARIO@APPEZPELETA.COM", "SUPERUSUARIO@APPEZPELETA.COM", "AQAAAAEAACcQAAAAEFDZv68tzNosVJTS92PQZo+OrcF4ifYxy+J/RR/vx8m75OcmOhk06Q8LvEDUGZuWXQ==", null, false, "76d48fc1-d92d-498c-8a9c-da6792a32b1c", false, "superusuario@appezpeleta.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "539ba79c-f9e1-4815-b28b-8b5893eb26e9", "95578f65-8ca3-4e70-94c8-2b1fd2a1f637" });

            migrationBuilder.CreateIndex(
                name: "IX_EjerciciosFisicos_TipoEjercicioFisicoID",
                table: "EjerciciosFisicos",
                column: "TipoEjercicioFisicoID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EjerciciosFisicos");

            migrationBuilder.DropTable(
                name: "TiposEjerciciosFisicos");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cccfa6e7-c83c-4e2b-9df9-619d31e948c2");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "539ba79c-f9e1-4815-b28b-8b5893eb26e9", "95578f65-8ca3-4e70-94c8-2b1fd2a1f637" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "539ba79c-f9e1-4815-b28b-8b5893eb26e9");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "95578f65-8ca3-4e70-94c8-2b1fd2a1f637");

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
    }
}
