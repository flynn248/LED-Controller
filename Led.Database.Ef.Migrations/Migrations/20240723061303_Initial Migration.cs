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
          name: "LedConfigStage",
          schema: "led",
          columns: table => new
          {
            Id = table.Column<int>(type: "integer", nullable: false)
                  .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
            Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
            SortOrder = table.Column<int>(type: "integer", nullable: false),
            Duration = table.Column<TimeSpan>(type: "interval", nullable: false),
            CreatedDateUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
            ModifiedDateUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_LedConfigStage", x => x.Id);
          });

      migrationBuilder.CreateTable(
          name: "LedNode",
          schema: "led",
          columns: table => new
          {
            Id = table.Column<int>(type: "integer", nullable: false)
                  .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
            RGBA = table.Column<int>(type: "integer", nullable: false),
            White = table.Column<short>(type: "smallint", nullable: true)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_LedNode", x => x.Id);
          });

      migrationBuilder.CreateTable(
          name: "LedStripTypeList",
          schema: "led",
          columns: table => new
          {
            Id = table.Column<int>(type: "integer", nullable: false)
                  .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
            SortOrder = table.Column<int>(type: "integer", nullable: false),
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
                      principalColumn: "Id");
          });

      migrationBuilder.InsertData(
          schema: "led",
          table: "LedStripTypeList",
          columns: new[] { "Id", "Description", "Name", "SortOrder" },
          values: new object[] { 1, "Individually addressable.", "WS2812B", 1 });

      migrationBuilder.CreateIndex(
          name: "IX_LedStrip_LedStripTypeId",
          schema: "led",
          table: "LedStrip",
          column: "LedStripTypeId");

      // Manually added to grant user access to database.
      migrationBuilder.Sql("grant \"pg_read_all_data\" to \"LedApiSvc\";");
      migrationBuilder.Sql("grant \"pg_write_all_data\" to \"LedApiSvc\";");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.Sql("revoke \"pg_read_all_data\" from \"LedApiSvc\";");
      migrationBuilder.Sql("revoke \"pg_write_all_data\" from \"LedApiSvc\";");

      migrationBuilder.DropTable(
          name: "LedConfigStage",
          schema: "led");

      migrationBuilder.DropTable(
          name: "LedNode",
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
