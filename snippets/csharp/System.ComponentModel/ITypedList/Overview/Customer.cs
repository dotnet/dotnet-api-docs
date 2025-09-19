// <snippet10>
using System.ComponentModel;

namespace ITypedListCS;

class Customer : INotifyPropertyChanged
{
    public Customer() { }

    public Customer(int id, string name, string company, string address, string city, string state, string zip)
    {
        _id = id;
        _name = name;
        _company = company;
        _address = address;
        _city = city;
        _state = state;
        _zip = zip;
    }

    #region Public Properties

    int _id;

    public int ID
    {
        get => _id;
        set
        {
            if (_id != value)
            {
                _id = value;
                OnPropertyChanged(new PropertyChangedEventArgs(nameof(ID)));
            }
        }
    }

    string _name;

    public string Name
    {
        get => _name;
        set
        {
            if (_name != value)
            {
                _name = value;
                OnPropertyChanged(new PropertyChangedEventArgs(nameof(Name)));
            }
        }
    }

    string _company;

    public string Company
    {
        get => _company;
        set
        {
            if (_company != value)
            {
                _company = value;
                OnPropertyChanged(new PropertyChangedEventArgs(nameof(Company)));
            }
        }
    }

    string _address;

    public string Address
    {
        get => _address;
        set
        {
            if (_address != value)
            {
                _address = value;
                OnPropertyChanged(new PropertyChangedEventArgs(nameof(Address)));
            }
        }
    }

    string _city;

    public string City
    {
        get => _city;
        set
        {
            if (_city != value)
            {
                _city = value;
                OnPropertyChanged(new PropertyChangedEventArgs(nameof(City)));
            }
        }
    }

    string _state;

    public string State
    {
        get => _state;
        set
        {
            if (_state != value)
            {
                _state = value;
                OnPropertyChanged(new PropertyChangedEventArgs(nameof(State)));
            }
        }
    }

    string _zip;

    public string ZipCode
    {
        get => _zip;
        set
        {
            if (_zip != value)
            {
                _zip = value;
                OnPropertyChanged(new PropertyChangedEventArgs(nameof(ZipCode)));
            }
        }
    }

    #endregion

    #region INotifyPropertyChanged Members

    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged(PropertyChangedEventArgs e) => PropertyChanged?.Invoke(this, e);

    #endregion
}
// </snippet10>
