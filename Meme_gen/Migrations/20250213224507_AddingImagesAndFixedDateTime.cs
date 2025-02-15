using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Meme_gen.Migrations
{
    /// <inheritdoc />
    public partial class AddingImagesAndFixedDateTime : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Memes",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2024, 2, 14, 10, 30, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Memes",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateAdded",
                value: new DateTime(2024, 2, 14, 10, 30, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Memes",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2025, 2, 13, 22, 41, 2, 75, DateTimeKind.Utc).AddTicks(3933));

            migrationBuilder.UpdateData(
                table: "Memes",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateAdded",
                value: new DateTime(2025, 2, 13, 22, 41, 2, 75, DateTimeKind.Utc).AddTicks(4164));
        }
    }
}
