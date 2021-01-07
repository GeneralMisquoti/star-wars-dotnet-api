using Microsoft.EntityFrameworkCore.Migrations;

namespace PL_452490_P2.Migrations
{
    public partial class MakeForceUserTypeAString : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "People",
                type: "varchar(24)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Type",
                table: "People",
                type: "integer",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(24)",
                oldNullable: true);
        }
    }
}
