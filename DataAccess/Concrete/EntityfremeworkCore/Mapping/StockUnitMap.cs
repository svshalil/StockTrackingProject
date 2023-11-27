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
    public class StockUnitMap : IEntityTypeConfiguration<StockUnit>
    {
        public void Configure(EntityTypeBuilder<StockUnit> builder)
        {
            builder.HasKey(I => I.ID);
            builder.Property(I => I.AmountUnit).HasMaxLength(50);
            builder.Property(I => I.Description).HasColumnType("ntext");
            builder.Property(I => I.PurchasePriceCurrency).HasMaxLength(10);
            builder.Property(I => I.SalePriceCurrency).HasMaxLength(10);

            builder.HasIndex(I => I.ID);
            builder.HasIndex(I => I.StockUnitCode);

            builder.HasOne(I => I.StockTypes).WithMany(I=>I.StockUnits).HasForeignKey(I => I.StockTypeID);
        }
    }
}
