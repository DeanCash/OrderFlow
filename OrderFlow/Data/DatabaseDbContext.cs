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
        }
    }
}
