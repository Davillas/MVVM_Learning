﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using MVVM_Learning.Infrastructure.Commands.Base;

namespace MVVM_Learning.Infrastructure.Commands
{
    class CloseWindowCommand : Command
    {
        public override bool CanExecute(object parameter) => parameter is Window;

        public override void Execute(object parameter)
        {
            if(!CanExecute(parameter)) return;

            var window = (Window) parameter;
            window.Close();

        }
    }
    class CloseDialogCommand : Command
    {
        public bool? DialogResult { get; set; }
        public override bool CanExecute(object parameter) => parameter is Window;

        public override void Execute(object parameter)
        {
            if(!CanExecute(parameter)) return;

            var window = (Window) parameter;
            window.DialogResult = DialogResult;
            window.Close();

        }
    }
}
