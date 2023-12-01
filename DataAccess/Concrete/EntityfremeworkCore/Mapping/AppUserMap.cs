using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrete.EntityfremeworkCore.Mapping
{
    public class AppUserMap : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.Property(I =>I.FirstName).HasMaxLength(150);
            builder.Property(I =>I.SurName).HasMaxLength(150);
            builder.Property(I =>I.Picture).HasColumnType("ntext");
        }
    }
}
