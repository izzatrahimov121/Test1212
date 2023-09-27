using BigonTask.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BigonTask.Models.Persistence.Configurations
{
    public class BlogPostConfiguration : IEntityTypeConfiguration<BlogPost>
    {
        public void Configure(EntityTypeBuilder<BlogPost> builder)
        {
            builder.Property(m => m.Id).UseIdentityColumn(1,1);
            builder.Property(m => m.Title).IsRequired().HasColumnType("nvarchar").HasMaxLength(200);
            builder.Property(m => m.Body).IsRequired().HasColumnType("nvarchar(max)");
            builder.Property(m => m.ImagePath).IsRequired().HasColumnType("nvarchar").HasMaxLength(50);
            builder.Property(m => m.Slug).IsRequired().HasColumnType("varchar").HasMaxLength(200);
            builder.Property(m => m.CategoryId).HasColumnType("int");
            builder.Property(m => m.PublishedAt).IsRequired().HasColumnType("datetime");
            builder.ConfigureAsAuditable();
           
            builder.HasKey(m => m.Id);
            builder.ToTable("BlogPosts");

            builder.HasOne<Category>()
                          .WithMany()
                          .HasForeignKey(m => m.CategoryId)
                          .HasPrincipalKey(m => m.Id)
                          .OnDelete(DeleteBehavior.NoAction);
            //bir kategory bir nece dene blog postla elaqeli ola biler ona gore 
        }
    }
}
