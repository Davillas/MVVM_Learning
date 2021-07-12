using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using MVVM_Learning.Services.Interfaces;
using MVVM_WebLib;

namespace MVVM_Learning.Services
{
    class HttpListenerWebServer : IWebServerService
    {
        private WebServer _Server = new WebServer(8080);
        public bool Enabled { get => _Server.Enabled; set => _Server.Enabled = value; }

        public void Start() => _Server.Start();

        public void Stop() => _Server.Stop();

        public HttpListenerWebServer() => _Server.RequestReceived += OnRequestReceived;

        private static void OnRequestReceived(object sender, RequestReceiverEventArgs e)
        {
            Thread.Sleep(3000);
            using var writer = new StreamWriter(e.Context.Response.OutputStream);
            writer.WriteLine("WebServer App - " + DateTime.Now);
        }
    }
}
