using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Fan_Website.Migrations.Post
{
    public partial class Post : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Forums",
                columns: table => new
                {
                    ForumId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PostTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Forums", x => x.ForumId);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    PostId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ForumId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.PostId);
                    table.ForeignKey(
                        name: "FK_Posts_Forums_ForumId",
                        column: x => x.ForumId,
                        principalTable: "Forums",
                        principalColumn: "ForumId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Forums",
                columns: new[] { "ForumId", "CreatedOn", "Description", "PostTitle", "UserName" },
                values: new object[] { "IX", new DateTime(2021, 4, 20, 0, 25, 3, 158, DateTimeKind.Local).AddTicks(4748), "A place to talk about Final Fantasy IX!", "Final Fantasy IX", "linguisticgamer98" });

            migrationBuilder.InsertData(
                table: "Forums",
                columns: new[] { "ForumId", "CreatedOn", "Description", "PostTitle", "UserName" },
                values: new object[] { "X", new DateTime(2021, 4, 20, 0, 25, 3, 160, DateTimeKind.Local).AddTicks(3067), "A place to talk about Final Fantasy X!", "Final Fantasy X", "mattdrain98" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "PostId", "Content", "CreatedOn", "ForumId", "Title", "UserName" },
                values: new object[] { 1, "Like I said in the title, this is my favorite game and nothing can change my mind about that.", new DateTime(2021, 4, 20, 4, 25, 3, 157, DateTimeKind.Utc).AddTicks(4026), "IX", "This is my favorite game!", "linguisticgamer98" });

            migrationBuilder.CreateIndex(
                name: "IX_Posts_ForumId",
                table: "Posts",
                column: "ForumId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Forums");
        }
    }
}
