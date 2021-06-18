using Microsoft.EntityFrameworkCore.Migrations;

namespace ProgrammingProject.Data.Migrations
{
    public partial class verifiedopen : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Open",
                table: "Sittings",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<bool>(
                name: "Verified",
                table: "People",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Open",
                table: "Sittings");

            migrationBuilder.DropColumn(
                name: "Verified",
                table: "People");
        }
    }
}
