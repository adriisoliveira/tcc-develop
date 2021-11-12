using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebCrawler.Data.Migrations
{
    public partial class AddPageRankEntityAndReshapingStructures : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "WhenUpdated",
                table: "PageUrlPageWords",
                type: "datetime2",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PageRanks",
                columns: table => new
                {
                    PageUrlId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ponctuation = table.Column<float>(type: "real", nullable: false),
                    LastRanking = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PageRanks", x => x.PageUrlId);
                    table.ForeignKey(
                        name: "FK_PageRanks_PageUrls_PageUrlId",
                        column: x => x.PageUrlId,
                        principalTable: "PageUrls",
                        principalColumn: "PageUrlId",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PageRanks");

            migrationBuilder.DropColumn(
                name: "WhenUpdated",
                table: "PageUrlPageWords");
        }
    }
}
