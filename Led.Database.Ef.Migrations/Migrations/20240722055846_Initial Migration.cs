using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Led.Database.Ef.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "led");

            migrationBuilder.CreateTable(
                name: "Led",
                schema: "led",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    HexCode = table.Column<string>(type: "character varying(9)", maxLength: 9, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Led", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LedStripTypeList",
                schema: "led",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LedStripTypeList", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LedStrip",
                schema: "led",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    LedCount = table.Column<long>(type: "bigint", nullable: false),
                    LedStripTypeId = table.Column<int>(type: "integer", nullable: false),
                    CreatedDateUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedDateUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LedStrip", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LedStrip_LedStripTypeList_LedStripTypeId",
                        column: x => x.LedStripTypeId,
                        principalSchema: "led",
                        principalTable: "LedStripTypeList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "led",
                table: "LedStripTypeList",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 1, "Individually addressable.", "WS2812B" });

            migrationBuilder.InsertData(
                schema: "led",
                table: "LedStrip",
                columns: new[] { "Id", "CreatedDateUtc", "Description", "LedCount", "LedStripTypeId", "ModifiedDateUtc", "Name" },
                values: new object[] { 1, new DateTime(1, 1, 1, 6, 0, 0, 0, DateTimeKind.Utc), "", 0L, 1, null, "" });

            migrationBuilder.CreateIndex(
                name: "IX_LedStrip_LedStripTypeId",
                schema: "led",
                table: "LedStrip",
                column: "LedStripTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Led",
                schema: "led");

            migrationBuilder.DropTable(
                name: "LedStrip",
                schema: "led");

            migrationBuilder.DropTable(
                name: "LedStripTypeList",
                schema: "led");
        }
    }
}
