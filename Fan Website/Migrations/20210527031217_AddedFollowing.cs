using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Fan_Website.Migrations
{
    public partial class AddedFollowing : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Follows_AspNetUsers_UserId",
                table: "Follows");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Follows",
                newName: "FollowingId");

            migrationBuilder.RenameIndex(
                name: "IX_Follows_UserId",
                table: "Follows",
                newName: "IX_Follows_FollowingId");

            migrationBuilder.AddColumn<string>(
                name: "FollowerId",
                table: "Follows",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Forums",
                keyColumn: "ForumId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2021, 5, 27, 3, 12, 17, 272, DateTimeKind.Utc).AddTicks(6732));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2021, 5, 27, 3, 12, 17, 272, DateTimeKind.Utc).AddTicks(5341));

            migrationBuilder.UpdateData(
                table: "Screenshots",
                keyColumn: "ScreenshotId",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2021, 5, 26, 23, 12, 17, 272, DateTimeKind.Local).AddTicks(8487));

            migrationBuilder.UpdateData(
                table: "Screenshots",
                keyColumn: "ScreenshotId",
                keyValue: 9,
                column: "CreatedOn",
                value: new DateTime(2021, 5, 26, 23, 12, 17, 274, DateTimeKind.Local).AddTicks(7548));

            migrationBuilder.CreateIndex(
                name: "IX_Follows_FollowerId",
                table: "Follows",
                column: "FollowerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Follows_AspNetUsers_FollowerId",
                table: "Follows",
                column: "FollowerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Follows_AspNetUsers_FollowingId",
                table: "Follows",
                column: "FollowingId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Follows_AspNetUsers_FollowerId",
                table: "Follows");

            migrationBuilder.DropForeignKey(
                name: "FK_Follows_AspNetUsers_FollowingId",
                table: "Follows");

            migrationBuilder.DropIndex(
                name: "IX_Follows_FollowerId",
                table: "Follows");

            migrationBuilder.DropColumn(
                name: "FollowerId",
                table: "Follows");

            migrationBuilder.RenameColumn(
                name: "FollowingId",
                table: "Follows",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Follows_FollowingId",
                table: "Follows",
                newName: "IX_Follows_UserId");

            migrationBuilder.UpdateData(
                table: "Forums",
                keyColumn: "ForumId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2021, 5, 27, 2, 31, 55, 79, DateTimeKind.Utc).AddTicks(2247));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2021, 5, 27, 2, 31, 55, 79, DateTimeKind.Utc).AddTicks(870));

            migrationBuilder.UpdateData(
                table: "Screenshots",
                keyColumn: "ScreenshotId",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2021, 5, 26, 22, 31, 55, 79, DateTimeKind.Local).AddTicks(3769));

            migrationBuilder.UpdateData(
                table: "Screenshots",
                keyColumn: "ScreenshotId",
                keyValue: 9,
                column: "CreatedOn",
                value: new DateTime(2021, 5, 26, 22, 31, 55, 81, DateTimeKind.Local).AddTicks(1738));

            migrationBuilder.AddForeignKey(
                name: "FK_Follows_AspNetUsers_UserId",
                table: "Follows",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
