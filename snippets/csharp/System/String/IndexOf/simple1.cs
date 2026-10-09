using System;

public class IndexOfSimpleExample
{
    public static void Run()
    {
        // <Snippet12>
        string str = "animal";
        string toFind = "n";
        int index = str.IndexOf("n");
        Console.WriteLine($"Found '{toFind}' in '{str}' at position {index}");

        // The example displays the following output:
        //        Found 'n' in 'animal' at position 1
        // </Snippet12>
    }
}
