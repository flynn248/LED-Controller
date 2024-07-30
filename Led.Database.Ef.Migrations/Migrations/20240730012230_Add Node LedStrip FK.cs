using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Led.Database.Ef.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class AddNodeLedStripFK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LedStripId",
                schema: "led",
                table: "LedNode",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_LedNode_LedStripId",
                schema: "led",
                table: "LedNode",
                column: "LedStripId");

            migrationBuilder.AddForeignKey(
                name: "FK_LedNode_LedStrip_LedStripId",
                schema: "led",
                table: "LedNode",
                column: "LedStripId",
                principalSchema: "led",
                principalTable: "LedStrip",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LedNode_LedStrip_LedStripId",
                schema: "led",
                table: "LedNode");

            migrationBuilder.DropIndex(
                name: "IX_LedNode_LedStripId",
                schema: "led",
                table: "LedNode");

            migrationBuilder.DropColumn(
                name: "LedStripId",
                schema: "led",
                table: "LedNode");
        }
    }
}
