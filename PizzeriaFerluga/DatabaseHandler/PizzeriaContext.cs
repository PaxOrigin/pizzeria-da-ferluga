using DatabaseHandler.Configurations;
using DatabaseHandler.Models;

using Microsoft.EntityFrameworkCore;

namespace DatabaseHandler
{
    public class PizzeriaContext : DbContext
    {

        public virtual DbSet<PizzaOrder> PizzaOrders { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<Receipt> Receipts { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlServer("Data Source=Pax; Initial Catalog=ToNpata_Elo_Prod; Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new OrdersConfiguration());
            modelBuilder.ApplyConfiguration(new PizzaOrdersConfiguration());
            modelBuilder.ApplyConfiguration(new ReceiptConfiguration());
        }

    }
}