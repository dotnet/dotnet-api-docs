// <Snippet1>
using System;


using System.Runtime.InteropServices;
class MyTypeSequential1
{
}
[StructLayoutAttribute(LayoutKind.Sequential)]
class MyTypeSequential2
{
    public static void Main(string[] args)
    {
        try
        {
            // Create an instance of myTypeSeq1.
            MyTypeSequential1 myObj1 = new();
            Type myTypeObj1 = myObj1.GetType();
            // Check for and display the SequentialLayout attribute.
            Console.WriteLine($"\nThe object myObj1 has IsLayoutSequential: {myObj1.GetType().IsLayoutSequential}.");
            // Create an instance of 'myTypeSeq2' class.
            MyTypeSequential2 myObj2 = new();
            Type myTypeObj2 = myObj2.GetType();
            // Check for and display the SequentialLayout attribute.
            Console.WriteLine($"\nThe object myObj2 has IsLayoutSequential: {myObj2.GetType().IsLayoutSequential}.");
        }
        catch (Exception e)
        {
            Console.WriteLine($"\nAn exception occurred: {e.Message}");
        }
    }
}
// </Snippet1>
