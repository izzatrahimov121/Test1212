using BigonTask.AppCode.Services;
using BigonTask.Models.Entities;
using BigonTask.Models.Entities.Commons;
using BigonTask.Models.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;


namespace BigonTask.Models.Persistence
{
    public class DataContext:DbContext
    {
        private readonly IDateTimeService dateTimeService;
        private readonly IIdentityService identityService;
        public DataContext(DbContextOptions options, IDateTimeService dateTimeService,IIdentityService identityService)
            : base(options)
        {
            this.dateTimeService = dateTimeService;
            this.identityService=identityService;
        }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<BlogPost> BlogPosts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ContactPost> ContactPosts { get; set; }
        public DbSet<Faq> Faqs { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Subscriber> Subscribers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataContext).Assembly);

        }
        public override int SaveChanges()
        {
            var changeSet = ChangeTracker.Entries<IAuditableEntity>();

            if (changeSet != null)
            {
                foreach (var entry in changeSet.Where(c => c.State == EntityState.Added || c.State == EntityState.Modified || c.State == EntityState.Deleted))
                {
            
                    switch (entry.State)
                    {
                        case EntityState.Added:
                            entry.Entity.CreatedAt = dateTimeService.ExecutingTime;
                            entry.Entity.CreatedBy = identityService.GetPrincibleId();
                            break;       
                        case EntityState.Modified:
                            entry.Entity.LastModifiedAt = dateTimeService.ExecutingTime;
                            entry.Entity.LastModifiedBy = identityService.GetPrincibleId();
                            break;
                        case EntityState.Deleted:
                            entry.State = EntityState.Modified;
                            entry.Entity.DeletedAt = dateTimeService.ExecutingTime;
                            entry.Entity.DeletedBy = identityService.GetPrincibleId();
                            break;
                        default:
                            break;
                    }
                
                }
            }
            return base.SaveChanges();
        }
    }
}
