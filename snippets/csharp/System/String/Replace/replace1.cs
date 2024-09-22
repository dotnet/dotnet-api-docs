using System;

public class Example1
{
    public static void Main()
    {
        // <Snippet1>
        string s = "aaa";
        Console.WriteLine($"The initial string: '{s}'");
        s = s.Replace("a", "b").Replace("b", "c").Replace("c", "d");
        Console.WriteLine($"The final string: '{s}'");

        // The example displays the following output:
        //       The initial string: 'aaa'
        //       The final string: 'ddd'
        // </Snippet1>
    }
}
