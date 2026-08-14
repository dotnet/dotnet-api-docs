// <Snippet1>
using System;
using System.Reflection;


// Create a class having two public methods and one protected method.
public class MyTypeClass
{
    public void MyMethods()
    {
    }
    public int MyMethods1() => 3;
    protected string MyMethods2() => "hello";
}
public class TypeMain
{
    public static void Main()
    {
        Type myType = (typeof(MyTypeClass));
        // Get the public methods.
        MethodInfo[] myArrayMethodInfo = myType.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
        Console.WriteLine($"\nThe number of public methods is {myArrayMethodInfo.Length}.");
        // Display all the methods.
        DisplayMethodInfo(myArrayMethodInfo);
        // Get the nonpublic methods.
        MethodInfo[] myArrayMethodInfo1 = myType.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly);
        Console.WriteLine($"\nThe number of protected methods is {myArrayMethodInfo1.Length}.");
        // Display information for all methods.
        DisplayMethodInfo(myArrayMethodInfo1);
    }
    public static void DisplayMethodInfo(MethodInfo[] myArrayMethodInfo)
    {
        // Display information for all methods.
        for (int i = 0; i < myArrayMethodInfo.Length; i++)
        {
            MethodInfo myMethodInfo = (MethodInfo)myArrayMethodInfo[i];
            Console.WriteLine($"\nThe name of the method is {myMethodInfo.Name}.");
        }
    }
}
// </Snippet1>
