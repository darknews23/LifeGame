using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Life.DAL.DatabaseFirst.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GameObjectsSessionTypes",
                columns: table => new
                {
                    TypeName = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    SessionId = table.Column<int>(nullable: false),
                    InitialHp = table.Column<int>(nullable: true),
                    MaxBirth = table.Column<int>(nullable: true),
                    BirthTime = table.Column<int>(nullable: true),
                    AdultAge = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameObjectsSessionTypes", x => new { x.TypeName, x.SessionId });
                });

            migrationBuilder.CreateTable(
                name: "GameObjectsTypes",
                columns: table => new
                {
                    TypeName = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    IsFullyEatable = table.Column<bool>(nullable: true),
                    IsEverGrowing = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameObjectsTypes", x => x.TypeName);
                });

            migrationBuilder.CreateTable(
                name: "Sessions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sessions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SessionPartiallyEatableTypes",
                columns: table => new
                {
                    TypeName = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    SessionId = table.Column<int>(nullable: false),
                    BeingEatenDamage = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SessionPartiallyEatableTypes", x => new { x.TypeName, x.SessionId });
                    table.ForeignKey(
                        name: "FK_SessionPartiallyEatableTypes_Sessions",
                        column: x => x.SessionId,
                        principalTable: "Sessions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SessionTypesMoveTypes",
                columns: table => new
                {
                    TypeName = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    MoveTypeId = table.Column<int>(nullable: false),
                    SessionId = table.Column<int>(nullable: false),
                    Speed = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SessionTypesMoveTypes", x => new { x.TypeName, x.MoveTypeId, x.SessionId });
                    table.ForeignKey(
                        name: "FK_SessionTypesMoveTypes_Sessions",
                        column: x => x.SessionId,
                        principalTable: "Sessions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Steps",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SessionId = table.Column<int>(nullable: false),
                    Number = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Steps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Steps_Sessions",
                        column: x => x.SessionId,
                        principalTable: "Sessions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StepId = table.Column<int>(nullable: false),
                    ActionId = table.Column<int>(nullable: false),
                    GameObjectId1 = table.Column<int>(nullable: false),
                    GameObjectId2 = table.Column<int>(nullable: true),
                    BecameAdult = table.Column<bool>(nullable: true),
                    HpChange = table.Column<int>(nullable: true),
                    DirectionId = table.Column<int>(nullable: true),
                    Distance = table.Column<int>(nullable: true),
                    MoveTypeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Events_Steps",
                        column: x => x.StepId,
                        principalTable: "Steps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GameObjectsStepState",
                columns: table => new
                {
                    GameObjectId = table.Column<int>(nullable: false),
                    TypeName = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    StepId = table.Column<int>(nullable: false),
                    X = table.Column<int>(nullable: false),
                    Y = table.Column<int>(nullable: false),
                    Hp = table.Column<int>(nullable: false),
                    StatusId = table.Column<int>(nullable: false),
                    CurrentAge = table.Column<int>(nullable: true),
                    GenderTypeId = table.Column<int>(nullable: true),
                    CurrentPregnancyTime = table.Column<int>(nullable: true),
                    IsPregnant = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameObjectsStepState", x => new { x.GameObjectId, x.TypeName, x.StepId });
                    table.ForeignKey(
                        name: "FK_GameObjectsStepState_Steps",
                        column: x => x.StepId,
                        principalTable: "Steps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GameTiles",
                columns: table => new
                {
                    StepId = table.Column<int>(nullable: false),
                    X = table.Column<int>(nullable: false),
                    Y = table.Column<int>(nullable: false),
                    AreaTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameTiles_1", x => new { x.StepId, x.X, x.Y });
                    table.ForeignKey(
                        name: "FK_GameTiles_Steps",
                        column: x => x.StepId,
                        principalTable: "Steps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Events_StepId",
                table: "Events",
                column: "StepId");

            migrationBuilder.CreateIndex(
                name: "IX_GameObjectsStepState_StepId",
                table: "GameObjectsStepState",
                column: "StepId");

            migrationBuilder.CreateIndex(
                name: "IX_SessionPartiallyEatableTypes_SessionId",
                table: "SessionPartiallyEatableTypes",
                column: "SessionId");

            migrationBuilder.CreateIndex(
                name: "IX_SessionTypesMoveTypes_SessionId",
                table: "SessionTypesMoveTypes",
                column: "SessionId");

            migrationBuilder.CreateIndex(
                name: "IX_Steps_SessionId",
                table: "Steps",
                column: "SessionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "GameObjectsSessionTypes");

            migrationBuilder.DropTable(
                name: "GameObjectsStepState");

            migrationBuilder.DropTable(
                name: "GameObjectsTypes");

            migrationBuilder.DropTable(
                name: "GameTiles");

            migrationBuilder.DropTable(
                name: "SessionPartiallyEatableTypes");

            migrationBuilder.DropTable(
                name: "SessionTypesMoveTypes");

            migrationBuilder.DropTable(
                name: "Steps");

            migrationBuilder.DropTable(
                name: "Sessions");
        }
    }
}
