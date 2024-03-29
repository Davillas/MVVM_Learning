﻿using MVVM_Learning.Infrastructure.Commands;
using MVVM_Learning.Models.DeanOffice;
using MVVM_Learning.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Linq;
using System.Net.NetworkInformation;
using System.Printing;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Markup;
using MVVM_Learning.Services;
using OxyPlot;
using DataPoint = MVVM_Learning.Models.DataPoint;

namespace MVVM_Learning.ViewModels
{
    [MarkupExtensionReturnType(typeof(MainWindowViewModel))]
    internal class MainWindowViewModel : BaseViewModel
    {

        private readonly IAsyncDataService _asyncData;
        /*-------------------------------------------------------------------------------------------*/

        public CountriesStatisticsViewModel CountriesStatistics {get;}
        public WebServerViewModel WebServer { get; }

        /*---------------------------------------Properties----------------------------------------------------*/

        

        

        

        #region StudentFilterText : string - Text of Student Filter

        /// <summary>DESCRIPTION</summary>
        private string _StudentFilterText;

        /// <summary>DESCRIPTION</summary>
        public string StudentFilterText
        {
            get => _StudentFilterText;
            set
            {
                if(!Set(ref _StudentFilterText, value)) return;
                _SelectedGroupStudents.View.Refresh();

            }
        }

        #endregion

        #region StudentFilter

        
        private readonly CollectionViewSource _SelectedGroupStudents = new CollectionViewSource();

        private void OnStudentFilter(object sender, FilterEventArgs E)
        {
            if (!(E.Item is Student student))
            {
                E.Accepted = false;
                return;

            }

            var filterText = _StudentFilterText;
            if(string.IsNullOrWhiteSpace(filterText))
                return;

            if (student.Name is null || student.Surname is null || student.Patronymic is null)
            {

                E.Accepted = false;
                return;
            }


            if (student.Name.Contains(filterText, StringComparison.OrdinalIgnoreCase)) return;
            if (student.Surname.Contains(filterText, StringComparison.OrdinalIgnoreCase)) return;
            if (student.Patronymic.Contains(filterText, StringComparison.OrdinalIgnoreCase)) return;

            E.Accepted = false;
        }
        public ICollectionView SelectedGroupStudents => _SelectedGroupStudents?.View;

        #endregion

        #region TestDataPoint : IEnumerable<DataPoint>  - Test data for visualization

        /// <summary>
        /// Test data for visualization
        /// </summary>
        private IEnumerable<DataPoint> _TestDataPoints;

        /// <summary>
        /// Test data for visualization
        /// </summary>
        public IEnumerable<DataPoint> TestDataPoints { get => _TestDataPoints; set => Set(ref _TestDataPoints, value); }

        #endregion

        #region SelectedPageIndex : int  - Test data for visualization

        /// <summary>
        /// Test data for visualization
        /// </summary>
        private int _SelectedPageIndex = 0;

        /// <summary>
        /// Test data for visualization
        /// </summary>
        public int SelectedPageIndex { get => _SelectedPageIndex; set => Set(ref _SelectedPageIndex, value); }

        #endregion

        #region MainWindow Title

        private string _Title = "Test Title";
        /// <summary> Main Window Title </summary>
        public string Title 
        {
            get => _Title;
            set => Set(ref _Title, value);
        }
        #endregion

        #region Status : string - Program Status

        /// <summary>
        /// Program Status
        /// </summary>
        private string _Status = "Ready";

        public string Status
        {
            get => _Status;
            set => Set(ref _Status, value);
        }

        #endregion

        #region DataValue : string - Result of long async operation

        /// <summary>Result of long async operation</summary>
        private string _DateValue;

        /// <summary>Result of long async operation</summary>
        public string DateValue
        {
            get => _DateValue;
            set => Set(ref _DateValue, value);
        }

        #endregion
      
        /*-------------------------------------------------------------------------------------------*/

        #region Commands

        #region CloseApplicationCommand
        public ICommand CloseApplicationCommand { get; }

        
        private bool CanCloseApplicationCommandExecute(object p) => true;
        private void OnCloseApplicationCommandExecuted(object p)
        {
            Application.Current.Shutdown();
        }
        #endregion

        #region ChangeTabIndexCommand

        public ICommand ChangeTabIndexCommand { get; }

        private bool CanChangeTabIndexCommandExecute(object p) => _SelectedPageIndex >= 0;

        private void OnChangeTabIndexCommandExecuted(object p)
        {
            if (p is null) return;
            SelectedPageIndex += Convert.ToInt32(p);
        }

        #endregion

        #region Command StartProcessCommand - Start Process

        /// <summary>Start Process</summary>
        public ICommand StartProcessCommand { get; }

        ///// <summary>Start Process</summary>
        //public ICommand StartProcessCommand => _StartProcessCommand
        //    ??= new LambdaCommand(OnStartProcessCommandExecuted, CanStartProcessCommandExecute);

        /// <summary>Проверка возможности выполнения - Start Process</summary>
        private static bool CanStartProcessCommandExecute(object p) => true;

        /// <summary>Логика выполнения - Start Process</summary>
        private void OnStartProcessCommandExecuted(object p)
        {
            new Thread(ComputeValue).Start();
        }

        private void ComputeValue()
        {
            DateValue = _asyncData.GetResult(DateTime.Now);
        }

        #endregion

        #region Command StopProcessCommand - Stop the Process

        /// <summary>Stop the Process</summary>
        public ICommand StopProcessCommand { get; }

        ///// <summary>Stop the Process</summary>
        //public ICommand StopProcessCommand => _StopProcessCommand
        //    ??= new LambdaCommand(OnStopProcessCommandExecuted, CanStopProcessCommandExecute);

        /// <summary>Проверка возможности выполнения - Stop the Process</summary>
        private bool CanStopProcessCommandExecute(object p) => true;

        /// <summary>Логика выполнения - Stop the Process</summary>
        private void OnStopProcessCommandExecuted(object p)
        {
            
        }

        #endregion

        #endregion

        /*-------------------------------------------------------------------------------------------*/
        public MainWindowViewModel(CountriesStatisticsViewModel Statistics, IAsyncDataService asyncData, WebServerViewModel WebServer)
        {
            _asyncData = asyncData;
            this.WebServer = WebServer;
            #region CountriesStatistics

            CountriesStatistics = Statistics;
            CountriesStatistics.MainModel = this;

            //CountriesStatistics = new CountriesStatisticsViewModel(this);
            #endregion

            #region Commands

            CloseApplicationCommand = new LambdaCommand(OnCloseApplicationCommandExecuted, CanCloseApplicationCommandExecute);
            ChangeTabIndexCommand = new LambdaCommand(OnChangeTabIndexCommandExecuted, CanChangeTabIndexCommandExecute);

            StartProcessCommand = new LambdaCommand(OnStartProcessCommandExecuted, CanStartProcessCommandExecute);
            StopProcessCommand = new LambdaCommand(OnStopProcessCommandExecuted, CanStopProcessCommandExecute);

            #endregion

            var data_points = new List<DataPoint>((int)(360 / 0.1));
            for (var x =0d; x <= 360; x+=0.1)
            {
                const double to_rad = Math.PI / 180;
                var y = Math.Sin(x * to_rad);

                data_points.Add(new DataPoint { XValue = x, YValue = y });

            }

            TestDataPoints = data_points;
            

            //_SelectedGroupStudents.GroupDescriptions.Add(new PropertyGroupDescription("Name"));
        }

        
    }
}
