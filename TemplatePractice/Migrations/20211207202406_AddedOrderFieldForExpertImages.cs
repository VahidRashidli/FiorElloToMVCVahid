using Microsoft.EntityFrameworkCore.Migrations;

namespace TemplatePractice.Migrations
{
    public partial class AddedOrderFieldForExpertImages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Order",
                table: "ExpertImages",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Order",
                table: "ExpertImages");
        }
    }
}
