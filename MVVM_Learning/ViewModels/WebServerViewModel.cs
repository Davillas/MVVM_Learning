using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using MVVM_Learning.Infrastructure.Commands;
using MVVM_Learning.Services.Interfaces;
using MVVM_Learning.ViewModels.Base;

namespace MVVM_Learning.ViewModels
{
    internal class WebServerViewModel : BaseViewModel
    {
        private readonly IWebServerService _Server;

        #region Enabled

        private bool _Enabled;

        public bool Enabled
        {
            get => _Server.Enabled;
            set
            {
                _Server.Enabled = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Command StartCommand - Summary

        /// <summary>Summary</summary>
        private ICommand _StartCommand;

        /// <summary>Summary</summary>
        public ICommand StartCommand => _StartCommand
            ??= new LambdaCommand(OnStartCommandExecuted, CanStartCommandExecute);

        /// <summary>Проверка возможности выполнения - Summary</summary>
        private bool CanStartCommandExecute(object p) => !Enabled;

        /// <summary>Логика выполнения - Summary</summary>
        private void OnStartCommandExecuted(object p)
        {
            _Server.Start();
            OnPropertyChanged(nameof(Enabled));
        }

        #endregion

        #region Command StopCommand - Summary

        /// <summary>Summary</summary>
        private ICommand _StopCommand;

        /// <summary>Summary</summary>
        public ICommand StopCommand => _StopCommand
            ??= new LambdaCommand(OnStopCommandExecuted, CanStopCommandExecute);

        /// <summary>Проверка возможности выполнения - Summary</summary>
        private bool CanStopCommandExecute(object p) => Enabled;

        /// <summary>Логика выполнения - Summary</summary>
        private void OnStopCommandExecuted(object p)
        {
            Enabled = false;
        }

        #endregion

        public WebServerViewModel(IWebServerService Server)
        {
            _Server.Stop();
            OnPropertyChanged(nameof(Enabled));
        }
    }
}
