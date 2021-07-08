using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF_TestApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            new Thread(ComputeValue).Start();
        }

        private void ComputeValue()
        {
            var value = LongProcess(DateTime.Now);
            if (ValueText.Dispatcher.CheckAccess())
                ValueText.Text = value;
            else
                //ValueText.Dispatcher.Invoke(() => ValueText.Text = value);
                ValueText.Dispatcher.BeginInvoke(new Action(() => ValueText.Text = value));
        }

        private static string LongProcess(DateTime Time)
        {
            Thread.Sleep(2000);
            return $"Value: {Time}";
        }
    }
}
