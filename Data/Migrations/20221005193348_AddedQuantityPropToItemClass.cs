using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Garage003.Data.Migrations
{
    public partial class AddedQuantityPropToItemClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "Item",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Item");
        }
    }
}
