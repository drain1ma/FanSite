using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Fan_Website.Migrations.Post
{
    public partial class Post : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    PostId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.PostId);
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "PostId", "Content", "CreatedOn", "Title", "UserName" },
                values: new object[] { 1, "Like I said in the title, this is my favorite game and nothing can change my mind about that.", new DateTime(2021, 4, 18, 23, 28, 30, 572, DateTimeKind.Utc).AddTicks(5601), "This is my favorite game!", "linguisticgamer98" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Posts");
        }
    }
}
