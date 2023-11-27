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
    public class CurrencyMap : IEntityTypeConfiguration<Currency>
    {
        public void Configure(EntityTypeBuilder<Currency> builder)
        {
            builder.HasKey(I => I.ID);
            builder.Property(I => I.ID).HasColumnType("bigint").UseIdentityColumn();
            builder.Property(I => I.Name).HasMaxLength(100);
            builder.Property(I => I.Symbol).HasMaxLength(10);

            builder.HasIndex(I => I.ID);
        }
    }
}
