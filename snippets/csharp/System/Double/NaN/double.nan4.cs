// <Snippet4>
using System;

public class Example
{
    public static void Main()
    {
        Console.WriteLine($"NaN == NaN: {double.NaN == double.NaN}");
        Console.WriteLine($"NaN != NaN: {double.NaN != double.NaN}");
        Console.WriteLine($"NaN.Equals(NaN): {double.NaN.Equals(double.NaN)}");
        Console.WriteLine($"! NaN.Equals(NaN): {!double.NaN.Equals(double.NaN)}");
        Console.WriteLine($"IsNaN: {double.IsNaN(double.NaN)}");

        Console.WriteLine($"\nNaN > NaN: {double.NaN > double.NaN}");
        Console.WriteLine($"NaN >= NaN: {double.NaN >= double.NaN}");
        Console.WriteLine($"NaN < NaN: {double.NaN < double.NaN}");
        Console.WriteLine($"NaN < 100.0: {double.NaN < 100.0}");
        Console.WriteLine($"NaN <= 100.0: {double.NaN <= 100.0}");
        Console.WriteLine($"NaN >= 100.0: {double.NaN > 100.0}");
        Console.WriteLine($"NaN.CompareTo(NaN): {double.NaN.CompareTo(double.NaN)}");
        Console.WriteLine($"NaN.CompareTo(100.0): {double.NaN.CompareTo(100.0)}");
        Console.WriteLine($"(100.0).CompareTo(Double.NaN): {(100.0).CompareTo(double.NaN)}");
    }
}
// The example displays the following output:
//       NaN == NaN: False
//       NaN != NaN: True
//       NaN.Equals(NaN): True
//       ! NaN.Equals(NaN): False
//       IsNaN: True
//
//       NaN > NaN: False
//       NaN >= NaN: False
//       NaN < NaN: False
//       NaN < 100.0: False
//       NaN <= 100.0: False
//       NaN >= 100.0: False
//       NaN.CompareTo(NaN): 0
//       NaN.CompareTo(100.0): -1
//       (100.0).CompareTo(Double.NaN): 1
// </Snippet4>
