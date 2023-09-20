using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudyinAppEntity.Migrations
{
    /// <inheritdoc />
    public partial class studentSubjectsRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Students and Subjects",
                columns: table => new
                {
                    StudentID = table.Column<int>(type: "int", nullable: false),
                    SubjectID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students and Subjects", x => new { x.StudentID, x.SubjectID });
                    table.ForeignKey(
                        name: "FK_Students and Subjects_StudentsTable_StudentID",
                        column: x => x.StudentID,
                        principalTable: "StudentsTable",
                        principalColumn: "S_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Students and Subjects_SubjectsTable_SubjectID",
                        column: x => x.SubjectID,
                        principalTable: "SubjectsTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Students and Subjects_SubjectID",
                table: "Students and Subjects",
                column: "SubjectID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Students and Subjects");
        }
    }
}
