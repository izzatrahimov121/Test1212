using BigonTask.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BigonTask.Models.Persistence.Configurations
{
    public class ColorEntityConfiguration : IEntityTypeConfiguration<Color>
    {
        public void Configure(EntityTypeBuilder<Color> builder)
        {
            builder.Property(m => m.Name).IsRequired().HasColumnType("nvarchar").HasMaxLength(100);
            builder.Property(m => m.CreatedBy).IsRequired().HasColumnType("int");
            builder.Property(m => m.CreatedAt).IsRequired().HasColumnType("datetime");
            builder.Property(m => m.LastModifiedBy).HasColumnType("int");
            builder.HasKey(m => m.Id);
            builder.ToTable("Colors");
        }
    }
}
