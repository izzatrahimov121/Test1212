using BigonTask.Models.Entities.Commons;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BigonTask.Models.Persistence.Configurations
{
    public static class ConfigurationHelper
    {
        public static void ConfigureAsAuditable<T>(this EntityTypeBuilder<T> builder)
              where T : AuditableEntity
        {
            builder.Property(m => m.CreatedBy).IsRequired().HasColumnType("int");
            builder.Property(m => m.CreatedAt).IsRequired().HasColumnType("datetime");
            builder.Property(m => m.LastModifiedBy).HasColumnType("int");
            builder.Property(m => m.LastModifiedAt).HasColumnType("datetime");
            builder.Property(m => m.DeletedAt).HasColumnType("datetime");
            builder.Property(m => m.DeletedBy).HasColumnType("int");
        }

    }
}
