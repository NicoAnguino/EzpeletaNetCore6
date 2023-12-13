using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EzpeletaNetCore6.Data.Migrations
{
    public partial class CrearTablaPiques : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d4f1df72-1dd3-4924-b58e-b6cc9ea9d632");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "c9b6e534-e2da-466c-867b-f23af26ea760", "db22fd58-a02d-47dd-a3c4-4d95b60040ed" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c9b6e534-e2da-466c-867b-f23af26ea760");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "db22fd58-a02d-47dd-a3c4-4d95b60040ed");

            migrationBuilder.CreateTable(
                name: "Piques",
                columns: table => new
                {
                    PiqueID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EjeX = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EjeY = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    WidthDevice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    HeightDevice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Piques", x => x.PiqueID);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a8ca83f4-7dfb-472a-9f6c-dc6b1fb5192b", "f3f42944-6e3f-40d7-b43e-db0a03e96eea", "Superusuario", "SUPERUSUARIO" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ed29929a-e87c-48d1-9523-7e8787b4b8bc", "5f450e5f-be3d-4747-8e46-671c4dd9b928", "Administrador", "ADMINISTRADOR" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "c8ec4a86-5fb3-49d9-8c52-760b6be769bf", 0, "5a2ea0cc-144e-4430-b4b3-97f3f7429203", "ApplicationUser", "superusuario@appezpeleta.com", false, false, null, "SUPERUSUARIO@APPEZPELETA.COM", "SUPERUSUARIO@APPEZPELETA.COM", "AQAAAAEAACcQAAAAEI5HLXox35M5PJUs/RkLBNIfRMe3FqTsuWsMtrF5EcT7aie7RWrVDIXktaIep9xiGA==", null, false, "1d5ba48f-556e-44f1-bea6-bea44a9bcd92", false, "superusuario@appezpeleta.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "a8ca83f4-7dfb-472a-9f6c-dc6b1fb5192b", "c8ec4a86-5fb3-49d9-8c52-760b6be769bf" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Piques");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ed29929a-e87c-48d1-9523-7e8787b4b8bc");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "a8ca83f4-7dfb-472a-9f6c-dc6b1fb5192b", "c8ec4a86-5fb3-49d9-8c52-760b6be769bf" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a8ca83f4-7dfb-472a-9f6c-dc6b1fb5192b");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c8ec4a86-5fb3-49d9-8c52-760b6be769bf");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c9b6e534-e2da-466c-867b-f23af26ea760", "695b8cfb-a4f0-4555-b6d5-1aa2ec890838", "Superusuario", "SUPERUSUARIO" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d4f1df72-1dd3-4924-b58e-b6cc9ea9d632", "83f54703-41a2-486e-a121-192a69880056", "Administrador", "ADMINISTRADOR" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "db22fd58-a02d-47dd-a3c4-4d95b60040ed", 0, "c9fcce66-9b1b-4b8a-85c6-196ae2db1391", "ApplicationUser", "superusuario@appezpeleta.com", false, false, null, "SUPERUSUARIO@APPEZPELETA.COM", "SUPERUSUARIO@APPEZPELETA.COM", "AQAAAAEAACcQAAAAEBLjf0rHlOJo6AJ1UooYe1G7M5r3f/gOdmJHLWl4n1233u7oMhL+d+0dpznn/s38dg==", null, false, "58bf236a-7649-410f-9a94-8669ef25bf24", false, "superusuario@appezpeleta.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "c9b6e534-e2da-466c-867b-f23af26ea760", "db22fd58-a02d-47dd-a3c4-4d95b60040ed" });
        }
    }
}
