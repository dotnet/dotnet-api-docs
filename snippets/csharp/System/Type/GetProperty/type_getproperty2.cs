// <Snippet1>

using System;
using System.Reflection;

class MyClass2
{
    // Declare MyProperty.
    public int MyProperty { get; set; }
}

public class MyTypeClass2
{
    public static void Main(string[] args)
    {
        try
        {
            // Get Type object of MyClass2.
            Type myType = typeof(MyClass2);

            // Get the PropertyInfo by passing the property name and specifying the BindingFlags.
            PropertyInfo myPropInfo = myType.GetProperty(
                "MyProperty",
                BindingFlags.Public | BindingFlags.Instance
                );

            // Display Name property to console.
            Console.WriteLine("{0} is a property of MyClass2.", myPropInfo.Name);
        }
        catch (NullReferenceException e)
        {
            Console.WriteLine("MyProperty does not exist in MyClass2." + e.Message);
        }
    }
}
// </Snippet1>
