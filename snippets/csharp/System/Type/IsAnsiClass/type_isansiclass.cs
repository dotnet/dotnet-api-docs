// <Snippet1>
using System;
using System.Reflection;
public class MyClass
{
    protected string myField = "A sample protected field.";
}
public class MyType_IsAnsiClass
{
    public static void Main()
    {
        try
        {
            MyClass myObject = new();
            // Get the type of the 'MyClass'.
            Type myType = typeof(MyClass);
            // Get the field information and the attributes associated with MyClass.
            FieldInfo myFieldInfo = myType.GetField("myField", BindingFlags.NonPublic | BindingFlags.Instance);
            Console.WriteLine("\nChecking for the AnsiClass attribute for a field.\n");
            // Get and display the name, field, and the AnsiClass attribute.
            Console.WriteLine($"Name of Class: {myType.FullName} \nValue of Field: {myFieldInfo.GetValue(myObject)} \nIsAnsiClass = {myType.IsAnsiClass}");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Exception: {e.Message}");
        }
    }
}
// </Snippet1>
