using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OrderFlow.Migrations
{
    /// <inheritdoc />
    public partial class migraz : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QR_Codes_Tables_Id",
                table: "QR_Codes");

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

            migrationBuilder.UpdateData(
                table: "Consumables",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "ImagePath", "Name", "Price" },
                values: new object[] { "Geroosterd brood met verse tomaten, knoflook, basilicum en olijfolie.", "", "Bruschetta al Pomodoro", 7.50m });

            migrationBuilder.UpdateData(
                table: "Consumables",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "ImagePath", "Name", "Price" },
                values: new object[] { "Gefrituurde inktvisringen met citroen en pikante tomatensaus.", "", "Calamari Fritti", 9.00m });

            migrationBuilder.UpdateData(
                table: "Consumables",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "ImagePath", "Name", "Price" },
                values: new object[] { "Buffelmozzarella, tomaten, verse basilicum en balsamico-glazuur.", "", "Caprese Salade", 8.50m });

            migrationBuilder.UpdateData(
                table: "Consumables",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Description", "ImagePath", "Name", "Price", "Type" },
                values: new object[] { "Geserveerd met citroen-dille saus, seizoensgroenten en aardappelpuree.", "", "Gegrilde Zalmfilet", 18.50m, 1 });

            migrationBuilder.UpdateData(
                table: "Consumables",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Description", "ImagePath", "Name", "Price", "Type" },
                values: new object[] { "Romige saus met spek, Parmezaanse kaas en eigeel.", "", "Pasta Carbonara", 14.00m, 1 });

            migrationBuilder.UpdateData(
                table: "Consumables",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Description", "ImagePath", "Name", "Price", "Type" },
                values: new object[] { "Malse kipfilet met basilicum-pestosaus, geserveerd met geroosterde groenten.", "", "Gegrilde Kip Pesto", 16.50m, 1 });

            migrationBuilder.UpdateData(
                table: "Consumables",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Description", "ImagePath", "Name", "Price", "Type" },
                values: new object[] { "Traditioneel Italiaans dessert met lagen koffie gedrenkte biscuit, mascarpone en cacao.", "", "Tiramisu", 7.00m, 2 });

            migrationBuilder.UpdateData(
                table: "Consumables",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Description", "ImagePath", "Name", "Price", "Type" },
                values: new object[] { "Warme chocoladetaart met een vloeibare chocoladekern, geserveerd met vanille-ijs.", "", "Chocolade Lava Cake", 8.50m, 2 });

            migrationBuilder.UpdateData(
                table: "Consumables",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Description", "ImagePath", "Name", "Price", "Type" },
                values: new object[] { "Verse munt, limoen, suiker en rum, afgemaakt met bruiswater.", "", "Mojito", 9.00m, 2 });

            migrationBuilder.UpdateData(
                table: "Consumables",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Description", "ImagePath", "Name", "Price", "Type" },
                values: new object[] { "Gemengd fruit met vruchtensap en een vleugje grenadine.", "", "Fruitige Mocktail", 6.50m, 2 });

            migrationBuilder.UpdateData(
                table: "Consumables",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Description", "ImagePath", "Name", "Price", "Type" },
                values: new object[] { "Sterke zwarte koffie.", "", "Espresso", 2.50m, 3 });

            migrationBuilder.UpdateData(
                table: "Consumables",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Description", "ImagePath", "Name", "Price", "Type" },
                values: new object[] { "Espresso met gestoomde melk en een laagje melkschuim.", "", "Cappuccino", 3.50m, 3 });

            migrationBuilder.InsertData(
                table: "Consumables",
                columns: new[] { "Id", "Description", "ImagePath", "Name", "Price", "Type" },
                values: new object[,]
                {
                    { 13, "Gekoelde koffie met ijsblokjes.", "", "Iced Coffee", 4.00m, 3 },
                    { 14, "Vers geperst sinaasappelsap.", "", "Verse Sinaasappelsap", 4.50m, 4 },
                    { 15, "Verfrissende limonade met een vleugje citroen.", "", "Citroenlimonade", 3.50m, 4 },
                    { 16, "Ambachtelijk gebrouwen pale ale.", "", "Lokale Pale Ale", 5.50m, 5 },
                    { 17, "Licht en verfrissend tarwebier.", "", "Witbier", 4.50m, 5 },
                    { 18, "Fresh and juicy apple", "apple.png", "Apple", 1.1m, 0 },
                    { 19, "Delicious cheesy pizza", "pizza.png", "Pizza", 5.15m, 1 },
                    { 20, "Classic sandwich with ham and cheese", "sandwich.png", "Sandwich", 4.3m, 0 },
                    { 21, "Buttery and flaky croissant", "croissant.png", "Croissant", 2m, 0 },
                    { 22, "Classic pasta with marinara sauce", "pasta.png", "Pasta", 9.3m, 1 },
                    { 23, "Juicy beef burger with cheese", "burger.png", "Burger", 4.4m, 1 },
                    { 24, "Refreshing orange juice", "orange-juice.jpg", "Orange Juice", 2m, 4 },
                    { 25, "Carbonated cola drink", "cola.png", "Cola", 1.4m, 4 },
                    { 26, "Refreshing iced tea", "icedtea.png", "Iced Tea", 2m, 4 },
                    { 27, "Homemade lemonade", "lemonade.png", "Lemonade", 3m, 4 },
                    { 28, "Rich and aromatic coffee", "coffee.jpg", "Coffee", 3.1m, 3 },
                    { 29, "Creamy milkshake", "milkshake.png", "Milkshake", 4m, 4 }
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tables_QR_Codes_QRCodeId",
                table: "Tables");

            migrationBuilder.DropIndex(
                name: "IX_Tables_QRCodeId",
                table: "Tables");

            migrationBuilder.DeleteData(
                table: "Consumables",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Consumables",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Consumables",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Consumables",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Consumables",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Consumables",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Consumables",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Consumables",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Consumables",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Consumables",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Consumables",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Consumables",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Consumables",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Consumables",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Consumables",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Consumables",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Consumables",
                keyColumn: "Id",
                keyValue: 29);

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

            migrationBuilder.UpdateData(
                table: "Consumables",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "ImagePath", "Name", "Price" },
                values: new object[] { "Fresh and juicy apple", "apple.png", "Apple", 1.1m });

            migrationBuilder.UpdateData(
                table: "Consumables",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "ImagePath", "Name", "Price" },
                values: new object[] { "Delicious cheesy pizza", "pizza.png", "Pizza", 5.15m });

            migrationBuilder.UpdateData(
                table: "Consumables",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "ImagePath", "Name", "Price" },
                values: new object[] { "Classic sandwich with ham and cheese", "sandwich.png", "Sandwich", 4.3m });

            migrationBuilder.UpdateData(
                table: "Consumables",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Description", "ImagePath", "Name", "Price", "Type" },
                values: new object[] { "Buttery and flaky croissant", "croissant.png", "Croissant", 2m, 0 });

            migrationBuilder.UpdateData(
                table: "Consumables",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Description", "ImagePath", "Name", "Price", "Type" },
                values: new object[] { "Classic pasta with marinara sauce", "pasta.png", "Pasta", 9.3m, 0 });

            migrationBuilder.UpdateData(
                table: "Consumables",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Description", "ImagePath", "Name", "Price", "Type" },
                values: new object[] { "Juicy beef burger with cheese", "burger.png", "Burger", 4.4m, 0 });

            migrationBuilder.UpdateData(
                table: "Consumables",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Description", "ImagePath", "Name", "Price", "Type" },
                values: new object[] { "Refreshing orange juice", "orange-juice.jpg", "Orange Juice", 2m, 1 });

            migrationBuilder.UpdateData(
                table: "Consumables",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Description", "ImagePath", "Name", "Price", "Type" },
                values: new object[] { "Carbonated cola drink", "cola.png", "Cola", 1.4m, 1 });

            migrationBuilder.UpdateData(
                table: "Consumables",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Description", "ImagePath", "Name", "Price", "Type" },
                values: new object[] { "Refreshing iced tea", "icedtea.png", "Iced Tea", 2m, 1 });

            migrationBuilder.UpdateData(
                table: "Consumables",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Description", "ImagePath", "Name", "Price", "Type" },
                values: new object[] { "Homemade lemonade", "lemonade.png", "Lemonade", 3m, 1 });

            migrationBuilder.UpdateData(
                table: "Consumables",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Description", "ImagePath", "Name", "Price", "Type" },
                values: new object[] { "Rich and aromatic coffee", "coffee.jpg", "Coffee", 3.1m, 1 });

            migrationBuilder.UpdateData(
                table: "Consumables",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Description", "ImagePath", "Name", "Price", "Type" },
                values: new object[] { "Creamy milkshake", "milkshake.png", "Milkshake", 4m, 1 });

            migrationBuilder.AddForeignKey(
                name: "FK_QR_Codes_Tables_Id",
                table: "QR_Codes",
                column: "Id",
                principalTable: "Tables",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
