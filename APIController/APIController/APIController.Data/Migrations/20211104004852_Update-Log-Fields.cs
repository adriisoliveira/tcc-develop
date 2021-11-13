using Microsoft.EntityFrameworkCore.Migrations;

namespace APIController.Data.Migrations
{
    public partial class UpdateLogFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TokenGenerationDate",
                table: "ApiTokenLogs",
                newName: "TokenGenerateDate");

            migrationBuilder.RenameColumn(
                name: "RequestedAction",
                table: "ApiAccessLogs",
                newName: "RequestAction");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TokenGenerateDate",
                table: "ApiTokenLogs",
                newName: "TokenGenerationDate");

            migrationBuilder.RenameColumn(
                name: "RequestAction",
                table: "ApiAccessLogs",
                newName: "RequestedAction");
        }
    }
}
