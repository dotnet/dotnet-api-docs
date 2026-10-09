// <snippet10>
using System;

namespace IListSourceCS;

public class Employee : BusinessObjectBase
{
    string _name;
    decimal _parkingId;

    public Employee() : this(string.Empty, 0)
    {
    }

    public Employee(string name) : this(name, 0)
    {
    }

    public Employee(string name, decimal parkingId)
    {
        ID = Guid.NewGuid().ToString();

        // Set values.
        Name = name;
        ParkingID = parkingId;
    }

    public string ID { get; }

    const string NameProperty = "Name";
    public string Name
    {
        get => _name;
        set
        {
            if (_name != value)
            {
                _name = value;

                // Raise the PropertyChanged event.
                OnPropertyChanged(NameProperty);
            }
        }
    }

    const string ParkingIdProperty = nameof(ParkingID);
    public decimal ParkingID
    {
        get => _parkingId;
        set
        {
            if (_parkingId != value)
            {
                _parkingId = value;

                // Raise the PropertyChanged event.
                OnPropertyChanged(ParkingIdProperty);
            }
        }
    }
}
// </snippet10>
