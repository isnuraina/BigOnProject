using Bigon.WebUI.AppCode.Services;
using Bigon.WebUI.Models.Persistences;
using Microsoft.EntityFrameworkCore;

namespace Bigon.WebUI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Services
            builder.Services.AddControllersWithViews();

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

            var app = builder.Build();

            // Middleware pipeline
            app.UseStaticFiles();

            app.UseRouting();

            // Əgər varsa avtorizasiya əlavə edin
            // app.UseAuthorization();

            // Endpoint-lər tək yerdə toplanır
            app.UseEndpoints(endpoints =>
            {
                // Area routelar
                endpoints.MapControllerRoute(
                    name: "areas",
                    pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}");

                // Default route
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=home}/{action=index}/{id?}");
            });

            app.Run();
        }
    }
}
