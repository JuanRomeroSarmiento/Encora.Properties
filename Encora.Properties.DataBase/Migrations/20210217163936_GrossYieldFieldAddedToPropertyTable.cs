using Microsoft.EntityFrameworkCore.Migrations;

namespace Encora.Properties.DataBase.Migrations
{
    public partial class GrossYieldFieldAddedToPropertyTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "GrossYield",
                schema: "bnl",
                table: "Property",
                type: "decimal(18,2)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GrossYield",
                schema: "bnl",
                table: "Property");
        }
    }
}
