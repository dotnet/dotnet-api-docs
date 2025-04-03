// <Snippet1>

using System;
using System.Reflection;

class MyPropertyTypeClass
{
    public string MyProperty1 { get; set; } = "Hello World.";
}

class TestClass
{
    static void Main()
    {
        try
        {
            Type myType = typeof(MyPropertyTypeClass);

            // Get the PropertyInfo object representing MyProperty1.
            PropertyInfo myStringProperties1 = myType.GetProperty("MyProperty1", typeof(string));

            Console.WriteLine("The name of the first property of MyPropertyTypeClass is {0}.",
                myStringProperties1.Name);
            Console.WriteLine("The type of the first property of MyPropertyTypeClass is {0}.",
                myStringProperties1.PropertyType);
        }
        catch (ArgumentNullException e)
        {
            Console.WriteLine("ArgumentNullException :" + e.Message);
        }
        catch (AmbiguousMatchException e)
        {
            Console.WriteLine("AmbiguousMatchException :" + e.Message);
        }
        catch (NullReferenceException e)
        {
            Console.WriteLine("Source : {0}", e.Source);
            Console.WriteLine("Message : {0}", e.Message);
        }
        //Output:
        //The name of the first property of MyPropertyTypeClass is MyProperty1.
        //The type of the first property of MyPropertyTypeClass is System.String.
    }
}
// </Snippet1>	
