using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Fan_Website.Migrations
{
    public partial class AddedUserLikes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PostId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Forums",
                keyColumn: "ForumId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2021, 5, 23, 20, 29, 34, 597, DateTimeKind.Utc).AddTicks(5882));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2021, 5, 23, 20, 29, 34, 597, DateTimeKind.Utc).AddTicks(4511));

            migrationBuilder.UpdateData(
                table: "Screenshots",
                keyColumn: "ScreenshotId",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2021, 5, 23, 16, 29, 34, 597, DateTimeKind.Local).AddTicks(7524));

            migrationBuilder.UpdateData(
                table: "Screenshots",
                keyColumn: "ScreenshotId",
                keyValue: 9,
                column: "CreatedOn",
                value: new DateTime(2021, 5, 23, 16, 29, 34, 599, DateTimeKind.Local).AddTicks(6488));

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_PostId",
                table: "AspNetUsers",
                column: "PostId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Posts_PostId",
                table: "AspNetUsers",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "PostId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Posts_PostId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_PostId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PostId",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "Forums",
                keyColumn: "ForumId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2021, 5, 23, 20, 22, 49, 651, DateTimeKind.Utc).AddTicks(8825));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2021, 5, 23, 20, 22, 49, 651, DateTimeKind.Utc).AddTicks(7468));

            migrationBuilder.UpdateData(
                table: "Screenshots",
                keyColumn: "ScreenshotId",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2021, 5, 23, 16, 22, 49, 652, DateTimeKind.Local).AddTicks(376));

            migrationBuilder.UpdateData(
                table: "Screenshots",
                keyColumn: "ScreenshotId",
                keyValue: 9,
                column: "CreatedOn",
                value: new DateTime(2021, 5, 23, 16, 22, 49, 653, DateTimeKind.Local).AddTicks(7424));
        }
    }
}
