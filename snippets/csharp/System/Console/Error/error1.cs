// <Snippet1>
using System;

public class Example
{
    public static void Main()
    {
        int increment = 0;
        bool exitFlag = false;

        while (!exitFlag)
        {
            if (Console.IsOutputRedirected)
                Console.Error.WriteLine($"Generating multiples of numbers from {increment + 1} to {increment + 10}");

            Console.WriteLine($"Generating multiples of numbers from {increment + 1} to {increment + 10}");
            for (int ctr = increment + 1; ctr <= increment + 10; ctr++)
            {
                Console.Write($"Multiples of {ctr}: ");
                for (int ctr2 = 1; ctr2 <= 10; ctr2++)
                    Console.Write($"{ctr * ctr2}{(ctr2 == 10 ? "" : ", ")}");

                Console.WriteLine();
            }
            Console.WriteLine();

            increment += 10;
            Console.Error.Write($"Display multiples of {increment + 1} through {increment + 10} (y/n)? ");
            char response = Console.ReadKey(true).KeyChar;
            Console.Error.WriteLine(response);
            if (!Console.IsOutputRedirected)
                Console.CursorTop--;

            if (char.ToUpperInvariant(response) == 'N')
                exitFlag = true;
        }
    }
}
// </Snippet1>
