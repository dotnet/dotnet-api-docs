// <Snippet2>
using System;

[Flags] enum IgnoreCaseColors { None = 0, Red = 1, Green = 2, Blue = 4 };

public class IgnoreCaseParseExample
{
    public static void Run()
    {
        string[] colorStrings = { "0", "2", "8", "blue", "Blue", "Yellow", "Red, Green" };
        foreach (string colorString in colorStrings)
        {
            try
            {
                IgnoreCaseColors colorValue = (IgnoreCaseColors)Enum.Parse(typeof(IgnoreCaseColors), colorString, true);
                if (Enum.IsDefined(typeof(IgnoreCaseColors), colorValue) | colorValue.ToString().Contains(","))
                    Console.WriteLine("Converted '{0}' to {1}.", colorString, colorValue.ToString());
                else
                    Console.WriteLine($"{colorString} is not an underlying value of the Colors enumeration.");
            }
            catch (ArgumentException)
            {
                Console.WriteLine($"{colorString} is not a member of the Colors enumeration.");
            }
        }
    }
}
// The example displays the following output:
//       Converted '0' to None.
//       Converted '2' to Green.
//       8 is not an underlying value of the Colors enumeration.
//       Converted 'blue' to Blue.
//       Converted 'Blue' to Blue.
//       Yellow is not a member of the Colors enumeration.
//       Converted 'Red, Green' to Red, Green.
// </Snippet2>
