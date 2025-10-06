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
using Test_project.ViewModels;

namespace Test_project
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private CurrencyViewModel viewModel;
        public MainWindow()
        {
            InitializeComponent();

            viewModel = new CurrencyViewModel();
            CurrenciesGrid.ItemsSource = viewModel.Currencies;
            DataContext = viewModel;


        }
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            viewModel.Add_Currency();
        }
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            var selected = (Currency)CurrenciesGrid.SelectedItem;
            viewModel.Delete_Currency(selected);
        }
        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            var selected = (Currency)CurrenciesGrid.SelectedItem;
            viewModel.Edit_Currency(selected);
        }
        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            viewModel.Refresh_Currency();
        }
    }
}