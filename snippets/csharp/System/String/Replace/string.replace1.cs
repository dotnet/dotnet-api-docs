using System;

class Example3
{
    public static void Main()
    {
        //<snippet1>
        string str = "1 2 3 4 5 6 7 8 9";
        Console.WriteLine($"Original string: \"{str}\"");
        Console.WriteLine($"CSV string:      \"{str.Replace(' ', ',')}\"");

        // This example produces the following output:
        // Original string: "1 2 3 4 5 6 7 8 9"
        // CSV string:      "1,2,3,4,5,6,7,8,9"
        //</snippet1>
    }
}
