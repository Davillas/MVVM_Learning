using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace MVVM_Learning.ViewModels
{
    internal class ViewModelLocator
    {
        public MainWindowViewModel MainWindowVModel => App.Host.Services.GetRequiredService<MainWindowViewModel>();
    }
}
