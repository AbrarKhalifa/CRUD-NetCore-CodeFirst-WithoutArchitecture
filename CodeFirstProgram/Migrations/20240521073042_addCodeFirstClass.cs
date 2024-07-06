using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodeFirstProgram.Migrations
{
    public partial class addCodeFirstClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "standard",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "standard",
                table: "Students");
        }
    }
}
