using Microsoft.EntityFrameworkCore.Migrations;

namespace Life.DAL.DatabaseFirst.Migrations
{
    public partial class SetStepAndSessionTypeNameFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_GameObjectsStepState_TypeName",
                table: "GameObjectsStepState",
                column: "TypeName");

            migrationBuilder.AddForeignKey(
                name: "FK_GameObjectsSessionTypes_GameObjectsTypes",
                table: "GameObjectsSessionTypes",
                column: "TypeName",
                principalTable: "GameObjectsTypes",
                principalColumn: "TypeName",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GameObjectsStepState_GameObjectsTypes",
                table: "GameObjectsStepState",
                column: "TypeName",
                principalTable: "GameObjectsTypes",
                principalColumn: "TypeName",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GameObjectsSessionTypes_GameObjectsTypes",
                table: "GameObjectsSessionTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_GameObjectsStepState_GameObjectsTypes",
                table: "GameObjectsStepState");

            migrationBuilder.DropIndex(
                name: "IX_GameObjectsStepState_TypeName",
                table: "GameObjectsStepState");
        }
    }
}
