// <Snippet1>
using System;
using System.Reflection;

class MyClass1
{
    // Declare MyProperty.
    public int MyProperty { get; set; }
}

public class MyTypeClass1
{
    public static void Main(string[] args)
    {
        try
        {
            // Get the Type object corresponding to MyClass1.
            Type myType = typeof(MyClass1);

            // Get the PropertyInfo object by passing the property name.
            PropertyInfo myPropInfo = myType.GetProperty("MyProperty");

            // Display the property name.
            Console.WriteLine("The {0} property exists in MyClass1.", myPropInfo.Name);
        }
        catch (NullReferenceException e)
        {
            Console.WriteLine("The property does not exist in MyClass1." + e.Message);
        }
    }
}
// </Snippet1>
