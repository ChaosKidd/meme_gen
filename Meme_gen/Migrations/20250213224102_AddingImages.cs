using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Meme_gen.Migrations
{
    /// <inheritdoc />
    public partial class AddingImages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_userBookmarks_AspNetUsers_UserId",
                table: "userBookmarks");

            migrationBuilder.DropForeignKey(
                name: "FK_userBookmarks_memes_MemeTemplateId",
                table: "userBookmarks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_userBookmarks",
                table: "userBookmarks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_memes",
                table: "memes");

            migrationBuilder.RenameTable(
                name: "userBookmarks",
                newName: "UserBookmarks");

            migrationBuilder.RenameTable(
                name: "memes",
                newName: "Memes");

            migrationBuilder.RenameIndex(
                name: "IX_userBookmarks_UserId",
                table: "UserBookmarks",
                newName: "IX_UserBookmarks_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_userBookmarks_MemeTemplateId",
                table: "UserBookmarks",
                newName: "IX_UserBookmarks_MemeTemplateId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserBookmarks",
                table: "UserBookmarks",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Memes",
                table: "Memes",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Memes",
                columns: new[] { "Id", "DateAdded", "ImagePath", "Title" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 2, 13, 22, 41, 2, 75, DateTimeKind.Utc).AddTicks(3933), "/images/meme_1.jpeg", "Meme 1" },
                    { 2, new DateTime(2025, 2, 13, 22, 41, 2, 75, DateTimeKind.Utc).AddTicks(4164), "/images/meme_2.jpeg", "Meme 2" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_UserBookmarks_AspNetUsers_UserId",
                table: "UserBookmarks",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserBookmarks_Memes_MemeTemplateId",
                table: "UserBookmarks",
                column: "MemeTemplateId",
                principalTable: "Memes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserBookmarks_AspNetUsers_UserId",
                table: "UserBookmarks");

            migrationBuilder.DropForeignKey(
                name: "FK_UserBookmarks_Memes_MemeTemplateId",
                table: "UserBookmarks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserBookmarks",
                table: "UserBookmarks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Memes",
                table: "Memes");

            migrationBuilder.DeleteData(
                table: "Memes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Memes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.RenameTable(
                name: "UserBookmarks",
                newName: "userBookmarks");

            migrationBuilder.RenameTable(
                name: "Memes",
                newName: "memes");

            migrationBuilder.RenameIndex(
                name: "IX_UserBookmarks_UserId",
                table: "userBookmarks",
                newName: "IX_userBookmarks_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserBookmarks_MemeTemplateId",
                table: "userBookmarks",
                newName: "IX_userBookmarks_MemeTemplateId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_userBookmarks",
                table: "userBookmarks",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_memes",
                table: "memes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_userBookmarks_AspNetUsers_UserId",
                table: "userBookmarks",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_userBookmarks_memes_MemeTemplateId",
                table: "userBookmarks",
                column: "MemeTemplateId",
                principalTable: "memes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
