using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YadSara.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Borrow",
                columns: table => new
                {
                    borrowId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    borrowName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    address = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
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
                    CityId = table.Column<int>(type: "int", nullable: false),
                    CityName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.CityId);
                });

            migrationBuilder.CreateTable(
                name: "Equipment",
                columns: table => new
                {
                    idEquipment = table.Column<int>(type: "int", nullable: false),
                    nameEquipment = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    nameEquipmentck = table.Column<int>(type: "int", nullable: false),
                    currentquantity = table.Column<int>(type: "int", nullable: false),
                    deposit = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    lenderId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipment", x => x.idEquipment);
                });

            migrationBuilder.CreateTable(
                name: "Lender",
                columns: table => new
                {
                    lenderId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    lenderName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    lenderPhone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    lenderAdress = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
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
                    LendingId = table.Column<int>(type: "int", nullable: false),
                    TimeLending = table.Column<DateTime>(type: "datetime2", nullable: false),
                    deadlineLending = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsReturned = table.Column<bool>(type: "bit", nullable: false),
                    IdEquipment = table.Column<int>(type: "int", nullable: false),
                    lenderId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    borrowId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lending", x => x.LendingId);
                });

            migrationBuilder.InsertData(
                table: "Borrow",
                columns: new[] { "borrowId", "address", "borrowName", "cityId", "phone" },
                values: new object[] { "246987569", "Rabbi Akiva", "yosiLev", 1, "0556987459" });

            migrationBuilder.InsertData(
                table: "City",
                columns: new[] { "CityId", "CityName" },
                values: new object[] { 1, "בני ברק" });

            migrationBuilder.InsertData(
                table: "Equipment",
                columns: new[] { "idEquipment", "currentquantity", "deposit", "lenderId", "nameEquipment", "nameEquipmentck" },
                values: new object[] { 1, 2, "צק פיקדון", "254698745", "מחולל חמצן", 5 });

            migrationBuilder.InsertData(
                table: "Lender",
                columns: new[] { "lenderId", "lenderAdress", "lenderCityId", "lenderName", "lenderPhone" },
                values: new object[] { "254698743", "Rabbi Akiva", 1, "david", "0556987459" });

            migrationBuilder.InsertData(
                table: "Lending",
                columns: new[] { "LendingId", "IdEquipment", "IsReturned", "TimeLending", "borrowId", "deadlineLending", "lenderId" },
                values: new object[] { 1, 1, false, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "246987569", new DateTime(2026, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "254698743" });
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
