using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using OrderFlow.Data.Tables;
using System.Data.Common;
using System.Transactions;
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
                    new Consumable { Id = 1, Name = "Apple", Description = "Fresh and juicy apple", Price = 1.1m, ImagePath = "apple.png", Type = ConsumableType.Food },
                    new Consumable { Id = 2, Name = "Pizza", Description = "Delicious cheesy pizza", Price = 5.15m, ImagePath = "pizza.png", Type = ConsumableType.Food },
                    new Consumable { Id = 3, Name = "Sandwich", Description = "Classic sandwich with ham and cheese", Price = 4.3m, ImagePath = "sandwich.png", Type = ConsumableType.Food },
                    new Consumable { Id = 4, Name = "Croissant", Description = "Buttery and flaky croissant", Price = 2m, ImagePath = "croissant.png", Type = ConsumableType.Food },
                    new Consumable { Id = 5, Name = "Pasta", Description = "Classic pasta with marinara sauce", Price = 9.3m, ImagePath = "pasta.png", Type = ConsumableType.Food },
                    new Consumable { Id = 6, Name = "Burger", Description = "Juicy beef burger with cheese", Price = 4.4m, ImagePath = "burger.png", Type = ConsumableType.Food },

                    new Consumable { Id = 7, Name = "Orange Juice", Description = "Refreshing orange juice", Price = 2m, ImagePath = "orange-juice.jpg", Type = ConsumableType.Drink },
                    new Consumable { Id = 8, Name = "Cola", Description = "Carbonated cola drink", Price = 1.4m, ImagePath = "cola.png", Type = ConsumableType.Drink },
                    new Consumable { Id = 9, Name = "Iced Tea", Description = "Refreshing iced tea", Price = 2m, ImagePath = "icedtea.png", Type = ConsumableType.Drink },
                    new Consumable { Id = 10, Name = "Lemonade", Description = "Homemade lemonade", Price = 3m, ImagePath = "lemonade.png", Type = ConsumableType.Drink },
                    new Consumable { Id = 11, Name = "Coffee", Description = "Rich and aromatic coffee", Price = 3.1m, ImagePath = "coffee.jpg", Type = ConsumableType.Drink },
                    new Consumable { Id = 12, Name = "Milkshake", Description = "Creamy milkshake", Price = 4m, ImagePath = "milkshake.png", Type = ConsumableType.Drink }
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
