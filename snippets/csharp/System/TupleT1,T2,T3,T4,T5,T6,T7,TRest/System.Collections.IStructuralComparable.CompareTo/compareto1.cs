// <Snippet1>
using System;

public class Example
{
    public static void Main()
    {
        // Create array of 8-tuple objects containing prime numbers.
        Tuple<int, int, int, int, int, int, int, Tuple<int>>[] primes =
                       { new Tuple<int, int, int, int, int, int, int,
                           Tuple<int>>(2, 3, 5, 7, 11, 13, 17, new Tuple<int>(19)),
                       new Tuple<int, int, int, int, int, int, int,
                           Tuple<int>>(23, 29, 31, 37, 41, 43, 47, new Tuple<int>(55)),
                       new Tuple<int, int, int, int, int, int, int,
                           Tuple<int>>(3, 2, 5, 7, 11, 13, 17, new Tuple<int>(19)) };
        // Display 8-tuples in unsorted order.
        foreach (var prime in primes)
            Console.WriteLine(prime.ToString());
        Console.WriteLine();

        // Sort the array and display its 8-tuples.
        Array.Sort(primes);
        foreach (var prime in primes)
            Console.WriteLine(prime.ToString());
    }
}
// The example displays the following output:
//       (2, 3, 5, 7, 11, 13, 17, 19)
//       (23, 29, 31, 37, 41, 43, 47, 55)
//       (3, 2, 5, 7, 11, 13, 17, 19)
//
//       (2, 3, 5, 7, 11, 13, 17, 19)
//       (3, 2, 5, 7, 11, 13, 17, 19)
//       (23, 29, 31, 37, 41, 43, 47, 55)
// </Snippet1>
