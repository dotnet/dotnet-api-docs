// <Snippet1>
using System;
using System.Collections.Generic;

public class JoinArrayExample
{
    public static void Run()
    {
        int maxPrime = 100;
        int[] primes = GetPrimes(maxPrime);
        Console.WriteLine($"Primes less than {maxPrime}:");
        Console.WriteLine($"   {string.Join(" ", primes)}");
    }

    private static int[] GetPrimes(int maxPrime)
    {
        Array values = Array.CreateInstance(typeof(int),
                                [maxPrime - 1], [2]);
        // Use Sieve of Eratosthenes to determine prime numbers.
        for (int ctr = values.GetLowerBound(0); ctr <= (int)Math.Ceiling(Math.Sqrt(values.GetUpperBound(0))); ctr++)
        {

            if ((int)values.GetValue(ctr) == 1) continue;

            for (int multiplier = ctr; multiplier <= maxPrime / 2; multiplier++)
                if (ctr * multiplier <= maxPrime)
                    values.SetValue(1, ctr * multiplier);
        }

        List<int> primes = new();
        for (int ctr = values.GetLowerBound(0); ctr <= values.GetUpperBound(0); ctr++)
            if ((int)values.GetValue(ctr) == 0)
                primes.Add(ctr);
        return [.. primes];
    }
}
// The example displays the following output:
//    Primes less than 100:
//       2 3 5 7 11 13 17 19 23 29 31 37 41 43 47 53 59 61 67 71 73 79 83 89 97
// </Snippet1>
