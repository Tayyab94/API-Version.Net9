using Microsoft.EntityFrameworkCore;

namespace Project.APIS.Models
{
    public static class ProductSeed
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            // Seed data for ProductV1
            modelBuilder.Entity<ProductV1>().HasData(
                new ProductV1 { Id = 1, Name = "Product A" },
                new ProductV1 { Id = 2, Name = "Product B" },
                new ProductV1 { Id = 3, Name = "Product C" },
                new ProductV1 { Id = 4, Name = "Product D" },
                new ProductV1 { Id = 5, Name = "Product E" }
            );

            //// Seed data for ProductV2
            //modelBuilder.Entity<ProductV2>().HasData(
            //    new ProductV2
            //    {
            //        Id = 1,
            //        Name = "Product A",
            //        ProductPrice = new ProductPrice { Amount = 10.99m, Currency = "USD" }
            //    },
            //    new ProductV2
            //    {
            //        Id = 2,
            //        Name = "Product B",
            //        ProductPrice = new ProductPrice { Amount = 20.49m, Currency = "USD" }
            //    },
            //    new ProductV2
            //    {
            //        Id = 3,
            //        Name = "Product C",
            //        ProductPrice = new ProductPrice { Amount = 15.75m, Currency = "EUR" }
            //    },
            //    new ProductV2
            //    {
            //        Id = 4,
            //        Name = "Product D",
            //        ProductPrice = new ProductPrice { Amount = 25.00m, Currency = "GBP" }
            //    },
            //    new ProductV2
            //    {
            //        Id = 5,
            //        Name = "Product E",
            //        ProductPrice = new ProductPrice { Amount = 30.99m, Currency = "USD" }
            //    }
            //);
        }
    }
}
