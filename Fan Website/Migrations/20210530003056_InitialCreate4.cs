using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Fan_Website.Migrations
{
    public partial class InitialCreate4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OtherUserImagePath",
                table: "ProfileComments");

            migrationBuilder.DropColumn(
                name: "OtherUserName",
                table: "ProfileComments");

            migrationBuilder.DropColumn(
                name: "OtherUserRating",
                table: "ProfileComments");

            migrationBuilder.AlterColumn<string>(
                name: "OtherUserId",
                table: "ProfileComments",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Forums",
                keyColumn: "ForumId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2021, 5, 30, 0, 30, 55, 868, DateTimeKind.Utc).AddTicks(2186));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2021, 5, 30, 0, 30, 55, 868, DateTimeKind.Utc).AddTicks(884));

            migrationBuilder.UpdateData(
                table: "Screenshots",
                keyColumn: "ScreenshotId",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2021, 5, 29, 20, 30, 55, 868, DateTimeKind.Local).AddTicks(3656));

            migrationBuilder.UpdateData(
                table: "Screenshots",
                keyColumn: "ScreenshotId",
                keyValue: 9,
                column: "CreatedOn",
                value: new DateTime(2021, 5, 29, 20, 30, 55, 870, DateTimeKind.Local).AddTicks(1776));

            migrationBuilder.CreateIndex(
                name: "IX_ProfileComments_OtherUserId",
                table: "ProfileComments",
                column: "OtherUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProfileComments_AspNetUsers_OtherUserId",
                table: "ProfileComments",
                column: "OtherUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProfileComments_AspNetUsers_OtherUserId",
                table: "ProfileComments");

            migrationBuilder.DropIndex(
                name: "IX_ProfileComments_OtherUserId",
                table: "ProfileComments");

            migrationBuilder.AlterColumn<string>(
                name: "OtherUserId",
                table: "ProfileComments",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OtherUserImagePath",
                table: "ProfileComments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OtherUserName",
                table: "ProfileComments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OtherUserRating",
                table: "ProfileComments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Forums",
                keyColumn: "ForumId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2021, 5, 29, 23, 39, 59, 213, DateTimeKind.Utc).AddTicks(1000));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2021, 5, 29, 23, 39, 59, 212, DateTimeKind.Utc).AddTicks(9554));

            migrationBuilder.UpdateData(
                table: "Screenshots",
                keyColumn: "ScreenshotId",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2021, 5, 29, 19, 39, 59, 213, DateTimeKind.Local).AddTicks(2544));

            migrationBuilder.UpdateData(
                table: "Screenshots",
                keyColumn: "ScreenshotId",
                keyValue: 9,
                column: "CreatedOn",
                value: new DateTime(2021, 5, 29, 19, 39, 59, 215, DateTimeKind.Local).AddTicks(632));
        }
    }
}
