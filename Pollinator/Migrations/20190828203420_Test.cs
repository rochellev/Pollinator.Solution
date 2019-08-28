using Microsoft.EntityFrameworkCore.Migrations;

namespace Pollinator.Migrations
{
    public partial class Test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Responses_AspNetUsers_UserId1",
                table: "Responses");

            migrationBuilder.DropIndex(
                name: "IX_Responses_UserId1",
                table: "Responses");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Responses");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Responses",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_Responses_UserId",
                table: "Responses",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Responses_AspNetUsers_UserId",
                table: "Responses",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Responses_AspNetUsers_UserId",
                table: "Responses");

            migrationBuilder.DropIndex(
                name: "IX_Responses_UserId",
                table: "Responses");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Responses",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "Responses",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Responses_UserId1",
                table: "Responses",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Responses_AspNetUsers_UserId1",
                table: "Responses",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
