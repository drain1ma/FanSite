using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Fan_Website.Migrations
{
    public partial class Likes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Forums",
                keyColumn: "ForumId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2021, 5, 18, 23, 25, 11, 617, DateTimeKind.Utc).AddTicks(2410));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2021, 5, 18, 23, 25, 11, 617, DateTimeKind.Utc).AddTicks(1052));

            migrationBuilder.UpdateData(
                table: "Screenshots",
                keyColumn: "ScreenshotId",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2021, 5, 18, 19, 25, 11, 617, DateTimeKind.Local).AddTicks(3929));

            migrationBuilder.UpdateData(
                table: "Screenshots",
                keyColumn: "ScreenshotId",
                keyValue: 9,
                column: "CreatedOn",
                value: new DateTime(2021, 5, 18, 19, 25, 11, 619, DateTimeKind.Local).AddTicks(1777));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Forums",
                keyColumn: "ForumId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2021, 5, 18, 23, 16, 41, 354, DateTimeKind.Utc).AddTicks(6071));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2021, 5, 18, 23, 16, 41, 354, DateTimeKind.Utc).AddTicks(4723));

            migrationBuilder.UpdateData(
                table: "Screenshots",
                keyColumn: "ScreenshotId",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2021, 5, 18, 19, 16, 41, 354, DateTimeKind.Local).AddTicks(7643));

            migrationBuilder.UpdateData(
                table: "Screenshots",
                keyColumn: "ScreenshotId",
                keyValue: 9,
                column: "CreatedOn",
                value: new DateTime(2021, 5, 18, 19, 16, 41, 356, DateTimeKind.Local).AddTicks(5019));
        }
    }
}
