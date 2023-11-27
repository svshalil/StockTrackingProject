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
            builder.Property(I => I.ID).HasColumnType("bigint").UseIdentityColumn();
            builder.Property(I => I.AmountUnit).HasMaxLength(50);
            builder.Property(I => I.Description).HasColumnType("ntext");
            builder.Property(I => I.StockUnitCode).HasColumnType("bigint");
            builder.Property(I => I.StockUnitName).HasMaxLength(100);
            builder.Property(I => I.StockTypeID).HasColumnType("bigint");
            builder.Property(I => I.PurchasePrice).HasColumnType("decimal");
            builder.Property(I => I.PurchasePriceCurrencyID).HasColumnType("bigint");
            builder.Property(I => I.SalePriceCurrencyID).HasColumnType("bigint");
            builder.Property(I => I.PaperWeight).HasColumnType("int");
            builder.Property(I => I.SalePrice).HasColumnType("decimal");
            builder.Property(I => I.Status).HasColumnType("bit");
            builder.Property(I => I.RecordDate).HasColumnType("datetime");

            builder.HasIndex(I => I.ID);
            builder.HasIndex(I => I.StockUnitCode);

            builder.HasOne(I => I.StockTypes).WithMany(I=>I.StockUnits).HasForeignKey(I => I.StockTypeID);
        }
    }
}
