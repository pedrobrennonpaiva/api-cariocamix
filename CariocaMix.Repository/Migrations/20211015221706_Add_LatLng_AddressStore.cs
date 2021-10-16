using Microsoft.EntityFrameworkCore.Migrations;

namespace CariocaMix.Repository.Migrations
{
    public partial class Add_LatLng_AddressStore : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Lat",
                table: "AddressStore",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Lng",
                table: "AddressStore",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Lat",
                table: "AddressStore");

            migrationBuilder.DropColumn(
                name: "Lng",
                table: "AddressStore");
        }
    }
}
