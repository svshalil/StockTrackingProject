using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityfremeworkCore.Mapping
{
    public class StockMap : IEntityTypeConfiguration<Stock>
    {
        public void Configure(EntityTypeBuilder<Stock> builder)
        {
            builder.HasKey(I => I.ID);
            builder.Property(I => I.ID).HasColumnType("bigint").UseIdentityColumn();
            builder.Property(I => I.ShelfInformation).HasMaxLength(50);
            builder.Property(I => I.CriticalAmount).HasMaxLength(50);
            builder.Property(I => I.StockClassID).HasColumnType("bigint");
            builder.Property(I => I.StockTypeID).HasColumnType("bigint");
            builder.Property(I => I.StockUnitID).HasColumnType("bigint");
            builder.Property(I => I.Amount).HasColumnType("int");
            builder.Property(I => I.Status).HasColumnType("bit");
            builder.Property(I => I.RecordDate).HasColumnType("datetime");

            builder.HasIndex(I => I.ID);
            builder.HasIndex(I => I.RecordDate);


            builder.HasOne(I => I.StockClasss).WithMany(I => I.Stocks).HasForeignKey(I => I.StockClassID);
            builder.HasOne(I => I.StockTypes).WithMany(I => I.Stocks).HasForeignKey(I => I.StockTypeID).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(I => I.StockUnits).WithMany(I => I.Stocks).HasForeignKey(I => I.StockUnitID);


        }
    }
}
