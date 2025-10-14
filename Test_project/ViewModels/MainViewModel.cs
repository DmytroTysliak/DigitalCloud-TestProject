using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_project.Services;

namespace Test_project.ViewModels
{
    public class MainViewModel
    {
        public CurrencyViewModel Currency { get; set; } = new CurrencyViewModel();
    }
}
