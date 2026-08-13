// <Snippet1>
using System;
using System.Reflection;

// This sample class has a field, constructor, method, and property.
class MyType
{
    int myField;
    public MyType(ref int x) => x *= 5;
    public override string ToString() => myField.ToString();
    public int MyProp
    {
        get => myField;
        set
        {
            if (value < 1)
                throw new ArgumentOutOfRangeException("value", value, "value must be > 0");
            myField = value;
        }
    }
}

class MyApp
{
    static void Main()
    {
        Type t = typeof(MyType);
        // Create an instance of a type.
        object[] args = [8];
        Console.WriteLine($"The value of x before the constructor is called is {args[0]}.");
        object obj = t.InvokeMember(null,
            BindingFlags.DeclaredOnly |
            BindingFlags.Public | BindingFlags.NonPublic |
            BindingFlags.Instance | BindingFlags.CreateInstance, null, null, args);
        Console.WriteLine("Type: " + obj.GetType());
        Console.WriteLine($"The value of x after the constructor returns is {args[0]}.");

        // Read and write to a field.
        t.InvokeMember("myField",
            BindingFlags.DeclaredOnly |
            BindingFlags.Public | BindingFlags.NonPublic |
            BindingFlags.Instance | BindingFlags.SetField, null, obj, [5]);
        int v = (int)t.InvokeMember("myField",
            BindingFlags.DeclaredOnly |
            BindingFlags.Public | BindingFlags.NonPublic |
            BindingFlags.Instance | BindingFlags.GetField, null, obj, null);
        Console.WriteLine("myField: " + v);

        // Call a method.
        string s = (string)t.InvokeMember("ToString",
            BindingFlags.DeclaredOnly |
            BindingFlags.Public | BindingFlags.NonPublic |
            BindingFlags.Instance | BindingFlags.InvokeMethod, null, obj, null);
        Console.WriteLine("ToString: " + s);

        // Read and write a property. First, attempt to assign an
        // invalid value; then assign a valid value; finally, get
        // the value.
        try
        {
            // Assign the value zero to MyProp. The Property Set
            // throws an exception, because zero is an invalid value.
            // InvokeMember catches the exception, and throws
            // TargetInvocationException. To discover the real cause
            // you must catch TargetInvocationException and examine
            // the inner exception.
            t.InvokeMember("MyProp",
                BindingFlags.DeclaredOnly |
                BindingFlags.Public | BindingFlags.NonPublic |
                BindingFlags.Instance | BindingFlags.SetProperty, null, obj, [0]);
        }
        catch (TargetInvocationException e)
        {
            // If the property assignment failed for some unexpected
            // reason, rethrow the TargetInvocationException.
            if (e.InnerException.GetType() !=
                typeof(ArgumentOutOfRangeException))
                throw;
            Console.WriteLine("An invalid value was assigned to MyProp.");
        }
        t.InvokeMember("MyProp",
            BindingFlags.DeclaredOnly |
            BindingFlags.Public | BindingFlags.NonPublic |
            BindingFlags.Instance | BindingFlags.SetProperty, null, obj, [2]);
        v = (int)t.InvokeMember("MyProp",
            BindingFlags.DeclaredOnly |
            BindingFlags.Public | BindingFlags.NonPublic |
            BindingFlags.Instance | BindingFlags.GetProperty, null, obj, null);
        Console.WriteLine("MyProp: " + v);
    }
}
// </Snippet1>
