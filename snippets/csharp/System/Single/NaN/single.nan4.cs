// <Snippet4>
using System;

public class Example
{
    public static void Main()
    {
        Console.WriteLine($"NaN == NaN: {float.NaN == float.NaN}");
        Console.WriteLine($"NaN != NaN: {float.NaN != float.NaN}");
        Console.WriteLine($"NaN.Equals(NaN): {float.NaN.Equals(float.NaN)}");
        Console.WriteLine($"! NaN.Equals(NaN): {!float.NaN.Equals(float.NaN)}");
        Console.WriteLine($"IsNaN: {double.IsNaN(double.NaN)}");

        Console.WriteLine($"\nNaN > NaN: {float.NaN > float.NaN}");
        Console.WriteLine($"NaN >= NaN: {float.NaN >= float.NaN}");
        Console.WriteLine($"NaN < NaN: {float.NaN < float.NaN}");
        Console.WriteLine($"NaN < 100.0: {float.NaN < 100.0f}");
        Console.WriteLine($"NaN <= 100.0: {float.NaN <= 100.0f}");
        Console.WriteLine($"NaN > 100.0: {float.NaN > 100.0f}");
        Console.WriteLine($"NaN.CompareTo(NaN): {float.NaN.CompareTo(float.NaN)}");
        Console.WriteLine($"NaN.CompareTo(100.0): {float.NaN.CompareTo(100.0f)}");
        Console.WriteLine($"(100.0).CompareTo(Single.NaN): {(100.0f).CompareTo(float.NaN)}");
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
//       (100.0).CompareTo(Single.NaN): 1
// </Snippet4>
