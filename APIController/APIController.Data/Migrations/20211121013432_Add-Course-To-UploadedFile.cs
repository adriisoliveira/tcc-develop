using Microsoft.EntityFrameworkCore.Migrations;

namespace APIController.Data.Migrations
{
    public partial class AddCourseToUploadedFile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Course",
                table: "UploadedFiles",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Course",
                table: "UploadedFiles");
        }
    }
}
