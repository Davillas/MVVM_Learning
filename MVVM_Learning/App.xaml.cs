using System.Linq;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MVVM_Learning.Models;
using MVVM_Learning.Services;
using MVVM_Learning.ViewModels;

namespace MVVM_Learning
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static bool IsDesignMode { get; private set; } = true;

        

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
        }

        public static void ConfigureServices(HostBuilderContext host, IServiceCollection services)
        {
            services.AddSingleton<DataService>();
            services.AddSingleton<CountriesStatisticsViewModel>();
        }
    }
}
