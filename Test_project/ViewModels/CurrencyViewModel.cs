using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Test_project.Models;

namespace Test_project.ViewModels
{
    public class CurrencyViewModel
    {
        public ObservableCollection<Currency> Currencies { get; set; }

        public CurrencyViewModel()
        {
            Currencies = new ObservableCollection<Currency>()
            {
                new Currency("US dollar", "USD", 1.0m),
                new Currency("Euro", "EUR", 0.92m),
                new Currency("Japanese Yen", "JPY", 144.5m)
            };
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
