using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Fan_Website.Migrations
{
    public partial class Likes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsLiked",
                table: "Posts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Likes",
                table: "Posts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Forums",
                keyColumn: "ForumId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2021, 5, 18, 5, 3, 31, 777, DateTimeKind.Utc).AddTicks(9648));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2021, 5, 18, 5, 3, 31, 777, DateTimeKind.Utc).AddTicks(8293));

            migrationBuilder.UpdateData(
                table: "Screenshots",
                keyColumn: "ScreenshotId",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2021, 5, 18, 1, 3, 31, 778, DateTimeKind.Local).AddTicks(1181));

            migrationBuilder.UpdateData(
                table: "Screenshots",
                keyColumn: "ScreenshotId",
                keyValue: 9,
                column: "CreatedOn",
                value: new DateTime(2021, 5, 18, 1, 3, 31, 779, DateTimeKind.Local).AddTicks(9296));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsLiked",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "Likes",
                table: "Posts");

            migrationBuilder.UpdateData(
                table: "Forums",
                keyColumn: "ForumId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2021, 5, 14, 22, 24, 40, 234, DateTimeKind.Utc).AddTicks(9983));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2021, 5, 14, 22, 24, 40, 234, DateTimeKind.Utc).AddTicks(8624));

            migrationBuilder.UpdateData(
                table: "Screenshots",
                keyColumn: "ScreenshotId",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2021, 5, 14, 18, 24, 40, 235, DateTimeKind.Local).AddTicks(1483));

            migrationBuilder.UpdateData(
                table: "Screenshots",
                keyColumn: "ScreenshotId",
                keyValue: 9,
                column: "CreatedOn",
                value: new DateTime(2021, 5, 14, 18, 24, 40, 236, DateTimeKind.Local).AddTicks(8345));
        }
    }
}
