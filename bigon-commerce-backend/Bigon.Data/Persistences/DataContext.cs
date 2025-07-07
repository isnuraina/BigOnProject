using Bigon.İnfrastructure.Commons.Abstracts;
using Bigon.İnfrastructure.Entities;
using Bigon.İnfrastructure.Services.Abstracts;
using Microsoft.EntityFrameworkCore;

namespace Bigon.Data.Persistences
{
    public class DataContext : DbContext
    {
        private readonly IDateTimeService? dateTimeService;
        private readonly IIdentityService? identityService;

        // Runtime zamanı DI ilə işləyəcək constructor
        public DataContext(DbContextOptions<DataContext> options,
                           IDateTimeService dateTimeService,
                           IIdentityService identityService)
            : base(options)
        {
            this.dateTimeService = dateTimeService;
            this.identityService = identityService;
        }

        // Design-time üçün əlavə constructor (məsələn, migration üçün)
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
            // boş - EF Core design-time üçün bunu istifadə edəcək
        }

        public DbSet<Subscriber> Subscribers { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<BlogPost> BlogPosts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataContext).Assembly);
        }

        public override int SaveChanges()
        {
            var changes = this.ChangeTracker.Entries<IAuditableEntity>();

            if (changes != null)
            {
                foreach (var entry in changes.Where(m =>
                    m.State == EntityState.Added ||
                    m.State == EntityState.Modified ||
                    m.State == EntityState.Deleted))
                {
                    switch (entry.State)
                    {
                        case EntityState.Added:
                            entry.Entity.CreatedBy = identityService.GetPrincipalId();
                            entry.Entity.CreatedAt = dateTimeService?.ExecutingTime ?? DateTime.Now;
                            break;

                        case EntityState.Modified:
                            entry.Entity.LastModifiedBy = identityService?.GetPrincipalId();
                            entry.Entity.LastModifiedAt = dateTimeService?.ExecutingTime ?? DateTime.Now;

                            entry.Property(m => m.CreatedBy).IsModified = false;
                            entry.Property(m => m.CreatedAt).IsModified = false;
                            break;

                        case EntityState.Deleted:
                            entry.State = EntityState.Modified;
                            entry.Entity.DeletedBy = identityService?.GetPrincipalId();
                            entry.Entity.DeletedAt = dateTimeService?.ExecutingTime ?? DateTime.Now;

                            entry.Property(m => m.CreatedBy).IsModified = false;
                            entry.Property(m => m.CreatedAt).IsModified = false;
                            entry.Property(m => m.LastModifiedBy).IsModified = false;
                            entry.Property(m => m.LastModifiedAt).IsModified = false;
                            break;
                    }
                }
            }

            return base.SaveChanges();
        }
    }
}
