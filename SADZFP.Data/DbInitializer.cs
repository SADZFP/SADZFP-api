using SADZFP.domain.Catalog;
using Microsoft.EntityFrameworkCore;


namespace SADZFP.Data
{
    public class DbInitializer
    {
        public static void Initialize(ModelBuilder builder)
        {
            builder.Entity<Item>().HasData(
                new Item("Shirt", "Ohio State Shirt", "Nike", 29.99m)
                {
                    Id = 1
                },
                 new Item("Shorts", "Ohio States shorts", "Nike", 44.99M)
                 {
                     Id = 2
                 }

            );
        }
    }
}