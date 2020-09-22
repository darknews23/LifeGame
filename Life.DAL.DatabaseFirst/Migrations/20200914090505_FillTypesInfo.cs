using Life.DAL.DatabaseFirst.Models;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Life.DAL.DatabaseFirst.Migrations
{
    public partial class FillTypesInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: nameof(GameObjectsTypes),
                columns: new[] { "TypeName", "IsFullyEatable", "IsEverGrowing" },
                values: new object[]
                {
                    "Algae",false,true
                });
            migrationBuilder.InsertData(
                table: nameof(GameObjectsTypes),
                columns: new[] { "TypeName", "IsFullyEatable", "IsEverGrowing" },
                values: new object[]
                {
                    "Cabbage",true, true
                });
            migrationBuilder.InsertData(
                table: nameof(GameObjectsTypes),
                columns: new[] { "TypeName", "IsFullyEatable", "IsEverGrowing" },
                values: new object[]
                {
                    "Duck",null, false
                });
            migrationBuilder.InsertData(
                table: nameof(GameObjectsTypes),
                columns: new[] { "TypeName", "IsFullyEatable", "IsEverGrowing" },
                values: new object[]
                {
                    "Fish",true, false
                });
            migrationBuilder.InsertData(
                table: nameof(GameObjectsTypes),
                columns: new[] { "TypeName", "IsFullyEatable", "IsEverGrowing" },
                values: new object[]
                {
                    "Rabbit",null, false
                });
            migrationBuilder.InsertData(
                table: nameof(GameObjectsTypes),
                columns: new[] { "TypeName", "IsFullyEatable", "IsEverGrowing" },
                values: new object[]
                {
                    "Rock",null, null
                });
            migrationBuilder.InsertData(
                table: nameof(GameObjectsTypes),
                columns: new[] { "TypeName", "IsFullyEatable", "IsEverGrowing" },
                values: new object[]
                {
                    "Sparrow",null, false
                });
            migrationBuilder.InsertData(
                table: nameof(GameObjectsTypes),
                columns: new[] { "TypeName", "IsFullyEatable", "IsEverGrowing" },
                values: new object[]
                {
                    "Tree",false,true
                });
            migrationBuilder.InsertData(
                table: nameof(GameObjectsTypes),
                columns: new[] { "TypeName", "IsFullyEatable", "IsEverGrowing" },
                values: new object[]
                {
                    "Turtle",null,false
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: nameof(GameObjectsTypes),
                keyColumns: new[] { "TypeName", "IsFullyEatable", "IsEverGrowing" },
                keyValues: new object[]
                {
                    "Algae",false,true
                });
            migrationBuilder.DeleteData(
                table: nameof(GameObjectsTypes),
                keyColumns: new[] { "TypeName", "IsFullyEatable", "IsEverGrowing" },
                keyValues: new object[]
                {
                    "Cabbage",true, true
                });
            migrationBuilder.DeleteData(
                table: nameof(GameObjectsTypes),
                keyColumns: new[] { "TypeName", "IsFullyEatable", "IsEverGrowing" },
                keyValues: new object[]
                {
                    "Duck",null, false
                });
            migrationBuilder.DeleteData(
                table: nameof(GameObjectsTypes),
                keyColumns: new[] { "TypeName", "IsFullyEatable", "IsEverGrowing" },
                keyValues: new object[]
                {
                    "Fish",true, false
                });
            migrationBuilder.DeleteData(
                table: nameof(GameObjectsTypes),
                keyColumns: new[] { "TypeName", "IsFullyEatable", "IsEverGrowing" },
                keyValues: new object[]
                {
                    "Rabbit",null, false
                });
            migrationBuilder.DeleteData(
                table: nameof(GameObjectsTypes),
                keyColumns: new[] { "TypeName", "IsFullyEatable", "IsEverGrowing" },
                keyValues: new object[]
                {
                    "Rock",null, null
                });
            migrationBuilder.DeleteData(
                table: nameof(GameObjectsTypes),
                keyColumns: new[] { "TypeName", "IsFullyEatable", "IsEverGrowing" },
                keyValues: new object[]
                {
                    "Sparrow",null, false
                });
            migrationBuilder.DeleteData(
                table: nameof(GameObjectsTypes),
                keyColumns: new[] { "TypeName", "IsFullyEatable", "IsEverGrowing" },
                keyValues: new object[]
                {
                    "Tree",false,true
                });
            migrationBuilder.DeleteData(
                table: nameof(GameObjectsTypes),
                keyColumns: new[] { "TypeName", "IsFullyEatable", "IsEverGrowing" },
                keyValues: new object[]
                {
                    "Turtle",null,false
                });
        }
    }
}
