using DataAccess.Concrete.EntityfremeworkCore.Mapping;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityfremeworkCore.Contexts
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=HalilT; database=StockTracking; integrated security=true;TrustServerCertificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new StockMap());
            modelBuilder.ApplyConfiguration(new CurrencyMap());
            modelBuilder.ApplyConfiguration(new StockUnitMap());
            modelBuilder.ApplyConfiguration(new StockTypeMap());
            modelBuilder.ApplyConfiguration(new StockClassMap());
        }

        public DbSet<Stock> Stocks { get; set; }
        public DbSet<StockClass> StockClasss { get; set; }
        public DbSet<StockType> StockTypes { get; set; }
        public DbSet<StockUnit> StockUnits { get; set; }
        public DbSet<Currency> Currencys { get; set; }
    }
}
