using Microsoft.EntityFrameworkCore.Migrations;

namespace PL_452490_P2.Migrations
{
    public partial class PersonChangeLfTypeCase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LifeFormTypes_AbstractLifeFormTypes_AbstractLifeFormTypeId",
                table: "LifeFormTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_People_LifeFormTypes_LFTypeId",
                table: "People");

            migrationBuilder.RenameColumn(
                name: "LFTypeId",
                table: "People",
                newName: "LfTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_People_LFTypeId",
                table: "People",
                newName: "IX_People_LfTypeId");

            migrationBuilder.AlterColumn<int>(
                name: "AbstractLifeFormTypeId",
                table: "LifeFormTypes",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_LifeFormTypes_AbstractLifeFormTypes_AbstractLifeFormTypeId",
                table: "LifeFormTypes",
                column: "AbstractLifeFormTypeId",
                principalTable: "AbstractLifeFormTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_People_LifeFormTypes_LfTypeId",
                table: "People",
                column: "LfTypeId",
                principalTable: "LifeFormTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LifeFormTypes_AbstractLifeFormTypes_AbstractLifeFormTypeId",
                table: "LifeFormTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_People_LifeFormTypes_LfTypeId",
                table: "People");

            migrationBuilder.RenameColumn(
                name: "LfTypeId",
                table: "People",
                newName: "LFTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_People_LfTypeId",
                table: "People",
                newName: "IX_People_LFTypeId");

            migrationBuilder.AlterColumn<int>(
                name: "AbstractLifeFormTypeId",
                table: "LifeFormTypes",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_LifeFormTypes_AbstractLifeFormTypes_AbstractLifeFormTypeId",
                table: "LifeFormTypes",
                column: "AbstractLifeFormTypeId",
                principalTable: "AbstractLifeFormTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_People_LifeFormTypes_LFTypeId",
                table: "People",
                column: "LFTypeId",
                principalTable: "LifeFormTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
