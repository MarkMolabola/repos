using FinalProjApp.Data;
using FinalProjApp.Models;
using FinalProjApp.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Syncfusion.Blazor;

namespace FinalProjApp
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

            builder.Services.AddMauiBlazorWebView();

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
            builder.Logging.AddDebug();
#endif

            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Ngo9BigBOggjHTQxAR8/V1JFaF5cXGRCf1FpRmJGdld5fUVHYVZUTXxaS00DNHVRdkdmWH9ccHVSR2ZcVEd/WktWYEg=");
            builder.Services.AddSyncfusionBlazor();

            builder.Services.AddScoped<ICRUD<Child>, ChildCRUD>();
            builder.Services.AddScoped<ICRUD<Guardian>, GuardianCRUD>();
            builder.Services.AddScoped<ICRUD<ScheduleEvent>, ScheduleEventCRUD>();

            builder.Services.AddDbContext<PhotoContext>(options =>
                options.UseSqlite("Data Source=C:\\DATA\\Photos.db"));

            builder.Services.AddDbContext<DataContext>(options =>
                options.UseSqlite("Data Source=C:\\DATA\\DaycareSystem.db"));

            var app = builder.Build();

            try
            {
                using var scope = app.Services.CreateScope();
                var dbContext = scope.ServiceProvider.GetRequiredService<DataContext>();
                dbContext.Database.EnsureCreated();
                var photoDbContext = scope.ServiceProvider.GetRequiredService<PhotoContext>();
                photoDbContext.Database.EnsureCreated();
            }
            catch (Exception ex)
            {
                File.WriteAllText("C:\\DATA\\startup_error.txt", ex.ToString());
                throw;
            }

            return app;
        }
    }
}