using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Fan_Website.Migrations
{
    public partial class InitialCreate12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProfileComments_AspNetUsers_CurrentUserId",
                table: "ProfileComments");

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "UserId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Forums",
                keyColumn: "ForumId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Screenshots",
                keyColumn: "ScreenshotId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Screenshots",
                keyColumn: "ScreenshotId",
                keyValue: 9);

            migrationBuilder.AlterColumn<string>(
                name: "CurrentUserId",
                table: "ProfileComments",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ProfileComments_AspNetUsers_CurrentUserId",
                table: "ProfileComments",
                column: "CurrentUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProfileComments_AspNetUsers_CurrentUserId",
                table: "ProfileComments");

            migrationBuilder.AlterColumn<string>(
                name: "CurrentUserId",
                table: "ProfileComments",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "UserId", "ConfirmPassword", "Password" },
                values: new object[] { 1, "Larkin71!", "Larkin71!" });

            migrationBuilder.InsertData(
                table: "Forums",
                columns: new[] { "ForumId", "CreatedOn", "Description", "PostTitle", "UserId" },
                values: new object[] { 1, new DateTime(2021, 5, 30, 2, 26, 1, 289, DateTimeKind.Utc).AddTicks(3586), "A place to discuss Final Fantasy IX!", "Final Fantasy IX", null });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "PostId", "Content", "CreatedOn", "ForumId", "Title", "TotalLikes", "UserId" },
                values: new object[] { 1, "Like I said in the title, this is my favorite game and nothing can change my mind about that.", new DateTime(2021, 5, 30, 2, 26, 1, 289, DateTimeKind.Utc).AddTicks(2241), null, "This is my favorite game!", 0, null });

            migrationBuilder.InsertData(
                table: "Screenshots",
                columns: new[] { "ScreenshotId", "CreatedOn", "ImagePath", "ScreenshotDescription", "ScreenshotTitle", "UserId" },
                values: new object[,]
                {
                    { 6, new DateTime(2021, 5, 29, 22, 26, 1, 289, DateTimeKind.Local).AddTicks(5071), "Final_Fantasy_XV_Chocobo-1.png", "I finally managed to find a chocobo", "Final Fantasy XV Chocobo", null },
                    { 9, new DateTime(2021, 5, 29, 22, 26, 1, 291, DateTimeKind.Local).AddTicks(2637), "Final-Fantasy-VII-Remake-Sephiroth.png", "This is my favorite game of all time", "Sephiroth from Final Fantasy VII", null }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_ProfileComments_AspNetUsers_CurrentUserId",
                table: "ProfileComments",
                column: "CurrentUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
