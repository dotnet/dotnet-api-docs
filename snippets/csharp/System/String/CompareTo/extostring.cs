//<Snippet1>
using System;

public class TestClass
{ }

public class CompareToObjectExample
{
    public static void Run()
    {
        var test = new TestClass();
        object[] objectsToCompare = { test, test.ToString(), 123,
                                    123.ToString(), "some text",
                                    "Some Text" };
        string s = "some text";
        foreach (object objectToCompare in objectsToCompare)
        {
            try
            {
                int i = s.CompareTo(objectToCompare);
                Console.WriteLine($"Comparing '{s}' with '{objectToCompare}': {i}");
            }
            catch (ArgumentException)
            {
                Console.WriteLine($"Bad argument: {objectToCompare} (type {objectToCompare.GetType().Name})");
            }
        }
    }
}
// The example displays the following output:
//    Bad argument: TestClass (type TestClass)
//    Comparing 'some text' with 'TestClass': -1
//    Bad argument: 123 (type Int32)
//    Comparing 'some text' with '123': 1
//    Comparing 'some text' with 'some text': 0
//    Comparing 'some text' with 'Some Text': -1
//</Snippet1>
