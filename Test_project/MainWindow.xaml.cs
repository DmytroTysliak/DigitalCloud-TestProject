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
    public partial class MainWindow : Window
    {
        public CurrencyViewModel CurrencyVM { get; set; }
        public MainWindow()
        {
            InitializeComponent();

            CurrencyVM = new CurrencyViewModel();
            DataContext = new MainViewModel();
        }
        
    }
}