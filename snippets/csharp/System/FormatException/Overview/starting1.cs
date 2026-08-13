using System;


public class Example14
{
    public static void Main()
    {
        // <Snippet30>
        decimal temp = 20.4m;
        string s = $"The temperature is {temp}°C.";
        Console.WriteLine(s);
        // Displays 'The temperature is 20.4°C.'
        // </Snippet30>

        Snippet31();
        Snippet32();
        Snippet34();
    }

    private static void Snippet31()
    {
        // <Snippet31>
        string s = $"At {DateTime.Now}, the temperature is {20.4}°C.";
        Console.WriteLine(s);
        // Output similar to: 'At 4/10/2015 9:29:41 AM, the temperature is 20.4°C.'
        // </Snippet31>
    }

    private static void Snippet32()
    {
        // <Snippet32>
        string s = string.Format("It is now {0:d} at {0:t}", DateTime.Now);
        Console.WriteLine(s);
        // Output similar to: 'It is now 4/10/2015 at 10:04 AM'
        // </Snippet32>
    }

    private static void Snippet34()
    {
        // <Snippet34>
        int[] years = { 2013, 2014, 2015 };
        int[] population = { 1025632, 1105967, 1148203 };
        string s = $"{"Year",-10} {"Population",-10}\n\n";
        for (int index = 0; index < years.Length; index++)
            s += $"{years[index],-10} {population[index],-10:N0}\n";
        Console.WriteLine($"\n{s}");
        // Result:
        //    Year       Population
        //
        //    2013       1,025,632
        //    2014       1,105,967
        //    2015       1,148,203
        // </Snippet34>
    }
}
