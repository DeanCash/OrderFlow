using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderFlow.Migrations
{
    /// <inheritdoc />
    public partial class zazazaza : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderedConsumables_Orders_OrderId1",
                table: "OrderedConsumables");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Tables_TableId1",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_TableId1",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_OrderedConsumables_OrderId1",
                table: "OrderedConsumables");

            migrationBuilder.DropColumn(
                name: "TableId1",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "OrderId1",
                table: "OrderedConsumables");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TableId1",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OrderId1",
                table: "OrderedConsumables",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_TableId1",
                table: "Orders",
                column: "TableId1");

            migrationBuilder.CreateIndex(
                name: "IX_OrderedConsumables_OrderId1",
                table: "OrderedConsumables",
                column: "OrderId1");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderedConsumables_Orders_OrderId1",
                table: "OrderedConsumables",
                column: "OrderId1",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Tables_TableId1",
                table: "Orders",
                column: "TableId1",
                principalTable: "Tables",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
