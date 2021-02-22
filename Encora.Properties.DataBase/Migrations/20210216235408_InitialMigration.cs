using Microsoft.EntityFrameworkCore.Migrations;

namespace Encora.Properties.DataBase.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "bnl");

            migrationBuilder.CreateTable(
                name: "Property",
                schema: "bnl",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    YearBuilt = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    ListPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    MonthlyRent = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Property", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                schema: "bnl",
                columns: table => new
                {
                    PropertyId = table.Column<int>(type: "int", nullable: false),
                    AddressOne = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    AddressTwo = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    City = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Country = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    County = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    District = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    State = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Zip = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    ZipPlus4 = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.PropertyId);
                    table.ForeignKey(
                        name: "FK_Addresses_Property_PropertyId",
                        column: x => x.PropertyId,
                        principalSchema: "bnl",
                        principalTable: "Property",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Addresses",
                schema: "bnl");

            migrationBuilder.DropTable(
                name: "Property",
                schema: "bnl");
        }
    }
}
