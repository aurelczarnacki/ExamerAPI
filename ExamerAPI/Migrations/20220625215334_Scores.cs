using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExamerAPI.Migrations
{
    public partial class Scores : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ExamId",
                table: "Scores",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Scores_ExamId",
                table: "Scores",
                column: "ExamId");

            migrationBuilder.AddForeignKey(
                name: "FK_Scores_Exams_ExamId",
                table: "Scores",
                column: "ExamId",
                principalTable: "Exams",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Scores_Exams_ExamId",
                table: "Scores");

            migrationBuilder.DropIndex(
                name: "IX_Scores_ExamId",
                table: "Scores");

            migrationBuilder.DropColumn(
                name: "ExamId",
                table: "Scores");
        }
    }
}
