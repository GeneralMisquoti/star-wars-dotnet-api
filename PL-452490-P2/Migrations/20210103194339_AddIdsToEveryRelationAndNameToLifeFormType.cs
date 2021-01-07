using Microsoft.EntityFrameworkCore.Migrations;

namespace PL_452490_P2.Migrations
{
    public partial class AddIdsToEveryRelationAndNameToLifeFormType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActorsPerMovies_Actors_PlayedById",
                table: "ActorsPerMovies");

            migrationBuilder.DropForeignKey(
                name: "FK_ActorsPerMovies_Movies_InMovieId",
                table: "ActorsPerMovies");

            migrationBuilder.DropForeignKey(
                name: "FK_ActorsPerMovies_People_PlaysId",
                table: "ActorsPerMovies");

            migrationBuilder.DropForeignKey(
                name: "FK_Blows_FightGroups_BloweesId",
                table: "Blows");

            migrationBuilder.DropForeignKey(
                name: "FK_Blows_FightGroups_BlowersId",
                table: "Blows");

            migrationBuilder.DropForeignKey(
                name: "FK_Fights_Movies_InMovieId",
                table: "Fights");

            migrationBuilder.DropForeignKey(
                name: "FK_FightStages_FightGroups_FirstGroupId",
                table: "FightStages");

            migrationBuilder.DropForeignKey(
                name: "FK_FightStages_FightGroups_SecondGroupId",
                table: "FightStages");

            migrationBuilder.DropForeignKey(
                name: "FK_WeaponOwners_People_OwnerId",
                table: "WeaponOwners");

            migrationBuilder.DropForeignKey(
                name: "FK_WeaponOwners_Weapons_WeaponId",
                table: "WeaponOwners");

            migrationBuilder.DropForeignKey(
                name: "FK_Weapons_AbstractWeaponTypes_WeaponTypeId",
                table: "Weapons");

            migrationBuilder.DropColumn(
                name: "ForceTypeId",
                table: "People");

            migrationBuilder.AlterColumn<int>(
                name: "WeaponTypeId",
                table: "Weapons",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "WeaponId",
                table: "WeaponOwners",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "OwnerId",
                table: "WeaponOwners",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ActorId",
                table: "Movies",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AbstractLifeFormTypeId",
                table: "LifeFormTypes",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "LifeFormTypes",
                type: "text",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SecondGroupId",
                table: "FightStages",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FirstGroupId",
                table: "FightStages",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ResultId",
                table: "FightStages",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "InMovieId",
                table: "Fights",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "DamageDealt",
                table: "Blows",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "BlowersId",
                table: "Blows",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BloweesId",
                table: "Blows",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "BlowOrderInFight",
                table: "Blows",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "PlaysId",
                table: "ActorsPerMovies",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PlayedById",
                table: "ActorsPerMovies",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "InMovieId",
                table: "ActorsPerMovies",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Movies_ActorId",
                table: "Movies",
                column: "ActorId");

            migrationBuilder.CreateIndex(
                name: "IX_LifeFormTypes_AbstractLifeFormTypeId",
                table: "LifeFormTypes",
                column: "AbstractLifeFormTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_ActorsPerMovies_Actors_PlayedById",
                table: "ActorsPerMovies",
                column: "PlayedById",
                principalTable: "Actors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ActorsPerMovies_Movies_InMovieId",
                table: "ActorsPerMovies",
                column: "InMovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ActorsPerMovies_People_PlaysId",
                table: "ActorsPerMovies",
                column: "PlaysId",
                principalTable: "People",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Blows_FightGroups_BloweesId",
                table: "Blows",
                column: "BloweesId",
                principalTable: "FightGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Blows_FightGroups_BlowersId",
                table: "Blows",
                column: "BlowersId",
                principalTable: "FightGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Fights_Movies_InMovieId",
                table: "Fights",
                column: "InMovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FightStages_FightGroups_FirstGroupId",
                table: "FightStages",
                column: "FirstGroupId",
                principalTable: "FightGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FightStages_FightGroups_SecondGroupId",
                table: "FightStages",
                column: "SecondGroupId",
                principalTable: "FightGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LifeFormTypes_AbstractLifeFormTypes_AbstractLifeFormTypeId",
                table: "LifeFormTypes",
                column: "AbstractLifeFormTypeId",
                principalTable: "AbstractLifeFormTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Actors_ActorId",
                table: "Movies",
                column: "ActorId",
                principalTable: "Actors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WeaponOwners_People_OwnerId",
                table: "WeaponOwners",
                column: "OwnerId",
                principalTable: "People",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WeaponOwners_Weapons_WeaponId",
                table: "WeaponOwners",
                column: "WeaponId",
                principalTable: "Weapons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Weapons_AbstractWeaponTypes_WeaponTypeId",
                table: "Weapons",
                column: "WeaponTypeId",
                principalTable: "AbstractWeaponTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActorsPerMovies_Actors_PlayedById",
                table: "ActorsPerMovies");

            migrationBuilder.DropForeignKey(
                name: "FK_ActorsPerMovies_Movies_InMovieId",
                table: "ActorsPerMovies");

            migrationBuilder.DropForeignKey(
                name: "FK_ActorsPerMovies_People_PlaysId",
                table: "ActorsPerMovies");

            migrationBuilder.DropForeignKey(
                name: "FK_Blows_FightGroups_BloweesId",
                table: "Blows");

            migrationBuilder.DropForeignKey(
                name: "FK_Blows_FightGroups_BlowersId",
                table: "Blows");

            migrationBuilder.DropForeignKey(
                name: "FK_Fights_Movies_InMovieId",
                table: "Fights");

            migrationBuilder.DropForeignKey(
                name: "FK_FightStages_FightGroups_FirstGroupId",
                table: "FightStages");

            migrationBuilder.DropForeignKey(
                name: "FK_FightStages_FightGroups_SecondGroupId",
                table: "FightStages");

            migrationBuilder.DropForeignKey(
                name: "FK_LifeFormTypes_AbstractLifeFormTypes_AbstractLifeFormTypeId",
                table: "LifeFormTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Actors_ActorId",
                table: "Movies");

            migrationBuilder.DropForeignKey(
                name: "FK_WeaponOwners_People_OwnerId",
                table: "WeaponOwners");

            migrationBuilder.DropForeignKey(
                name: "FK_WeaponOwners_Weapons_WeaponId",
                table: "WeaponOwners");

            migrationBuilder.DropForeignKey(
                name: "FK_Weapons_AbstractWeaponTypes_WeaponTypeId",
                table: "Weapons");

            migrationBuilder.DropIndex(
                name: "IX_Movies_ActorId",
                table: "Movies");

            migrationBuilder.DropIndex(
                name: "IX_LifeFormTypes_AbstractLifeFormTypeId",
                table: "LifeFormTypes");

            migrationBuilder.DropColumn(
                name: "ActorId",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "AbstractLifeFormTypeId",
                table: "LifeFormTypes");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "LifeFormTypes");

            migrationBuilder.DropColumn(
                name: "ResultId",
                table: "FightStages");

            migrationBuilder.AlterColumn<int>(
                name: "WeaponTypeId",
                table: "Weapons",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "WeaponId",
                table: "WeaponOwners",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "OwnerId",
                table: "WeaponOwners",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<int>(
                name: "ForceTypeId",
                table: "People",
                type: "integer",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SecondGroupId",
                table: "FightStages",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "FirstGroupId",
                table: "FightStages",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "InMovieId",
                table: "Fights",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<long>(
                name: "DamageDealt",
                table: "Blows",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BlowersId",
                table: "Blows",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "BloweesId",
                table: "Blows",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<long>(
                name: "BlowOrderInFight",
                table: "Blows",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PlaysId",
                table: "ActorsPerMovies",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "PlayedById",
                table: "ActorsPerMovies",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "InMovieId",
                table: "ActorsPerMovies",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_ActorsPerMovies_Actors_PlayedById",
                table: "ActorsPerMovies",
                column: "PlayedById",
                principalTable: "Actors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ActorsPerMovies_Movies_InMovieId",
                table: "ActorsPerMovies",
                column: "InMovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ActorsPerMovies_People_PlaysId",
                table: "ActorsPerMovies",
                column: "PlaysId",
                principalTable: "People",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Blows_FightGroups_BloweesId",
                table: "Blows",
                column: "BloweesId",
                principalTable: "FightGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Blows_FightGroups_BlowersId",
                table: "Blows",
                column: "BlowersId",
                principalTable: "FightGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Fights_Movies_InMovieId",
                table: "Fights",
                column: "InMovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FightStages_FightGroups_FirstGroupId",
                table: "FightStages",
                column: "FirstGroupId",
                principalTable: "FightGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FightStages_FightGroups_SecondGroupId",
                table: "FightStages",
                column: "SecondGroupId",
                principalTable: "FightGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WeaponOwners_People_OwnerId",
                table: "WeaponOwners",
                column: "OwnerId",
                principalTable: "People",
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
    }
}
