using System;
using System.Collections.Generic;

public class Example0
{
    public static void Main()
    {
        var list = new List<string>();
        list.AddRange(new string[] { "A", "B", "C" });
        // <Snippet10>
        // Display each element in the list.
        foreach (string item in list)
            Console.WriteLine($"'{item}'");
        // </Snippet10>
    }
}
