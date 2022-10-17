using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Garage003.Data.Migrations
{
    public partial class AddedItemZoneDbSet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemZone_Item_ItemId",
                table: "ItemZone");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemZone_Zone_ZoneId",
                table: "ItemZone");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ItemZone",
                table: "ItemZone");

            migrationBuilder.RenameTable(
                name: "ItemZone",
                newName: "ItemZones");

            migrationBuilder.RenameIndex(
                name: "IX_ItemZone_ZoneId",
                table: "ItemZones",
                newName: "IX_ItemZones_ZoneId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ItemZones",
                table: "ItemZones",
                columns: new[] { "ItemId", "ZoneId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ItemZones_Item_ItemId",
                table: "ItemZones",
                column: "ItemId",
                principalTable: "Item",
                principalColumn: "ItemId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemZones_Zone_ZoneId",
                table: "ItemZones",
                column: "ZoneId",
                principalTable: "Zone",
                principalColumn: "ZoneId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemZones_Item_ItemId",
                table: "ItemZones");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemZones_Zone_ZoneId",
                table: "ItemZones");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ItemZones",
                table: "ItemZones");

            migrationBuilder.RenameTable(
                name: "ItemZones",
                newName: "ItemZone");

            migrationBuilder.RenameIndex(
                name: "IX_ItemZones_ZoneId",
                table: "ItemZone",
                newName: "IX_ItemZone_ZoneId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ItemZone",
                table: "ItemZone",
                columns: new[] { "ItemId", "ZoneId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ItemZone_Item_ItemId",
                table: "ItemZone",
                column: "ItemId",
                principalTable: "Item",
                principalColumn: "ItemId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemZone_Zone_ZoneId",
                table: "ItemZone",
                column: "ZoneId",
                principalTable: "Zone",
                principalColumn: "ZoneId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
