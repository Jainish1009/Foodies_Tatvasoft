using Microsoft.EntityFrameworkCore.Migrations;

namespace Foodies.Migrations
{
    public partial class UserIdToRestId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "RestMenus",
                newName: "RestId");

            migrationBuilder.RenameColumn(
                name: "BasePrice",
                table: "BookOrders",
                newName: "Price");

            migrationBuilder.AddColumn<string>(
                name: "RestId",
                table: "BookOrders",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RestId",
                table: "BookOrders");

            migrationBuilder.RenameColumn(
                name: "RestId",
                table: "RestMenus",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "BookOrders",
                newName: "BasePrice");
        }
    }
}
