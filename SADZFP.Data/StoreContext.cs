﻿using SADZFP.domain.Catalog;
using Microsoft.EntityFrameworkCore;


namespace SADZFP.Data
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options) : base(options)
        {}

        public DbSet<Item> Items { get; set; }
    }
}