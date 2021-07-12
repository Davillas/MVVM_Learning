using System;
using System.Collections.Generic;
using System.Text;
using MVVM_Learning.Services.Interfaces;

namespace MVVM_Learning.Services
{
    class HttpListenerWebServer : IWebServerService
    {
        public bool Enabled { get; set; }

        public void Start()
        {
            throw new NotImplementedException();
        }

        public void Stop()
        {
            throw new NotImplementedException();
        }
    }
}
