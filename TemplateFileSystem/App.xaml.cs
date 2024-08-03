namespace TemplateFileSystem;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.IO;
using System.Windows;
using Business.Interfaces;
using Business.Services;
using Data.DbContexts;
using Data.Repositories;
using Presentation.ViewModels;
using Presentation.Views;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    private readonly IHost _host;

    public App()
    {
        _host = Host.CreateDefaultBuilder()
            .ConfigureServices((context, services) =>
            {
                // Obtener la ruta del archivo de la base de datos SQLite en el directorio de la aplicación
                string dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "configuration.db");

                services.AddDbContext<ConfigurationContext>(options =>
                    options.UseSqlite($"Data Source={dbPath}"));

                services.AddScoped<IConfigurationRepository, ConfigurationRepository>();
                services.AddScoped<IConfigurationService, ConfigurationService>();

                services.AddTransient<ConfigurationViewModel>();
                services.AddTransient<MainWindowViewModel>();
                services.AddTransient<ConfigurationView>();
                services.AddTransient<MainWindow>();
            })
            .Build();
    } // end App

    protected override async void OnStartup(StartupEventArgs e)
    {
        // Crear el directorio si no existe
        string dbDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data");
        if (!Directory.Exists(dbDirectory)) Directory.CreateDirectory(dbDirectory);

        await _host.StartAsync();
        ApplyMigrations();

        MainWindow mainWindow = _host.Services.GetRequiredService<MainWindow>();
        mainWindow.Show();
        base.OnStartup(e);
    } // end OnStartup

    protected override async void OnExit(ExitEventArgs e)
    {
        await _host.StopAsync();
        _host.Dispose();
        base.OnExit(e);
    } // end OnExit

    private void ApplyMigrations()
    {
        using IServiceScope scope = _host.Services.CreateScope();
        ConfigurationContext context = scope.ServiceProvider.GetRequiredService<ConfigurationContext>();
        context.Database.Migrate();
    } // end ApplyMigrations
}