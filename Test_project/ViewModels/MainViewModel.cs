using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Test_project.Services;

namespace Test_project.ViewModels
{
    public class MainViewModel
    {
        public CurrencyViewModel Currency { get; set; } = new CurrencyViewModel();

        public IRelayCommand SetLightThemeCommand { get; set; }
        public IRelayCommand SetDarkThemeCommand { get; set; }

        public MainViewModel()
        {
            SetLightThemeCommand = new RelayCommand(() => ApplyTheme(LightTheme.xaml));
            SetDarkThemeCommand = new RelayCommand(() => ApplyTheme(DarkTheme.xaml));
        }

        private void ApplyTheme(string themePath)
        {
            var dict = new ResourceDictionary { Source = new Uri($"/Test_project;component/Themes/{themePath}", UriKind.Relative) };
            Application.Current.Resources.MergedDictionaries.Clear();
            Application.Current.Resources.MergedDictionaries.Add(dict);

        }
    }
}
