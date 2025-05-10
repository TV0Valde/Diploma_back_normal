using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePointsConfig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Points_BuildingId",
                table: "Points");

            migrationBuilder.CreateIndex(
                name: "IX_Points_BuildingId",
                table: "Points",
                column: "BuildingId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Points_BuildingId",
                table: "Points");

            migrationBuilder.CreateIndex(
                name: "IX_Points_BuildingId",
                table: "Points",
                column: "BuildingId",
                unique: true);
        }
    }
}
