using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Test_project.Models;

namespace Test_project.ViewModels
{
    public class CurrencyViewModel : INotifyPropertyChanged
    {
        
        public ObservableCollection<Currency> Currencies { get; set; }

        public ICommand AddCurrencyCommand { get; }
        public ICommand DeleteCurrencyCommand { get; }
        public ICommand EditCurrencyCommand { get; }
        public ICommand RefreshCurrencyCommand { get; }

        public CurrencyViewModel()
        {
            Currencies = new ObservableCollection<Currency>()
            {
                new Currency("US dollar", "USD", 1.0m),
                new Currency("Euro", "EUR", 0.92m),
                new Currency("Japanese Yen", "JPY", 144.5m)
            };

            AddCurrencyCommand = new RelayCommand(Add_Currency);
            DeleteCurrencyCommand = new RelayCommand<Currency>(Delete_Currency);
            EditCurrencyCommand = new RelayCommand<Currency>(Edit_Currency);
            RefreshCurrencyCommand = new RelayCommand(Refresh_Currency);
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName]string propertyName = null)
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

        public void Refresh_Currency()
        {
            Currencies.Clear();
            Currencies.Add(new Currency("US dollar", "USD", 1.0m));
            Currencies.Add(new Currency("Euro", "EUR", 0.92m));
            Currencies.Add(new Currency("Japanese Yen", "JPY", 144.5m));
        }
    }
}
