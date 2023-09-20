using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudyinAppEntity.Migrations
{
    /// <inheritdoc />
    public partial class notsure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SubjectId",
                table: "FacultiesTable",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_FacultiesTable_SubjectId",
                table: "FacultiesTable",
                column: "SubjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_FacultiesTable_SubjectsTable_SubjectId",
                table: "FacultiesTable",
                column: "SubjectId",
                principalTable: "SubjectsTable",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FacultiesTable_SubjectsTable_SubjectId",
                table: "FacultiesTable");

            migrationBuilder.DropIndex(
                name: "IX_FacultiesTable_SubjectId",
                table: "FacultiesTable");

            migrationBuilder.DropColumn(
                name: "SubjectId",
                table: "FacultiesTable");
        }
    }
}
