using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Test_project.Models
{

    public class Currency : INotifyPropertyChanged
    {
        private string _name;
        private string _code;
        private decimal _price;
        private string _errorMessage; 


        public event PropertyChangedEventHandler PropertyChanged;

        public Currency(string name, string code, decimal price)
        {
            _name = name;
            _code = code;
            _price = price;
            ValidatePrice();
        }
        
        

        private void ValidatePrice()
        {
            if (_price < 0)
                ErrorMessage = "Price cannot be negative";
            else
                ErrorMessage = "";            
        }
        public string Name
        {
            get { return _name; }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged("Name");
                }
            }
        }

        public string Code
        {
            get { return _code; }
            set
            {
                if (_code != value)
                {
                    _code = value;
                    OnPropertyChanged("Code");
                }
            }
        }

        public decimal Price
        {
            get { return _price; }
            set
            {
                if (_price != value)
                {
                    _price = value;
                    ValidatePrice();
                    OnPropertyChanged("Price");
                    OnPropertyChanged("ErrorMessage"); 
                }
            }
        }

        public string ErrorMessage
        {
            get { return _errorMessage; }
            private set
            {
                _errorMessage = value;
                OnPropertyChanged("ErrorMessage");
            }
        }

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
