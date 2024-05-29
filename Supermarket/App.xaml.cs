using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using Supermarket.MVVM.ViewModel;
using Supermarket.Core;
using Supermarket.Services;
using Microsoft.EntityFrameworkCore;
using Supermarket.MVVM.Model;
using Supermarket.MVVM.Model.BusinessLogicLayer;

namespace Supermarket
{
    public partial class App : Application
    {
        private readonly ServiceProvider _serviceProvider;

        public static MainViewModel MainVM { get; set; }
        public App()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddSingleton<MainWindow>(provider => new MainWindow()
            {
                DataContext = provider.GetRequiredService<MainViewModel>()
            });

            services.AddSingleton<MainViewModel>(); // main

            services.AddSingleton<HomeViewModel>();
            services.AddSingleton<LoginViewModel>(); // login
            services.AddSingleton<RegisterViewModel>(); // register
            services.AddSingleton<UserViewModel>(); // profile
            services.AddSingleton<DistributorViewModel>(); // distributor
            services.AddSingleton<CategoryViewModel>(); // category
            services.AddSingleton<ProductViewModel>(); // product
            services.AddSingleton<StockViewModel>(); // stock

            services.AddSingleton<INavigationService, NavigationService>();

            services.AddDbContext<SupermarketDBContext>(); // Use scoped lifetime

            services.AddTransient<UserBLL>();
            services.AddTransient<DistributorBLL>();
            services.AddTransient<CategoryBLL>();
            services.AddTransient<ProductBLL>();
            services.AddTransient<ProductReceiptBLL>();
            services.AddTransient<ReceiptBLL>();
            services.AddTransient<StockBLL>();

            services.AddSingleton<Func<Type, ViewModel>>(serviceProvider => viewModelType => serviceProvider.GetRequiredService(viewModelType) as ViewModel);

            _serviceProvider = services.BuildServiceProvider();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            var mainWindow = _serviceProvider.GetService<MainWindow>();
            MainVM = _serviceProvider.GetRequiredService<MainViewModel>();
            mainWindow.Show();
        }
    }
}
