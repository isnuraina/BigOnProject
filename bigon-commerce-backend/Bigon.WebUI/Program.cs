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
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<DataContext>(
                cfg =>
                {
                    cfg.UseSqlServer(builder.Configuration.GetConnectionString("cString"),
                        opt =>
                        {
                            opt.MigrationsHistoryTable("Migrations");
                        });
                });
            builder.Services.AddRouting(cfg => cfg.LowercaseUrls = true);
            //builder.Services.Configure<EmailOptions>(cfg =>
            //{
            //    builder.Configuration.GetSection(cfg.GetType().Name).Bind(cfg);
            //});

            builder.Services.Configure<EmailOptions>(
    builder.Configuration.GetSection("emailAccount"));


            builder.Services.AddSingleton<IEmailService,EmailService>(); 

            var app = builder.Build();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseEndpoints(cfg =>
            {
                cfg.MapControllerRoute("default", "{controller=home}/{action=index}/{id?}");
            });

            app.Run();
        }
    }
}
