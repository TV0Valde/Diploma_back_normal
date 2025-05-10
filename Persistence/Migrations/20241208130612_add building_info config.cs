using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class addbuilding_infoconfig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Infos_BuildingId",
                table: "Infos");

            migrationBuilder.CreateIndex(
                name: "IX_Infos_BuildingId",
                table: "Infos",
                column: "BuildingId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Infos_BuildingId",
                table: "Infos");

            migrationBuilder.CreateIndex(
                name: "IX_Infos_BuildingId",
                table: "Infos",
                column: "BuildingId");
        }
    }
}
