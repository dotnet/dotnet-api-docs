using System;

public class Class1
{
    public static void Main()
    {
        // <Snippet1>
        var primes = new Tuple<int, int, int, int, int, int, int,
                     Tuple<int>>(2, 3, 5, 7, 11, 13, 17, new Tuple<int>(19));
        // </Snippet1>
        Console.WriteLine(primes);
    }
}
