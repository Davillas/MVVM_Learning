using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using MVVM_Learning.Infrastructure.Commands;
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

        #region Commands

        #region Command AddStudentCommand - Adding Student Command

        /// <summary>Adding Student Command</summary>
        private ICommand _AddStudentCommand;

        /// <summary>Adding Student Command</summary>
        public ICommand AddStudentCommand => _AddStudentCommand
            ??= new LambdaCommand(OnAddStudentCommandExecuted, CanAddStudentCommandExecute);

        /// <summary>Проверка возможности выполнения - Adding Student Command</summary>
        private bool CanAddStudentCommandExecute(object p) => p is Group;

        /// <summary>Логика выполнения - Adding Student Command</summary>
        private void OnAddStudentCommandExecuted(object p)
        {
            var group = (Group) p;
        }

        #endregion

        #region Command EditStudentCommand - Edit Student

        /// <summary>Edit Student</summary>
        private ICommand _EditStudentCommand;

        /// <summary>Edit Student</summary>
        public ICommand EditStudentCommand => _EditStudentCommand
            ??= new LambdaCommand(OnEditStudentCommandExecuted, CanEditStudentCommandExecute);

        /// <summary>Проверка возможности выполнения - Edit Student</summary>
        private bool CanEditStudentCommandExecute(object p) => p is Student;

        /// <summary>Логика выполнения - Edit Student</summary>
        private void OnEditStudentCommandExecuted(object p)
        {
            var student = (Student) p;


        }

        #endregion

        #endregion

        public StudentManagementViewModel(StudentsManager StudentsManager) => _StudentsManager = StudentsManager;
    }
}
