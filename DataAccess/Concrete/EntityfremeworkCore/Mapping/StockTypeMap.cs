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
    public class StockTypeMap : IEntityTypeConfiguration<StockType>
    {
        public void Configure(EntityTypeBuilder<StockType> builder)
        {
            builder.HasKey(I => I.ID);
            builder.Property(I => I.StockTypeName).HasMaxLength(100);

            builder.HasIndex(I => I.ID);
            builder.HasIndex(I => I.StockTypeName);


        }
    }
}
