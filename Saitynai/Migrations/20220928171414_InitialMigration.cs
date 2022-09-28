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
                    DownloadedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
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
                values: new object[] { "admin", new byte[] { 67, 140, 127, 191, 243, 207, 215, 3, 161, 148, 117, 205, 220, 30, 252, 174, 151, 68, 163, 44, 1, 28, 49, 239, 204, 7, 96, 114, 100, 183, 111, 54, 82, 248, 208, 255, 198, 221, 71, 150, 101, 168, 67, 233, 34, 141, 73, 169, 253, 90, 56, 155, 122, 16, 33, 97, 247, 44, 81, 16, 122, 66, 58, 174 }, new byte[] { 36, 92, 66, 19, 164, 17, 31, 157, 86, 102, 34, 36, 103, 253, 174, 200, 135, 60, 61, 128, 29, 152, 109, 241, 124, 25, 129, 92, 147, 151, 80, 183, 205, 16, 183, 21, 195, 168, 93, 241, 174, 111, 121, 170, 235, 38, 210, 46, 42, 212, 144, 170, 192, 187, 176, 167, 80, 107, 26, 65, 15, 69, 85, 70, 197, 135, 103, 76, 91, 14, 155, 245, 220, 102, 111, 94, 99, 159, 75, 202, 136, 69, 172, 145, 178, 196, 197, 193, 126, 148, 61, 250, 196, 168, 104, 156, 166, 141, 61, 37, 229, 97, 165, 159, 226, 78, 53, 19, 185, 189, 242, 117, 106, 167, 160, 151, 49, 61, 200, 17, 245, 130, 121, 191, 36, 78, 5, 117 }, 0, -1 });

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
