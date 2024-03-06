using Microsoft.EntityFrameworkCore;
using OrderFlow.Data.Tables;
using Table = OrderFlow.Data.Tables.Table;

namespace OrderFlow.Data
{
    public class DatabaseDbContext : DbContext
    {
        public DbSet<Table> Tables { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Consumable> Consumables { get; set; }
        public DbSet<OrderedConsumable> OrderedConsumables { get; set; }
        public DbSet<QR_Code> QR_Codes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Tom     : 10.4.28-MariaDB
            // Soufyan : 10.4.21-MariaDB
            // Dean    : 10.4.21-MariaDB

            optionsBuilder.UseMySql(
                "Server=127.0.0.1;User=root;Password=;Database=OrderFlow_Db;Port=3306;",
                ServerVersion.Parse(
                    "10.4.21",
                    Pomelo.EntityFrameworkCore.MySql.Infrastructure.ServerType.MariaDb
                )
            );
            
            // Handig voor development
            optionsBuilder.EnableDetailedErrors();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Table>()
                .HasOne(e => e.QRCode)
                .WithOne(e => e.Table)
                .HasForeignKey<QR_Code>(e => e.Id);

            AddSeeders(modelBuilder);
        }

        private void AddSeeders(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Consumable>()
                .HasData(
                    new Consumable { Id = 1, Name = "Bruschetta al Pomodoro", Description = "Geroosterd brood met verse tomaten, knoflook, basilicum en olijfolie.", Price = 7.50m, ImagePath = "", Type = ConsumableType.Voorgerechten },
                    new Consumable { Id = 2, Name = "Calamari Fritti", Description = "Gefrituurde inktvisringen met citroen en pikante tomatensaus.", Price = 9.00m, ImagePath = "", Type = ConsumableType.Voorgerechten },
                    new Consumable { Id = 3, Name = "Caprese Salade", Description = "Buffelmozzarella, tomaten, verse basilicum en balsamico-glazuur.", Price = 8.50m, ImagePath = "", Type = ConsumableType.Voorgerechten },
                    new Consumable { Id = 4, Name = "Gegrilde Zalmfilet", Description = "Geserveerd met citroen-dille saus, seizoensgroenten en aardappelpuree.", Price = 18.50m, ImagePath = "", Type = ConsumableType.Hoofdgerechten },
                    new Consumable { Id = 5, Name = "Pasta Carbonara", Description = "Romige saus met spek, Parmezaanse kaas en eigeel.", Price = 14.00m, ImagePath = "", Type = ConsumableType.Hoofdgerechten },
                    new Consumable { Id = 6, Name = "Gegrilde Kip Pesto", Description = "Malse kipfilet met basilicum-pestosaus, geserveerd met geroosterde groenten.", Price = 16.50m, ImagePath = "", Type = ConsumableType.Hoofdgerechten },
                    new Consumable { Id = 7, Name = "Tiramisu", Description = "Traditioneel Italiaans dessert met lagen koffie gedrenkte biscuit, mascarpone en cacao.", Price = 7.00m, ImagePath = "", Type = ConsumableType.Desserts },
                    new Consumable { Id = 8, Name = "Chocolade Lava Cake", Description = "Warme chocoladetaart met een vloeibare chocoladekern, geserveerd met vanille-ijs.", Price = 8.50m, ImagePath = "", Type = ConsumableType.Desserts },
                    new Consumable { Id = 9, Name = "Mojito", Description = "Verse munt, limoen, suiker en rum, afgemaakt met bruiswater.", Price = 9.00m, ImagePath = "", Type = ConsumableType.Desserts },
                    new Consumable { Id = 10, Name = "Fruitige Mocktail", Description = "Gemengd fruit met vruchtensap en een vleugje grenadine.", Price = 6.50m, ImagePath = "", Type = ConsumableType.Desserts },
                    new Consumable { Id = 11, Name = "Espresso", Description = "Sterke zwarte koffie.", Price = 2.50m, ImagePath = "", Type = ConsumableType.Koffie },
                    new Consumable { Id = 12, Name = "Cappuccino", Description = "Espresso met gestoomde melk en een laagje melkschuim.", Price = 3.50m, ImagePath = "", Type = ConsumableType.Koffie },
                    new Consumable { Id = 13, Name = "Iced Coffee", Description = "Gekoelde koffie met ijsblokjes.", Price = 4.00m, ImagePath = "", Type = ConsumableType.Koffie },
                    new Consumable { Id = 14, Name = "Verse Sinaasappelsap", Description = "Vers geperst sinaasappelsap.", Price = 4.50m, ImagePath = "", Type = ConsumableType.Frisdranken },
                    new Consumable { Id = 15, Name = "Citroenlimonade", Description = "Verfrissende limonade met een vleugje citroen.", Price = 3.50m, ImagePath = "", Type = ConsumableType.Frisdranken },
                    new Consumable { Id = 16, Name = "Lokale Pale Ale", Description = "Ambachtelijk gebrouwen pale ale.", Price = 5.50m, ImagePath = "", Type = ConsumableType.Bieren },
                    new Consumable { Id = 17, Name = "Witbier", Description = "Licht en verfrissend tarwebier.", Price = 4.50m, ImagePath = "", Type = ConsumableType.Bieren },

                    // custom
                    new Consumable { Id = 18, Name = "Apple", Description = "Fresh and juicy apple", Price = 1.1m, ImagePath = "apple.png", Type = ConsumableType.Voorgerechten },
                    new Consumable { Id = 19, Name = "Pizza", Description = "Delicious cheesy pizza", Price = 5.15m, ImagePath = "pizza.png", Type = ConsumableType.Hoofdgerechten },
                    new Consumable { Id = 20, Name = "Sandwich", Description = "Classic sandwich with ham and cheese", Price = 4.3m, ImagePath = "sandwich.png", Type = ConsumableType.Voorgerechten},
                    new Consumable { Id = 21, Name = "Croissant", Description = "Buttery and flaky croissant", Price = 2m, ImagePath = "croissant.png", Type = ConsumableType.Voorgerechten },
                    new Consumable { Id = 22, Name = "Pasta", Description = "Classic pasta with marinara sauce", Price = 9.3m, ImagePath = "pasta.png", Type = ConsumableType.Hoofdgerechten },
                    new Consumable { Id = 23, Name = "Burger", Description = "Juicy beef burger with cheese", Price = 4.4m, ImagePath = "burger.png", Type = ConsumableType.Hoofdgerechten },

                    new Consumable { Id = 24, Name = "Orange Juice", Description = "Refreshing orange juice", Price = 2m, ImagePath = "orange-juice.jpg", Type = ConsumableType.Frisdranken },
                    new Consumable { Id = 25, Name = "Cola", Description = "Carbonated cola drink", Price = 1.4m, ImagePath = "cola.png", Type = ConsumableType.Frisdranken },
                    new Consumable { Id = 26, Name = "Iced Tea", Description = "Refreshing iced tea", Price = 2m, ImagePath = "icedtea.png", Type = ConsumableType.Frisdranken },
                    new Consumable { Id = 27, Name = "Lemonade", Description = "Homemade lemonade", Price = 3m, ImagePath = "lemonade.png", Type = ConsumableType.Frisdranken },
                    new Consumable { Id = 28, Name = "Coffee", Description = "Rich and aromatic coffee", Price = 3.1m, ImagePath = "coffee.jpg", Type = ConsumableType.Koffie },
                    new Consumable { Id = 29, Name = "Milkshake", Description = "Creamy milkshake", Price = 4m, ImagePath = "milkshake.png", Type = ConsumableType.Frisdranken }
                )
            ;

            //modelBuilder.Entity<QR_Code>()
            //    .HasData(
            //        //new QR_Code { Id = 1, ImagePath = "table1.png" },
            //        //new QR_Code { Id = 2, ImagePath = "table2.png" },
            //        //new QR_Code { Id = 3, ImagePath = "table3.png" },
            //        //new QR_Code { Id = 4, ImagePath = "table4.png" }
            //    )
            //;
        }
    }
}
