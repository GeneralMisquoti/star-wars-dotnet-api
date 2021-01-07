using Microsoft.EntityFrameworkCore.Migrations;

namespace PL_452490_P2.Migrations
{
    public partial class AddMidichlorian : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Type",
                table: "People",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<long>(
                name: "MidichlorianCount",
                table: "People",
                type: "bigint",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MidichlorianCount",
                table: "People");

            migrationBuilder.AlterColumn<int>(
                name: "Type",
                table: "People",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);
        }
    }
}
