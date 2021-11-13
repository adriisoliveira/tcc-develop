using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebCrawler.Data.Migrations
{
    public partial class CreateUrlCrawlerQueueTableAndPageTitleToPageUrlTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "PageUrls",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "UrlCrawlerQueue",
                columns: table => new
                {
                    UrlCrawlerQueueId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WhenQueued = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WhenCreated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UrlCrawlerQueue", x => x.UrlCrawlerQueueId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UrlCrawlerQueue");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "PageUrls");
        }
    }
}
