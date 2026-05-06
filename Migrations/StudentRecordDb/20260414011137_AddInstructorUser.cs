using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MessagingPlatformBackend.Migrations.StudentRecordDb
{
    /// <inheritdoc />
    public partial class AddInstructorUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "0dab0ffb-d860-43e1-875b-dd456d6fb7b4");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "965c5985-ccce-4c6b-afe3-4793b3d06a34");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "f9e674ee-282e-451b-8813-a817bc44e0a2");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3c87d36a-32a3-4d15-901a-71321730d8f4", "35048b93-51dd-452d-a4bc-39506df328fe", "Instructor", "INSTRUCTOR" },
                    { "a096e448-bbdc-44ec-b4e1-f00634f49352", "57e89d5a-1686-4923-9a85-e532a3f5bc26", "Student", "STUDENT" },
                    { "db0c49bc-ec50-4e42-ad63-8d11d0e0220d", "e111b71d-9769-488b-ae2b-355b22dbb722", "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "3c87d36a-32a3-4d15-901a-71321730d8f4");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "a096e448-bbdc-44ec-b4e1-f00634f49352");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "db0c49bc-ec50-4e42-ad63-8d11d0e0220d");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0dab0ffb-d860-43e1-875b-dd456d6fb7b4", "8440f046-a121-4002-b88c-7f0ec2c25b77", "Student", "STUDENT" },
                    { "965c5985-ccce-4c6b-afe3-4793b3d06a34", "f0d6d603-f7e1-401a-abd9-f56b1b1cb098", "Admin", "ADMIN" },
                    { "f9e674ee-282e-451b-8813-a817bc44e0a2", "510aabd0-d409-45de-a49c-17a26b9e9871", "Instructor", "INSTRUCTOR" }
                });
        }
    }
}
