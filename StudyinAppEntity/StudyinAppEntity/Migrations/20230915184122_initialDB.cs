using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudyinAppEntity.Migrations
{
    /// <inheritdoc />
    public partial class initialDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FacultiesTable",
                columns: table => new
                {
                    F_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DirectionlikeTitle = table.Column<string>(name: "Direction(like Title)", type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FacultiesTable", x => x.F_id);
                });

            migrationBuilder.CreateTable(
                name: "SubjectsTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubjectsTable", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StudentsTable",
                columns: table => new
                {
                    Studentname = table.Column<string>(name: "Student name", type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StudentsFaculty = table.Column<string>(name: "Student's Faculty", type: "nvarchar(max)", nullable: false),
                    FacultyID = table.Column<int>(name: "Faculty ID", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentsTable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentsTable_FacultiesTable_Faculty ID",
                        column: x => x.FacultyID,
                        principalTable: "FacultiesTable",
                        principalColumn: "F_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Faculties and Subjects",
                columns: table => new
                {
                    FacultyID = table.Column<int>(type: "int", nullable: false),
                    SubjectID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faculties and Subjects", x => new { x.FacultyID, x.SubjectID });
                    table.ForeignKey(
                        name: "FK_Faculties and Subjects_FacultiesTable_FacultyID",
                        column: x => x.FacultyID,
                        principalTable: "FacultiesTable",
                        principalColumn: "F_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Faculties and Subjects_SubjectsTable_SubjectID",
                        column: x => x.SubjectID,
                        principalTable: "SubjectsTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Students and Subjects",
                columns: table => new
                {
                    StudentID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SubjectID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students and Subjects", x => new { x.StudentID, x.SubjectID });
                    table.ForeignKey(
                        name: "FK_Students and Subjects_StudentsTable_StudentID",
                        column: x => x.StudentID,
                        principalTable: "StudentsTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Students and Subjects_SubjectsTable_SubjectID",
                        column: x => x.SubjectID,
                        principalTable: "SubjectsTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Faculties and Subjects_SubjectID",
                table: "Faculties and Subjects",
                column: "SubjectID");

            migrationBuilder.CreateIndex(
                name: "IX_Students and Subjects_SubjectID",
                table: "Students and Subjects",
                column: "SubjectID");

            migrationBuilder.CreateIndex(
                name: "IX_StudentsTable_Faculty ID",
                table: "StudentsTable",
                column: "Faculty ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Faculties and Subjects");

            migrationBuilder.DropTable(
                name: "Students and Subjects");

            migrationBuilder.DropTable(
                name: "StudentsTable");

            migrationBuilder.DropTable(
                name: "SubjectsTable");

            migrationBuilder.DropTable(
                name: "FacultiesTable");
        }
    }
}
