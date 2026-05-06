using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MessagingPlatformBackend.Migrations.StudentRecordDb
{
    /// <inheritdoc />
    public partial class Roles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4502e963-7f7f-4b9f-b218-9ca2afc43df2", "e0f2d5bc-39d1-4ac7-b225-e94ea9c16ab7", "Student", "STUDENT" },
                    { "666ca489-ffe4-4362-8642-259e5300039b", "99fc5918-b411-4211-bdd6-9fa21f5a1ed1", "Admin", "ADMIN" },
                    { "7100d48c-c79e-48f6-b67b-99051d0f97c3", "d40631ad-fb45-4259-806c-894c1b62d197", "Instructor", "INSTRUCTOR" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "4502e963-7f7f-4b9f-b218-9ca2afc43df2");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "666ca489-ffe4-4362-8642-259e5300039b");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "7100d48c-c79e-48f6-b67b-99051d0f97c3");
        }
    }
}
