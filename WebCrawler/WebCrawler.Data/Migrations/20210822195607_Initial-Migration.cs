using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebCrawler.Data.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PageUrls",
                columns: table => new
                {
                    PageUrlId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(2048)", maxLength: 2048, nullable: false),
                    LastIndexing = table.Column<DateTime>(type: "datetime2", nullable: true),
                    WhenCreated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PageUrls", x => x.PageUrlId);
                });

            migrationBuilder.CreateTable(
                name: "PageWords",
                columns: table => new
                {
                    PageWordId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Word = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    WhenCreated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PageWords", x => x.PageWordId);
                });

            migrationBuilder.CreateTable(
                name: "PageUrlRelations",
                columns: table => new
                {
                    PageUrlRelationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PageUrlOriginId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PageUrlDestinationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WhenCreated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PageUrlRelations", x => x.PageUrlRelationId);
                    table.ForeignKey(
                        name: "FK_PageUrlRelations_PageUrls_PageUrlDestinationId",
                        column: x => x.PageUrlDestinationId,
                        principalTable: "PageUrls",
                        principalColumn: "PageUrlId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PageUrlRelations_PageUrls_PageUrlOriginId",
                        column: x => x.PageUrlOriginId,
                        principalTable: "PageUrls",
                        principalColumn: "PageUrlId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PageUrlPageWords",
                columns: table => new
                {
                    PageUrlPageWordId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PageUrlId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PageWordId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WhenCreated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PageUrlPageWords", x => x.PageUrlPageWordId);
                    table.ForeignKey(
                        name: "FK_PageUrlPageWords_PageUrls_PageUrlId",
                        column: x => x.PageUrlId,
                        principalTable: "PageUrls",
                        principalColumn: "PageUrlId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PageUrlPageWords_PageWords_PageWordId",
                        column: x => x.PageWordId,
                        principalTable: "PageWords",
                        principalColumn: "PageWordId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PageWordLocalizations",
                columns: table => new
                {
                    PageWordLocalizationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PageWordId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PageUrlId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Localization = table.Column<int>(type: "int", nullable: false),
                    WhenCreated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PageWordLocalizations", x => x.PageWordLocalizationId);
                    table.ForeignKey(
                        name: "FK_PageWordLocalizations_PageUrls_PageUrlId",
                        column: x => x.PageUrlId,
                        principalTable: "PageUrls",
                        principalColumn: "PageUrlId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PageWordLocalizations_PageWords_PageWordId",
                        column: x => x.PageWordId,
                        principalTable: "PageWords",
                        principalColumn: "PageWordId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PageUrlPageWords_PageUrlId",
                table: "PageUrlPageWords",
                column: "PageUrlId");

            migrationBuilder.CreateIndex(
                name: "IX_PageUrlPageWords_PageWordId",
                table: "PageUrlPageWords",
                column: "PageWordId");

            migrationBuilder.CreateIndex(
                name: "IX_PageUrlRelations_PageUrlDestinationId",
                table: "PageUrlRelations",
                column: "PageUrlDestinationId");

            migrationBuilder.CreateIndex(
                name: "IX_PageUrlRelations_PageUrlOriginId",
                table: "PageUrlRelations",
                column: "PageUrlOriginId");

            migrationBuilder.CreateIndex(
                name: "IX_PageWordLocalizations_PageUrlId",
                table: "PageWordLocalizations",
                column: "PageUrlId");

            migrationBuilder.CreateIndex(
                name: "IX_PageWordLocalizations_PageWordId",
                table: "PageWordLocalizations",
                column: "PageWordId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PageUrlPageWords");

            migrationBuilder.DropTable(
                name: "PageUrlRelations");

            migrationBuilder.DropTable(
                name: "PageWordLocalizations");

            migrationBuilder.DropTable(
                name: "PageUrls");

            migrationBuilder.DropTable(
                name: "PageWords");
        }
    }
}
