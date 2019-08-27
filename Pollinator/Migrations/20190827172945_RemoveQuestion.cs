using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pollinator.Migrations
{
    public partial class RemoveQuestion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QuizQuestion");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Responses",
                newName: "AnswerChoice");

            migrationBuilder.AddColumn<string>(
                name: "AnswerA",
                table: "Quizzes",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AnswerB",
                table: "Quizzes",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "QuestionText",
                table: "Quizzes",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AnswerA",
                table: "Quizzes");

            migrationBuilder.DropColumn(
                name: "AnswerB",
                table: "Quizzes");

            migrationBuilder.DropColumn(
                name: "QuestionText",
                table: "Quizzes");

            migrationBuilder.RenameColumn(
                name: "AnswerChoice",
                table: "Responses",
                newName: "Description");

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    QuestionId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.QuestionId);
                });

            migrationBuilder.CreateTable(
                name: "QuizQuestion",
                columns: table => new
                {
                    QuizQuestionId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    QuestionId = table.Column<int>(nullable: false),
                    QuizId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuizQuestion", x => x.QuizQuestionId);
                    table.ForeignKey(
                        name: "FK_QuizQuestion_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "QuestionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuizQuestion_Quizzes_QuizId",
                        column: x => x.QuizId,
                        principalTable: "Quizzes",
                        principalColumn: "QuizId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_QuizQuestion_QuestionId",
                table: "QuizQuestion",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_QuizQuestion_QuizId",
                table: "QuizQuestion",
                column: "QuizId");
        }
    }
}
