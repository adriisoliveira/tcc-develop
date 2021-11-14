using Microsoft.EntityFrameworkCore.Migrations;

namespace APIController.Data.Migrations
{
    public partial class AddTitleAndSubtitleToUploadedFileEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Subtitle",
                table: "UploadedFiles",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "UploadedFiles",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Subtitle",
                table: "UploadedFiles");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "UploadedFiles");
        }
    }
}
