using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Saitynai.Migrations
{
    public partial class aa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Username",
                keyValue: "admin",
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 201, 248, 228, 98, 80, 99, 6, 26, 73, 203, 102, 108, 167, 148, 183, 62, 98, 191, 228, 216, 71, 207, 119, 208, 232, 98, 23, 165, 24, 109, 79, 28, 66, 155, 167, 60, 133, 120, 173, 122, 54, 108, 137, 237, 74, 14, 56, 1, 17, 30, 181, 68, 13, 174, 15, 159, 187, 107, 241, 81, 81, 46, 38, 184 }, new byte[] { 157, 104, 66, 222, 155, 136, 40, 109, 161, 52, 244, 36, 17, 202, 160, 24, 16, 99, 180, 208, 241, 110, 81, 233, 76, 56, 158, 176, 190, 211, 81, 241, 172, 244, 77, 125, 114, 14, 32, 135, 192, 196, 144, 44, 119, 24, 121, 107, 222, 115, 57, 235, 255, 152, 65, 21, 235, 35, 162, 72, 208, 88, 82, 123, 222, 143, 179, 216, 178, 144, 161, 6, 26, 32, 16, 138, 129, 151, 124, 126, 34, 15, 115, 11, 106, 116, 134, 163, 4, 53, 7, 211, 148, 118, 5, 38, 8, 219, 140, 174, 13, 153, 131, 101, 138, 100, 41, 75, 4, 111, 186, 73, 19, 219, 174, 150, 58, 115, 48, 50, 197, 240, 251, 195, 64, 203, 48, 102 } });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Username",
                keyValue: "admin",
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 191, 158, 220, 67, 9, 59, 142, 151, 199, 220, 59, 147, 173, 73, 51, 62, 24, 18, 12, 122, 207, 128, 69, 52, 26, 24, 221, 46, 215, 80, 173, 1, 150, 110, 174, 36, 147, 111, 88, 217, 112, 42, 234, 110, 34, 122, 12, 92, 162, 74, 1, 12, 31, 179, 147, 164, 102, 115, 232, 177, 254, 225, 90, 132 }, new byte[] { 118, 57, 132, 229, 48, 139, 235, 83, 210, 109, 231, 247, 111, 145, 155, 177, 205, 74, 227, 23, 199, 227, 205, 147, 41, 68, 127, 248, 55, 114, 140, 251, 11, 164, 219, 84, 252, 196, 78, 36, 181, 72, 154, 91, 214, 119, 187, 224, 19, 128, 44, 183, 43, 194, 46, 120, 209, 216, 169, 216, 130, 240, 98, 214, 53, 181, 116, 14, 87, 149, 232, 115, 50, 19, 157, 94, 173, 134, 92, 168, 10, 11, 171, 246, 242, 102, 235, 128, 118, 251, 101, 18, 169, 71, 204, 181, 88, 226, 64, 63, 146, 9, 94, 165, 128, 222, 75, 187, 94, 78, 7, 166, 73, 161, 89, 114, 88, 201, 57, 155, 125, 4, 106, 90, 39, 117, 53, 211 } });
        }
    }
}
