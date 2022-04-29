using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Foodies.Migrations
{
    public partial class CreatedOnInInvoice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Invoices",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "RestId",
                table: "Invoices",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "RestId",
                table: "Invoices");
        }
    }
}
