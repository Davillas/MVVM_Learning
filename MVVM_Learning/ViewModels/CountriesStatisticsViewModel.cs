using System;
using System.Collections.Generic;
using System.Text;
using MVVM_Learning.Services;
using MVVM_Learning.ViewModels.Base;

namespace MVVM_Learning.ViewModels
{
    internal class CountriesStatisticsViewModel : BaseViewModel
    {
        private DataService _DataService;

        private MainWindowViewModel MainModel { get; }



        public CountriesStatisticsViewModel(MainWindowViewModel MainModel)
        {
            MainModel = MainModel;

            _DataService = new DataService();
        }
    }
}
