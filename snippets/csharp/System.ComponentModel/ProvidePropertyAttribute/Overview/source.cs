using System.ComponentModel;
using System.Globalization;
using System.Windows.Forms;

// <Snippet1>
[ProvideProperty("MyProperty", typeof(Control))]
public class MyClass : IExtenderProvider
{
    protected CultureInfo ciMine;
    // Provides the Get portion of MyProperty. 
    public CultureInfo GetMyProperty(Control myControl) =>
        // Insert code here.
        ciMine;

    // Provides the Set portion of MyProperty.
    public void SetMyProperty(Control myControl, string value)
    {
        // Insert code here.
    }

    /* When you inherit from IExtenderProvider, you must implement the 
     * CanExtend method. */
    public bool CanExtend(object target) => target is Control;

    // Insert additional code here.
}
// </Snippet1>
