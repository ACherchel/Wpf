using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WpfApp1.Domain;
using WpfApp1.Domain.Repositories;
using WpfApp1.ModelMapping;
using WpfApp1.Services;
using WpfApp1.ServicesAbstract;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        ServiceProvider serviceProvider;
        public App()
        {
            ServiceCollection services = new ServiceCollection();
            ConfigureServices(services);
            serviceProvider = services.BuildServiceProvider();
        }

        private void ConfigureServices(ServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(optns =>
            {
                optns.UseSqlite("Data Source=ShopDb.db");
            });
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            // services.AddTransient<IProductsService, ProductsService>();
            services.AddTransient<IServiceManager, ServiceManager>();
            services.AddSingleton<MainWindow>();
            services.AddAutoMapper((cnfg) =>
            {
                cnfg.AddProfile(new MappingProfile());
            });
        }
        private void OnStartup(object sender, StartupEventArgs e)
        {
            var mainWindow = serviceProvider.GetService<MainWindow>();
            mainWindow.Show();
        }
    }
}
