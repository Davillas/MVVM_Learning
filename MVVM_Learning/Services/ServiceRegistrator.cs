using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using MVVM_Learning.Services.Interfaces;
using MVVM_Learning.Services.Students;
using MVVM_Learning.ViewModels;

namespace MVVM_Learning.Services
{
    internal static class ServiceRegistrator
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddTransient<IDataService, DataService>();

            services.AddTransient<IAsyncDataService, AsyncDataService>();

            services.AddTransient<IWebServerService, HttpListenerWebServer>();

            services.AddSingleton<StudentRepository>();
            services.AddSingleton<GroupRepository>();
            services.AddSingleton<StudentsManager>();

            return services;
        }
    }
}
