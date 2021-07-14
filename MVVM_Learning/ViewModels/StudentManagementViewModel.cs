using System;
using System.Collections.Generic;
using System.Text;
using MVVM_Learning.Models.DeanOffice;
using MVVM_Learning.Services.Students;
using MVVM_Learning.ViewModels.Base;

namespace MVVM_Learning.ViewModels
{
    class StudentManagementViewModel : BaseViewModel
    {
        private readonly StudentsManager _StudentsManager;
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

        public IEnumerable<Student> Students => _StudentsManager.Students;
        public IEnumerable<Group> Groups => _StudentsManager.Groups;

        #region SelectedGroup : Group - Selected Students group

        /// <summary>Selected Students group</summary>
        private Group _SelectedGroup;

        /// <summary>Selected Students group</summary>
        public Group SelectedGroup
        {
            get => _SelectedGroup;
            set => Set(ref _SelectedGroup, value);
        }

        #endregion

        #region SelectedStudent : Student - Selected Student in a Group

        /// <summary>Selected Student in a Group</summary>
        private Student _SelectedStudent;

        /// <summary>Selected Student in a Group</summary>
        public Student SelectedStudent
        {
            get => _SelectedStudent;
            set => Set(ref _SelectedStudent, value);
        }

        #endregion

        public StudentManagementViewModel(StudentsManager StudentsManager) => _StudentsManager = StudentsManager;
    }
}
