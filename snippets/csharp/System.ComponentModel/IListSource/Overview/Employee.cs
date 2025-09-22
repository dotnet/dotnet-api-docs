// <snippet10>
using System;

namespace IListSourceCS;

public class Employee : BusinessObjectBase
{
    string _name;
    decimal parkingId;

    public Employee() : this(string.Empty, 0) { }
    public Employee(string name) : this(name, 0) { }

    public Employee(string name, decimal parkingId) : base()
    {
        ID = Guid.NewGuid().ToString();

        // Set values
        Name = name;
        ParkingID = parkingId;
    }

    public string ID { get; }

    const string NAME = "Name";
    public string Name
    {
        get => _name;
        set
        {
            if (_name != value)
            {
                _name = value;

                // Raise the PropertyChanged event.
                OnPropertyChanged(NAME);
            }
        }
    }

    const string PARKING_ID = "Salary";
    public decimal ParkingID
    {
        get => parkingId;
        set
        {
            if (parkingId != value)
            {
                parkingId = value;

                // Raise the PropertyChanged event.
                OnPropertyChanged(PARKING_ID);
            }
        }
    }
}
// </snippet10>
