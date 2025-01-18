using Microsoft.EntityFrameworkCore;

namespace Project.APIS.Models
{
    public class ProductDbContext :DbContext
    {
        public DbSet<ProductV1> ProductsV1 { get; set; }
        //public DbSet<ProductV2> ProductsV2 { get; set; }

        public ProductDbContext(DbContextOptions<ProductDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //// Configure ProductPrice as an owned type for ProductV2
            //modelBuilder.Entity<ProductV2>().OwnsOne(p => p.ProductPrice);

            // Seed data
            ProductSeed.Seed(modelBuilder);
        }
    }
}
