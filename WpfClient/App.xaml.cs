using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using MediatR;
using WpfClient.Views;
using WpfClient.ViewModels;
using WpfClient.Services;
using System;

namespace WpfClient
{
    public partial class App : Application
    {
        private ServiceProvider? _provider; // Holds the DI service provider used to resolve dependencies

        protected override void OnStartup(StartupEventArgs e)
        {
            // Create a new service collection for dependency injection
            var services = new ServiceCollection();

            // Register services, view models, views
            services.AddSingleton<MainViewModel>();
            services.AddSingleton<GrpcListener>();
            services.AddSingleton<IGrpcListener, GrpcListener>();

            // Register MediatR
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(App).Assembly));

            // Register MainWindow
            services.AddSingleton<MainWindow>();

            // Build the provider
            _provider = services.BuildServiceProvider();

            // Show MainWindow and set MainViewModel as DataContext
            var mainWindow = _provider.GetRequiredService<MainWindow>();
            mainWindow.DataContext = _provider.GetRequiredService<MainViewModel>();
            mainWindow.Show();

            base.OnStartup(e);
        }
    }
}


