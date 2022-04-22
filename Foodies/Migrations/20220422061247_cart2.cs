using Microsoft.EntityFrameworkCore.Migrations;

namespace Foodies.Migrations
{
    public partial class cart2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_BookOrder",
                table: "BookOrder");

            migrationBuilder.RenameTable(
                name: "BookOrder",
                newName: "BookOrders");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookOrders",
                table: "BookOrders",
                column: "OrderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_BookOrders",
                table: "BookOrders");

            migrationBuilder.RenameTable(
                name: "BookOrders",
                newName: "BookOrder");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookOrder",
                table: "BookOrder",
                column: "OrderId");
        }
    }
}
