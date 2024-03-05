using AnimeJail.App.Data;
using AnimeJail.App.Enums;
using AnimeJail.App.Methods;
using AnimeJail.App.Models;
using AnimeJail.App.Windows;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Configuration;
using System.Data;
using System.Windows;

namespace AnimeJail.App
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        //public static IHost? AppHost { get; private set; }

        //public App()
        //{
        //    AppHost = Host.CreateDefaultBuilder()
        //        .ConfigureServices((hostContext, services) =>
        //        {
        //            services.AddSingleton<LoginWindow>();
        //            services.AddSingleton<MainWindow>();
        //            services.AddTransient<DataFromDb>();
        //        })
        //        .Build();
        //}

        //protected override async void OnStartup(StartupEventArgs e)
        //{
        //    await AppHost!.StartAsync();

        //    var startupForm = AppHost.Services.GetRequiredService<LoginWindow>();
        //    startupForm.Show();

        //    base.OnStartup(e);
        //}

        //protected override async void OnExit(ExitEventArgs e)
        //{
        //    await AppHost!.StopAsync();
        //    base.OnExit(e);
        //}

        public static TrueContext Context = new TrueContext();
        public static User CurrentUser = null;
        public static EmployeeUserRole CurrentRole;
    }   
}
