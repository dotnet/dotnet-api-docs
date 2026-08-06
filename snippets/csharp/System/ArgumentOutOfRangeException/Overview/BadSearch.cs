// <Snippet6>
using System;
using System.Collections.Generic;

public class Example
{
    public static void Main()
    {
        var list = new List<string>();
        list.AddRange(new string[] { "A", "B", "C" });
        // Get the index of the element whose value is "Z".
        int index = list.FindIndex((new StringSearcher("Z")).FindEquals);
        try
        {
            Console.WriteLine($"Index {index} contains '{list[index]}'");
        }
        catch (ArgumentOutOfRangeException e)
        {
            Console.WriteLine(e.Message);
        }
    }
}

internal class StringSearcher
{
    string value;

    public StringSearcher(string value) => this.value = value;

    public bool FindEquals(string s) => s.Equals(value, StringComparison.InvariantCulture);
}
// The example displays the following output:
//   Index was out of range. Must be non-negative and less than the size of the collection.
//   Parameter name: index
// </Snippet6>

public class Example2
{
    public static void Test()
    {
        var list = new List<string>();
        list.AddRange(new string[] { "A", "B", "C" });
        // <Snippet7>
        // Get the index of the element whose value is "Z".
        int index = list.FindIndex((new StringSearcher("Z")).FindEquals);
        if (index >= 0)
            Console.WriteLine($"'Z' is found at index {list[index]}");
        // </Snippet7>
    }
}
