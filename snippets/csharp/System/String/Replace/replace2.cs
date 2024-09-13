using System;

public class Example2
{
    public static void Main()
    {
        // <Snippet2>
        string s = new('a', 3);
        Console.WriteLine($"The initial string: '{s}'");
        s = s.Replace('a', 'b').Replace('b', 'c').Replace('c', 'd');
        Console.WriteLine($"The final string: '{s}'");

        // The example displays the following output:
        //       The initial string: 'aaa'
        //       The final string: 'ddd'
        // </Snippet2>
    }
}
