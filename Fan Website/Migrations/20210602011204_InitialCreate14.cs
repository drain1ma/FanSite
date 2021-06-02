using Microsoft.EntityFrameworkCore.Migrations;

namespace Fan_Website.Migrations
{
    public partial class InitialCreate14 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Follows_AspNetUsers_ApplicationUserId",
                table: "Follows");

            migrationBuilder.DropColumn(
                name: "Follower",
                table: "Follows");

            migrationBuilder.DropColumn(
                name: "Following",
                table: "Follows");

            migrationBuilder.RenameColumn(
                name: "ApplicationUserId",
                table: "Follows",
                newName: "FollowingId");

            migrationBuilder.RenameIndex(
                name: "IX_Follows_ApplicationUserId",
                table: "Follows",
                newName: "IX_Follows_FollowingId");

            migrationBuilder.AddColumn<string>(
                name: "FollowerId",
                table: "Follows",
                type: "nvarchar(450)",
                nullable: true);

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
                newName: "ApplicationUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Follows_FollowingId",
                table: "Follows",
                newName: "IX_Follows_ApplicationUserId");

            migrationBuilder.AddColumn<string>(
                name: "Follower",
                table: "Follows",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Following",
                table: "Follows",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Follows_AspNetUsers_ApplicationUserId",
                table: "Follows",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
