using System;

// Note: you must compile this sample using the unsafe flag.
// From the command line, type the following: csc sample.cs /unsafe

public class Example
{
    public static unsafe void Main()
    {
        int[] array = CreateInt32Array();

        // Create a span, pin it, and print its elements.
        Span<int> span = array.AsSpan();
        fixed (int* spanPtr = span)
        {
            Console.WriteLine($"Span contains {span.Length} elements:");
            for (int i = 0; i < span.Length; i++)
            {
                Console.WriteLine(spanPtr[i]);
            }
            Console.WriteLine();
        }

        // Create a read-only span, pin it, and print its elements.
        ReadOnlySpan<int> readonlyspan = array.AsSpan();
        fixed (int* readonlyspanPtr = readonlyspan)
        {
            Console.WriteLine($"ReadOnlySpan contains {readonlyspan.Length} elements:");
            for (int i = 0; i < readonlyspan.Length; i++)
            {
                Console.WriteLine(readonlyspanPtr[i]);
            }
            Console.WriteLine();
        }
    }

    private static int[] CreateInt32Array()
    {
        return new int[] { 100, 200, 300, 400, 500 };
    }
}

// The example displays the following output:
//       Span contains 5 elements:
//       100
//       200
//       300
//       400
//       500
//
//       ReadOnlySpan contains 5 elements:
//       100
//       200
//       300
//       400
//       500
