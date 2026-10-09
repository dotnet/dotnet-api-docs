// <Snippet1>
using System;
using System.Collections;

public class Temperature : IComparable
{
    // The temperature value
    protected double temperatureF;

    public int CompareTo(object obj)
    {
        if (obj == null) return 1;

        Temperature otherTemperature = obj as Temperature;
        if (otherTemperature != null)
            return this.temperatureF.CompareTo(otherTemperature.temperatureF);
        else
            throw new ArgumentException("Object is not a Temperature");
    }

    public double Fahrenheit
    {
        get => this.temperatureF;
        set => this.temperatureF = value;
    }

    public double Celsius
    {
        get => (this.temperatureF - 32) * (5.0 / 9);
        set => this.temperatureF = (value * 9.0 / 5) + 32;
    }
}

public class CompareTemperatures
{
    public static void Main()
    {
        ArrayList temperatures = new();
        // Initialize random number generator.
        Random rnd = new();

        // Generate 10 temperatures between 0 and 100 randomly.
        for (int ctr = 1; ctr <= 10; ctr++)
        {
            int degrees = rnd.Next(0, 100);
            Temperature temp = new()
            {
                Fahrenheit = degrees
            };
            temperatures.Add(temp);
        }

        // Sort ArrayList.
        temperatures.Sort();

        foreach (Temperature temp in temperatures)
            Console.WriteLine(temp.Fahrenheit);
    }
}
// The example displays the following output to the console (individual
// values may vary because they are randomly generated):
//       2
//       7
//       16
//       17
//       31
//       37
//       58
//       66
//       72
//       95
// </Snippet1>
