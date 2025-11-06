using Assignment_12._3._2_CRUDappMAUI.Models;

using Assignment_12._3._2_CRUDappMAUI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Assignment_12._3._2_CRUDappMAUI
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
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif
            builder.Services.AddDbContext<Data.DataContext>(options =>
            {
                options.UseSqlite("Data Source=Children.db");
            });

            builder.Services.AddSingleton<Services.ICRUD<Child>, Services.ChildCRUD>();
            builder.Services.AddSingleton<Services.ICRUD<Guardian>, Services.GuardianCRUD>();

            return builder.Build();
        }
    }
}
