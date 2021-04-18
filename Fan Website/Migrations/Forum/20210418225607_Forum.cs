using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Fan_Website.Migrations.Forum
{
    public partial class Forum : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Forums",
                columns: table => new
                {
                    ForumId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PostTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Forums", x => x.ForumId);
                });

            migrationBuilder.InsertData(
                table: "Forums",
                columns: new[] { "ForumId", "CreatedOn", "Description", "PostTitle", "UserName" },
                values: new object[] { 1, new DateTime(2021, 4, 18, 18, 56, 7, 591, DateTimeKind.Local).AddTicks(4760), "A place to talk about Final Fantasy IX", "Final Fantasy IX", "mattdrain98" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Forums");
        }
    }
}
