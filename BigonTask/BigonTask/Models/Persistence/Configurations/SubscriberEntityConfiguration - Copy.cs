using BigonTask.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BigonTask.Models.Persistence.Configurations
{
    public class SubscriberEntityConfiguration : IEntityTypeConfiguration<Subscriber>
    {
        public void Configure(EntityTypeBuilder<Subscriber> builder)
        {
            builder.Property(m => m.Email).HasColumnType("varchar").HasMaxLength(100);
        
            builder.ConfigureAsAuditable();

            builder.HasKey(m => m.Email);

            builder.ToTable("Subscribers");
        }
    }
}
