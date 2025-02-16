using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Meme_gen.Migrations
{
    /// <inheritdoc />
    public partial class Godspeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserBookmarks_Memes_MemeTemplateId",
                table: "UserBookmarks");

            migrationBuilder.AlterColumn<int>(
                name: "MemeTemplateId",
                table: "UserBookmarks",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "CustomImageData",
                table: "UserBookmarks",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_UserBookmarks_Memes_MemeTemplateId",
                table: "UserBookmarks",
                column: "MemeTemplateId",
                principalTable: "Memes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserBookmarks_Memes_MemeTemplateId",
                table: "UserBookmarks");

            migrationBuilder.DropColumn(
                name: "CustomImageData",
                table: "UserBookmarks");

            migrationBuilder.AlterColumn<int>(
                name: "MemeTemplateId",
                table: "UserBookmarks",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_UserBookmarks_Memes_MemeTemplateId",
                table: "UserBookmarks",
                column: "MemeTemplateId",
                principalTable: "Memes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
