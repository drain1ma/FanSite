using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Fan_Website.Migrations
{
    public partial class InitialCreate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Forums",
                keyColumn: "ForumId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2021, 5, 21, 1, 53, 7, 10, DateTimeKind.Utc).AddTicks(6452));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2021, 5, 21, 1, 53, 7, 10, DateTimeKind.Utc).AddTicks(5126));

            migrationBuilder.UpdateData(
                table: "Screenshots",
                keyColumn: "ScreenshotId",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2021, 5, 20, 21, 53, 7, 10, DateTimeKind.Local).AddTicks(8014));

            migrationBuilder.UpdateData(
                table: "Screenshots",
                keyColumn: "ScreenshotId",
                keyValue: 9,
                column: "CreatedOn",
                value: new DateTime(2021, 5, 20, 21, 53, 7, 12, DateTimeKind.Local).AddTicks(5545));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Forums",
                keyColumn: "ForumId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2021, 5, 21, 1, 31, 56, 74, DateTimeKind.Utc).AddTicks(4880));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2021, 5, 21, 1, 31, 56, 74, DateTimeKind.Utc).AddTicks(3474));

            migrationBuilder.UpdateData(
                table: "Screenshots",
                keyColumn: "ScreenshotId",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2021, 5, 20, 21, 31, 56, 74, DateTimeKind.Local).AddTicks(6407));

            migrationBuilder.UpdateData(
                table: "Screenshots",
                keyColumn: "ScreenshotId",
                keyValue: 9,
                column: "CreatedOn",
                value: new DateTime(2021, 5, 20, 21, 31, 56, 76, DateTimeKind.Local).AddTicks(4439));
        }
    }
}
