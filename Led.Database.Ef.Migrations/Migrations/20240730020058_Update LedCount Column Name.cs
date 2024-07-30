using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Led.Database.Ef.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class UpdateLedCountColumnName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LedCount",
                schema: "led",
                table: "LedStrip",
                newName: "LedNodeCount");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LedNodeCount",
                schema: "led",
                table: "LedStrip",
                newName: "LedCount");
        }
    }
}
