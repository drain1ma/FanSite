using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Fan_Website.Migrations
{
    public partial class UpdateInitialCreate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Screenshots");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Screenshots",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Screenshots",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Forums",
                keyColumn: "ForumId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2021, 5, 3, 1, 51, 34, 971, DateTimeKind.Utc).AddTicks(9502));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2021, 5, 3, 1, 51, 34, 971, DateTimeKind.Utc).AddTicks(8338));

            migrationBuilder.CreateIndex(
                name: "IX_Screenshots_UserId",
                table: "Screenshots",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Screenshots_AspNetUsers_UserId",
                table: "Screenshots",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Screenshots_AspNetUsers_UserId",
                table: "Screenshots");

            migrationBuilder.DropIndex(
                name: "IX_Screenshots_UserId",
                table: "Screenshots");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Screenshots");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Screenshots");

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Screenshots",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Forums",
                keyColumn: "ForumId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2021, 4, 30, 18, 41, 6, 486, DateTimeKind.Utc).AddTicks(7184));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2021, 4, 30, 18, 41, 6, 486, DateTimeKind.Utc).AddTicks(5701));

            migrationBuilder.UpdateData(
                table: "Screenshots",
                keyColumn: "ScreenshotId",
                keyValue: 6,
                column: "UserName",
                value: "mattdrain98");

            migrationBuilder.UpdateData(
                table: "Screenshots",
                keyColumn: "ScreenshotId",
                keyValue: 9,
                column: "UserName",
                value: "mattdrain98");
        }
    }
}
