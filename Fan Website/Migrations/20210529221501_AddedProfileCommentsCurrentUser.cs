using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Fan_Website.Migrations
{
    public partial class AddedProfileCommentsCurrentUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProfileComments_AspNetUsers_UserId",
                table: "ProfileComments");

            migrationBuilder.DropIndex(
                name: "IX_ProfileComments_UserId",
                table: "ProfileComments");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "ProfileComments",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CurrentUserId",
                table: "ProfileComments",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Forums",
                keyColumn: "ForumId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2021, 5, 29, 22, 15, 1, 47, DateTimeKind.Utc).AddTicks(4785));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2021, 5, 29, 22, 15, 1, 47, DateTimeKind.Utc).AddTicks(3461));

            migrationBuilder.UpdateData(
                table: "Screenshots",
                keyColumn: "ScreenshotId",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2021, 5, 29, 18, 15, 1, 47, DateTimeKind.Local).AddTicks(6310));

            migrationBuilder.UpdateData(
                table: "Screenshots",
                keyColumn: "ScreenshotId",
                keyValue: 9,
                column: "CreatedOn",
                value: new DateTime(2021, 5, 29, 18, 15, 1, 49, DateTimeKind.Local).AddTicks(4226));

            migrationBuilder.CreateIndex(
                name: "IX_ProfileComments_CurrentUserId",
                table: "ProfileComments",
                column: "CurrentUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProfileComments_AspNetUsers_CurrentUserId",
                table: "ProfileComments",
                column: "CurrentUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProfileComments_AspNetUsers_CurrentUserId",
                table: "ProfileComments");

            migrationBuilder.DropIndex(
                name: "IX_ProfileComments_CurrentUserId",
                table: "ProfileComments");

            migrationBuilder.DropColumn(
                name: "CurrentUserId",
                table: "ProfileComments");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
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
                value: new DateTime(2021, 5, 29, 21, 34, 14, 527, DateTimeKind.Utc).AddTicks(5965));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2021, 5, 29, 21, 34, 14, 527, DateTimeKind.Utc).AddTicks(4587));

            migrationBuilder.UpdateData(
                table: "Screenshots",
                keyColumn: "ScreenshotId",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2021, 5, 29, 17, 34, 14, 527, DateTimeKind.Local).AddTicks(7537));

            migrationBuilder.UpdateData(
                table: "Screenshots",
                keyColumn: "ScreenshotId",
                keyValue: 9,
                column: "CreatedOn",
                value: new DateTime(2021, 5, 29, 17, 34, 14, 529, DateTimeKind.Local).AddTicks(5060));

            migrationBuilder.CreateIndex(
                name: "IX_ProfileComments_UserId",
                table: "ProfileComments",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProfileComments_AspNetUsers_UserId",
                table: "ProfileComments",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
