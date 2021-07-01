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
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var serviceTest = new DataService();

            var countries = serviceTest.GetData().ToArray();
        }
    }
}
