using Microsoft.EntityFrameworkCore.Migrations;

namespace TemplatePractice.Migrations
{
    public partial class AddedOwlSlider : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OwlSliders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Image = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OwlSliders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OwlSliderImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    sliderId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OwlSliderImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OwlSliderImages_OwlSliders_sliderId",
                        column: x => x.sliderId,
                        principalTable: "OwlSliders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OwlSliderImages_sliderId",
                table: "OwlSliderImages",
                column: "sliderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OwlSliderImages");

            migrationBuilder.DropTable(
                name: "OwlSliders");
        }
    }
}
