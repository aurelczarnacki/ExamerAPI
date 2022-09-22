using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExamerAPI.Migrations
{
    public partial class final : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Scores_QnAs_QnAId",
                table: "Scores");

            migrationBuilder.DropIndex(
                name: "IX_Scores_QnAId",
                table: "Scores");

            migrationBuilder.DropColumn(
                name: "QnAId",
                table: "Scores");

            migrationBuilder.RenameColumn(
                name: "Answer",
                table: "Scores",
                newName: "Points");

            migrationBuilder.AddColumn<int>(
                name: "Max",
                table: "Scores",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UserLastName",
                table: "Scores",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Scores",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Max",
                table: "Scores");

            migrationBuilder.DropColumn(
                name: "UserLastName",
                table: "Scores");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Scores");

            migrationBuilder.RenameColumn(
                name: "Points",
                table: "Scores",
                newName: "Answer");

            migrationBuilder.AddColumn<int>(
                name: "QnAId",
                table: "Scores",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Scores_QnAId",
                table: "Scores",
                column: "QnAId");

            migrationBuilder.AddForeignKey(
                name: "FK_Scores_QnAs_QnAId",
                table: "Scores",
                column: "QnAId",
                principalTable: "QnAs",
                principalColumn: "Id");
        }
    }
}
