using Microsoft.EntityFrameworkCore.Migrations;

namespace PL_452490_P2.Migrations
{
    public partial class FixPluralNamingOfActorsAndWeapons : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActorsPerMovies_Actor_PlayedById",
                table: "ActorsPerMovies");

            migrationBuilder.DropForeignKey(
                name: "FK_Blows_AbstractWeaponType_AbstractWeaponTypeId",
                table: "Blows");

            migrationBuilder.DropForeignKey(
                name: "FK_Blows_Weapon_WithWeaponId",
                table: "Blows");

            migrationBuilder.DropForeignKey(
                name: "FK_People_AbstractWeaponType_AbstractWeaponTypeId",
                table: "People");

            migrationBuilder.DropForeignKey(
                name: "FK_Weapon_AbstractWeaponType_WeaponTypeId",
                table: "Weapon");

            migrationBuilder.DropForeignKey(
                name: "FK_WeaponOwners_Weapon_WeaponId",
                table: "WeaponOwners");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Weapon",
                table: "Weapon");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Actor",
                table: "Actor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AbstractWeaponType",
                table: "AbstractWeaponType");

            migrationBuilder.RenameTable(
                name: "Weapon",
                newName: "Weapons");

            migrationBuilder.RenameTable(
                name: "Actor",
                newName: "Actors");

            migrationBuilder.RenameTable(
                name: "AbstractWeaponType",
                newName: "AbstractWeaponTypes");

            migrationBuilder.RenameIndex(
                name: "IX_Weapon_WeaponTypeId",
                table: "Weapons",
                newName: "IX_Weapons_WeaponTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Weapons",
                table: "Weapons",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Actors",
                table: "Actors",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AbstractWeaponTypes",
                table: "AbstractWeaponTypes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ActorsPerMovies_Actors_PlayedById",
                table: "ActorsPerMovies",
                column: "PlayedById",
                principalTable: "Actors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Blows_AbstractWeaponTypes_AbstractWeaponTypeId",
                table: "Blows",
                column: "AbstractWeaponTypeId",
                principalTable: "AbstractWeaponTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Blows_Weapons_WithWeaponId",
                table: "Blows",
                column: "WithWeaponId",
                principalTable: "Weapons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_People_AbstractWeaponTypes_AbstractWeaponTypeId",
                table: "People",
                column: "AbstractWeaponTypeId",
                principalTable: "AbstractWeaponTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WeaponOwners_Weapons_WeaponId",
                table: "WeaponOwners",
                column: "WeaponId",
                principalTable: "Weapons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Weapons_AbstractWeaponTypes_WeaponTypeId",
                table: "Weapons",
                column: "WeaponTypeId",
                principalTable: "AbstractWeaponTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActorsPerMovies_Actors_PlayedById",
                table: "ActorsPerMovies");

            migrationBuilder.DropForeignKey(
                name: "FK_Blows_AbstractWeaponTypes_AbstractWeaponTypeId",
                table: "Blows");

            migrationBuilder.DropForeignKey(
                name: "FK_Blows_Weapons_WithWeaponId",
                table: "Blows");

            migrationBuilder.DropForeignKey(
                name: "FK_People_AbstractWeaponTypes_AbstractWeaponTypeId",
                table: "People");

            migrationBuilder.DropForeignKey(
                name: "FK_WeaponOwners_Weapons_WeaponId",
                table: "WeaponOwners");

            migrationBuilder.DropForeignKey(
                name: "FK_Weapons_AbstractWeaponTypes_WeaponTypeId",
                table: "Weapons");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Weapons",
                table: "Weapons");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Actors",
                table: "Actors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AbstractWeaponTypes",
                table: "AbstractWeaponTypes");

            migrationBuilder.RenameTable(
                name: "Weapons",
                newName: "Weapon");

            migrationBuilder.RenameTable(
                name: "Actors",
                newName: "Actor");

            migrationBuilder.RenameTable(
                name: "AbstractWeaponTypes",
                newName: "AbstractWeaponType");

            migrationBuilder.RenameIndex(
                name: "IX_Weapons_WeaponTypeId",
                table: "Weapon",
                newName: "IX_Weapon_WeaponTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Weapon",
                table: "Weapon",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Actor",
                table: "Actor",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AbstractWeaponType",
                table: "AbstractWeaponType",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ActorsPerMovies_Actor_PlayedById",
                table: "ActorsPerMovies",
                column: "PlayedById",
                principalTable: "Actor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Blows_AbstractWeaponType_AbstractWeaponTypeId",
                table: "Blows",
                column: "AbstractWeaponTypeId",
                principalTable: "AbstractWeaponType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Blows_Weapon_WithWeaponId",
                table: "Blows",
                column: "WithWeaponId",
                principalTable: "Weapon",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_People_AbstractWeaponType_AbstractWeaponTypeId",
                table: "People",
                column: "AbstractWeaponTypeId",
                principalTable: "AbstractWeaponType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Weapon_AbstractWeaponType_WeaponTypeId",
                table: "Weapon",
                column: "WeaponTypeId",
                principalTable: "AbstractWeaponType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WeaponOwners_Weapon_WeaponId",
                table: "WeaponOwners",
                column: "WeaponId",
                principalTable: "Weapon",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
