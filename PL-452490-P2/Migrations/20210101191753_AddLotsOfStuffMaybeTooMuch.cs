using Microsoft.EntityFrameworkCore.Migrations;
using NodaTime;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace PL_452490_P2.Migrations
{
    public partial class AddLotsOfStuffMaybeTooMuch : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "People");

            migrationBuilder.AddColumn<int>(
                name: "AbstractWeaponTypeId",
                table: "People",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ForceType",
                table: "People",
                type: "VARCHAR(24)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FromPlanetId",
                table: "People",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LFTypeId",
                table: "People",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MasterId",
                table: "People",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AbstractWeaponType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbstractWeaponType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Actor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LifeFormType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LifeFormType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ChronologicalOrderId = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    ReleaseDate = table.Column<LocalDate>(type: "date", nullable: true),
                    Budget = table.Column<decimal>(type: "numeric(20,0)", nullable: true),
                    BoxOffice = table.Column<decimal>(type: "numeric(20,0)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Planets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    NumSuns = table.Column<long>(type: "bigint", nullable: true, defaultValueSql: "1"),
                    NumMoons = table.Column<long>(type: "bigint", nullable: true, defaultValueSql: "1"),
                    Population = table.Column<decimal>(type: "numeric(20,0)", nullable: true, defaultValueSql: "0")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Planets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Weapon",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    WeaponTypeId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weapon", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Weapon_AbstractWeaponType_WeaponTypeId",
                        column: x => x.WeaponTypeId,
                        principalTable: "AbstractWeaponType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ActorsPerMovies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    InMovieId = table.Column<int>(type: "integer", nullable: true),
                    PlaysId = table.Column<int>(type: "integer", nullable: true),
                    PlayedById = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActorsPerMovies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ActorsPerMovies_Actor_PlayedById",
                        column: x => x.PlayedById,
                        principalTable: "Actor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ActorsPerMovies_Movies_InMovieId",
                        column: x => x.InMovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ActorsPerMovies_People_PlaysId",
                        column: x => x.PlaysId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Fight",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    InMovieId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fight", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fight_Movies_InMovieId",
                        column: x => x.InMovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WeaponOwners",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    WeaponOwnerOrder = table.Column<long>(type: "bigint", nullable: false),
                    OwnerId = table.Column<int>(type: "integer", nullable: true),
                    WeaponId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeaponOwners", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WeaponOwners_People_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WeaponOwners_Weapon_WeaponId",
                        column: x => x.WeaponId,
                        principalTable: "Weapon",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FightGroup",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    InFightId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FightGroup", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FightGroup_Fight_InFightId",
                        column: x => x.InFightId,
                        principalTable: "Fight",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FightGroupPerson",
                columns: table => new
                {
                    GroupMembersId = table.Column<int>(type: "integer", nullable: false),
                    InFightGroupsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FightGroupPerson", x => new { x.GroupMembersId, x.InFightGroupsId });
                    table.ForeignKey(
                        name: "FK_FightGroupPerson_FightGroup_InFightGroupsId",
                        column: x => x.InFightGroupsId,
                        principalTable: "FightGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FightGroupPerson_People_GroupMembersId",
                        column: x => x.GroupMembersId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FightStage",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstGroupId = table.Column<int>(type: "integer", nullable: true),
                    SecondGroupId = table.Column<int>(type: "integer", nullable: true),
                    Result = table.Column<int>(type: "integer", nullable: false),
                    FightId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FightStage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FightStage_Fight_FightId",
                        column: x => x.FightId,
                        principalTable: "Fight",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FightStage_FightGroup_FirstGroupId",
                        column: x => x.FirstGroupId,
                        principalTable: "FightGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FightStage_FightGroup_SecondGroupId",
                        column: x => x.SecondGroupId,
                        principalTable: "FightGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Blow",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BlowOrderInFight = table.Column<long>(type: "bigint", nullable: false),
                    BlowersId = table.Column<int>(type: "integer", nullable: true),
                    BloweesId = table.Column<int>(type: "integer", nullable: true),
                    WithWeaponId = table.Column<int>(type: "integer", nullable: true),
                    DamageDealt = table.Column<long>(type: "bigint", nullable: false),
                    InFightId = table.Column<int>(type: "integer", nullable: true),
                    AbstractWeaponTypeId = table.Column<int>(type: "integer", nullable: true),
                    FightStageId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blow", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Blow_AbstractWeaponType_AbstractWeaponTypeId",
                        column: x => x.AbstractWeaponTypeId,
                        principalTable: "AbstractWeaponType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Blow_Fight_InFightId",
                        column: x => x.InFightId,
                        principalTable: "Fight",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Blow_FightGroup_BloweesId",
                        column: x => x.BloweesId,
                        principalTable: "FightGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Blow_FightGroup_BlowersId",
                        column: x => x.BlowersId,
                        principalTable: "FightGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Blow_FightStage_FightStageId",
                        column: x => x.FightStageId,
                        principalTable: "FightStage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Blow_Weapon_WithWeaponId",
                        column: x => x.WithWeaponId,
                        principalTable: "Weapon",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_People_AbstractWeaponTypeId",
                table: "People",
                column: "AbstractWeaponTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_People_FromPlanetId",
                table: "People",
                column: "FromPlanetId");

            migrationBuilder.CreateIndex(
                name: "IX_People_LFTypeId",
                table: "People",
                column: "LFTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_People_MasterId",
                table: "People",
                column: "MasterId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ActorsPerMovies_InMovieId",
                table: "ActorsPerMovies",
                column: "InMovieId");

            migrationBuilder.CreateIndex(
                name: "IX_ActorsPerMovies_PlayedById",
                table: "ActorsPerMovies",
                column: "PlayedById");

            migrationBuilder.CreateIndex(
                name: "IX_ActorsPerMovies_PlaysId",
                table: "ActorsPerMovies",
                column: "PlaysId");

            migrationBuilder.CreateIndex(
                name: "IX_Blow_AbstractWeaponTypeId",
                table: "Blow",
                column: "AbstractWeaponTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Blow_BloweesId",
                table: "Blow",
                column: "BloweesId");

            migrationBuilder.CreateIndex(
                name: "IX_Blow_BlowersId",
                table: "Blow",
                column: "BlowersId");

            migrationBuilder.CreateIndex(
                name: "IX_Blow_FightStageId",
                table: "Blow",
                column: "FightStageId");

            migrationBuilder.CreateIndex(
                name: "IX_Blow_InFightId",
                table: "Blow",
                column: "InFightId");

            migrationBuilder.CreateIndex(
                name: "IX_Blow_WithWeaponId",
                table: "Blow",
                column: "WithWeaponId");

            migrationBuilder.CreateIndex(
                name: "IX_Fight_InMovieId",
                table: "Fight",
                column: "InMovieId");

            migrationBuilder.CreateIndex(
                name: "IX_FightGroup_InFightId",
                table: "FightGroup",
                column: "InFightId");

            migrationBuilder.CreateIndex(
                name: "IX_FightGroupPerson_InFightGroupsId",
                table: "FightGroupPerson",
                column: "InFightGroupsId");

            migrationBuilder.CreateIndex(
                name: "IX_FightStage_FightId",
                table: "FightStage",
                column: "FightId");

            migrationBuilder.CreateIndex(
                name: "IX_FightStage_FirstGroupId",
                table: "FightStage",
                column: "FirstGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_FightStage_SecondGroupId",
                table: "FightStage",
                column: "SecondGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Weapon_WeaponTypeId",
                table: "Weapon",
                column: "WeaponTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_WeaponOwners_OwnerId",
                table: "WeaponOwners",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_WeaponOwners_WeaponId",
                table: "WeaponOwners",
                column: "WeaponId");

            migrationBuilder.AddForeignKey(
                name: "FK_People_AbstractWeaponType_AbstractWeaponTypeId",
                table: "People",
                column: "AbstractWeaponTypeId",
                principalTable: "AbstractWeaponType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_People_LifeFormType_LFTypeId",
                table: "People",
                column: "LFTypeId",
                principalTable: "LifeFormType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_People_People_MasterId",
                table: "People",
                column: "MasterId",
                principalTable: "People",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_People_Planets_FromPlanetId",
                table: "People",
                column: "FromPlanetId",
                principalTable: "Planets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_People_AbstractWeaponType_AbstractWeaponTypeId",
                table: "People");

            migrationBuilder.DropForeignKey(
                name: "FK_People_LifeFormType_LFTypeId",
                table: "People");

            migrationBuilder.DropForeignKey(
                name: "FK_People_People_MasterId",
                table: "People");

            migrationBuilder.DropForeignKey(
                name: "FK_People_Planets_FromPlanetId",
                table: "People");

            migrationBuilder.DropTable(
                name: "ActorsPerMovies");

            migrationBuilder.DropTable(
                name: "Blow");

            migrationBuilder.DropTable(
                name: "FightGroupPerson");

            migrationBuilder.DropTable(
                name: "LifeFormType");

            migrationBuilder.DropTable(
                name: "Planets");

            migrationBuilder.DropTable(
                name: "WeaponOwners");

            migrationBuilder.DropTable(
                name: "Actor");

            migrationBuilder.DropTable(
                name: "FightStage");

            migrationBuilder.DropTable(
                name: "Weapon");

            migrationBuilder.DropTable(
                name: "FightGroup");

            migrationBuilder.DropTable(
                name: "AbstractWeaponType");

            migrationBuilder.DropTable(
                name: "Fight");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropIndex(
                name: "IX_People_AbstractWeaponTypeId",
                table: "People");

            migrationBuilder.DropIndex(
                name: "IX_People_FromPlanetId",
                table: "People");

            migrationBuilder.DropIndex(
                name: "IX_People_LFTypeId",
                table: "People");

            migrationBuilder.DropIndex(
                name: "IX_People_MasterId",
                table: "People");

            migrationBuilder.DropColumn(
                name: "AbstractWeaponTypeId",
                table: "People");

            migrationBuilder.DropColumn(
                name: "ForceType",
                table: "People");

            migrationBuilder.DropColumn(
                name: "FromPlanetId",
                table: "People");

            migrationBuilder.DropColumn(
                name: "LFTypeId",
                table: "People");

            migrationBuilder.DropColumn(
                name: "MasterId",
                table: "People");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "People",
                type: "nvarchar(24",
                nullable: true);
        }
    }
}
