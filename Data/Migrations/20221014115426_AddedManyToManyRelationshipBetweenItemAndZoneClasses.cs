using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Garage003.Data.Migrations
{
    public partial class AddedManyToManyRelationshipBetweenItemAndZoneClasses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ItemZone",
                columns: table => new
                {
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    ZoneId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemZone", x => new { x.ItemId, x.ZoneId });
                    table.ForeignKey(
                        name: "FK_ItemZone_Item_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Item",
                        principalColumn: "ItemId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemZone_Zone_ZoneId",
                        column: x => x.ZoneId,
                        principalTable: "Zone",
                        principalColumn: "ZoneId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItemZone_ZoneId",
                table: "ItemZone",
                column: "ZoneId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemZone");
        }
    }
}
