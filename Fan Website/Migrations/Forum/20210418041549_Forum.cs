using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Fan_Website.Migrations.Forum
{
    public partial class Forum : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    ForumId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PostTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Post = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.ForumId);
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "ForumId", "CreatedOn", "Post", "PostTitle", "UserName" },
                values: new object[] { 1, new DateTime(2021, 4, 18, 0, 15, 49, 427, DateTimeKind.Local).AddTicks(6027), "The reason I believe this to be the best game is due to the character development as well as the pacing of the story as a whole. Without the characters the game would not have been nearly as good, although the story was still fantastic as well.", "Final Fantasy IX is the best", "mattdrain98" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Posts");
        }
    }
}
