using Bigon.Business;
using Bigon.Data;
using Bigon.İnfrastructure.Services.Abstracts;
using Bigon.İnfrastructure.Services.Concrates;
using Bigon.İnfrastructure.Services.Configurations;
using Bigon.WebUI.Models.Persistences;
using Microsoft.EntityFrameworkCore;
namespace Bigon.WebUI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllersWithViews();

            DataServiceInjection.InstallDataServices(builder.Services, builder.Configuration);


            builder.Services.AddDbContext<DataContext>(cfg =>
            {
                cfg.UseSqlServer(builder.Configuration.GetConnectionString("cString"), opt =>
                {
                    opt.MigrationsHistoryTable("Migrations");
                });
            });

            builder.Services.AddRouting(cfg => cfg.LowercaseUrls = true);




            builder.Services.Configure<EmailOptions>(builder.Configuration.GetSection("emailAccount"));

            builder.Services.AddSingleton<IEmailService, EmailService>();
            builder.Services.AddSingleton<IDateTimeService, DateTimeService>();
            builder.Services.AddScoped<IIdentityService, IdentityService>();

            builder.Services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(typeof(IBusinessReferance).Assembly);
            });

           

            var app = builder.Build();

            app.UseStaticFiles();

            app.UseRouting();

           
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "areas",
                    pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=home}/{action=index}/{id?}");
            });

            app.Run();
        }
    }
}





