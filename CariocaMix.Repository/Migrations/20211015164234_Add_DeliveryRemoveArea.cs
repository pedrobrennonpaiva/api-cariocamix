using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CariocaMix.Repository.Migrations
{
    public partial class Add_DeliveryRemoveArea : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AddressStore_StoreId",
                table: "AddressStore");

            migrationBuilder.CreateTable(
                name: "DeliveryRemoveArea",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StoreId = table.Column<long>(type: "bigint", nullable: false),
                    ShapeIndex = table.Column<int>(type: "int", nullable: false),
                    Lat = table.Column<double>(type: "float", nullable: false),
                    Lng = table.Column<double>(type: "float", nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryRemoveArea", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DeliveryRemoveArea_Store_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Store",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AddressStore_StoreId",
                table: "AddressStore",
                column: "StoreId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryRemoveArea_StoreId",
                table: "DeliveryRemoveArea",
                column: "StoreId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DeliveryRemoveArea");

            migrationBuilder.DropIndex(
                name: "IX_AddressStore_StoreId",
                table: "AddressStore");

            migrationBuilder.CreateIndex(
                name: "IX_AddressStore_StoreId",
                table: "AddressStore",
                column: "StoreId");
        }
    }
}
