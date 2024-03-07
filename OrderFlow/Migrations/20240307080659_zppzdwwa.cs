using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OrderFlow.Migrations
{
    /// <inheritdoc />
    public partial class zppzdwwa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tables_QR_Codes_QRCodeId",
                table: "Tables");

            migrationBuilder.DropIndex(
                name: "IX_Tables_QRCodeId",
                table: "Tables");

            migrationBuilder.DeleteData(
                table: "QR_Codes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "QR_Codes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "QR_Codes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "QR_Codes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DropColumn(
                name: "QRCodeId",
                table: "Tables");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "QR_Codes",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.InsertData(
                table: "Tables",
                columns: new[] { "Id", "TableCode" },
                values: new object[,]
                {
                    { 1, "TN01" },
                    { 2, "TN02" },
                    { 3, "TN03" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_QR_Codes_Tables_Id",
                table: "QR_Codes",
                column: "Id",
                principalTable: "Tables",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QR_Codes_Tables_Id",
                table: "QR_Codes");

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.AddColumn<int>(
                name: "QRCodeId",
                table: "Tables",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "QR_Codes",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.InsertData(
                table: "QR_Codes",
                columns: new[] { "Id", "ImagePath" },
                values: new object[,]
                {
                    { 1, "/qr_code1.png" },
                    { 2, "/qr_code2.png" },
                    { 3, "/qr_code3.png" },
                    { 4, "/qr_code4.png" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tables_QRCodeId",
                table: "Tables",
                column: "QRCodeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tables_QR_Codes_QRCodeId",
                table: "Tables",
                column: "QRCodeId",
                principalTable: "QR_Codes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
