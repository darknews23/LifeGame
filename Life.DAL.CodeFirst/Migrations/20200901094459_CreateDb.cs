using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Life.DAL.CodeFirst.Migrations
{
    public partial class CreateDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Actions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AreaTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AreaTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Directions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Directions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GameObjectsTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameObjectsTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GenderTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenderTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MoveTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoveTypes", x => x.Id);
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
                name: "Statuses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GameObjects",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeId = table.Column<int>(nullable: false),
                    Habitat = table.Column<int>(nullable: false),
                    IsEverGrowing = table.Column<bool>(nullable: true),
                    ActionId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameObjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GameObjects_Actions",
                        column: x => x.ActionId,
                        principalTable: "Actions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GameObjects_AreaTypes",
                        column: x => x.Habitat,
                        principalTable: "AreaTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GameObjects_GameObjectsTypes",
                        column: x => x.TypeId,
                        principalTable: "GameObjectsTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GameObjectsSessionState",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeId = table.Column<int>(nullable: false),
                    SessionId = table.Column<int>(nullable: false),
                    InitialHp = table.Column<int>(nullable: false),
                    MaxBirth = table.Column<int>(nullable: true),
                    BirthTime = table.Column<int>(nullable: true),
                    AdultAge = table.Column<int>(nullable: true),
                    IsFullyEatable = table.Column<bool>(nullable: true),
                    ReceivedDamage = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameObjectsSessionState", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GameObjectsSessionState_Sessions",
                        column: x => x.SessionId,
                        principalTable: "Sessions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GameObjectsSessionState_GameObjectsTypes",
                        column: x => x.TypeId,
                        principalTable: "GameObjectsTypes",
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
                name: "GameObjectsMoveTypes",
                columns: table => new
                {
                    GameObjectId = table.Column<int>(nullable: false),
                    MoveTypeId = table.Column<int>(nullable: false),
                    Speed = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameObjectsMoveTypes", x => new { x.GameObjectId, x.MoveTypeId });
                    table.ForeignKey(
                        name: "FK_GameObjectsMoveTypes_GameObjects",
                        column: x => x.GameObjectId,
                        principalTable: "GameObjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GameObjectsMoveTypes_MoveTypes",
                        column: x => x.MoveTypeId,
                        principalTable: "MoveTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GameObjectsStepState",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeId = table.Column<int>(nullable: false),
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
                    table.PrimaryKey("PK_GameObjectsStepState", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GameObjectsStepState_GenderTypes",
                        column: x => x.GenderTypeId,
                        principalTable: "GenderTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GameObjectsStepState_Statuses",
                        column: x => x.StatusId,
                        principalTable: "Statuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GameObjectsStepState_Steps",
                        column: x => x.StepId,
                        principalTable: "Steps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GameObjectsStepState_GameObjectsTypes",
                        column: x => x.TypeId,
                        principalTable: "GameObjectsTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GameTiles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StepId = table.Column<int>(nullable: false),
                    AreaTypeId = table.Column<int>(nullable: false),
                    X = table.Column<int>(nullable: false),
                    Y = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameTiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GameTiles_AreaTypes",
                        column: x => x.AreaTypeId,
                        principalTable: "AreaTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GameTiles_Steps",
                        column: x => x.StepId,
                        principalTable: "Steps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActionId = table.Column<int>(nullable: false),
                    GameObjectID1 = table.Column<int>(nullable: false),
                    GameObjectID2 = table.Column<int>(nullable: true),
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
                        name: "FK_Events_Actions",
                        column: x => x.ActionId,
                        principalTable: "Actions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Events_GameObjectsStepState",
                        column: x => x.GameObjectID1,
                        principalTable: "GameObjectsStepState",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Events_MoveTypes",
                        column: x => x.Id,
                        principalTable: "MoveTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Events_ActionId",
                table: "Events",
                column: "ActionId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_GameObjectID1",
                table: "Events",
                column: "GameObjectID1");

            migrationBuilder.CreateIndex(
                name: "IX_GameObjects_ActionId",
                table: "GameObjects",
                column: "ActionId");

            migrationBuilder.CreateIndex(
                name: "IX_GameObjects_Habitat",
                table: "GameObjects",
                column: "Habitat");

            migrationBuilder.CreateIndex(
                name: "IX_GameObjects_TypeId",
                table: "GameObjects",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_GameObjectsMoveTypes_MoveTypeId",
                table: "GameObjectsMoveTypes",
                column: "MoveTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_GameObjectsSessionState_SessionId",
                table: "GameObjectsSessionState",
                column: "SessionId");

            migrationBuilder.CreateIndex(
                name: "IX_GameObjectsSessionState_TypeId",
                table: "GameObjectsSessionState",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_GameObjectsStepState_GenderTypeId",
                table: "GameObjectsStepState",
                column: "GenderTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_GameObjectsStepState_StatusId",
                table: "GameObjectsStepState",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_GameObjectsStepState_StepId",
                table: "GameObjectsStepState",
                column: "StepId");

            migrationBuilder.CreateIndex(
                name: "IX_GameObjectsStepState_TypeId",
                table: "GameObjectsStepState",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_GameTiles_AreaTypeId",
                table: "GameTiles",
                column: "AreaTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_GameTiles_StepId",
                table: "GameTiles",
                column: "StepId");

            migrationBuilder.CreateIndex(
                name: "IX_Steps_SessionId",
                table: "Steps",
                column: "SessionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Directions");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "GameObjectsMoveTypes");

            migrationBuilder.DropTable(
                name: "GameObjectsSessionState");

            migrationBuilder.DropTable(
                name: "GameTiles");

            migrationBuilder.DropTable(
                name: "GameObjectsStepState");

            migrationBuilder.DropTable(
                name: "GameObjects");

            migrationBuilder.DropTable(
                name: "MoveTypes");

            migrationBuilder.DropTable(
                name: "GenderTypes");

            migrationBuilder.DropTable(
                name: "Statuses");

            migrationBuilder.DropTable(
                name: "Steps");

            migrationBuilder.DropTable(
                name: "Actions");

            migrationBuilder.DropTable(
                name: "AreaTypes");

            migrationBuilder.DropTable(
                name: "GameObjectsTypes");

            migrationBuilder.DropTable(
                name: "Sessions");
        }
    }
}
