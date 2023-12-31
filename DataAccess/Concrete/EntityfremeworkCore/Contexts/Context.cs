﻿using DataAccess.Concrete.EntityfremeworkCore.Mapping;
using Entities.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityfremeworkCore.Contexts
{
    public class Context : IdentityDbContext<AppUser,AppRole,long>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=HALIL\\HALIL; database=StockTracking; integrated security=true;TrustServerCertificate=True;Command Timeout=300");
           
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new StockMap());
            modelBuilder.ApplyConfiguration(new CurrencyMap());
            modelBuilder.ApplyConfiguration(new StockUnitMap());
            modelBuilder.ApplyConfiguration(new StockTypeMap());
            modelBuilder.ApplyConfiguration(new StockClassMap());
            modelBuilder.ApplyConfiguration(new AppUserMap());

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Stock> Stocks { get; set; }
        public DbSet<StockClass> StockClasss { get; set; }
        public DbSet<StockType> StockTypes { get; set; }
        public DbSet<StockUnit> StockUnits { get; set; }
        public DbSet<Currency> Currencys { get; set; }
    }
}
