using Bigon.Data.Persistences;
using Bigon.İnfrastructure.Services.Abstracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;


namespace Bigon.Data
{
    public class DataContextFactory : IDesignTimeDbContextFactory<DataContext>
    {
        public DataContext CreateDbContext(string[] args)
        {
            // Startup layihəsinin kök qovluğunu götürürük (yəni WebUI)
            var basePath = Path.Combine(Directory.GetCurrentDirectory(), "../Bigon.WebUI");

            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<DataContext>();
            var connectionString = configuration.GetConnectionString("cString");

            optionsBuilder.UseSqlServer(connectionString);

            var dateTimeService = new FakeDateTimeService();
            var identityService = new FakeIdentityService();

            return new DataContext(optionsBuilder.Options, dateTimeService, identityService);
        }

    }

    internal class FakeDateTimeService : IDateTimeService
    {
        public DateTime ExecutingTime => DateTime.Now;
    }

    internal class FakeIdentityService : IIdentityService
    {
        public int GetPrincipalId() => 0;
    }
}
