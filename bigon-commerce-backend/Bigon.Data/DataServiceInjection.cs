using Bigon.Data.Persistences;
using Bigon.İnfrastructure.Commons.Abstracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Bigon.Data
{
    public static class DataServiceInjection
    {
        public static IServiceCollection InstallDataServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<DbContext, DataContext>(cfg =>
            {

                cfg.UseSqlServer(configuration.GetConnectionString("cString"),
                    opt =>
                    {
                        opt.MigrationsHistoryTable("Migrations");
                    });

            });

            var repoInterfaceType = typeof(IRepository<>);
            var abstractRepositoryAssembly = repoInterfaceType.Assembly;

            var concretRepositoryAssembly = typeof(DataServiceInjection).Assembly;


            foreach (var item in abstractRepositoryAssembly.GetTypes().Where(m => m.IsInterface && ((TypeInfo)m).ImplementedInterfaces
            .Any(x => x.Name.Equals("IRepository`1"))
            ))
            {
                var concrateRepository = concretRepositoryAssembly.GetTypes()
                    .FirstOrDefault(m => m.IsClass && item.IsAssignableFrom(m));
                if(concrateRepository!=null)
                    services.AddScoped(item, concrateRepository);

            }

            return services;
        }

    }
}
 