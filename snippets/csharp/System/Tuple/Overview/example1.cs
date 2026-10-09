using System;

public class TupleOverviewExample1
{
    public static void Run()
    {
        Ctor1();
        Factory();
    }

    private static void Ctor1()
    {
        // <Snippet1>
        // Create a 7-tuple.
        var population = new Tuple<string, int, int, int, int, int, int>(
                                   "New York", 7891957, 7781984,
                                   7894862, 7071639, 7322564, 8008278);
        // Display the first and last elements.
        Console.WriteLine($"Population of {population.Item1} in 2000: {population.Item7:N0}");
        // The example displays the following output:
        //       Population of New York in 2000: 8,008,278
        // </Snippet1>
    }

    private static void Factory()
    {
        // <Snippet2>
        // Create a 7-tuple.
        var population = Tuple.Create("New York", 7891957, 7781984, 7894862, 7071639, 7322564, 8008278);
        // Display the first and last elements.
        Console.WriteLine($"Population of {population.Item1} in 2000: {population.Item7:N0}");
        // The example displays the following output:
        //       Population of New York in 2000: 8,008,278
        // </Snippet2>
    }
}
