using AltenShopBackProductsApi.Models;
using Microsoft.EntityFrameworkCore;

namespace AltenShopBackProductsApi.Data
{
    public class DataContext : DbContext, IDataContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .Property(p => p.InventoryStatus)
                .HasConversion<string>();
        }
    }
}
