// <Snippet1>
using System;

public class TestClass
{
}

public class Example
{
    public static void Main()
    {
        TestClass testClassInstance = new();
        // Get the type of myTestClassInstance.
        Type testType = testClassInstance.GetType();
        // Get the IsPublic property of testClassInstance.
        bool isPublic = testType.IsPublic;
        Console.WriteLine($"Is {testType.FullName} public? {isPublic}");
    }
}
// The example displays the following output:
//        Is TestClass public? True
// </Snippet1>
