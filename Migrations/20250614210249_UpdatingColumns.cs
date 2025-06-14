using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UrlShortner.Migrations
{
    /// <inheritdoc />
    public partial class UpdatingColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ShortenedUrlId",
                table: "UrlInfos",
                type: "character varying(4)",
                maxLength: 4,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UrlInfos_ShortenedUrlId",
                table: "UrlInfos",
                column: "ShortenedUrlId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UrlInfos_ShortenedUrlId",
                table: "UrlInfos");

            migrationBuilder.AlterColumn<string>(
                name: "ShortenedUrlId",
                table: "UrlInfos",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(4)",
                oldMaxLength: 4,
                oldNullable: true);
        }
    }
}
