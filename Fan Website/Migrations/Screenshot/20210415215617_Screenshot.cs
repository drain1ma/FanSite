using Microsoft.EntityFrameworkCore.Migrations;

namespace Fan_Website.Migrations.Screenshot
{
    public partial class Screenshot : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Screenshots",
                columns: table => new
                {
                    ScreenshotId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ScreenshotTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ScreenshotDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Screenshots", x => x.ScreenshotId);
                });

            migrationBuilder.InsertData(
                table: "Screenshots",
                columns: new[] { "ScreenshotId", "ImagePath", "ScreenshotDescription", "ScreenshotTitle" },
                values: new object[] { 4, "Final_Fantasy_XV_Chocobo-1.png", "I finally managed to find a chocobo", "Final Fantasy XV Chocobo" });

            migrationBuilder.InsertData(
                table: "Screenshots",
                columns: new[] { "ScreenshotId", "ImagePath", "ScreenshotDescription", "ScreenshotTitle" },
                values: new object[] { 2, "Final-Fantasy-VII-Remake-Sephiroth.png", "This is my favorite game of all title", "Sephiroth from Final Fantasy VII" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Screenshots");
        }
    }
}
