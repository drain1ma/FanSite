using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Fan_Website.Migrations
{
    public partial class AddedLikes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Likes_PostId",
                table: "Posts");

            migrationBuilder.AlterColumn<int>(
                name: "PostId",
                table: "Posts",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "LikeId",
                table: "Posts",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Forums",
                keyColumn: "ForumId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2021, 5, 18, 7, 23, 3, 949, DateTimeKind.Utc).AddTicks(3315));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2021, 5, 18, 7, 23, 3, 949, DateTimeKind.Utc).AddTicks(1990));

            migrationBuilder.UpdateData(
                table: "Screenshots",
                keyColumn: "ScreenshotId",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2021, 5, 18, 3, 23, 3, 949, DateTimeKind.Local).AddTicks(4789));

            migrationBuilder.UpdateData(
                table: "Screenshots",
                keyColumn: "ScreenshotId",
                keyValue: 9,
                column: "CreatedOn",
                value: new DateTime(2021, 5, 18, 3, 23, 3, 951, DateTimeKind.Local).AddTicks(2518));

            migrationBuilder.CreateIndex(
                name: "IX_Posts_LikeId",
                table: "Posts",
                column: "LikeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Likes_LikeId",
                table: "Posts",
                column: "LikeId",
                principalTable: "Likes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Likes_LikeId",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_LikeId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "LikeId",
                table: "Posts");

            migrationBuilder.AlterColumn<int>(
                name: "PostId",
                table: "Posts",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.UpdateData(
                table: "Forums",
                keyColumn: "ForumId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2021, 5, 18, 7, 19, 21, 980, DateTimeKind.Utc).AddTicks(8302));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2021, 5, 18, 7, 19, 21, 980, DateTimeKind.Utc).AddTicks(6313));

            migrationBuilder.UpdateData(
                table: "Screenshots",
                keyColumn: "ScreenshotId",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2021, 5, 18, 3, 19, 21, 981, DateTimeKind.Local).AddTicks(417));

            migrationBuilder.UpdateData(
                table: "Screenshots",
                keyColumn: "ScreenshotId",
                keyValue: 9,
                column: "CreatedOn",
                value: new DateTime(2021, 5, 18, 3, 19, 21, 983, DateTimeKind.Local).AddTicks(5752));

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Likes_PostId",
                table: "Posts",
                column: "PostId",
                principalTable: "Likes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
