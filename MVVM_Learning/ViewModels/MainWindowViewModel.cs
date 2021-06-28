using MVVM_Learning.Infrastructure.Commands;
using MVVM_Learning.Models;
using MVVM_Learning.Models.DeanOffice;
using MVVM_Learning.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace MVVM_Learning.ViewModels
{
    internal class MainWindowViewModel : BaseViewModel
    {

    /*-------------------------------------------------------------------------------------------*/

        public ObservableCollection<Group> Groups { get; }
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

        public ICommand ChangeTabIndexCommand { get; }

        private bool CanChangeTabIndexCommandExecute(object p) => _SelectedPageIndex >= 0;

        private void OnChangeTabIndexCommandExecuted(object p)
        {
            if (p is null) return;
            SelectedPageIndex += Convert.ToInt32(p);
        }

        #endregion

        /*-------------------------------------------------------------------------------------------*/
        public MainWindowViewModel()
        {
            #region Commands

            CloseApplicationCommand = new LambdaCommand(OnCloseApplicationCommandExecuted, CanCloseApplicationCommandExecute);

            ChangeTabIndexCommand = new LambdaCommand(OnChangeTabIndexCommandExecuted, CanChangeTabIndexCommandExecute);
            #endregion

            var data_points = new List<DataPoint>((int)(360 / 0.1));
            for (var x =0d; x <= 360; x+=0.1)
            {
                const double to_rad = Math.PI / 180;
                var y = Math.Sin(2 * Math.PI * x * to_rad);

                data_points.Add(new DataPoint { XValue = x, YValue = y });

            }

            TestDataPoints = data_points;

            var student_index = 1;
            var students = Enumerable.Range(1, 10).Select(i => new Student 
            {
                Name = $"Name {student_index}",
                Surname = $"Surname {student_index}",
                Patronymic = $"Patronymic {student_index}",
                BirthDay = DateTime.Now,
                Rating = 0
            });

            var groups = Enumerable.Range(1, 20).Select(i => new Group
            {
                Name = $"Group {i}",
                Students = new ObservableCollection<Student>()
            }
                );

            Groups = new ObservableCollection<Group>(groups);
        }

    }
}
