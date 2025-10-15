using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Test_project.Models;
using Test_project.Services;
using Test_project.View.CurrencyDetails;
using Test_project.ViewModels;

namespace Test_project
{
    public partial class MainWindow : Window
    {
        public CurrencyViewModel CurrencyVM { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            CurrencyVM = new CurrencyViewModel();
            DataContext = CurrencyVM;
        }
        private async void CurrenciesGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (CurrencyVM.SelectedCurrency is Currency selectedCurrency)
            {
                var detailsVm = new CurrencyDetailsViewModel();

                string coinId = selectedCurrency.Code.ToLower() switch
                {
                    "btc" => "bitcoin",
                    "eth" => "ethereum",
                    "usdc" => "usd-coin",
                    "bnb" => "binancecoin",
                    "sol" => "solana",
                    "xrp" => "ripple",
                    "doge" => "dogecoin",
                    "ada" => "cardano",
                    "steth" => "staked-ether",
                    "trx" => "tron",
                    _ => selectedCurrency.Code.ToLower()
                };

                await detailsVm.LoadCurrencyDetailAsync(coinId);

                var detailsWindow = new CurrencyDetailsView
                {
                    DataContext = detailsVm
                };
                detailsWindow.ShowDialog();
            }
        }

        private void LightThemeButton_Click(object sender, RoutedEventArgs e)
        {
            var lightTheme = new ResourceDictionary
            {
                Source = new Uri("/Themes/LightTheme.xaml", UriKind.Relative)
            };
            ApplyTheme(lightTheme);
        }

        private void DarkThemeButton_Click(object sender, RoutedEventArgs e)
        { 
            var darkTheme = new ResourceDictionary
            {
                Source = new Uri("/Themes/DarkTheme.xaml", UriKind.Relative)
            };
            ApplyTheme(darkTheme);
        }

        private void ApplyTheme(ResourceDictionary theme)
        {
            var existingThemes = Application.Current.Resources.MergedDictionaries
                .Where(d => d.Source != null && d.Source.OriginalString.Contains("Theme"))
                .ToList();

            foreach (var t in existingThemes)
                Application.Current.Resources.MergedDictionaries.Remove(t);

            Application.Current.Resources.MergedDictionaries.Add(theme);
        }

    }
}