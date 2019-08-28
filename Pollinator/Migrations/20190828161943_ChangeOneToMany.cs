using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pollinator.Migrations
{
    public partial class ChangeOneToMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QuizResponse");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Quizzes");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Quizzes");

            migrationBuilder.AddColumn<int>(
                name: "QuizId",
                table: "Responses",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Responses_QuizId",
                table: "Responses",
                column: "QuizId");

            migrationBuilder.AddForeignKey(
                name: "FK_Responses_Quizzes_QuizId",
                table: "Responses",
                column: "QuizId",
                principalTable: "Quizzes",
                principalColumn: "QuizId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Responses_Quizzes_QuizId",
                table: "Responses");

            migrationBuilder.DropIndex(
                name: "IX_Responses_QuizId",
                table: "Responses");

            migrationBuilder.DropColumn(
                name: "QuizId",
                table: "Responses");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Quizzes",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Quizzes",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "QuizResponse",
                columns: table => new
                {
                    QuizResponseId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    QuizId = table.Column<int>(nullable: false),
                    ResponseId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuizResponse", x => x.QuizResponseId);
                    table.ForeignKey(
                        name: "FK_QuizResponse_Quizzes_QuizId",
                        column: x => x.QuizId,
                        principalTable: "Quizzes",
                        principalColumn: "QuizId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuizResponse_Responses_ResponseId",
                        column: x => x.ResponseId,
                        principalTable: "Responses",
                        principalColumn: "ResponseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_QuizResponse_QuizId",
                table: "QuizResponse",
                column: "QuizId");

            migrationBuilder.CreateIndex(
                name: "IX_QuizResponse_ResponseId",
                table: "QuizResponse",
                column: "ResponseId");
        }
    }
}
