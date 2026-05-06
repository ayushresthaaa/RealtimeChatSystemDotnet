using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MessagingPlatformBackend.Migrations.StudentRecordDb
{
    /// <inheritdoc />
    public partial class InitIdentityFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Student",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "83e7453b-7967-4f7e-9503-444b014804a0", "760b6dc9-bdb4-414e-b359-e86fe4081f3e", "Student", "STUDENT" },
                    { "acf722d6-4fcd-4411-a32d-ab0d1a2772a0", "75c6ae2f-7f1e-423d-b567-3e44b054f3d5", "Admin", "ADMIN" },
                    { "ec1e80b2-8091-4ea5-8135-4e2b431d0f75", "cc208861-be60-4fee-bb65-05edf5514fb8", "Instructor", "INSTRUCTOR" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Student_UserId",
                table: "Student",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Users_UserId",
                table: "Student",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Student_Users_UserId",
                table: "Student");

            migrationBuilder.DropIndex(
                name: "IX_Student_UserId",
                table: "Student");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "83e7453b-7967-4f7e-9503-444b014804a0");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "acf722d6-4fcd-4411-a32d-ab0d1a2772a0");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "ec1e80b2-8091-4ea5-8135-4e2b431d0f75");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Student");

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
    }
}
