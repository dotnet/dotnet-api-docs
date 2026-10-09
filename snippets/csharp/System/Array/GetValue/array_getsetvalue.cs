// The following code example demonstrates how to set and get a specific value in a one-dimensional or multidimensional array.

// <Snippet1>
using System;

public class SamplesArray
{

    public static void Main()
    {

        // Creates and initializes a one-dimensional array.
        string[] myArr1 = new string[5];

        // Sets the element at index 3.
        myArr1.SetValue("three", 3);
        Console.WriteLine($"[3]:   {myArr1.GetValue(3)}");

        // Creates and initializes a two-dimensional array.
        string[,] myArr2 = new string[5, 5];

        // Sets the element at index 1,3.
        myArr2.SetValue("one-three", 1, 3);
        Console.WriteLine($"[1,3]:   {myArr2.GetValue(1, 3)}");

        // Creates and initializes a three-dimensional array.
        string[,,] myArr3 = new string[5, 5, 5];

        // Sets the element at index 1,2,3.
        myArr3.SetValue("one-two-three", 1, 2, 3);
        Console.WriteLine($"[1,2,3]:   {myArr3.GetValue(1, 2, 3)}");

        // Creates and initializes a seven-dimensional array.
        string[,,,,,,] myArr7 = new string[5, 5, 5, 5, 5, 5, 5];

        // Sets the element at index 1,2,3,0,1,2,3.
        int[] myIndices = new int[7] { 1, 2, 3, 0, 1, 2, 3 };
        myArr7.SetValue("one-two-three-zero-one-two-three", myIndices);
        Console.WriteLine($"[1,2,3,0,1,2,3]:   {myArr7.GetValue(myIndices)}");
    }
}


/*
This code produces the following output.

[3]:   three
[1,3]:   one-three
[1,2,3]:   one-two-three
[1,2,3,0,1,2,3]:   one-two-three-zero-one-two-three

*/

// </Snippet1>
