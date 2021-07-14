using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using MVVM_Learning.Infrastructure.Commands.Base;
using MVVM_Learning.Models.DeanOffice;
using MVVM_Learning.ViewModels;
using MVVM_Learning.Views.Windows;

namespace MVVM_Learning.Infrastructure.Commands
{
    class ManageStudentCommand : Command
    {
        private StudentsManagementWindow _Window;
        public override bool CanExecute(object parameter) => _Window == null;

        public override void Execute(object parameter)
        {

            var window = new StudentsManagementWindow
            {
                Owner = Application.Current.MainWindow
            };
            _Window = window;
            window.Closed += OnWindowClosed;

            window.ShowDialog();
        }

        private void OnWindowClosed(object sender, EventArgs e)
        {
            ((Window) sender).Closed -= OnWindowClosed;
            _Window = null;
        }
    }
}
