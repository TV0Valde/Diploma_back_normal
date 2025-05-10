using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Updatedbstructure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CheckupDate",
                table: "Points");

            migrationBuilder.DropColumn(
                name: "Info",
                table: "Points");

            migrationBuilder.DropColumn(
                name: "MaterialName",
                table: "Points");

            migrationBuilder.DropColumn(
                name: "PhotoData",
                table: "Points");

            migrationBuilder.CreateTable(
                name: "Records",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PointId = table.Column<int>(type: "integer", nullable: false),
                    PhotoData = table.Column<string>(type: "text", nullable: true),
                    Info = table.Column<string>(type: "text", nullable: true),
                    MaterialName = table.Column<string>(type: "text", nullable: true),
                    CheckupDate = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Records", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Records_Points_PointId",
                        column: x => x.PointId,
                        principalTable: "Points",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Records_PointId",
                table: "Records",
                column: "PointId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Records");

            migrationBuilder.AddColumn<DateOnly>(
                name: "CheckupDate",
                table: "Points",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Info",
                table: "Points",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MaterialName",
                table: "Points",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhotoData",
                table: "Points",
                type: "text",
                nullable: true);
        }
    }
}
