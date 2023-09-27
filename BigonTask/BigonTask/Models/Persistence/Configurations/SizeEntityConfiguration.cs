using BigonTask.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BigonTask.Models.Persistence.Configurations
{
    public class SizeEntityConfiguration : IEntityTypeConfiguration<Size>
    {
        public void Configure(EntityTypeBuilder<Size> builder)
        {
            builder.Property(m => m.Name).IsRequired().HasColumnType("nvarchar").HasMaxLength(100);
            builder.Property(m => m.Id).UseIdentityColumn(1,1);
            builder.ConfigureAsAuditable();
            builder.HasKey(m => m.Id);
            builder.ToTable("Sizes");
        }
    }
}
