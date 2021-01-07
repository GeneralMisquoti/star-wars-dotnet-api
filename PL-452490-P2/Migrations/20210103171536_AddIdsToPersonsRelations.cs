using Microsoft.EntityFrameworkCore.Migrations;

namespace PL_452490_P2.Migrations
{
    public partial class AddIdsToPersonsRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ApprenticeId",
                table: "People",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ForceTypeId",
                table: "People",
                type: "integer",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApprenticeId",
                table: "People");

            migrationBuilder.DropColumn(
                name: "ForceTypeId",
                table: "People");
        }
    }
}
