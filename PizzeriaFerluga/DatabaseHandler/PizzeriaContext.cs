using DatabaseHandler.Configurations;
using DatabaseHandler.Models;

using Microsoft.EntityFrameworkCore;

namespace DatabaseHandler
{
    public class PizzeriaContext : DbContext
    {
        public PizzeriaContext(DbContextOptions options) : base(options)
        {
        }

        public virtual DbSet<PizzaOrder> PizzaOrders { get; set; }
        public virtual DbSet<Receipt> Receipts { get; set; }


        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //    => optionsBuilder.UseSqlServer("Data Source=Pax; Initial Catalog=PizzeriaFerluga1; Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PizzaOrdersConfiguration());
            modelBuilder.ApplyConfiguration(new ReceiptConfiguration());
        }

    }
}