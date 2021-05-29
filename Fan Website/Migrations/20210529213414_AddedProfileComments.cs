using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Fan_Website.Migrations
{
    public partial class AddedProfileComments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProfileComments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfileComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProfileComments_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProfileComments");

            migrationBuilder.UpdateData(
                table: "Forums",
                keyColumn: "ForumId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2021, 5, 27, 3, 29, 19, 35, DateTimeKind.Utc).AddTicks(7872));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2021, 5, 27, 3, 29, 19, 35, DateTimeKind.Utc).AddTicks(4596));

            migrationBuilder.UpdateData(
                table: "Screenshots",
                keyColumn: "ScreenshotId",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2021, 5, 26, 23, 29, 19, 35, DateTimeKind.Local).AddTicks(9489));

            migrationBuilder.UpdateData(
                table: "Screenshots",
                keyColumn: "ScreenshotId",
                keyValue: 9,
                column: "CreatedOn",
                value: new DateTime(2021, 5, 26, 23, 29, 19, 37, DateTimeKind.Local).AddTicks(8053));
        }
    }
}
