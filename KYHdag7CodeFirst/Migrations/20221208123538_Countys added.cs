using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KYHdag7CodeFirst.Migrations
{
    public partial class Countysadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ContactPerson",
                table: "County",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContactPerson",
                table: "County");
        }
    }
}
