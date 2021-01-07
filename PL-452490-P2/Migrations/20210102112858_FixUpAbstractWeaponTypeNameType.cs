using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace PL_452490_P2.Migrations
{
    public partial class FixUpAbstractWeaponTypeNameType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blow_AbstractWeaponType_AbstractWeaponTypeId",
                table: "Blow");

            migrationBuilder.DropForeignKey(
                name: "FK_Blow_Fight_InFightId",
                table: "Blow");

            migrationBuilder.DropForeignKey(
                name: "FK_Blow_FightGroup_BloweesId",
                table: "Blow");

            migrationBuilder.DropForeignKey(
                name: "FK_Blow_FightGroup_BlowersId",
                table: "Blow");

            migrationBuilder.DropForeignKey(
                name: "FK_Blow_FightStage_FightStageId",
                table: "Blow");

            migrationBuilder.DropForeignKey(
                name: "FK_Blow_Weapon_WithWeaponId",
                table: "Blow");

            migrationBuilder.DropForeignKey(
                name: "FK_Fight_Movies_InMovieId",
                table: "Fight");

            migrationBuilder.DropForeignKey(
                name: "FK_FightGroup_Fight_InFightId",
                table: "FightGroup");

            migrationBuilder.DropForeignKey(
                name: "FK_FightGroupPerson_FightGroup_InFightGroupsId",
                table: "FightGroupPerson");

            migrationBuilder.DropForeignKey(
                name: "FK_FightStage_Fight_FightId",
                table: "FightStage");

            migrationBuilder.DropForeignKey(
                name: "FK_FightStage_FightGroup_FirstGroupId",
                table: "FightStage");

            migrationBuilder.DropForeignKey(
                name: "FK_FightStage_FightGroup_SecondGroupId",
                table: "FightStage");

            migrationBuilder.DropForeignKey(
                name: "FK_People_LifeFormType_LFTypeId",
                table: "People");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LifeFormType",
                table: "LifeFormType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FightStage",
                table: "FightStage");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FightGroup",
                table: "FightGroup");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Fight",
                table: "Fight");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Blow",
                table: "Blow");

            migrationBuilder.RenameTable(
                name: "LifeFormType",
                newName: "LifeFormTypes");

            migrationBuilder.RenameTable(
                name: "FightStage",
                newName: "FightStages");

            migrationBuilder.RenameTable(
                name: "FightGroup",
                newName: "FightGroups");

            migrationBuilder.RenameTable(
                name: "Fight",
                newName: "Fights");

            migrationBuilder.RenameTable(
                name: "Blow",
                newName: "Blows");

            migrationBuilder.RenameIndex(
                name: "IX_FightStage_SecondGroupId",
                table: "FightStages",
                newName: "IX_FightStages_SecondGroupId");

            migrationBuilder.RenameIndex(
                name: "IX_FightStage_FirstGroupId",
                table: "FightStages",
                newName: "IX_FightStages_FirstGroupId");

            migrationBuilder.RenameIndex(
                name: "IX_FightStage_FightId",
                table: "FightStages",
                newName: "IX_FightStages_FightId");

            migrationBuilder.RenameIndex(
                name: "IX_FightGroup_InFightId",
                table: "FightGroups",
                newName: "IX_FightGroups_InFightId");

            migrationBuilder.RenameIndex(
                name: "IX_Fight_InMovieId",
                table: "Fights",
                newName: "IX_Fights_InMovieId");

            migrationBuilder.RenameIndex(
                name: "IX_Blow_WithWeaponId",
                table: "Blows",
                newName: "IX_Blows_WithWeaponId");

            migrationBuilder.RenameIndex(
                name: "IX_Blow_InFightId",
                table: "Blows",
                newName: "IX_Blows_InFightId");

            migrationBuilder.RenameIndex(
                name: "IX_Blow_FightStageId",
                table: "Blows",
                newName: "IX_Blows_FightStageId");

            migrationBuilder.RenameIndex(
                name: "IX_Blow_BlowersId",
                table: "Blows",
                newName: "IX_Blows_BlowersId");

            migrationBuilder.RenameIndex(
                name: "IX_Blow_BloweesId",
                table: "Blows",
                newName: "IX_Blows_BloweesId");

            migrationBuilder.RenameIndex(
                name: "IX_Blow_AbstractWeaponTypeId",
                table: "Blows",
                newName: "IX_Blows_AbstractWeaponTypeId");

            migrationBuilder.AddColumn<long>(
                name: "TmdbId",
                table: "Movies",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AbstractWeaponType",
                type: "text",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LifeFormTypes",
                table: "LifeFormTypes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FightStages",
                table: "FightStages",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FightGroups",
                table: "FightGroups",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Fights",
                table: "Fights",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Blows",
                table: "Blows",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "AbstractLifeFormTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    ParentAbstractLifeFormTypeId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbstractLifeFormTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AbstractLifeFormTypes_AbstractLifeFormTypes_ParentAbstractL~",
                        column: x => x.ParentAbstractLifeFormTypeId,
                        principalTable: "AbstractLifeFormTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AbstractLifeFormTypes_ParentAbstractLifeFormTypeId",
                table: "AbstractLifeFormTypes",
                column: "ParentAbstractLifeFormTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Blows_AbstractWeaponType_AbstractWeaponTypeId",
                table: "Blows",
                column: "AbstractWeaponTypeId",
                principalTable: "AbstractWeaponType",
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
                name: "FK_Blows_Fights_InFightId",
                table: "Blows",
                column: "InFightId",
                principalTable: "Fights",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Blows_FightStages_FightStageId",
                table: "Blows",
                column: "FightStageId",
                principalTable: "FightStages",
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
                name: "FK_FightGroupPerson_FightGroups_InFightGroupsId",
                table: "FightGroupPerson",
                column: "InFightGroupsId",
                principalTable: "FightGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FightGroups_Fights_InFightId",
                table: "FightGroups",
                column: "InFightId",
                principalTable: "Fights",
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
                name: "FK_FightStages_Fights_FightId",
                table: "FightStages",
                column: "FightId",
                principalTable: "Fights",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_People_LifeFormTypes_LFTypeId",
                table: "People",
                column: "LFTypeId",
                principalTable: "LifeFormTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blows_AbstractWeaponType_AbstractWeaponTypeId",
                table: "Blows");

            migrationBuilder.DropForeignKey(
                name: "FK_Blows_FightGroups_BloweesId",
                table: "Blows");

            migrationBuilder.DropForeignKey(
                name: "FK_Blows_FightGroups_BlowersId",
                table: "Blows");

            migrationBuilder.DropForeignKey(
                name: "FK_Blows_Fights_InFightId",
                table: "Blows");

            migrationBuilder.DropForeignKey(
                name: "FK_Blows_FightStages_FightStageId",
                table: "Blows");

            migrationBuilder.DropForeignKey(
                name: "FK_Blows_Weapon_WithWeaponId",
                table: "Blows");

            migrationBuilder.DropForeignKey(
                name: "FK_FightGroupPerson_FightGroups_InFightGroupsId",
                table: "FightGroupPerson");

            migrationBuilder.DropForeignKey(
                name: "FK_FightGroups_Fights_InFightId",
                table: "FightGroups");

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
                name: "FK_FightStages_Fights_FightId",
                table: "FightStages");

            migrationBuilder.DropForeignKey(
                name: "FK_People_LifeFormTypes_LFTypeId",
                table: "People");

            migrationBuilder.DropTable(
                name: "AbstractLifeFormTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LifeFormTypes",
                table: "LifeFormTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FightStages",
                table: "FightStages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Fights",
                table: "Fights");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FightGroups",
                table: "FightGroups");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Blows",
                table: "Blows");

            migrationBuilder.DropColumn(
                name: "TmdbId",
                table: "Movies");

            migrationBuilder.RenameTable(
                name: "LifeFormTypes",
                newName: "LifeFormType");

            migrationBuilder.RenameTable(
                name: "FightStages",
                newName: "FightStage");

            migrationBuilder.RenameTable(
                name: "Fights",
                newName: "Fight");

            migrationBuilder.RenameTable(
                name: "FightGroups",
                newName: "FightGroup");

            migrationBuilder.RenameTable(
                name: "Blows",
                newName: "Blow");

            migrationBuilder.RenameIndex(
                name: "IX_FightStages_SecondGroupId",
                table: "FightStage",
                newName: "IX_FightStage_SecondGroupId");

            migrationBuilder.RenameIndex(
                name: "IX_FightStages_FirstGroupId",
                table: "FightStage",
                newName: "IX_FightStage_FirstGroupId");

            migrationBuilder.RenameIndex(
                name: "IX_FightStages_FightId",
                table: "FightStage",
                newName: "IX_FightStage_FightId");

            migrationBuilder.RenameIndex(
                name: "IX_Fights_InMovieId",
                table: "Fight",
                newName: "IX_Fight_InMovieId");

            migrationBuilder.RenameIndex(
                name: "IX_FightGroups_InFightId",
                table: "FightGroup",
                newName: "IX_FightGroup_InFightId");

            migrationBuilder.RenameIndex(
                name: "IX_Blows_WithWeaponId",
                table: "Blow",
                newName: "IX_Blow_WithWeaponId");

            migrationBuilder.RenameIndex(
                name: "IX_Blows_InFightId",
                table: "Blow",
                newName: "IX_Blow_InFightId");

            migrationBuilder.RenameIndex(
                name: "IX_Blows_FightStageId",
                table: "Blow",
                newName: "IX_Blow_FightStageId");

            migrationBuilder.RenameIndex(
                name: "IX_Blows_BlowersId",
                table: "Blow",
                newName: "IX_Blow_BlowersId");

            migrationBuilder.RenameIndex(
                name: "IX_Blows_BloweesId",
                table: "Blow",
                newName: "IX_Blow_BloweesId");

            migrationBuilder.RenameIndex(
                name: "IX_Blows_AbstractWeaponTypeId",
                table: "Blow",
                newName: "IX_Blow_AbstractWeaponTypeId");

            migrationBuilder.AlterColumn<int>(
                name: "Name",
                table: "AbstractWeaponType",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_LifeFormType",
                table: "LifeFormType",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FightStage",
                table: "FightStage",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Fight",
                table: "Fight",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FightGroup",
                table: "FightGroup",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Blow",
                table: "Blow",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Blow_AbstractWeaponType_AbstractWeaponTypeId",
                table: "Blow",
                column: "AbstractWeaponTypeId",
                principalTable: "AbstractWeaponType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Blow_Fight_InFightId",
                table: "Blow",
                column: "InFightId",
                principalTable: "Fight",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Blow_FightGroup_BloweesId",
                table: "Blow",
                column: "BloweesId",
                principalTable: "FightGroup",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Blow_FightGroup_BlowersId",
                table: "Blow",
                column: "BlowersId",
                principalTable: "FightGroup",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Blow_FightStage_FightStageId",
                table: "Blow",
                column: "FightStageId",
                principalTable: "FightStage",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Blow_Weapon_WithWeaponId",
                table: "Blow",
                column: "WithWeaponId",
                principalTable: "Weapon",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Fight_Movies_InMovieId",
                table: "Fight",
                column: "InMovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FightGroup_Fight_InFightId",
                table: "FightGroup",
                column: "InFightId",
                principalTable: "Fight",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FightGroupPerson_FightGroup_InFightGroupsId",
                table: "FightGroupPerson",
                column: "InFightGroupsId",
                principalTable: "FightGroup",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FightStage_Fight_FightId",
                table: "FightStage",
                column: "FightId",
                principalTable: "Fight",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FightStage_FightGroup_FirstGroupId",
                table: "FightStage",
                column: "FirstGroupId",
                principalTable: "FightGroup",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FightStage_FightGroup_SecondGroupId",
                table: "FightStage",
                column: "SecondGroupId",
                principalTable: "FightGroup",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_People_LifeFormType_LFTypeId",
                table: "People",
                column: "LFTypeId",
                principalTable: "LifeFormType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
