using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class _123 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PhotoData",
                table: "Records",
                newName: "PhotoUrl");

            migrationBuilder.AddColumn<Guid>(
                name: "PhotoId",
                table: "Records",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PointPhotos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ObjectName = table.Column<string>(type: "text", nullable: false),
                    OriginalFileName = table.Column<string>(type: "text", nullable: false),
                    ContentType = table.Column<string>(type: "text", nullable: false),
                    BucketName = table.Column<string>(type: "text", nullable: false),
                    Size = table.Column<long>(type: "bigint", nullable: false),
                    UploadDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    PointRecordId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PointPhotos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PointPhotos_Records_PointRecordId",
                        column: x => x.PointRecordId,
                        principalTable: "Records",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PointPhotos_PointRecordId",
                table: "PointPhotos",
                column: "PointRecordId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PointPhotos");

            migrationBuilder.DropColumn(
                name: "PhotoId",
                table: "Records");

            migrationBuilder.RenameColumn(
                name: "PhotoUrl",
                table: "Records",
                newName: "PhotoData");
        }
    }
}
