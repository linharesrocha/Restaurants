﻿using Microsoft.EntityFrameworkCore;
using Restaurants.Domain.Entities;

namespace Restaurants.Infrastructure.Persistence
{
    internal class RestaurantsDbContext : DbContext
    {
        public RestaurantsDbContext(DbContextOptions<RestaurantsDbContext> options) : base(options)
        {
            
        }

        internal DbSet<Restaurant> Restaurants { get; set; }    
        internal DbSet<Dish> Dishes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)  
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Restaurant>().OwnsOne(x => x.Address);

            modelBuilder.Entity<Restaurant>().HasMany(x => x.Dishes).WithOne().HasForeignKey(x => x.RestaurantId);
        }
    }
}
