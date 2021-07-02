using System.Linq;
using System.Windows;
using MVVM_Learning.Services;

namespace MVVM_Learning
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static bool IsDesignMode { get; private set; } = true;
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            
        }
    }
}
