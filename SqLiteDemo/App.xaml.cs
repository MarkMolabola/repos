using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
using System.Data;
using System.Windows;

namespace SqLiteDemo
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private ServiceProvider _serviceProvider;

        public App()
        {
            ServiceCollection services = new ServiceCollection();
            services.AddDbContext<Data.ProductContext>(options =>
            {
                options.UseSqlite("Data Source=products.db");
            });//register ProductContext with SQLite configuration
            services.AddSingleton<MainWindow>();//register MainWindow as singleton
            _serviceProvider = services.BuildServiceProvider();
        }
        private void OnStartUp(object sender, StartupEventArgs e)
        {
            var mainWindow = _serviceProvider.GetService<MainWindow>();
            mainWindow.Show();
        }


    }

}
