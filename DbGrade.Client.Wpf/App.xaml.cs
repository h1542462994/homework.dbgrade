using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Tro.DbGrade.Client.Wpf.Storage;

namespace Tro.DbGrade.Client.Wpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public new static App Current => (App)Application.Current;

        public App()
        {
            var services = new ServiceCollection();
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appSettings.json");
            var configuration = builder.Build();
            services.AddSingleton(configuration);
            ConfigureServices(services, configuration);
            ServiceProvider = services.BuildServiceProvider();

        }

        public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddOptions<StorageOptions>().Bind(configuration.GetSection("RemoteStorage"));
            services.AddSingleton<RemoteStorage>();
            services.AddHttpClient<GradeHttpClient>();
            services.AddSingleton(this);
            services.AddSingleton<GlobalState>();
            services.AddSingleton<SelectorViewModel>();
            services.AddSingleton<PageNavigator>();
        }

        public IServiceProvider ServiceProvider { get; }
    }
}
