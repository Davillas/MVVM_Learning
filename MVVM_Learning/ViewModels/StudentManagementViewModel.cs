using System;
using System.Collections.Generic;
using System.Text;
using MVVM_Learning.ViewModels.Base;

namespace MVVM_Learning.ViewModels
{
    class StudentManagementViewModel : BaseViewModel
    {
        #region Title : string - Title

        /// <summary>Title</summary>
        private string _Title = "Student Management";

        /// <summary>Title</summary>
        public string Title
        {
            get => _Title;
            set => Set(ref _Title, value);
        }

        #endregion

    }
}
