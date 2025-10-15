using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Test_project.Models;
using Test_project.Services;

namespace Test_project.ViewModels
{
    public class CurrencyViewModel : INotifyPropertyChanged
    {
        private readonly CoinMarketCapService _service;
        public ObservableCollection<Currency> Currencies { get; set; }
 

        public ICommand AddCurrencyCommand { get; }
        public ICommand DeleteCurrencyCommand { get; }
        public ICommand EditCurrencyCommand { get; }
        public ICommand RefreshCurrencyCommand { get; }
        public ICommand LoadBTCCommand { get; }

        public CurrencyViewModel()
        {
            _service = new CoinMarketCapService("7ce93d4944f545f8a455469609320716");
            Currencies = new ObservableCollection<Currency>();
            LoadTopCoinsAsync();


            AddCurrencyCommand = new RelayCommand(Add_Currency);
            DeleteCurrencyCommand = new RelayCommand<Currency>(Delete_Currency);
            EditCurrencyCommand = new RelayCommand<Currency>(Edit_Currency);
            RefreshCurrencyCommand = new AsyncRelayCommand(Refresh_CurrencyAsync);
            LoadBTCCommand = new AsyncRelayCommand(LoadBTCAsync);
        }
        private async Task LoadTopCoinsAsync()
        {
            try
            {
                using HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (compatible; MyApp/1.0)");
                string url = "https://api.coingecko.com/api/v3/coins/markets?vs_currency=usd&order=market_cap_desc&per_page=10&page=1";
                var json = await client.GetStringAsync(url);

                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var data = JsonSerializer.Deserialize<List<CoinGeko>>(json, options);

                Application.Current.Dispatcher.Invoke(() =>
                {
                    Currencies.Clear();
                    foreach (var item in data)
                        Currencies.Add(new Currency(item.Name, item.Symbol.ToUpper(), item.Current_Price));
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"❌ Помилка завантаження: {ex.Message}");
            }
        }

        private async Task LoadBTCAsync()
        {
            await LoadCurrencyAsync("BTC");
        }

        private async Task LoadCurrencyAsync(string symbol)
        {
            var currency = await _service.GetPriceAsync(symbol);
            Currencies.Add(currency);
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        public void Add_Currency()
        {
            Currencies.Add(new Currency("New Currency", "New", 0m));
        }

        public void Delete_Currency(Currency currency)
        {
            if (currency != null)
                Currencies.Remove(currency);
        }

        public void Edit_Currency(Currency currency)
        {
            if (currency != null)
                currency.Price += 1;
        }

        public async Task Refresh_CurrencyAsync()
        {
            using HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (compatible; MyApp/1.0)");
            string url = "https://api.coingecko.com/api/v3/coins/markets?vs_currency=usd&order=market_cap_desc&per_page=10&page=1";
            var json = await client.GetStringAsync(url);

            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var data = JsonSerializer.Deserialize<List<CoinGeko>>(json, options);

            Application.Current.Dispatcher.Invoke(() =>
            {
                Currencies.Clear();
                foreach (var item in data)
                    Currencies.Add(new Currency(item.Name, item.Symbol.ToUpper(), item.Current_Price));
            });

        }
    }
}
