using BigonTask.AppCode.Services;
using BigonTask.Models.Persistence;
using Microsoft.EntityFrameworkCore;

namespace BigonTask
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<DataContext>(cfg =>
            {
                cfg.UseSqlServer(builder.Configuration.GetConnectionString("cString"));
            });
            builder.Services.AddRouting(cfg => cfg.LowercaseUrls = true);

            builder.Services.Configure<EmailOptions>(cfg =>
            {
                builder.Configuration.GetSection("emailAccount").Bind(cfg);
            });
            builder.Services.AddSingleton<IEmailService, EmailService>();
            builder.Services.AddSingleton<IDateTimeService, DateTimeService>();
            builder.Services.AddScoped<IIdentityService, IdentityService>();
            var app = builder.Build();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseEndpoints(cfg =>
            {
                app.UseEndpoints(endpoints =>
                {
                    endpoints.MapControllerRoute(
                      name: "areas",
                      pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}"
                    );
                    endpoints.MapControllerRoute(
                      name: "default",
                      pattern: "{controller=home}/{action=index}/{id?}"
                    );
                });
            });
            app.Run();
        }
    }
}