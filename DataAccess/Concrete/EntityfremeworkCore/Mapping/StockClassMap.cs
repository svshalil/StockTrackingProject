using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityfremeworkCore.Mapping
{
    public class StockClassMap : IEntityTypeConfiguration<StockClass>
    {
        public void Configure(EntityTypeBuilder<StockClass> builder)
        {
            builder.HasKey(I => I.ID);
            builder.Property(I => I.ID).HasColumnType("bigint").UseIdentityColumn();
            builder.Property(I => I.StockClassName).HasMaxLength(100);

            builder.HasIndex(I => I.ID);
            builder.HasIndex(I => I.StockClassName);
        }
    }
}
