﻿using System;
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
                    Fac_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DirectionlikeTitle = table.Column<string>(name: "Direction(like Title)", type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FacultiesTable", x => x.Fac_Id);
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
                    S_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Studentname = table.Column<string>(name: "Student name", type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PersonalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StudentsFaculty = table.Column<string>(name: "Student's Faculty", type: "nvarchar(max)", nullable: false),
                    Fac_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentsTable", x => x.S_Id);
                    table.ForeignKey(
                        name: "FK_StudentsTable_FacultiesTable_Fac_Id",
                        column: x => x.Fac_Id,
                        principalTable: "FacultiesTable",
                        principalColumn: "Fac_Id",
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
                        principalColumn: "Fac_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Faculties and Subjects_SubjectsTable_SubjectID",
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
                name: "IX_StudentsTable_Fac_Id",
                table: "StudentsTable",
                column: "Fac_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Faculties and Subjects");

            migrationBuilder.DropTable(
                name: "StudentsTable");

            migrationBuilder.DropTable(
                name: "SubjectsTable");

            migrationBuilder.DropTable(
                name: "FacultiesTable");
        }
    }
}
