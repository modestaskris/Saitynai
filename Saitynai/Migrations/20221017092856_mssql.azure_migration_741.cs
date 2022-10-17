﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Saitynai.Migrations
{
    public partial class mssqlazure_migration_741 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Username",
                keyValue: "admin",
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 195, 72, 30, 49, 183, 113, 10, 245, 199, 73, 198, 235, 6, 56, 16, 95, 237, 143, 7, 38, 186, 82, 225, 149, 165, 241, 206, 140, 204, 96, 152, 210, 218, 197, 52, 68, 229, 21, 181, 232, 6, 53, 5, 225, 50, 68, 127, 170, 155, 121, 183, 137, 237, 137, 127, 207, 129, 99, 151, 205, 121, 207, 23, 153 }, new byte[] { 143, 48, 161, 67, 135, 41, 98, 172, 179, 144, 141, 2, 33, 184, 145, 105, 123, 129, 132, 76, 249, 227, 82, 164, 54, 114, 181, 148, 94, 71, 64, 184, 144, 199, 124, 110, 137, 180, 250, 175, 173, 250, 215, 217, 178, 66, 244, 184, 179, 184, 110, 6, 252, 158, 135, 15, 169, 210, 137, 202, 198, 114, 98, 50, 78, 10, 253, 24, 165, 247, 48, 229, 201, 151, 114, 241, 139, 69, 5, 11, 186, 105, 186, 47, 195, 194, 115, 195, 56, 255, 162, 57, 20, 77, 234, 186, 209, 35, 206, 216, 17, 90, 100, 110, 207, 65, 244, 0, 177, 134, 123, 131, 4, 159, 161, 66, 54, 241, 64, 97, 129, 241, 53, 233, 13, 214, 231, 199 } });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Username",
                keyValue: "admin",
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 163, 84, 196, 240, 19, 125, 179, 192, 175, 35, 251, 55, 26, 44, 158, 92, 199, 15, 161, 69, 232, 171, 20, 201, 134, 11, 43, 24, 60, 171, 139, 97, 141, 183, 210, 164, 5, 10, 7, 202, 21, 148, 73, 146, 105, 200, 189, 172, 138, 5, 46, 59, 245, 251, 221, 86, 132, 130, 49, 79, 1, 199, 90, 88 }, new byte[] { 69, 105, 176, 167, 213, 159, 80, 42, 80, 134, 61, 32, 125, 233, 221, 209, 179, 54, 208, 60, 151, 178, 73, 190, 37, 202, 22, 17, 253, 63, 93, 177, 50, 199, 12, 141, 32, 78, 212, 81, 180, 176, 98, 244, 139, 252, 222, 60, 13, 223, 99, 10, 102, 203, 51, 106, 13, 14, 115, 245, 57, 183, 129, 216, 183, 92, 248, 100, 55, 91, 193, 130, 93, 56, 115, 59, 135, 232, 150, 218, 164, 225, 121, 57, 212, 157, 9, 250, 190, 254, 147, 65, 248, 30, 59, 253, 82, 14, 173, 177, 79, 197, 129, 240, 140, 25, 37, 178, 234, 191, 5, 14, 3, 147, 162, 16, 151, 198, 54, 121, 252, 93, 61, 141, 163, 123, 192, 183 } });
        }
    }
}