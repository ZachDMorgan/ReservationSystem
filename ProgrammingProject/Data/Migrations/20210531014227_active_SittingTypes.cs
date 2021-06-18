using Microsoft.EntityFrameworkCore.Migrations;

namespace ProgrammingProject.Data.Migrations
{
    public partial class active_SittingTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "SittingTypes",
                nullable: false,
                defaultValue: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Active",
                table: "SittingTypes");
        }
    }
}
