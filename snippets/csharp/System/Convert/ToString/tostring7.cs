// <Snippet27>
using System;
using System.Globalization;

public class Example
{
    public static void Main()
    {
        // Create a NumberFormatInfo object and set its NegativeSigns
        // property to use for integer formatting.
        NumberFormatInfo provider = new()
        {
            NegativeSign = "minus "
        };

        int[] values = { -20, 0, 100 };

        Console.WriteLine($"{"Value",-8} --> {CultureInfo.CurrentCulture.Name,10} {"Custom",10}\n");
        foreach (int value in values)
            Console.WriteLine($"{value,-8} --> {Convert.ToString(value),10} {Convert.ToString(value, provider),10}");
        // The example displays output like the following:
        //       Value    -->      en-US     Custom
        //
        //       -20      -->        -20   minus 20
        //       0        -->          0          0
        //       100      -->        100        100
    }
}
// </Snippet27>
