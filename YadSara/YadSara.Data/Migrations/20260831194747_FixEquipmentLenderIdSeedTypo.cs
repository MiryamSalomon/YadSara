using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YadSara.Data.Migrations
{
    public partial class FixEquipmentLenderIdSeedTypo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Equipment",
                keyColumn: "idEquipment",
                keyValue: 1,
                column: "lenderId",
                value: "254698743");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Equipment",
                keyColumn: "idEquipment",
                keyValue: 1,
                column: "lenderId",
                value: "254698745");
        }
    }
}
