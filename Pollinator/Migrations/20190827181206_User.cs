using Microsoft.EntityFrameworkCore.Migrations;

namespace Pollinator.Migrations
{
    public partial class User : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "Responses",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Quizzes",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Responses_UserId1",
                table: "Responses",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Quizzes_UserId",
                table: "Quizzes",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Quizzes_AspNetUsers_UserId",
                table: "Quizzes",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Responses_AspNetUsers_UserId1",
                table: "Responses",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Quizzes_AspNetUsers_UserId",
                table: "Quizzes");

            migrationBuilder.DropForeignKey(
                name: "FK_Responses_AspNetUsers_UserId1",
                table: "Responses");

            migrationBuilder.DropIndex(
                name: "IX_Responses_UserId1",
                table: "Responses");

            migrationBuilder.DropIndex(
                name: "IX_Quizzes_UserId",
                table: "Quizzes");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Responses");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Quizzes");
        }
    }
}
