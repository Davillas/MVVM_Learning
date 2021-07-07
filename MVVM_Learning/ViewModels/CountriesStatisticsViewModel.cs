using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;
using MVVM_Learning.Infrastructure.Commands;
using MVVM_Learning.Models;
using MVVM_Learning.Services;
using MVVM_Learning.ViewModels.Base;

namespace MVVM_Learning.ViewModels
{
    internal class CountriesStatisticsViewModel : BaseViewModel
    {
        private readonly DataService _DataService;

        public MainWindowViewModel MainModel { get; internal set; }

        #region SelectedCountry : CountryInfo - Selected Country

        /// <summary>DESCRIPTION</summary>
        private CountryInfo _SelectedCountry;

        /// <summary>DESCRIPTION</summary>
        public CountryInfo SelectedCountry
        {
            get => _SelectedCountry;
            set => Set(ref _SelectedCountry, value);
        }

        #endregion

        #region Countries : IEnumerable<CountryInfo> - Countries Statistics 

        /// <summary>Countries Statistics </summary>
        private IEnumerable<CountryInfo> _Countries;

        /// <summary>Countries Statistics </summary>
        public IEnumerable<CountryInfo> Countries
        {
            get => _Countries;
            private set => Set(ref _Countries, value);
        }

        #endregion

        #region Commands

        public ICommand RefreshDataCommand { get; }

        private void OnRefreshDataCommandExecuted(object p)
        {
            Countries = _DataService.GetData();
        }

        #endregion
        /// <summary>
        /// Debug Constructor for visual designer
        /// </summary>
       /* public CountriesStatisticsViewModel() : this(null)
        {
            if (!App.IsDesignMode)
                throw new InvalidOperationException("Constructor Call not designed for using in regular mode");

            _Countries = Enumerable.Range(1, 10)
                .Select(i => new CountryInfo
                {
                    Name = $"Country {i}",
                    ProvinceCounts = Enumerable.Range(1,10).Select(j => new PlaceInfo
                    {
                        Name = $"Province {i}",
                        Location = new Point(i,j),
                        Counts = Enumerable.Range(1,10).Select(k=> new ConfirmedCount
                        {
                            Date = DateTime.Now.Subtract(TimeSpan.FromDays(100-k)),
                            Count = k
                        }).ToArray()
                    }).ToArray()
                }).ToArray();
        }
*/
        public CountriesStatisticsViewModel( DataService dataService)
        {
            

            _DataService = dataService;

            #region Commands

            RefreshDataCommand = new LambdaCommand(OnRefreshDataCommandExecuted); 
            #endregion
        }
    }
}
