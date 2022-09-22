using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExamerAPI.Migrations
{
    public partial class mig2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QnA_Exam_ExamId",
                table: "QnA");

            migrationBuilder.DropForeignKey(
                name: "FK_Score_QnA_QnAId",
                table: "Score");

            migrationBuilder.DropForeignKey(
                name: "FK_Score_User_UserId",
                table: "Score");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Score",
                table: "Score");

            migrationBuilder.DropPrimaryKey(
                name: "PK_QnA",
                table: "QnA");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Exam",
                table: "Exam");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "Score",
                newName: "Scores");

            migrationBuilder.RenameTable(
                name: "QnA",
                newName: "QnAs");

            migrationBuilder.RenameTable(
                name: "Exam",
                newName: "Exams");

            migrationBuilder.RenameIndex(
                name: "IX_Score_UserId",
                table: "Scores",
                newName: "IX_Scores_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Score_QnAId",
                table: "Scores",
                newName: "IX_Scores_QnAId");

            migrationBuilder.RenameIndex(
                name: "IX_QnA_ExamId",
                table: "QnAs",
                newName: "IX_QnAs_ExamId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Scores",
                table: "Scores",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_QnAs",
                table: "QnAs",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Exams",
                table: "Exams",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_QnAs_Exams_ExamId",
                table: "QnAs",
                column: "ExamId",
                principalTable: "Exams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Scores_QnAs_QnAId",
                table: "Scores",
                column: "QnAId",
                principalTable: "QnAs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Scores_Users_UserId",
                table: "Scores",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QnAs_Exams_ExamId",
                table: "QnAs");

            migrationBuilder.DropForeignKey(
                name: "FK_Scores_QnAs_QnAId",
                table: "Scores");

            migrationBuilder.DropForeignKey(
                name: "FK_Scores_Users_UserId",
                table: "Scores");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Scores",
                table: "Scores");

            migrationBuilder.DropPrimaryKey(
                name: "PK_QnAs",
                table: "QnAs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Exams",
                table: "Exams");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "User");

            migrationBuilder.RenameTable(
                name: "Scores",
                newName: "Score");

            migrationBuilder.RenameTable(
                name: "QnAs",
                newName: "QnA");

            migrationBuilder.RenameTable(
                name: "Exams",
                newName: "Exam");

            migrationBuilder.RenameIndex(
                name: "IX_Scores_UserId",
                table: "Score",
                newName: "IX_Score_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Scores_QnAId",
                table: "Score",
                newName: "IX_Score_QnAId");

            migrationBuilder.RenameIndex(
                name: "IX_QnAs_ExamId",
                table: "QnA",
                newName: "IX_QnA_ExamId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Score",
                table: "Score",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_QnA",
                table: "QnA",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Exam",
                table: "Exam",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_QnA_Exam_ExamId",
                table: "QnA",
                column: "ExamId",
                principalTable: "Exam",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Score_QnA_QnAId",
                table: "Score",
                column: "QnAId",
                principalTable: "QnA",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Score_User_UserId",
                table: "Score",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
