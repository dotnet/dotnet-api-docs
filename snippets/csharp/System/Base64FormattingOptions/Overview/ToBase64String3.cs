// <Snippet3>
using System;

public class Base64RoundTripExample
{
    public static void Main()
    {
        // Define a byte array.
        byte[] bytes = new byte[100];
        int originalTotal = 0;
        for (int ctr = 0; ctr <= bytes.GetUpperBound(0); ctr++)
        {
            bytes[ctr] = (byte)(ctr + 1);
            originalTotal += bytes[ctr];
        }
        // Display summary information about the array.
        Console.WriteLine("The original byte array:");
        Console.WriteLine($"   Total elements: {bytes.Length}");
        Console.WriteLine($"   Length of String Representation: {BitConverter.ToString(bytes).Length}");
        Console.WriteLine($"   Sum of elements: {originalTotal:N0}");
        Console.WriteLine();

        // Convert the array to a base 64 string.
        string s = Convert.ToBase64String(bytes,
                                          Base64FormattingOptions.InsertLineBreaks);
        Console.WriteLine($"The base 64 string:\n   {s}\n");

        // Restore the byte array.
        byte[] newBytes = Convert.FromBase64String(s);
        int newTotal = 0;
        foreach (byte newByte in newBytes)
        {
            newTotal += newByte;
        }

        // Display summary information about the restored array.
        Console.WriteLine($"   Total elements: {newBytes.Length}");
        Console.WriteLine($"   Length of String Representation: {BitConverter.ToString(newBytes).Length}");
        Console.WriteLine($"   Sum of elements: {newTotal:N0}");
    }
}
// The example displays the following output:
//   The original byte array:
//      Total elements: 100
//      Length of String Representation: 299
//      Sum of elements: 5,050
//
//   The base 64 string:
//      AQIDBAUGBwgJCgsMDQ4PEBESExQVFhcYGRobHB0eHyAhIiMkJSYnKCkqKywtLi8wMTIzNDU2Nzg5
//   Ojs8PT4/QEFCQ0RFRkdISUpLTE1OT1BRUlNUVVZXWFlaW1xdXl9gYWJjZA==
//
//      Total elements: 100
//      Length of String Representation: 299
//      Sum of elements: 5,050
// </Snippet3>
