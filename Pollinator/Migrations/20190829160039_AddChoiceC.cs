using Microsoft.EntityFrameworkCore.Migrations;

namespace Pollinator.Migrations
{
    public partial class AddChoiceC : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AnswerC",
                table: "Quizzes",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AnswerC",
                table: "Quizzes");
        }
    }
}
