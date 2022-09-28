using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Saitynai.Migrations
{
    public partial class DownloadedDateNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DownloadedDate",
                table: "Songs",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Username",
                keyValue: "admin",
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 132, 245, 253, 46, 54, 53, 79, 100, 67, 115, 162, 208, 90, 82, 125, 185, 1, 172, 220, 247, 118, 29, 24, 96, 162, 58, 239, 141, 120, 154, 251, 50, 95, 53, 175, 125, 10, 79, 3, 106, 77, 152, 113, 81, 133, 181, 225, 98, 87, 179, 6, 91, 237, 38, 117, 48, 220, 13, 59, 222, 210, 219, 232, 162 }, new byte[] { 223, 182, 6, 213, 11, 101, 235, 122, 173, 30, 250, 157, 108, 189, 164, 158, 165, 43, 1, 114, 151, 207, 36, 95, 118, 150, 96, 212, 58, 165, 122, 60, 154, 63, 112, 230, 145, 60, 198, 17, 42, 253, 115, 183, 220, 252, 175, 36, 230, 230, 3, 173, 14, 76, 33, 205, 195, 8, 165, 21, 71, 131, 219, 155, 18, 183, 143, 61, 194, 129, 240, 106, 132, 27, 176, 221, 70, 63, 251, 185, 26, 98, 78, 171, 145, 96, 155, 32, 98, 173, 236, 137, 5, 177, 118, 58, 170, 254, 209, 205, 34, 57, 126, 200, 35, 104, 92, 213, 136, 92, 34, 75, 100, 141, 46, 223, 230, 85, 177, 190, 128, 245, 57, 234, 128, 67, 151, 105 } });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DownloadedDate",
                table: "Songs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Username",
                keyValue: "admin",
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 67, 140, 127, 191, 243, 207, 215, 3, 161, 148, 117, 205, 220, 30, 252, 174, 151, 68, 163, 44, 1, 28, 49, 239, 204, 7, 96, 114, 100, 183, 111, 54, 82, 248, 208, 255, 198, 221, 71, 150, 101, 168, 67, 233, 34, 141, 73, 169, 253, 90, 56, 155, 122, 16, 33, 97, 247, 44, 81, 16, 122, 66, 58, 174 }, new byte[] { 36, 92, 66, 19, 164, 17, 31, 157, 86, 102, 34, 36, 103, 253, 174, 200, 135, 60, 61, 128, 29, 152, 109, 241, 124, 25, 129, 92, 147, 151, 80, 183, 205, 16, 183, 21, 195, 168, 93, 241, 174, 111, 121, 170, 235, 38, 210, 46, 42, 212, 144, 170, 192, 187, 176, 167, 80, 107, 26, 65, 15, 69, 85, 70, 197, 135, 103, 76, 91, 14, 155, 245, 220, 102, 111, 94, 99, 159, 75, 202, 136, 69, 172, 145, 178, 196, 197, 193, 126, 148, 61, 250, 196, 168, 104, 156, 166, 141, 61, 37, 229, 97, 165, 159, 226, 78, 53, 19, 185, 189, 242, 117, 106, 167, 160, 151, 49, 61, 200, 17, 245, 130, 121, 191, 36, 78, 5, 117 } });
        }
    }
}
