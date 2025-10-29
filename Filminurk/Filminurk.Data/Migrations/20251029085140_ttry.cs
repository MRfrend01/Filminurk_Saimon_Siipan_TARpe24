using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Filminurk.Data.Migrations
{
    /// <inheritdoc />
    public partial class ttry : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "EntryCreatedAt",
                table: "Movies",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "EntryModifiedAt",
                table: "Movies",
                type: "datetime2",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "FilesToApi",
                columns: table => new
                {
                    ImageID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExistingFilepath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MovieID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsPoster = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilesToApi", x => x.ImageID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FilesToApi");

            migrationBuilder.DropColumn(
                name: "EntryCreatedAt",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "EntryModifiedAt",
                table: "Movies");
        }
    }
}
