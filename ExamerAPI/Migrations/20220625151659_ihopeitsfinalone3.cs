using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExamerAPI.Migrations
{
    public partial class ihopeitsfinalone3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QnAs_Exams_ExamId",
                table: "QnAs");

            migrationBuilder.AlterColumn<int>(
                name: "ExamId",
                table: "QnAs",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_QnAs_Exams_ExamId",
                table: "QnAs",
                column: "ExamId",
                principalTable: "Exams",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QnAs_Exams_ExamId",
                table: "QnAs");

            migrationBuilder.AlterColumn<int>(
                name: "ExamId",
                table: "QnAs",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_QnAs_Exams_ExamId",
                table: "QnAs",
                column: "ExamId",
                principalTable: "Exams",
                principalColumn: "Id");
        }
    }
}
