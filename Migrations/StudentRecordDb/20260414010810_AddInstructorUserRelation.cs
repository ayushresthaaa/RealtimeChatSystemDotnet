using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MessagingPlatformBackend.Migrations.StudentRecordDb
{
    /// <inheritdoc />
    public partial class AddInstructorUserRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ModuleInstructor_Instructor_InstructorId",
                table: "ModuleInstructor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Instructor",
                table: "Instructor");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "68f9fafe-be28-49dc-8dd6-b83ee8c48fa5");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "d754dd0e-94f7-48d9-aaf8-3fc891c22e30");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "e9da0dec-8420-407e-ad91-778a3d5f8764");

            migrationBuilder.RenameTable(
                name: "Instructor",
                newName: "Instructors");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Instructors",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Instructors",
                table: "Instructors",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0dab0ffb-d860-43e1-875b-dd456d6fb7b4", "8440f046-a121-4002-b88c-7f0ec2c25b77", "Student", "STUDENT" },
                    { "965c5985-ccce-4c6b-afe3-4793b3d06a34", "f0d6d603-f7e1-401a-abd9-f56b1b1cb098", "Admin", "ADMIN" },
                    { "f9e674ee-282e-451b-8813-a817bc44e0a2", "510aabd0-d409-45de-a49c-17a26b9e9871", "Instructor", "INSTRUCTOR" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Instructors_UserId",
                table: "Instructors",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Instructors_Users_UserId",
                table: "Instructors",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ModuleInstructor_Instructors_InstructorId",
                table: "ModuleInstructor",
                column: "InstructorId",
                principalTable: "Instructors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Instructors_Users_UserId",
                table: "Instructors");

            migrationBuilder.DropForeignKey(
                name: "FK_ModuleInstructor_Instructors_InstructorId",
                table: "ModuleInstructor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Instructors",
                table: "Instructors");

            migrationBuilder.DropIndex(
                name: "IX_Instructors_UserId",
                table: "Instructors");

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

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Instructors");

            migrationBuilder.RenameTable(
                name: "Instructors",
                newName: "Instructor");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Instructor",
                table: "Instructor",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "68f9fafe-be28-49dc-8dd6-b83ee8c48fa5", "ae305c97-b113-49bb-aaa2-fdd49a0516a7", "Instructor", "INSTRUCTOR" },
                    { "d754dd0e-94f7-48d9-aaf8-3fc891c22e30", "f399685a-e12a-45dd-877a-d0f643ea5a5c", "Student", "STUDENT" },
                    { "e9da0dec-8420-407e-ad91-778a3d5f8764", "5ea8b96d-8f69-4800-8d32-54d1fb9524a1", "Admin", "ADMIN" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_ModuleInstructor_Instructor_InstructorId",
                table: "ModuleInstructor",
                column: "InstructorId",
                principalTable: "Instructor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
