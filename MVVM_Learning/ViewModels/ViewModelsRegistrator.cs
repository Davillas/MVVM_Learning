using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace MVVM_Learning.ViewModels
{
    internal static class ViewModelsRegistrator
    {
        public static IServiceCollection RegisterViewModels(this IServiceCollection services)
        {
            services.AddSingleton<MainWindowViewModel>();
            services.AddSingleton<CountriesStatisticsViewModel>();
            return services;
        }
    }
}
