using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Daycare_Management.Services;
using Daycare_Management.Models;
using Daycare_Management.Data;

namespace Daycare_Management
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });
            builder.Services.AddSingleton<ICRUD<Child>, ChildCRUD>();
            builder.Services.AddSingleton<ICRUD<Guardian>, GuardianCRUD>();
            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddDbContext<Data.DataContext>(options =>
            {
                options.UseSqlite("Data Source=DaycareSystem.db");
            });
            var app = builder.Build();
            using (var scope = app.Services.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<DataContext>();
                db.Database.EnsureCreated();
            }
            builder.Services.AddMauiBlazorWebView();


#if DEBUG
    		builder.Services.AddBlazorWebViewDeveloperTools();
            
            builder.Logging.AddDebug();
            
            
#endif

            return app;
        }
    }
}
