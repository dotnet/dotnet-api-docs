using System;

class Sample
{
    public static void Main()
    {
        //<snippet1>
        string str = "abcdefg";
        Console.WriteLine($"1) The length of '{str}' is {str.Length}");
        Console.WriteLine($"2) The length of '{"xyz"}' is {"xyz".Length}");

        int length = str.Length;
        Console.WriteLine($"3) The length of '{str}' is {length}");

        // This example displays the following output:
        //    1) The length of 'abcdefg' is 7
        //    2) The length of 'xyz' is 3
        //    3) The length of 'abcdefg' is 7
        //</snippet1>
    }
}
