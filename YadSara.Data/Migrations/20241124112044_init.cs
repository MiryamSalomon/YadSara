using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YadSara.Data.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Borrow",
                columns: table => new
                {
                    borrowId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    borrowName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Borrow", x => x.borrowId);
                });

            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    CityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.CityId);
                });

            migrationBuilder.CreateTable(
                name: "Equipment",
                columns: table => new
                {
                    idEquipment = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nameEquipment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nameEquipmentck = table.Column<int>(type: "int", nullable: false),
                    currentquantity = table.Column<int>(type: "int", nullable: false),
                    deposit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lenderId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipment", x => x.idEquipment);
                });

            migrationBuilder.CreateTable(
                name: "Lender",
                columns: table => new
                {
                    lenderId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    lenderName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lenderPhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lenderAdress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lenderCityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lender", x => x.lenderId);
                });

            migrationBuilder.CreateTable(
                name: "Lending",
                columns: table => new
                {
                    LendingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TimeLending = table.Column<DateTime>(type: "datetime2", nullable: false),
                    deadlineLending = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsReturned = table.Column<bool>(type: "bit", nullable: false),
                    IdEquipment = table.Column<int>(type: "int", nullable: false),
                    lenderId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    borrowId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lending", x => x.LendingId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Borrow");

            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropTable(
                name: "Equipment");

            migrationBuilder.DropTable(
                name: "Lender");

            migrationBuilder.DropTable(
                name: "Lending");
        }
    }
}
