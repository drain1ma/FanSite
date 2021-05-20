using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Fan_Website.Migrations
{
    public partial class ChangeLikesToTotalLikes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsLiked",
                table: "Likes");

            migrationBuilder.RenameColumn(
                name: "Likes",
                table: "Posts",
                newName: "TotalLikes");

            migrationBuilder.UpdateData(
                table: "Forums",
                keyColumn: "ForumId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2021, 5, 20, 0, 44, 24, 919, DateTimeKind.Utc).AddTicks(7622));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2021, 5, 20, 0, 44, 24, 919, DateTimeKind.Utc).AddTicks(6191));

            migrationBuilder.UpdateData(
                table: "Screenshots",
                keyColumn: "ScreenshotId",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2021, 5, 19, 20, 44, 24, 919, DateTimeKind.Local).AddTicks(9161));

            migrationBuilder.UpdateData(
                table: "Screenshots",
                keyColumn: "ScreenshotId",
                keyValue: 9,
                column: "CreatedOn",
                value: new DateTime(2021, 5, 19, 20, 44, 24, 921, DateTimeKind.Local).AddTicks(6509));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TotalLikes",
                table: "Posts",
                newName: "Likes");

            migrationBuilder.AddColumn<bool>(
                name: "IsLiked",
                table: "Likes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Forums",
                keyColumn: "ForumId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2021, 5, 19, 23, 19, 55, 613, DateTimeKind.Utc).AddTicks(7904));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2021, 5, 19, 23, 19, 55, 613, DateTimeKind.Utc).AddTicks(6514));

            migrationBuilder.UpdateData(
                table: "Screenshots",
                keyColumn: "ScreenshotId",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2021, 5, 19, 19, 19, 55, 613, DateTimeKind.Local).AddTicks(9465));

            migrationBuilder.UpdateData(
                table: "Screenshots",
                keyColumn: "ScreenshotId",
                keyValue: 9,
                column: "CreatedOn",
                value: new DateTime(2021, 5, 19, 19, 19, 55, 615, DateTimeKind.Local).AddTicks(8910));
        }
    }
}
