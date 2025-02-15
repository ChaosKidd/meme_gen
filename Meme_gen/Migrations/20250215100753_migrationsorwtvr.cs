using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Meme_gen.Migrations
{
    /// <inheritdoc />
    public partial class migrationsorwtvr : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Memes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Memes",
                keyColumn: "Id",
                keyValue: 2);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Memes",
                columns: new[] { "Id", "DateAdded", "ImagePath", "Title" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 2, 14, 10, 30, 0, 0, DateTimeKind.Unspecified), "/images/meme_1.jpeg", "Meme 1" },
                    { 2, new DateTime(2024, 2, 14, 10, 30, 0, 0, DateTimeKind.Unspecified), "/images/meme_2.jpeg", "Meme 2" }
                });
        }
    }
}
