using System;
using System.Collections.Generic;
using System.Text;

namespace MVVM_Learning
{

    public static class Program
    {
        [STAThread]
        public static void Main()
        {
            var app = new App();
            app.InitializeComponent();
            app.Run();
        }
    }
}
