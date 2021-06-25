using MVVM_Learning.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace MVVM_Learning.ViewModels
{
    internal class MainWindowViewModel : BaseViewModel
    {
        #region MainWindow Title

        private string _Title = "Test Title";
        /// <summary> Main Window Title </summary>
        public string Title 
        {
            get => _Title;
            set => Set(ref _Title, value);
        }
        #endregion
    }
}
