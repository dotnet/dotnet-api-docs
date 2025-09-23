// <snippet1>
using System.ComponentModel;

namespace IListSourceCS;

public class EmployeeListSource : Component, IListSource
{
    public EmployeeListSource() { }

    public EmployeeListSource(IContainer container) => container.Add(this);

    // <snippet2>
    #region IListSource Members

    // <snippet3>
    bool IListSource.ContainsListCollection => false;
    // </snippet3>

    // <snippet4>
    System.Collections.IList IListSource.GetList()
    {
        BindingList<Employee> ble = DesignMode
        ? []
        : [
            new("Aaberg, Jesper", 26000000),
            new ("Aaberg, Jesper", 26000000),
            new ("Cajhen, Janko", 19600000),
            new ("Furse, Kari", 19000000),
            new ("Langhorn, Carl", 16000000),
            new ("Todorov, Teodor", 15700000),
            new ("Verebélyi, Ágnes", 15700000)
            ];

        return ble;
    }
    // </snippet4>

    #endregion
    // </snippet2>
}
// </snippet1>
