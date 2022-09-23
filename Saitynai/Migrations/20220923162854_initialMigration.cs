using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Saitynai.Migrations
{
    public partial class initialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorie",
                columns: table => new
                {
                    CategorieId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorie", x => x.CategorieId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Username = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Username);
                });

            migrationBuilder.CreateTable(
                name: "Playlists",
                columns: table => new
                {
                    Url = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CategorieId = table.Column<int>(type: "int", nullable: true),
                    Username = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Playlists", x => x.Url);
                    table.ForeignKey(
                        name: "FK_Playlists_Categorie_CategorieId",
                        column: x => x.CategorieId,
                        principalTable: "Categorie",
                        principalColumn: "CategorieId");
                    table.ForeignKey(
                        name: "FK_Playlists_Users_Username",
                        column: x => x.Username,
                        principalTable: "Users",
                        principalColumn: "Username");
                });

            migrationBuilder.CreateTable(
                name: "Songs",
                columns: table => new
                {
                    Url = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Downloaded = table.Column<bool>(type: "bit", nullable: false),
                    DownloadedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PlaylistUrl = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Songs", x => x.Url);
                    table.ForeignKey(
                        name: "FK_Songs_Playlists_PlaylistUrl",
                        column: x => x.PlaylistUrl,
                        principalTable: "Playlists",
                        principalColumn: "Url");
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Username", "Id", "PasswordHash", "PasswordSalt", "Role" },
                values: new object[] { "admin", -1, new byte[] { 202, 102, 21, 44, 163, 29, 251, 47, 83, 150, 123, 193, 137, 206, 75, 164, 174, 143, 233, 86, 222, 33, 208, 204, 178, 214, 160, 158, 116, 14, 100, 152, 137, 28, 184, 99, 198, 121, 115, 66, 255, 120, 217, 201, 168, 109, 136, 180, 126, 238, 59, 105, 26, 7, 147, 3, 162, 104, 100, 135, 89, 229, 70, 75 }, new byte[] { 209, 125, 171, 227, 187, 184, 233, 148, 175, 100, 63, 17, 189, 153, 192, 72, 1, 248, 63, 35, 85, 23, 76, 69, 254, 95, 193, 239, 172, 216, 39, 96, 3, 3, 143, 179, 125, 192, 138, 102, 16, 55, 64, 132, 241, 96, 10, 119, 101, 190, 205, 184, 29, 35, 114, 223, 255, 101, 205, 65, 229, 78, 174, 201, 58, 224, 45, 218, 67, 49, 213, 0, 201, 171, 203, 191, 15, 32, 147, 107, 167, 33, 140, 51, 18, 38, 37, 170, 11, 223, 150, 168, 219, 238, 247, 58, 144, 72, 82, 108, 19, 123, 192, 198, 49, 207, 126, 93, 78, 6, 251, 108, 181, 211, 243, 28, 228, 161, 16, 228, 158, 186, 164, 95, 24, 1, 242, 111 }, 0 });

            migrationBuilder.CreateIndex(
                name: "IX_Playlists_CategorieId",
                table: "Playlists",
                column: "CategorieId");

            migrationBuilder.CreateIndex(
                name: "IX_Playlists_Username",
                table: "Playlists",
                column: "Username");

            migrationBuilder.CreateIndex(
                name: "IX_Songs_PlaylistUrl",
                table: "Songs",
                column: "PlaylistUrl");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Songs");

            migrationBuilder.DropTable(
                name: "Playlists");

            migrationBuilder.DropTable(
                name: "Categorie");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
