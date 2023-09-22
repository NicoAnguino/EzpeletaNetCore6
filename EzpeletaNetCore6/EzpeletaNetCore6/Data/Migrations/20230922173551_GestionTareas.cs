using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EzpeletaNetCore6.Data.Migrations
{
    public partial class GestionTareas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateTable(
                name: "Tareas",
                columns: table => new
                {
                    TareaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prioridad = table.Column<int>(type: "int", nullable: false),
                    Realizada = table.Column<bool>(type: "bit", nullable: false),
                    UsuarioID = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tareas", x => x.TareaID);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "23c2dfa5-6436-4fbd-bdbc-387a24c45dff", "749cc7d3-84d0-4865-908d-70b35b033811", "Superusuario", "SUPERUSUARIO" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "315c702c-88e2-4a62-a43e-7cf4d4fe5407", "06b6bfea-5468-4064-ba32-5d4803be907f", "Administrador", "ADMINISTRADOR" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "619c4dcc-b7fc-4a19-869d-e8be2f3361be", 0, "7db4eaba-94ef-439b-a40c-756fd012b68d", "ApplicationUser", "superusuario@appezpeleta.com", false, false, null, "SUPERUSUARIO@APPEZPELETA.COM", "SUPERUSUARIO@APPEZPELETA.COM", "AQAAAAEAACcQAAAAECCk8hMV99bd9QWOHo2GfE0aZGm0QVKbAsyAwW13dM9jkOCAWK6wT3pVjExBZD/dUw==", null, false, "246d3cb6-4226-4e89-8f3f-4bfefdb0adf7", false, "superusuario@appezpeleta.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "23c2dfa5-6436-4fbd-bdbc-387a24c45dff", "619c4dcc-b7fc-4a19-869d-e8be2f3361be" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tareas");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "315c702c-88e2-4a62-a43e-7cf4d4fe5407");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "23c2dfa5-6436-4fbd-bdbc-387a24c45dff", "619c4dcc-b7fc-4a19-869d-e8be2f3361be" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "23c2dfa5-6436-4fbd-bdbc-387a24c45dff");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "619c4dcc-b7fc-4a19-869d-e8be2f3361be");

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
        }
    }
}
