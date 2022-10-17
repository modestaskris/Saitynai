using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Saitynai.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Username = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Username);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.CategoryId);
                    table.ForeignKey(
                        name: "FK_Category_Users_Username",
                        column: x => x.Username,
                        principalTable: "Users",
                        principalColumn: "Username",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Playlists",
                columns: table => new
                {
                    PlaylistId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategorieCategoryId = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Playlists", x => x.PlaylistId);
                    table.ForeignKey(
                        name: "FK_Playlists_Category_CategorieCategoryId",
                        column: x => x.CategorieCategoryId,
                        principalTable: "Category",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Songs",
                columns: table => new
                {
                    SongId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlaylistId = table.Column<int>(type: "int", nullable: false),
                    Downloaded = table.Column<bool>(type: "bit", nullable: false),
                    DownloadedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Songs", x => x.SongId);
                    table.ForeignKey(
                        name: "FK_Songs_Playlists_PlaylistId",
                        column: x => x.PlaylistId,
                        principalTable: "Playlists",
                        principalColumn: "PlaylistId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Username", "PasswordHash", "PasswordSalt", "Role", "UserId" },
                values: new object[] { "admin", new byte[] { 191, 158, 220, 67, 9, 59, 142, 151, 199, 220, 59, 147, 173, 73, 51, 62, 24, 18, 12, 122, 207, 128, 69, 52, 26, 24, 221, 46, 215, 80, 173, 1, 150, 110, 174, 36, 147, 111, 88, 217, 112, 42, 234, 110, 34, 122, 12, 92, 162, 74, 1, 12, 31, 179, 147, 164, 102, 115, 232, 177, 254, 225, 90, 132 }, new byte[] { 118, 57, 132, 229, 48, 139, 235, 83, 210, 109, 231, 247, 111, 145, 155, 177, 205, 74, 227, 23, 199, 227, 205, 147, 41, 68, 127, 248, 55, 114, 140, 251, 11, 164, 219, 84, 252, 196, 78, 36, 181, 72, 154, 91, 214, 119, 187, 224, 19, 128, 44, 183, 43, 194, 46, 120, 209, 216, 169, 216, 130, 240, 98, 214, 53, 181, 116, 14, 87, 149, 232, 115, 50, 19, 157, 94, 173, 134, 92, 168, 10, 11, 171, 246, 242, 102, 235, 128, 118, 251, 101, 18, 169, 71, 204, 181, 88, 226, 64, 63, 146, 9, 94, 165, 128, 222, 75, 187, 94, 78, 7, 166, 73, 161, 89, 114, 88, 201, 57, 155, 125, 4, 106, 90, 39, 117, 53, 211 }, 0, -1 });

            migrationBuilder.CreateIndex(
                name: "IX_Category_Username",
                table: "Category",
                column: "Username");

            migrationBuilder.CreateIndex(
                name: "IX_Playlists_CategorieCategoryId",
                table: "Playlists",
                column: "CategorieCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Songs_PlaylistId",
                table: "Songs",
                column: "PlaylistId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Songs");

            migrationBuilder.DropTable(
                name: "Playlists");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
