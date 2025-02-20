using System;
using System.ComponentModel;
using System.Drawing;

public class Sample
{
    // <Snippet1>
    [TypeConverter(typeof(MyClassConverter))]
    public class MyClass
    {
        // Insert code here.
    }
    // </Snippet1>
    public enum MyPropertyEnum { option1, option2, option3 };
    public class MyClassConverter;

    // <Snippet2>
    public MyPropertyEnum MyProperty
    {
        set
        {
            // Checks to see if the value passed is valid.
            if (!TypeDescriptor.GetConverter(typeof(MyPropertyEnum)).IsValid(value))
            {
                throw new ArgumentException($"{nameof(MyProperty)} is not valid");
            }
            // The value is valid. Insert code to set the property.
        }
    }
    // </Snippet2>
    public void Method1()
    {
        // <Snippet3>
        Color c = Color.Red;
        Console.WriteLine(TypeDescriptor.GetConverter(typeof(Color)).ConvertToString(c));
        // </Snippet3>
    }
    public void Method2() =>
        // <Snippet4>
        _ = (Color)TypeDescriptor.GetConverter(typeof(Color)).ConvertFromString("Red");// </Snippet4>

    public void Method3()
    {
        // <Snippet5>
        foreach (Color c in TypeDescriptor.GetConverter(typeof(Color)).GetStandardValues())
        {
            Console.WriteLine(TypeDescriptor.GetConverter(c).ConvertToString(c));
        }
        // </Snippet5>
    }
}
