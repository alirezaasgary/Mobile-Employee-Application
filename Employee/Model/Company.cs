using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Model
{
    public class Company : INotifyPropertyChanged
    {
        int _id;
        public int Id
        {
            get => _id;
            set
            {
                if (_id == value)
                    return;
                _id = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Id)));
            }
        }
        string _name;
        public string Name
        {
            get => _name;
            set
            {
                if (_name == value) return;
                _name = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Name)));
            }
        }
        string _address;
        public string Address
        {
            get => _address;
            set
            {
                if (_address == value) return;
                _address = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Address)));
            }
        }

        string _country;
    public string Country { 
            get=>_country;
            set 
            { if(_country == value) return;
            _country = value;
                PropertyChanged.Invoke(this,new PropertyChangedEventArgs(nameof(Country)));


            }
        }




    public event PropertyChangedEventHandler PropertyChanged;
}
}
