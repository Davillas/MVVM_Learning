using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using MVVM_Learning.Models.DeanOffice;
using MVVM_Learning.Services.Interfaces;
using MVVM_Learning.Views.Windows;

namespace MVVM_Learning.Services
{
    class WindowsUserDialogService:IUserDialogService
    {
        public bool Edit(object item)
        {
            if (item is null)
                throw new ArgumentNullException(nameof(item));

            switch (item)
            {
                case Student student:
                    return EditStudent(student);
                default: throw new NotSupportedException($"Editing of type {item.GetType().Name} is not supported");
            }
        }

        public void ShowInformation(string Information, string Caption) =>
            MessageBox.Show(Information,
                Caption,
                MessageBoxButton.OK, MessageBoxImage.Information);
        public void ShowWarning(string Message, string Caption) =>
            MessageBox.Show(Message,
                Caption,
                MessageBoxButton.OK, MessageBoxImage.Warning);
        public void ShowError(string Message, string Caption) =>
            MessageBox.Show(Message,
                Caption,
                MessageBoxButton.OK, MessageBoxImage.Error);

        public bool Confirm(string Message, string Caption, bool Exclamation = false) =>
            MessageBox.Show(Message,
                Caption,
                MessageBoxButton.YesNo,
                Exclamation ? MessageBoxImage.Exclamation : MessageBoxImage.Question)
            == MessageBoxResult.Yes;



        private static bool EditStudent(Student student)
        {
            var dlg = new StudentEditorWindow
            {
                FirstName = student.Name,
                LastName = student.Surname,
                Patronymic = student.Patronymic,
                Rating = student.Rating,
                BirthDay = student.BirthDay,
            };
            if (dlg.ShowDialog() != true) return false;

            student.Name = dlg.FirstName;
            student.Surname = dlg.LastName;
            student.Patronymic = dlg.Patronymic;
            student.Rating = dlg.Rating;
            student.BirthDay = dlg.BirthDay;

            return true;
        }
    }

   

}
