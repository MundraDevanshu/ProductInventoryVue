using Data_Layer.Entity;
using Microsoft.EntityFrameworkCore;

namespace Data_Layer.DbContextFile
{
    public class ProductContext : DbContext
    {
        public ProductContext()
        {
        }

        public ProductContext(DbContextOptions<ProductContext> options)
       : base(options)
        { }

        public DbSet<Product> Products { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().Property(m => m.Title).HasMaxLength(50).IsRequired();
            modelBuilder.Entity<Product>().Property(m => m.Description).IsRequired();
            modelBuilder.Entity<Product>().Property(m => m.Price).IsRequired();
            modelBuilder.Entity<Product>().Property(m => m.Category).IsRequired();
            base.OnModelCreating(modelBuilder);
        }
    }
}
