using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Garage003.Data.Migrations
{
    public partial class AddedOneToManyRelationshipBetweenItemAndStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "Item",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Item_StatusId",
                table: "Item",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Item_Status_StatusId",
                table: "Item",
                column: "StatusId",
                principalTable: "Status",
                principalColumn: "StatusId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Item_Status_StatusId",
                table: "Item");

            migrationBuilder.DropIndex(
                name: "IX_Item_StatusId",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "Item");
        }
    }
}
