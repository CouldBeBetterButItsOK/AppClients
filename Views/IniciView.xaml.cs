using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

namespace WPF_MVVM_SPA_Template.Views
{
    /// <summary>
    /// Lógica de interacción para IniciView.xaml
    /// </summary>
    public partial class IniciView : UserControl
    {
        public IniciView()
        {
            InitializeComponent();
        }
        private bool darkTheme = false;
        private bool lightTheme = true;
        private void DarkTheme(object sender, RoutedEventArgs e)
        {
            switchTheme("DarkTheme.xaml");
            darkTheme = true;
            lightTheme = false;
        }
        private void LightButton(object sender, RoutedEventArgs e)
        {
            switchTheme("DarkTheme.xaml");
            darkTheme = false;
            lightTheme = true;
        }
        private void switchTheme(string theme)
        {
            Application.Current.Resources.MergedDictionaries.Clear();

            var themeUri = new Uri($"pack://application:,,,/Views/Themes/{theme}", UriKind.Absolute);
            var themeDictionary = new ResourceDictionary { Source = themeUri };

            Application.Current.Resources.MergedDictionaries.Add(themeDictionary);

            Application.Current.MainWindow.UpdateLayout();
        }
    }
}
