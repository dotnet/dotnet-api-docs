// <Snippet1>
using System;
using System.Reflection;

public class MyDefaultBinderSample
{
    public static void Main()
    {
        try
        {
            Binder defaultBinder = Type.DefaultBinder;
            MyClass myClass = new();
            // Invoke the HelloWorld method of MyClass.
            myClass.GetType().InvokeMember("HelloWorld", BindingFlags.InvokeMethod,
                defaultBinder, myClass, []);
        }
        catch (Exception e)
        {
            Console.WriteLine("Exception :" + e.Message);
        }
    }

    class MyClass
    {
        public void HelloWorld() => Console.WriteLine("Hello World");
    }
}
// </Snippet1>
