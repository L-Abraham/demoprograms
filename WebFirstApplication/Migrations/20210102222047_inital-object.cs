using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebFirstApplication.Migrations
{
    public partial class initalobject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CourseName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CourseCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CoruseDate = table.Column<DateTime>(type: "date", nullable: false),
                    CoruseTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StudentID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UploadedDocuments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Content = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    ContetntType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UploadedDocuments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StudentCourse",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StudentGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CourseGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentCourse", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentCourse_Courses_CourseGuid",
                        column: x => x.CourseGuid,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentCourse_Students_StudentGuid",
                        column: x => x.StudentGuid,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StudentGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Students_StudentGuid",
                        column: x => x.StudentGuid,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DailyNotes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UploadDocumentGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContetntType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StudentCoursesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyNotes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DailyNotes_StudentCourse_StudentCoursesId",
                        column: x => x.StudentCoursesId,
                        principalTable: "StudentCourse",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DailyNotes_UploadedDocuments_UploadDocumentGuid",
                        column: x => x.UploadDocumentGuid,
                        principalTable: "UploadedDocuments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CoruseDate", "CoruseTime", "CourseCode", "CourseName", "CreatedAt", "IsActive", "IsDeleted" },
                values: new object[] { new Guid("0378a0d3-6052-4baa-a869-c5aaf39b5cd6"), new DateTime(2021, 1, 2, 17, 20, 46, 896, DateTimeKind.Local).AddTicks(6685), "12:00", "EN", "English", null, true, false });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CoruseDate", "CoruseTime", "CourseCode", "CourseName", "CreatedAt", "IsActive", "IsDeleted" },
                values: new object[] { new Guid("2de66195-d303-4015-b2ca-b0b7120a3572"), new DateTime(2021, 1, 2, 17, 20, 46, 901, DateTimeKind.Local).AddTicks(2312), "9:00", "FN", "French", null, true, false });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CoruseDate", "CoruseTime", "CourseCode", "CourseName", "CreatedAt", "IsActive", "IsDeleted" },
                values: new object[] { new Guid("10a22095-ca6e-4fe9-87ad-1027cd3c68ea"), new DateTime(2021, 1, 2, 17, 20, 46, 901, DateTimeKind.Local).AddTicks(2397), "10:00", "MATH", "Mathematic", null, true, false });

            migrationBuilder.CreateIndex(
                name: "IX_DailyNotes_StudentCoursesId",
                table: "DailyNotes",
                column: "StudentCoursesId");

            migrationBuilder.CreateIndex(
                name: "IX_DailyNotes_UploadDocumentGuid",
                table: "DailyNotes",
                column: "UploadDocumentGuid");

            migrationBuilder.CreateIndex(
                name: "IX_StudentCourse_CourseGuid",
                table: "StudentCourse",
                column: "CourseGuid");

            migrationBuilder.CreateIndex(
                name: "IX_StudentCourse_StudentGuid",
                table: "StudentCourse",
                column: "StudentGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Users_StudentGuid",
                table: "Users",
                column: "StudentGuid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DailyNotes");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "StudentCourse");

            migrationBuilder.DropTable(
                name: "UploadedDocuments");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Students");
        }
    }
}
