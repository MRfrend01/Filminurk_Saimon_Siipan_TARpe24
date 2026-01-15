using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Filminurk.Data.Migrations
{
    /// <inheritdoc />
    public partial class potat : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "FavouriteListID",
                table: "Movies",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "FavouriteListID",
                table: "Actors",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ApplicationUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FavouriteListIDs = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CommentIDs = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AvatarImageID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DisplayName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProfileType = table.Column<bool>(type: "bit", nullable: false),
                    Reputation = table.Column<int>(type: "int", nullable: false),
                    Signature = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FavouriteLists",
                columns: table => new
                {
                    FavouriteListID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ListBelongsToUser = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsMovieOrActor = table.Column<bool>(type: "bit", nullable: false),
                    ListName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ListDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsPrivate = table.Column<bool>(type: "bit", nullable: false),
                    ListCreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ListModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ListDeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsReported = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavouriteLists", x => x.FavouriteListID);
                });

            migrationBuilder.CreateTable(
                name: "FilesToDatabase",
                columns: table => new
                {
                    ImageID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ImageTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageData = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ListID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilesToDatabase", x => x.ImageID);
                });

            migrationBuilder.CreateTable(
                name: "identityRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_identityRoles", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Movies_FavouriteListID",
                table: "Movies",
                column: "FavouriteListID");

            migrationBuilder.CreateIndex(
                name: "IX_Actors_FavouriteListID",
                table: "Actors",
                column: "FavouriteListID");

            migrationBuilder.AddForeignKey(
                name: "FK_Actors_FavouriteLists_FavouriteListID",
                table: "Actors",
                column: "FavouriteListID",
                principalTable: "FavouriteLists",
                principalColumn: "FavouriteListID");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_FavouriteLists_FavouriteListID",
                table: "Movies",
                column: "FavouriteListID",
                principalTable: "FavouriteLists",
                principalColumn: "FavouriteListID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Actors_FavouriteLists_FavouriteListID",
                table: "Actors");

            migrationBuilder.DropForeignKey(
                name: "FK_Movies_FavouriteLists_FavouriteListID",
                table: "Movies");

            migrationBuilder.DropTable(
                name: "ApplicationUsers");

            migrationBuilder.DropTable(
                name: "FavouriteLists");

            migrationBuilder.DropTable(
                name: "FilesToDatabase");

            migrationBuilder.DropTable(
                name: "identityRoles");

            migrationBuilder.DropIndex(
                name: "IX_Movies_FavouriteListID",
                table: "Movies");

            migrationBuilder.DropIndex(
                name: "IX_Actors_FavouriteListID",
                table: "Actors");

            migrationBuilder.DropColumn(
                name: "FavouriteListID",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "FavouriteListID",
                table: "Actors");
        }
    }
}
