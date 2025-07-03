using Bigon.İnfrastructure.Commons.Abstracts;
using Bigon.İnfrastructure.Services.Abstracts;
using Bigon.İnfrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Bigon.WebUI.Models.Persistences
{
    public class DataContext:DbContext
    {
        private readonly IDateTimeService dateTimeService;
        private readonly IIdentityService identityService;
        public DataContext(DbContextOptions options,IDateTimeService dateTimeService,IIdentityService identityService):base(options)
        {
            this.dateTimeService = dateTimeService;
            this.identityService = identityService;
        }
        public DbSet<Subscriber> Subscribers { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Brand> Brands { get; set; }
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
                foreach (var entry in changes.Where(m => m.State == EntityState.Added || m.State == EntityState.Modified  || m.State==EntityState.Deleted))
                {
                    switch (entry.State)
                    {
                        case EntityState.Added:
                            entry.Entity.CreatedBy = identityService.GetPrincipalId();
                            entry.Entity.CreatedAt = dateTimeService.ExecutingTime;
                            break;
                        case EntityState.Modified:
                            entry.Entity.LastModifiedBy = identityService.GetPrincipalId();
                            entry.Entity.LastModifiedAt = dateTimeService.ExecutingTime;
                            break;
                        case EntityState.Deleted:
                            entry.State = EntityState.Modified;
                            entry.Entity.DeletedBy = identityService.GetPrincipalId();
                            entry.Entity.DeletedAt = dateTimeService.ExecutingTime;
                            break;
                    }
                }
            }
            return base.SaveChanges();
        }
    }
}
